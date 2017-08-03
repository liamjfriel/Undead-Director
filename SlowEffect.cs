using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class SlowEffect : EnvironmentalEffect
    {
        /// <summary>
        /// Static instance of this
        /// </summary>
        public static SlowEffect sloweffect;
        public static SlowEffect Instance
        {
            get
            {
                if (sloweffect == null)
                {
                    sloweffect = new SlowEffect();
                }
                return sloweffect;
            }
        }

        public SlowEffect()
        {
            Cost = 1000;
        }

        //Make every zombie in the game world faster
        public override void Activate()
        {
            //If the director has enough resources..
            if (World.Director.Resources >= Cost)
            {
                //Change the speed of every zombie in the game world
                foreach (Survivor surv in World.AliveSurvivorList)
                {
                    //Change the speed multiplier
                    surv.SpeedMultiplier = 1;
                    surv.IsSlowed = true;
                }
                //Deduct the 1000 resources from the director
                World.Director.Resources -= Cost;
            }

        }
    }
}
