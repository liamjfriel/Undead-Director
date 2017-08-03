using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UndeadDirector
{
    class GameOverRenderer : Renderer
    {
        public static GameOverRenderer renderer;
        public static GameOverRenderer Instance
        {
            get
            {
                if (renderer == null)
                {
                    renderer = new GameOverRenderer();
                }
                return renderer;
            }
        }
        private Vector2 GameOverPosition = new Vector2(400, 100);
        private Vector2[] PlayerScoreMessages = { new Vector2(400, 300), new Vector2(400, 400), new Vector2(400, 500), new Vector2(400, 600) };
        private Vector2 Director = new Vector2(400, 700);
        private Vector2 Menu = new Vector2(400, 900);

        public override void Draw(SpriteBatch spriteBatch, GameEngine instance)
        {
            //Draw the title
            spriteBatch.DrawString(GraphicAssets.TitleFont, "GAME OVER", GameOverPosition, Color.White);

            //Print what controllers are connected            
            foreach (Survivor surv in World.SurvivorList)
            {
                //If this is the first player
                if (surv.PlayerIndex == PlayerIndex.One)
                {
                    spriteBatch.DrawString(GraphicAssets.YButtonFont, "Player 1 kills:" + surv.Kills, PlayerScoreMessages[0], Color.White);
                }
                //If this is the  second
                if (surv.PlayerIndex == PlayerIndex.Two)
                {
                    spriteBatch.DrawString(GraphicAssets.YButtonFont, "Player 2 kills:" + surv.Kills, PlayerScoreMessages[1], Color.White);
                }
                //If this is the third
                if (surv.PlayerIndex == PlayerIndex.Three)
                {
                    spriteBatch.DrawString(GraphicAssets.YButtonFont, "Player 3 kills:" + surv.Kills, PlayerScoreMessages[2], Color.White);
                }
                //FOURTH
                if (surv.PlayerIndex == PlayerIndex.Four)
                {
                    spriteBatch.DrawString(GraphicAssets.YButtonFont, "Player 4 kills:" + surv.Kills, PlayerScoreMessages[3], Color.White);
                }
            }

            spriteBatch.DrawString(GraphicAssets.YButtonFont, "Director time taken to kill: " + (WorldDirector.spawningcounter / 60), Director, Color.Yellow);
            spriteBatch.DrawString(GraphicAssets.YButtonFont, "Player one press start to go back to menu!", Menu, Color.White);
        }
    }
}
