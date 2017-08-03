using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static UndeadDirector.ExtensionMethods;

namespace UndeadDirector
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Game
    {
        public static GameEngine Instance { get; private set; }
        
        //State enumerator
        public enum GameState
        {
            Menu,
            Playing,
            HowToPlay,
            GameOver
        }
        public GameState previousState;
        public GameState currentState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            //Make game fullscreen
            graphics.IsFullScreen = true;
            //Give game 1920x1080 resolution
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
            
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            //Set the current state to menu
            currentState = GameState.Menu;
            previousState = GameState.Menu;
           
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Load the assets needed
            GraphicAssets.Load(Content);
            SoundAssets.Load(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //Check the gamestate
            switch (currentState)
            {
                //If we're playing the game
                case GameState.Playing:
                    {
                        //Update the world controller and world
                        World.Update(this);
                        WorldController.Update(this);
                        break;
                    }
                case GameState.Menu:
                    {
                        Menu.Update();
                        MenuController.Update(this);
                        break;
                    }
                case GameState.GameOver:
                    {
                        GameOverController.Update(this);
                        break;
                    }
                case GameState.HowToPlay:
                    {
                        HowToPlayController.Update(this);
                        break;
                    }
            }
            //Update
            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            //This line is from the MSDN document on tiling backgrounds
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointWrap);
            //Check the gamestate
            switch (currentState)
            {
                //If we're playing the game
                case GameState.Playing:
                    {
                        WorldRenderer.Instance.Draw(spriteBatch,this);
                        break;
                    }
                //If we're at the menu
                case GameState.Menu:
                    {
                        MenuRenderer.Instance.Draw(spriteBatch,this);
                        break;
                    }
                case GameState.GameOver:
                    {
                        GameOverRenderer.Instance.Draw(spriteBatch,this);
                        break;
                    }
                case GameState.HowToPlay:
                    {
                        HowToPlayRenderer.Instance.Draw(spriteBatch,this);
                        break;
                    }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
