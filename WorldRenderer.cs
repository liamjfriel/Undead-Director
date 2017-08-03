using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace UndeadDirector
{
    class WorldRenderer : Renderer
    {

        private Vector2[] PlayerScoreMessages = { new Vector2(40, 100), new Vector2(40,200), new Vector2(40, 300), new Vector2(40, 400) };
        public static WorldRenderer worldrender;
        public static WorldRenderer Instance
        {
            get
            {
                if (worldrender == null)
                {
                    worldrender = new WorldRenderer();
                }
                return worldrender;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameEngine instance)
        {
            Rectangle background = new Rectangle(0, 0, 1920, 1080);
            spriteBatch.Draw(GraphicAssets.BackgroundSprite, Vector2.Zero, background, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            //For every entity in the list of game entities
            foreach (GameEntity entity in World.GameEntities)
            {
                //Draw em
                entity.Draw(spriteBatch);
            }
            //Draw the directors resource count
            spriteBatch.DrawString(GraphicAssets.GameFont, "Director Resources: " + World.Director.Resources + "\nLevel: " + WorldDirector.LevelCounter, new Vector2(1500, 10), Color.White);

            //Print what controllers are connected            
            foreach (Survivor surv in World.AliveSurvivorList)
            {
                //If this is the first player
                if (surv.PlayerIndex == PlayerIndex.One)
                {
                    spriteBatch.DrawString(GraphicAssets.GameFont, "Player 1 Ammo:"  + surv.HolsteredWeapon.Ammunition, PlayerScoreMessages[0], Color.Red);
                }
                //If this is the  second
                if (surv.PlayerIndex == PlayerIndex.Two)
                {
                    spriteBatch.DrawString(GraphicAssets.GameFont, "Player 2 Ammo:" + surv.HolsteredWeapon.Ammunition, PlayerScoreMessages[1], Color.Blue);
                }
                //If this is the third
                if (surv.PlayerIndex == PlayerIndex.Three)
                {
                    spriteBatch.DrawString(GraphicAssets.GameFont, "Player 3 Ammo:" + surv.HolsteredWeapon.Ammunition, PlayerScoreMessages[2], Color.Yellow);
                }
                //FOURTH
                if (surv.PlayerIndex == PlayerIndex.Four)
                {
                    spriteBatch.DrawString(GraphicAssets.GameFont, "Player 4 Ammo:" + surv.HolsteredWeapon.Ammunition, PlayerScoreMessages[3], Color.Pink);
                }
            }
        }
    }
}
