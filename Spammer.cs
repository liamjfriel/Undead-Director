using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class SpammerAI : AIPersonality
    {
        public static SpammerAI spammerai;
        public static SpammerAI Instance
        {
            get
            {
                if (spammerai == null)
                {
                    spammerai = new SpammerAI();
                }
                return spammerai;
            }
        }

        /// <summary>
        /// Constructor method for this class
        /// </summary>
        public SpammerAI()
        {
            //First target is just player one, until the game has progressed a bit and decisions can be made
            Target = World.AliveSurvivorList.ElementAt(0);
        }

        /// <summary>
        /// Override Logic method
        /// </summary>
        public override void Logic()
        {
 
            if(Target.IsAlive == false)
            {
                Target = World.AliveSurvivorList.ElementAt(ExtensionMethods.RandomNumber(0, World.AliveSurvivorList.Count));
            }   
            //If the Director has enough resources
            if (World.Director.Resources > SpeedEffect.Instance.Cost)
            {
                //Use either the slow or speed up
                if (ExtensionMethods.RandomNumber(1, 10) == 5)
                {
                    //Slow the players
                    SpeedEffect.Instance.Activate();
                }
                else if(ExtensionMethods.RandomNumber(1,10) == 2)
                {
                    //Make the zombies go faster
                    SlowEffect.Instance.Activate();
                }     
            }
            //Spawn a new common zomibie, one in five chance
            if (ExtensionMethods.RandomNumber(1, 20) == 2)
            {
                //Try and spawn a common zombie
                WorldDirector.ZombieSpawner("cm");
            }
            //If the director can spawn a weapon, do it 
            if(World.Director.CanSpawnWeapon)
            {
                SpawnWeaponEffect.Instance.Activate();
            }
        }
    }
}
