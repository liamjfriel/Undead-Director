using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    static class GameOverController
    {
        /// <summary>
        /// Update the controller
        /// </summary>
        public static void Update(GameEngine instance)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
            {
                //Start the game
                instance.previousState = GameEngine.GameState.GameOver;
                instance.currentState = GameEngine.GameState.Menu;
            }

        }

    }
}
