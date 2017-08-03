using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class Shotgun : Weapon
    {
        public Shotgun(Survivor origin, bool visible)
        {
            //Is the gun meant to be visible?
            if (visible == true)
            {
                //Give the gun a random position
                Position = new Vector2(ExtensionMethods.RandomNumber(0, 1920), ExtensionMethods.RandomNumber(0, 1080));
                //Set the sprite for this entity to be the survivor sprite
                Sprite = GraphicAssets.ShotgunSprite;
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
            WeaponCoolDown = 100;
            //Shotgun has 20 rounds
            Ammunition = 20;
            Gunshot = SoundAssets.ShotgunShot;
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
                Vector2 bullet1velocity = ExtensionMethods.FromPolar(Origin.FacingAngle + 0.2f, 50f);
                Vector2 bullet2velocity = ExtensionMethods.FromPolar(Origin.FacingAngle, 50f);
                Vector2 bullet3velocity = ExtensionMethods.FromPolar(Origin.FacingAngle - 0.2f, 50f);
                //Add three new bullets to the world, one down the middle at two at slightly different angles
                World.Add(new Bullet(bullet1velocity, Origin.Position + FiringOffset, Origin.FacingAngle, Origin));
                World.Add(new Bullet(bullet2velocity, Origin.Position + FiringOffset, Origin.FacingAngle, Origin));
                World.Add(new Bullet(bullet3velocity, Origin.Position + FiringOffset, Origin.FacingAngle, Origin));
                //Decrease the number of bullets
                Ammunition--;
                //Survivor can now fire
                Origin.WeaponCooldownTimer = WeaponCoolDown;
                SoundEngine.MultithreadSound(Gunshot);
            }
        }
    }
}
