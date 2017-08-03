using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class AssaultRifle : Weapon
    {

        public AssaultRifle(Survivor origin, bool visible)
        {
            //Is the gun meant to be visible?
            if (visible == true)
            {
                //Give the gun a random position
                Position = new Vector2(ExtensionMethods.RandomNumber(0, 1920), ExtensionMethods.RandomNumber(0, 1080));
                //Set the sprite for this entity to be the survivor sprite
                Sprite = GraphicAssets.AssaultRifleSprite;
                //Collisition radius is 30 for the survivor
                CollisionRadius = 30;
                //Set the survivor to alive, since he is actually alive..
                IsAlive = true;
            }
            //Origin is equal to origin
            Origin = origin;
            //The offset for this sprite so that the bullet appears to come out of the barrel of the gun
            WeaponOffset = new Vector2(150, 50);
            //Set the weapon cooldown
            WeaponCoolDown = 10;
            //Set the amount of ammunition
            Ammunition = 50;
            //Set the gunshot
            Gunshot = SoundAssets.AssaultRifle;
            SpriteColor = Color.White;
        }


        public override void Fire()
        {
            //If there still is ammo
            if (Ammunition > 0)
            {
                //Three dimensional rotation object
                Quaternion aimquat = Quaternion.CreateFromYawPitchRoll(0, 0, Origin.FacingAngle);
                //Bullet offset so that it appears to come out of the barrel of the gun
                FiringOffset = Vector2.Transform(WeaponOffset, aimquat);
                //Vector2 that will dictate the velocity of the bullet
                Vector2 velocity = ExtensionMethods.FromPolar(Origin.FacingAngle, 50f);
                //Add the new bullet to the world
                World.Add(new Bullet(velocity, Origin.Position + FiringOffset, Origin.FacingAngle,Origin));
                //Decrease the amount of ammunation
                Ammunition--;
                //Survivor can now fire
                Origin.WeaponCooldownTimer = WeaponCoolDown;
                SoundEngine.MultithreadSound(Gunshot);
            }

        }

    }
}
