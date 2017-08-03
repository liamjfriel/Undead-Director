using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    static class WorldController
    {

        public static void Update(GameEngine instance)
        {
            //Check if the player shoots
            CheckIfShot();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
            {
                //Go back to main menu
                instance.previousState = GameEngine.GameState.Playing;
                instance.currentState = GameEngine.GameState.HowToPlay;
            }

            if (World.Director.Personality == Director.DirectorPersonality.Human)
            {
                //Should we spawn a special zombie
                CheckSpawnSpecial();
                CheckEnvironmental();
            }
            //If the player started the game
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                //Go back to main menu
                instance.previousState = GameEngine.GameState.Playing;
                instance.currentState = GameEngine.GameState.Menu;
            }
        }


        public static float SurvivorAngle(PlayerIndex pindex)
        {
            //Angle that we will calculate
            float angle;
            //Get the angle, subtract it from zero so Y isn't flipped
            angle = 0 - GamePad.GetState(pindex).ThumbSticks.Right.Angle();
            //Return the angle
            return angle;
        }

        public static Vector2 SurvivorMovement(PlayerIndex pindex)
        {
            //Vector2 we will use to get the movement direction
            Vector2 movement;
            //Get the direction
            movement = GamePad.GetState(pindex).ThumbSticks.Left;
            //Mulitply Y index by -1 so we can invert Y axis
            movement.Y *= -1;
            //Return the vector2
            return movement;
        }


        public static Vector2 DirectorSwarmFlagMovement()
        {
            //Vector2 we will use to get the movement direction
            Vector2 movement;
            //Get the direction
            movement = GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left;
            //Mulitply Y index by -1 so we can invert Y axis
            movement.Y *= -1;
            //Return the vector2
            return movement;
        }

        public static Vector2 DirectorSpecialFlagMovement()
        {
            //Vector2 we will use to get the movement direction
            Vector2 movement;
            //Get the direction
            movement = GamePad.GetState(PlayerIndex.Two).ThumbSticks.Right;
            //Mulitply Y index by -1 so we can invert Y axis
            movement.Y *= -1;
            //Return the vector2
            return movement;
        }

        /// <summary>
        /// Should we spawn a special zombie?
        /// </summary>
        public static void CheckSpawnSpecial()
        {
            //If the player started the game
            if (GamePad.GetState(PlayerIndex.Two).Buttons.Y == ButtonState.Pressed)
            {
                //Call the spawn special zombie method, passing the variable for Juggernaught
                WorldDirector.ZombieSpawner("j");
            }
            //If the player started the game
            if (GamePad.GetState(PlayerIndex.Two).Buttons.X == ButtonState.Pressed)
            {
                //Call the spawn special zombie method, passing the variable for Juggernaught
                WorldDirector.ZombieSpawner("s");
            }
            //If the player started the game
            if (GamePad.GetState(PlayerIndex.Two).Buttons.A == ButtonState.Pressed)
            {
                //Call the spawn special zombie method, passing the variable for Juggernaught
                WorldDirector.ZombieSpawner("e");
            }
            //If the player started the game
            if (GamePad.GetState(PlayerIndex.Two).Buttons.B == ButtonState.Pressed)
            {
                //Call the spawn special zombie method, passing the variable for Juggernaught
                WorldDirector.ZombieSpawner("cm");
            }
        }

        public static void CheckEnvironmental()
        {
            //If the player started the game
            if (GamePad.GetState(PlayerIndex.Two).DPad.Up == ButtonState.Pressed)
            {
                //Call the spawn special zombie method, passing the variable for Juggernaught
                SpeedEffect.Instance.Activate();
            }
            //If the player started the game
            if (GamePad.GetState(PlayerIndex.Two).DPad.Down == ButtonState.Pressed)
            {
                //Call the spawn special zombie method, passing the variable for Juggernaught
                SlowEffect.Instance.Activate();
            }
            //If the player started the game
            if (GamePad.GetState(PlayerIndex.Two).DPad.Right== ButtonState.Pressed)
            {
                //Call the spawn special zombie method, passing the variable for Juggernaught
                SpawnWeaponEffect.Instance.Activate();
            }

        }

        public static void CheckIfShot()
        {
            //For every survivor in the game
            foreach(Survivor surv in World.AliveSurvivorList)
            {
                //If the player is attempting to fire and can do so
                if (GamePad.GetState(surv.PlayerIndex).Triggers.Right >= 0.5 && surv.CanFire)
                {
                    //Fire the weapon
                    surv.HolsteredWeapon.Fire();
                }
            }
        }


    }
}
