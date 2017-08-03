using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    static class MenuController
    {

        /// <summary>
        /// Update the controller
        /// </summary>
        public static void Update(GameEngine instance)
        {
            //If the player pressed start, start a new game

            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                //Number of players
                World.NewGame(Menu.IsHuman, NumberOfPlayers());
                //Start the game
                instance.previousState = GameEngine.GameState.Menu;
                instance.currentState = GameEngine.GameState.Playing;
            }
            //If they pressed Y, toggle is human or not
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed && Menu.CanYButton)
            {
                if(Menu.IsHuman == false)
                {
                    Menu.IsHuman = true;
                }
                else
                {
                    Menu.IsHuman = false;
                }
            }
            //
            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
            {
                //Set the gamestates
                instance.previousState = GameEngine.GameState.Menu;
                instance.currentState = GameEngine.GameState.HowToPlay;
            }
            //Menu players connected array is equal to the return of one of this classes methods
            Menu.PlayersConnected = checkControllers();
        }


        public static bool HumanDirector = false;

        /// <summary>
        /// This returns the number of players connected
        /// </summary>
        /// <returns></returns>
        static int NumberOfPlayers()
        {
            //Integer number of players
            int numofplayers = 0;
            //Array of players
            bool[] players = checkControllers();
            //For every bool in players
            foreach (bool connected in players)
            {
                //If a controller is corrected
                if (connected)
                {
                    //Increment the number of players
                    numofplayers++;
                }
            }
        
            return numofplayers;
        }

        /// <summary>
        /// Check every controller and update the array
        /// </summary>
        public static bool[] checkControllers()
        {
            //Players that are connected
            bool [] PlayersConnected = new bool[4] { false, false, false, false };
            //Check if players are connected and update list accordingly
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                PlayersConnected[0] = true;
            }
            else
            {
                PlayersConnected[0] = false;
            }
            if (GamePad.GetState(PlayerIndex.Two).IsConnected)
            {
                PlayersConnected[1] = true;
            }
            else
            {
                PlayersConnected[1] = false;
            }
            if (GamePad.GetState(PlayerIndex.Three).IsConnected)
            {
                PlayersConnected[2] = true;
            }
            else
            {
                PlayersConnected[2] = false;
            }
            if (GamePad.GetState(PlayerIndex.Four).IsConnected)
            {
                PlayersConnected[3] = true;
            }
            else
            {
                PlayersConnected[3] = false;
            }

            //Return the array
            return PlayersConnected;
        }

    }
}
