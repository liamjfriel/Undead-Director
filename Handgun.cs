using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class Handgun : Weapon
    {
        public Handgun(Survivor origin, bool visible)
        {
            //Is the gun meant to be visible?
            if (visible == true)
            {
                //Give the gun a random position
                Position = new Vector2(ExtensionMethods.RandomNumber(0, 1920), ExtensionMethods.RandomNumber(0, 1080));
                //Set the sprite for this entity to be the survivor sprite
                Sprite = GraphicAssets.PistolSprite;
                //Collisition radius is 30 for the survivor
                CollisionRadius = 30;
                //Set the survivor to alive, since he is actually alive..
                IsAlive = true;
                //Ammunition set to 99
                Ammunition = 99;
                
            }
            //Origin is equal to origin
            Origin = origin;
            //The offset for this sprite so that the bullet appears to come out of the barrel of the gun
            WeaponOffset = new Vector2(150, 50);
            //Set the weapon cooldown
            WeaponCoolDown = 60;
            //Gunshot noise
            Gunshot = SoundAssets.HandgunShot;
        }


        public override void Fire()
        {
            //Three dimensional rotation object
            Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, Origin.FacingAngle);
            //Bullet offset so that it appears to come out of the barrel of the gun
            FiringOffset = Vector2.Transform(WeaponOffset, aimQuat);
            //Vector2 that will dictate the velocity of the bullet
            Vector2 velocity = ExtensionMethods.FromPolar(Origin.FacingAngle, 50f);
            //Add the new bullet to the world
            World.Add(new Bullet(velocity, Origin.Position + FiringOffset, Origin.FacingAngle, Origin));
            //Survivor can now fire
            Origin.WeaponCooldownTimer = WeaponCoolDown;
            //Fire the gunshot
            SoundEngine.MultithreadSound(Gunshot);
        }
    }
}
