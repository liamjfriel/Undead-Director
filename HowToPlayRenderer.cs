using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class HowToPlayRenderer : Renderer
    {
        public static HowToPlayRenderer renderer;
        public static HowToPlayRenderer Instance
        {
            get
            {
                if (renderer == null)
                {
                    renderer = new HowToPlayRenderer();
                }
                return renderer;
            }
        }
        private Vector2 HowToPlayPosition = new Vector2(100, 50);
        private Vector2 Director = new Vector2(150, 150);
        private Vector2 ZOMBIES = new Vector2(150, 525);
        private Vector2 Exploder = new Vector2(150, 550);
        private Vector2 Speeder = new Vector2(150, 575);
        private Vector2 Juggernaught = new Vector2(150, 600);
        private Vector2 Common = new Vector2(150, 625);
        private Vector2 Human = new Vector2(150, 700);
        private Vector2 GoBack = new Vector2(150, 1000);

        public override void Draw(SpriteBatch spriteBatch, GameEngine instance)
        {
            //Draw the how to play renderer
            spriteBatch.DrawString(GraphicAssets.GameFont, "How to play...", HowToPlayPosition, Color.White);
            spriteBatch.DrawString(GraphicAssets.GameFont, "DIRECTOR CONTROLS:\n\nMoving the left stick moves an invisible flag that all the common zombies walk towards.\nMoving the right stick does the same but for special zombies.\nA on the controller spawns an exploder zombie at the cost of 1750 resources.\nB on the controller spawns another common zombie at the cost of 200 resources.\nY on the controller spawns a juggernaught zombie at the cost of 1000 resources.\nX on the controller spawns a speeder zombie at the cost of 750 resources.\nUP on the D-Pad triggers the Speed Environmental Effect at the cost of 1000 resources.\nDOWN on the D-Pad triggers the Slow Enviornmental Effect at the cost of 1000 resources.\nRIGHT on the D-Pad triggers the Spawn Weapon Environmental Effect with a 1000 resource REWARD.", Director, Color.White);
            spriteBatch.DrawString(GraphicAssets.GameFont, "ZOMBIES:", ZOMBIES, Color.White);
            spriteBatch.DrawString(GraphicAssets.GameFont, "EXPLODER: Red zombie, blows up and kills all survivorss in the radius. 1HP.", Exploder, Color.Red);
            spriteBatch.DrawString(GraphicAssets.GameFont, "SPEEDER: Blue zombie, fast but weak. 1HP.", Speeder, Color.Blue);
            spriteBatch.DrawString(GraphicAssets.GameFont, "JUGGERNAUGHT: Yellow zombie. Slow but strong. 20HP.", Juggernaught, Color.Yellow);
            spriteBatch.DrawString(GraphicAssets.GameFont, "Common: Not tinted zombie, medium pace. Bread and butter zombie. 1HP.", Common, Color.White);
            spriteBatch.DrawString(GraphicAssets.GameFont, "SURVIVORS:\n\nLeft analogue stick to move the survivor.\nRight analogue stick to aim.\nRight trigger to fire.\nStart button in game to pause (PLAYER ONE ONLY).\nBack button to go back to Menu (PLAYER ONE ONLY).", Human, Color.White);
            //If the 
            if (instance.previousState == GameEngine.GameState.Playing)
            {
                spriteBatch.DrawString(GraphicAssets.GameFont, "PRESS B TO GO BACK TO PLAYING!", GoBack, Color.White);
            } else if(instance.previousState == GameEngine.GameState.Menu)
            {
                spriteBatch.DrawString(GraphicAssets.GameFont, "PRESS B TO GO BACK TO THE MENU!", GoBack, Color.White);
            }
        }
    }
}

