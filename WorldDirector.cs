using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UndeadDirector.ExtensionMethods;

namespace UndeadDirector
{
    static class WorldDirector
    {
        //Count of all frames
        public static int spawningcounter = 0;
        static int resourcemultiplier = 1;
        public static int LevelCounter = 0;

        public static void Update()
        {
            //If we're not at the final stage in the game
            if (spawningcounter != 100000)
            {
                //Increment spawning counter by 0.05
                spawningcounter++;
            } else
            {
                spawningcounter = spawningcounter - 250;
            }
            //Should we worry about adding new things?
            if (spawningcounter % 100 == 0)
            {    
                //Go to zombie spawner method
                roundController();
            }
            
            //Give the director 10 resources
            World.Director.Resources += 1 * resourcemultiplier;
          
        }

        static void roundController()
        {
            //Should we spawn a new weapon?
            if(spawningcounter % 2000 == 0)
            {
                SpawnWeapon();

            }
            //If in the first quarter of the game
            if (spawningcounter >= 0  && spawningcounter <= 12500)
            {
                //Give the director 10 resources
                World.Director.Resources += 10 * resourcemultiplier;
                //Spawn one zombie
                ZombieSpawner("c");
                LevelCounter = 1;
            }
            else
            //If we're in the second quarter of the game
            if (spawningcounter >= 12500 && spawningcounter <= 25000)
            {
                //Multiply the directors resources by 2 
                resourcemultiplier = resourcemultiplier * 2;
                //Give the director resources
                World.Director.Resources += 10 * resourcemultiplier;
                //Spawn two zombies
                ZombieSpawner("c");
                ZombieSpawner("c");
                LevelCounter = 2;
            }
            //If we're in the third quarter of the game
            if (spawningcounter >= 25000 && spawningcounter <= 37500)
            {
                //Multiply the directors resources by 2 
                resourcemultiplier = resourcemultiplier * 2;
                //Give the director resources
                World.Director.Resources += 10 * resourcemultiplier;
                //Spawn three zombies
                ZombieSpawner("c");
                ZombieSpawner("c");
                ZombieSpawner("c");
                LevelCounter = 3;
            }
            //If we're in the final quarter of the game
            if (spawningcounter >= 50000 && spawningcounter <= 51250)
            {
                //Multiply the directors resources by 2 
                resourcemultiplier = resourcemultiplier * 2;
                //Give the director resources
                World.Director.Resources += 10 * resourcemultiplier;
                //Spawn four zombies
                ZombieSpawner("c");
                ZombieSpawner("c");
                ZombieSpawner("c");
                ZombieSpawner("c");
                LevelCounter = 4;
            }

        }

        public static void SpawnWeapon()
        {
            //One in three random numbers, one representing each weapon
            int rand = ExtensionMethods.RandomNumber(0, 3);

            switch (rand)
            {
                case 0:
                    {
                        //Spawn a new handgun at a random location
                        World.Add(new Handgun(null, true));
                        break;
                    }
                case 1:
                    {
                        //Spawn a new handgun at a random location
                        World.Add(new AssaultRifle(null, true));
                        break;
                    }
                case 2:
                    {
                        //Spawn a new handgun at a random location
                        World.Add(new Shotgun(null, true));
                        break;
                    }
            }
        }


        public static bool ZombieSpawner(String typetoget)
        {
            //Get a location to spawn the zombie
            Vector2 spawnlocation = ZombieLocation();
            //Check what type the zombie is
            if (typetoget.Equals("c"))
            {
                //Add a new common zombie
                World.Add(new Common(spawnlocation, 0));
                return true;
            }
            else if (typetoget.Equals("j"))
            {
                //Does the director have enough resources?
                if (World.Director.Resources >= 1000)
                {
                    //Add a new juggernaught zombie
                    World.Add(new Juggernaught(spawnlocation, 0));
                    //Deduct 100 from the Directors resources
                    World.Director.Resources -= 1000;
                    //Return true
                    return true;
                } else
                {
                    return false;
                }
            } else if (typetoget.Equals("s"))
            {
                //Does the director have enough resources?
                if (World.Director.Resources >= 750)
                {
                    //Add a new juggernaught zombie
                    World.Add(new Speeder(spawnlocation, 0));
                    //Deduct 100 from the Directors resources
                    World.Director.Resources -= 750;
                    //Return true
                    return true;
                }
                else
                {
                    return false;
                }
            } else if (typetoget.Equals("e"))
            {
                //Does the director have enough resources?
                if (World.Director.Resources >= 1750)
                {
                    //Add a new juggernaught zombie
                    World.Add(new Exploder(spawnlocation, 0));
                    //Deduct 100 from the Directors resources
                    World.Director.Resources -= 1750;
                    //Return true
                    return true;
                }
            } else if (typetoget.Equals("cm"))
                {
                //Does the director have enough resources?
                if (World.Director.Resources >= 200)
                {
                    //Add a new juggernaught zombie
                    World.Add(new Common(spawnlocation, 0));
                    //Deduct 100 from the Directors resources
                    World.Director.Resources -= 200;
                    //Return true
                    return true;
                } 
            }
            return false;
        }

        static Vector2 ZombieLocation()
        {
    
            //Spawn in left, right sides of the screen or up and down
            switch (ExtensionMethods.RandomNumber(0, 3))
            {
                case 0:
                    {
                        //Add a new common zombie at the top of the screen
                        return new Vector2(ExtensionMethods.RandomNumber(0, 1920), 1080);
                    }
                case 1:
                    {
                        //Add a new common zombie at the bottom of the screen
                        return new Vector2(ExtensionMethods.RandomNumber(0, 1920), 0);
                    }
                case 2:
                    {
                        //Add a new common zombie at the left of the screen
                        return new Vector2(0, ExtensionMethods.RandomNumber(0, 1080));
                    }
                case 3:
                    {
                        //Add a new common zombie at the right of the screen
                        return new Vector2(1920, ExtensionMethods.RandomNumber(0, 1080));
                    }
            }
            return new Vector2(0, 0);
        }
        

    }
}
