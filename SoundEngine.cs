using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class SoundEngine
    {
        private SoundEffectInstance SoundInstance; 

        public static void MultithreadSound(SoundEffect sound)
        {
            //Multithreaded
            Thread thread = new Thread(() => sound.Play());
            thread.Start();
        }


    }
}
