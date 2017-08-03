using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    static class Menu
    {
        ///Public boolean playersconnected
        public static bool[] PlayersConnected = new bool[4] {false, false, false, false };
        ///Public boolean IsHuman
        public static bool IsHuman;
        public static bool CanYButton = false;
        private static int YButtonTimer = 10;

        public static void Update()
        {
            //Use a timer for the Y button so it doesn't constantly cycle when you press it
            if (YButtonTimer > 0)
            {
                CanYButton = false;
                //Put down the cooldown timer
                YButtonTimer--;
            }
            else
            {
                //No cooldown left, so Y can be pressed again
                CanYButton = true;
                YButtonTimer = 10;
            }
        }


    }
}
