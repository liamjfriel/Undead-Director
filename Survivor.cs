using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class Survivor : GameEntity
    {
        //The actual survivor
        public Weapon HolsteredWeapon {get; set; }
        private const int WeaponCoolDown = 60;
        public int WeaponCooldownTimer;
        public bool CanFire;
        public bool IsSlowed;
        private const int SlowedTime = 400;
        private int SlowedCooldownTimer;
        public int Kills;
        public PlayerIndex PlayerIndex;
  

        public Survivor(PlayerIndex pindex)
        {
            //Set the sprite for this entity to be the survivor sprite
            Sprite = GraphicAssets.SurvivorHandgun;
            //Players start in the middle
            Position = new Vector2(900, 500);
            //Collisition radius is 30 for the survivor
            CollisionRadius = 30;
            //Set the survivor to alive, since he is actually alive..
            IsAlive = true;
            //Cooldown timer set at 10
            WeaponCooldownTimer = 60;
            //First weapon is a handgun
            HolsteredWeapon = new Handgun(this, false);
            HolsteredWeapon.Ammunition = 99;
            //Speed multiplier is 10
            SlowedCooldownTimer = 400;
            SpeedMultiplier = 10;
            IsSlowed = false;
            Kills = 0;
            PlayerIndex = pindex;
            CanFire = true;
            //Set the tint of the survivor based off of the player index
            switch(pindex)
            {
                case PlayerIndex.One:
                    {
                        //Tint red
                        SpriteColor = Color.Red;
                        break;
                    }
                case PlayerIndex.Two:
                    {
                        //Tint red
                        SpriteColor = Color.Blue;
                        break;
                    }
                case PlayerIndex.Three:
                    {
                        //Tint red
                        SpriteColor = Color.Yellow;
                        break;
                    }
                case PlayerIndex.Four:
                    {
                        //Tint red
                        SpriteColor = Color.Pink;
                        break;
                    }
            }
        }

        public override void Update()
        {
            //Update the sprite
            setSprite();
            //Facing angle equals the angle the playyer is looking at
            FacingAngle = WorldController.SurvivorAngle(PlayerIndex);
            //Velocity is speed multiplied by movement direction
            Velocity = SpeedMultiplier * WorldController.SurvivorMovement(PlayerIndex);
            //Position of the survivor set
            Position += Velocity;
            //If the cooldown timer is above 0
            if (WeaponCooldownTimer > 0)
            {
                CanFire = false;
                //Put down the cooldown timer
                WeaponCooldownTimer--;
            }
            else
            {
                //No cooldown left, so fire the gun and then reset the timer
                CanFire = true;
            }
            if(IsSlowed)
            {
                if (SlowedCooldownTimer > 0)
                {
                    //Put down the cooldown timer
                    SlowedCooldownTimer--;
                }
                else
                {
                    IsSlowed = false;
                    SpeedMultiplier = 10;
                    SlowedCooldownTimer = SlowedTime;
                }
            }

        }

        public void setSprite()
        {
            //Change the players sprite based off of the weapon that they have
            if(HolsteredWeapon is Handgun)
            {
                //Set the model to the survivor with handgun model
                Sprite = GraphicAssets.SurvivorHandgun;
            }
            else
            if (HolsteredWeapon is Shotgun)
            {
                //Set the model to the survivor with shotgun model
                Sprite = GraphicAssets.SurvivorShotgun;
            }
            else
            if (HolsteredWeapon is AssaultRifle)
            {
                //Set the model to the survivor with shotgun model
                Sprite = GraphicAssets.Survivor1;
            }
        }



    }
}
