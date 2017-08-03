using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    static class HowToPlayController
    {
        /// <summary>
        /// Update the controller
        /// </summary>
        public static void Update(GameEngine instance)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                //If if the the previous state is playing, go back to that
                if (instance.previousState == GameEngine.GameState.Playing)
                {
                    instance.previousState = GameEngine.GameState.HowToPlay;
                    instance.currentState = GameEngine.GameState.Playing;
                }
                //If if the the previous state is playing, go back to that
                if (instance.previousState == GameEngine.GameState.Menu)
                {
                    instance.previousState = GameEngine.GameState.HowToPlay;
                    instance.currentState = GameEngine.GameState.Menu;
                }

            }
        }

    }
}

