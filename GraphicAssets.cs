using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class GraphicAssets
    {
        //List of assets and accessors
        public static Texture2D Survivor1 { get; private set; }
        public static Texture2D PistolSprite { get; private set; }
        public static Texture2D ShotgunSprite { get; private set; }
        public static Texture2D SurvivorHandgun { get; private set; }
        public static Texture2D SurvivorShotgun { get; private set; }
        public static SpriteFont DebugFont { get; private set; }
        public static SpriteFont TitleFont { get; private set; }
        public static Texture2D Bullet { get; private set; }
        public static Texture2D CommonZombie { get; private set; }
        public static Texture2D Speeder { get; private set; }
        public static Texture2D Exploder { get; private set; }
        public static Texture2D Juggernaught { get; private set; }
        public static Texture2D Director { get; private set; }
        public static Texture2D AssaultRifleSprite { get; private set; }
        public static Texture2D BackgroundSprite { get; private set; }
        public static Texture2D ControllerSprite { get; private set; }
        public static SpriteFont YButtonFont { get; private set; }
        public static SpriteFont GameFont { get; private set; }
        //Load all the assets we need
        public static void Load(ContentManager Content)
        {
            //Load the bullets
            //Bullet texture http://opengameart.org/content/2d-object-pack
            Bullet = Content.Load<Texture2D>("bullet");
            //Load the survivor
            //All these assets are specified in the original design document and are sourced from open game art
            Survivor1= Content.Load<Texture2D>("survivor");
            SurvivorHandgun = Content.Load<Texture2D>("survivorhandgun");
            SurvivorShotgun = Content.Load<Texture2D>("survivorshotgun");
            //Load in spritefont 
            DebugFont = Content.Load<SpriteFont>("version");
            //Modified versions of material from opengame art that is specified in the design document originally
            CommonZombie = Content.Load<Texture2D>("commonzombie");
            Speeder = Content.Load<Texture2D>("speeder");
            Exploder = Content.Load<Texture2D>("exploder");
            Juggernaught = Content.Load<Texture2D>("juggernaught");
            Director = Content.Load<Texture2D>("freemusic");
            //Load in weapons
            //From opengame art, credit listed in original design document
            PistolSprite = Content.Load<Texture2D>("ColtPixel");
            AssaultRifleSprite = Content.Load<Texture2D>("AK");
            ShotgunSprite = Content.Load<Texture2D>("Shotgunsprite");
            //Grass asset http://opengameart.org/content/30-grass-textures-tilable
            BackgroundSprite = Content.Load<Texture2D>("grassstile");
            //Controller asset http://opengameart.org/content/common-controller
            ControllerSprite = Content.Load<Texture2D>("Controller1");
            TitleFont = Content.Load<SpriteFont>("Title");
            YButtonFont = Content.Load<SpriteFont>("YButton");
            GameFont = Content.Load<SpriteFont>("GameFont");
        }
    }
}
