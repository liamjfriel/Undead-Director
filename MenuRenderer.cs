using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace UndeadDirector
{
    class MenuRenderer : Renderer
    {

        //Vectors for the positions of the player info
        private Vector2[] PlayerPositions = { new Vector2(300,800), new Vector2(700, 800), new Vector2(1000,800), new Vector2(1300,800)};
        private Vector2[] PlayerPositionMessages= { new Vector2(350,750), new Vector2(700, 750), new Vector2(1050, 750), new Vector2(1400, 750) };
        private Vector2 TitlePosition = new Vector2(400,200);
        private Vector2 YButton = new Vector2(400, 400);
        private Vector2 StartButton = new Vector2(620, 500);
        private Vector2 HelpButton = new Vector2(580, 600);
        public static MenuRenderer menurenderer;
        public static MenuRenderer Instance
        {
            get
            {
                if (menurenderer== null)
                {
                    menurenderer = new MenuRenderer();
                }
                return menurenderer;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameEngine instance)
        {
            //Draw the title
            spriteBatch.DrawString(GraphicAssets.TitleFont, "UNDEAD DIRECTOR", TitlePosition, Color.White);
            
            int i = 1;
            //Print what controllers are connected            
            foreach (bool connected in Menu.PlayersConnected)
            {
                //Check if the controller is connected
                if (connected == true)
                {
                    spriteBatch.DrawString(GraphicAssets.DebugFont, "Player " + i + " is connected.", PlayerPositionMessages[i - 1], Color.White);
                    //Draw the sprite
                    spriteBatch.Draw(GraphicAssets.ControllerSprite, PlayerPositions[i-1], null, Color.White);
                }
                else
                {
                    spriteBatch.DrawString(GraphicAssets.DebugFont, "Player " + i + " is not connected.", PlayerPositionMessages[i - 1], Color.White);
                }
                i++;
            }
            //If the director is going to be ai
            if (Menu.IsHuman == false)
            {
                spriteBatch.DrawString(GraphicAssets.YButtonFont, "AI DIRECTOR: Press Y if you want a Human Director!", YButton, Color.Yellow);
            } else {
                spriteBatch.DrawString(GraphicAssets.YButtonFont, "HUMAN DIRECTOR: Press Y if you want an AI Director!", YButton, Color.Yellow);
            }
            spriteBatch.DrawString(GraphicAssets.YButtonFont, "Player one press A to play!", StartButton, Color.White);
            spriteBatch.DrawString(GraphicAssets.YButtonFont, "Player X to view the controls!", HelpButton, Color.White);
        }
    }
}
