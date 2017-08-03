using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class Bullet : GameEntity
    {
        /// <summary>
        /// The origin of this bullet
        /// </summary>
        public Survivor SurvOrigin;

        public Bullet(Vector2 velocity, Vector2 position, float facingAngle, Survivor origin)
        {
            //Position
            Position = position;
            //Angle
            FacingAngle = facingAngle;
            //Collision Radius is 5
            CollisionRadius = 5;
            //Velocity is set to velocity
            Velocity = velocity;
            //Sprite for bullet
            Sprite = GraphicAssets.Bullet;
            //Set is alive to true
            IsAlive = true;
            //Set the origin
            SurvOrigin = origin;
            SpriteColor = Color.White;
        }

        public override void Update()
        {
            //set position
            Position += Velocity;
            //If the bullet goes off the screen, delete it 
            
            if (Position.X < 0 || Position.X > 1920 || Position.Y < 0 || Position.Y > 1080)
            {
                //It's now "dead"
                IsAlive = false;
            }
            
        }

    }
}
