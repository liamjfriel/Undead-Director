using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class Director : GameEntity
    {

        //Enumerator that holds the state of the director
        public enum DirectorPersonality
        {
            Human,
            Bully,
            Spammer,
            Swarmer
        }
        //The actual personality of the director
        public DirectorPersonality Personality;
        //Integer that holds the amount of resources that the Director has
        public int Resources;
        //Flag one for main zombie movement
        public Vector2 SwarmFlag {get; set; }
        //Flag for special zombie movement
        public Vector2 SpecialFlag { get; set; }
        //Spawn weapon cooldown
        private const int WeaponSpawnTime = 500;
        private int WeaponSpawnTimer;
        //Boolean that checks if the director can spawn a weapon
        public bool CanSpawnWeapon;
        
  
        //This contains the flag that the user moves to change zombie direction
        public Director(DirectorPersonality personality)
        {
            //Intitialise the specialflag
            SpecialFlag = new Vector2(500, 500);
            //Set the resources
            Resources = 0;
            //Set is alive flag to true
            IsAlive = true;
            //Set the swarmflag to a value for debugging
            SwarmFlag = new Vector2(500, 500);
            //Set IsAI to false
            Sprite = GraphicAssets.Bullet;
            Position = new Vector2(-100,-100);
            Personality = personality;
            CanSpawnWeapon = true;
            WeaponSpawnTimer = 0;
            
         }

        public override void Update()
        {
            switch(Personality)
            {
                case DirectorPersonality.Human:
                    {
                        //Constant speed equals 10
                        const float Speed = 10;
                        //Velocity is speed multiplied by movement direction
                        Velocity = Speed * WorldController.DirectorSwarmFlagMovement();
                        //Position of the survivor set
                        SwarmFlag += Velocity;
                        //Now do the same for the special flag, reusing velocity
                        Velocity = Speed * WorldController.DirectorSpecialFlagMovement();
                        //Position of the survivor set
                        SpecialFlag += Velocity;
                        break;
                    }
                case DirectorPersonality.Bully:
                    {
                        BullyAI.Instance.Logic();
                        //Set the flags 
                        SwarmFlag = BullyAI.Instance.Target.Position;
                        SpecialFlag = BullyAI.Instance.Target.Position;
                        break;
                    }
                case DirectorPersonality.Spammer:
                    {
                        SpammerAI.Instance.Logic();
                        //Set the flags
                        SwarmFlag = SpammerAI.Instance.Target.Position;
                        SpecialFlag = SpammerAI.Instance.Target.Position;
                        break;
                    }
                case DirectorPersonality.Swarmer:
                    {
                        SwarmAI.Instance.Logic();
                        //Set the flags
                        SwarmFlag = SwarmAI.Instance.Target.Position;
                        SpecialFlag = SwarmAI.Instance.Target.Position;
                        break;
                    }
            }
            //If the user cant spawn a weapon
            if (!CanSpawnWeapon)
            {
                if (WeaponSpawnTimer > 0)
                {
                    //Put down the cooldown timer
                    WeaponSpawnTimer--;
                }
                else
                {
                    CanSpawnWeapon = true;
                    WeaponSpawnTimer = WeaponSpawnTime;
                }
            }

        }
    }
}
