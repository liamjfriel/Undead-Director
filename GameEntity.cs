using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

abstract class GameEntity
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public Texture2D Sprite { get; set; }
    public float CollisionRadius { get; set; }
    public bool IsAlive { get; set; }
    public float FacingAngle { get; set; }
    public float SpeedMultiplier { get; set; }
    public Color SpriteColor { get; set; }
    


    public Vector2 Origin
    {
        get
        {
            //Return a vector that represents half the sprites width and height 
            return new Vector2(Sprite.Width / 2, Sprite.Height / 2);
        }
    }

    public abstract void Update();
      
    public void Draw(SpriteBatch spriteBatch)
    {  
        //Draw the sprite, layer it over the background
        spriteBatch.Draw(Sprite, Position, null, SpriteColor, FacingAngle, Origin, 1.0f, SpriteEffects.None, 0);
    }

}
