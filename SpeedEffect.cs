using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class SpeedEffect : EnvironmentalEffect
    {
        /// <summary>
        /// Static instance of this
        /// </summary>
        public static SpeedEffect speedeffect;
        public static SpeedEffect Instance
        {
            get
            {
                if(speedeffect == null)
                {
                    speedeffect = new SpeedEffect();
                }
                return speedeffect;
            }
        }

        public SpeedEffect()
        {
            Cost = 1000;
        }

        //Make every zombie in the game world faster
        public override void Activate()
        {
            //If the director has enough resources..
            if(World.Director.Resources >= Cost)
            {
                //Change the speed of every zombie in the game world
                foreach (Zombie zom in World.ZombieList)
                {
                    //Change the speed multiplier
                    zom.SpeedMultiplier = 7;
                }
                //Deduct the 1000 resources from the director
                World.Director.Resources -= Cost;
            }

        }
    }
}
