using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    class SwarmAI : AIPersonality
    {

        public static SwarmAI swarmai;
        public static SwarmAI Instance
        {
            get
            {
                if (swarmai == null)
                {
                    swarmai = new SwarmAI();
                }
                return swarmai;
            }
        }

        /// <summary>
        /// Constructor method for this class
        /// </summary>
        public SwarmAI()
        {
            //First target is just player one, until the game has progressed a bit and decisions can be made
            Target = World.AliveSurvivorList.ElementAt(0);
        }

        /// <summary>
        /// Override Logic method
        /// </summary>
        public override void Logic()
        {
            //Go through every survivor
            foreach (Survivor surv in World.AliveSurvivorList)
            {
                //If the survivor has more kills than the target
                if (Target.Kills < surv.Kills && surv.IsAlive)
                {
                    //Set that survivor to be the target
                    Target = surv;
                }
            }
            //If the Director has enough resources
            if (World.Director.Resources >= 10000)
            {
                while(World.Director.Resources > 500)
                {
                    //Use either the slow or speed up
                    if (ExtensionMethods.RandomNumber(1, 10) == 5)
                    {
                        //Slow the players
                        SpeedEffect.Instance.Activate();
                    }
                    if (ExtensionMethods.RandomNumber(1, 10) == 2)
                    {
                        //Make the zombies go faster
                        SlowEffect.Instance.Activate();
                    }
                    //Spawn a new common zomibie, one in ten chance
                    if (ExtensionMethods.RandomNumber(1, 10) == 2)
                    {
                        //Try and spawn a common zombie
                        WorldDirector.ZombieSpawner("cm");
                    }
                    //Spawn a juggernaught, one in ten
                    if (ExtensionMethods.RandomNumber(1, 10) == 7)
                    {
                        //Try and spawn a common zombie
                        WorldDirector.ZombieSpawner("j");
                    }
                    //Spawn an exploder, one in ten
                    if (ExtensionMethods.RandomNumber(1, 10) == 4)
                    {
                        //Try and spawn a common zombie
                        WorldDirector.ZombieSpawner("e");
                    }
                    //Spawn a speeder, one in ten
                    if (ExtensionMethods.RandomNumber(1, 10) == 3)
                    {
                        //Try and spawn a common zombie
                        WorldDirector.ZombieSpawner("s");
                    }
                }
                
            }
            
            //If the director can spawn a weapon, do it 
            if (World.Director.CanSpawnWeapon)
            {
                SpawnWeaponEffect.Instance.Activate();
            }
        }
    }
}
