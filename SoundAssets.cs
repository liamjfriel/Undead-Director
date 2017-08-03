using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class SoundAssets
    {
        //List of assets and accessors
        public static SoundEffect HandgunShot { get; private set; }
        public static SoundEffect AssaultRifle { get; private set; }
        public static SoundEffect ShotgunShot { get; private set; }
        public static SoundEffect ExplosionSound { get; private set; }
        //Load all the assets we need
        public static void Load(ContentManager Content)
        {
            //Load the bullets
            //All gunshot sounds are credited in design document
            HandgunShot = Content.Load<SoundEffect>("9mm");
            AssaultRifle = Content.Load<SoundEffect>("assaultrifle");
            ShotgunShot = Content.Load<SoundEffect>("shotgunshot");
            //Explosion sound http://www.freesound.org/people/harpoyume/sounds/86032/
            ExplosionSound = Content.Load<SoundEffect>("explosionsound");
        }
    }
}
