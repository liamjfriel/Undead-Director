using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class BullyAI : AIPersonality
    {
        public static BullyAI bullyai;
        public static BullyAI Instance
        {
            get
            {
                if (bullyai == null)
                {
                    bullyai = new BullyAI();
                }
                return bullyai;
            }
        }
        
        /// <summary>
        /// Constructor method for this class
        /// </summary>
        public BullyAI()
        {
            //First target is just player one, until the game has progressed a bit and decisions can be made
            Target = World.AliveSurvivorList.ElementAt(0);
        }

        /// <summary>
        /// Override Logic method
        /// </summary>
        public override void Logic()
        {
            //Set the target to the first entry in the survivor list
            Target = World.AliveSurvivorList.ElementAt(0);
            //Go through every survivor
            foreach(Survivor surv in World.AliveSurvivorList)
            {
                //If the target has more kills than the next survivor
                if(Target.Kills >= surv.Kills && surv.IsAlive)
                {
                    //Set that survivor as the target
                    Target = surv;
                }
            }
            //One in three chance of this happening
            if (ExtensionMethods.RandomNumber(1, 3) == 2)
            {
                //If the Director has enough resources
                if (World.Director.Resources > SpeedEffect.Instance.Cost)
                {
                    //Go through all the zombies
                    foreach (Zombie zom in World.ZombieList)
                    {
                        if (CollisionEngine.IsNear(Target, zom))
                        {
                            //Use either the slow or speed up
                            if (ExtensionMethods.RandomNumber(1, 2) == 2)
                            {
                                //Slow the players
                                SpeedEffect.Instance.Activate();
                            }
                            else
                            {
                                //Make the zombies go faster
                                SlowEffect.Instance.Activate();
                            }
                        }
                    }
                }
            }
            //One in three chance of spawning a juggernaught
            if (ExtensionMethods.RandomNumber(1, 3) == 2)
            {
                //Try and spawn a juggernaught
                WorldDirector.ZombieSpawner("j");
            }
            //One in two chance of spawning an exploder
            if (ExtensionMethods.RandomNumber(1, 5) == 3)
            {
                //Try and spawn a juggernaught
                WorldDirector.ZombieSpawner("e");
            }
            //One in three chance of spawning a speeder
            //One in three chance of spawning a juggernaught
            if (ExtensionMethods.RandomNumber(1, 1000) == 2)
            {
                //Try and spawn a juggernaught
                WorldDirector.ZombieSpawner("s");
            }
        }

    }
}
