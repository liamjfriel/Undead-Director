using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class Speeder : Zombie
    {
        public Speeder(Vector2 position, float angle)
        {
            //Set the health to 1
            Health = 1;
            //Set the sprite for this entity to be the zombie
            Sprite = GraphicAssets.Speeder;
            Position = position;
            FacingAngle = angle;
            IsAlive = true;
            //Collisition radius is 30 for the survivor
            CollisionRadius = 30;
            SpeedMultiplier = 7;
            SpriteColor = Color.White;
        }

        public override void Update()
        {

            //Figure the difference between the position of the common zombie and that of the swarmflag
            float xDiff = Position.X - World.Director.SpecialFlag.X;
            float yDiff = Position.Y - World.Director.SpecialFlag.Y;
            //If the unit isn't near the swarmflag
            if (xDiff > 10 || xDiff < -10 || yDiff > 10 || yDiff < -10)
            {
                //Move the zombie to the users flag
                Velocity = ((World.Director.SpecialFlag - Position).ScaleTo(1.0f)) * SpeedMultiplier;
                //set position
                Position += Velocity;
                //Set the special flag
                FacingAngle = Velocity.Angle();
            }

        }
    }
}
