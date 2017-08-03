using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    static class World
    {
        //List of all the entities in the game
        public static List<GameEntity> GameEntities = new List<GameEntity>();
        //New entity list
        public static List<GameEntity> NewEntities = new List<GameEntity>();
        //List of all the added entities
        public static List<GameEntity> AddedEntities = new List<GameEntity>();
        //List of all bullets in the world
        public static List<Bullet> BulletList = new List<Bullet>();
        //List of all weapons in the world
        public static List<Weapon> WeaponList = new List<Weapon>();
        //List of all the zombies in the world
        public static List<Zombie> ZombieList = new List<Zombie>();
        //List of all the survivors in the world
        public static List<Survivor> SurvivorList = new List<Survivor>();
        public static List<Survivor> AliveSurvivorList = new List<Survivor>();
        //The director
        public static Director Director {get; set; }

        //Are we updating?
        static bool IsUpdating;
        //Frames elapsed
 

        public static void Update(GameEngine instance)
        {
            //Is updating equals true
            IsUpdating = true;
            //Update the world director
            WorldDirector.Update();
            //Check for collisions
            CollisionEngine.collisionHandler(ZombieList, BulletList, SurvivorList,WeaponList);
            //Call update for every entity in the game
            foreach (GameEntity entity in GameEntities)
            {
                //Update every entity in the game
                entity.Update();
            }
            //Once every entity has been updated, set the updating flag to false
            IsUpdating = false;

            //Add all the newly added entities into the list of added entities
            foreach (GameEntity entity in AddedEntities)
            {
                AddEntityToLists(entity);
            }
            //Clear the added entities list
            AddedEntities.Clear();

            //Remove any dead entities
            //Lambada alogirthims adapted from Michael Hoffmans 
            //http://gamedevelopment.tutsplus.com/tutorials/make-a-neon-vector-shooter-in-xna-more-gameplay--gamedev-10103
            GameEntities = GameEntities.Where(x => x.IsAlive).ToList();
            ZombieList = ZombieList.Where(x => x.IsAlive).ToList();
            BulletList = BulletList.Where(x => x.IsAlive).ToList();
            WeaponList = WeaponList.Where(x => x.IsAlive).ToList();
            AliveSurvivorList = SurvivorList.Where(x => x.IsAlive).ToList();

            //Gameover is true
            bool gameover = true;
            //If any survivors are still alive
            foreach(Survivor surv in SurvivorList)
            {
                if(surv.IsAlive == true)
                {
                    //Then it's not game over
                    gameover = false;
                }
            }
            //If the games over, set the gamestate to gameover
            if(gameover)
            {
                instance.currentState = GameEngine.GameState.GameOver;
            }
        }
   
        public static void AddEntityToLists(GameEntity toadd)
        {
            //If the entity being added is a zombie
            if(toadd is Zombie)
            {
                //Add it to the zombie list
                ZombieList.Add(toadd as Zombie);
            }
            //Add the bullet to the bullet list if it is of that type
            else if (toadd is Bullet)
            {
                //Add it to the bullet list
                BulletList.Add(toadd as Bullet);
            }
            else if (toadd is Survivor)
            {
                SurvivorList.Add(toadd as Survivor);
                AliveSurvivorList.Add(toadd as Survivor);
            }
            else if (toadd is Director)
            {
                Director = toadd as Director;
            }
            else if (toadd is Weapon)
            {
                WeaponList.Add(toadd as Weapon);
            }
            //Add the entity to game entity list
            GameEntities.Add(toadd);

        }


        public static void NewGame(bool HumanDirector, int survivors)
        {
            //Reset all the things we need to reset
            Director = null;
            SurvivorList.Clear();
            WorldDirector.LevelCounter = 0;
            //Reset everything in the world
            GameEntities.Clear();
            NewEntities.Clear();
            AddedEntities.Clear();
            BulletList.Clear();
            ZombieList.Clear();
            AliveSurvivorList.Clear();
            //Reset the psawning counter
            WorldDirector.spawningcounter = 0;
            //If the director is human
            if (HumanDirector)
            {
                Add(new Director(Director.DirectorPersonality.Human));
                //Now start adding the survivors
                switch (survivors)
                {
                    case 2:
                        {
                            Add(new Survivor(PlayerIndex.One));
                            break;
                        }
                    case 3:
                        {
                            Add(new Survivor(PlayerIndex.One));
                            Add(new Survivor(PlayerIndex.Three));
                            break;
                        }
                    case 4:
                        {
                            Add(new Survivor(PlayerIndex.One));
                            Add(new Survivor(PlayerIndex.Three));
                            Add(new Survivor(PlayerIndex.Four));
                            break;
                        }
                }
            } else
            {
                //Check the amount of survivors and spawn the number of survivors
                switch (survivors)
                {
                    case 1:
                        {
                            Add(new Survivor(PlayerIndex.One));
                            break;
                        }
                    case 2:
                        {
                            Add(new Survivor(PlayerIndex.One));
                            Add(new Survivor(PlayerIndex.Two));
                            break;
                        }
                    case 3:
                        {
                            Add(new Survivor(PlayerIndex.One));
                            Add(new Survivor(PlayerIndex.Two));
                            Add(new Survivor(PlayerIndex.Three));
                            break;
                        }
                    case 4:
                        {
                            Add(new Survivor(PlayerIndex.One));
                            Add(new Survivor(PlayerIndex.Two));
                            Add(new Survivor(PlayerIndex.Three));
                            Add(new Survivor(PlayerIndex.Four));
                            break;
                        }
                }
                //So it's an AI, pick one of the three personalities
                switch (ExtensionMethods.RandomNumber(1,3))
                {
                    case 1:
                        {
                            Director dir = new Director(Director.DirectorPersonality.Swarmer);
                            Director = dir;
                            Add(Director);
                            break;
                        }
                    case 2:
                        {
                            Director dir = new Director(Director.DirectorPersonality.Spammer);
                            Director = dir;
                            Add(Director);
                            break;
                        }
                    case 3:
                        {
                            Director dir = new Director(Director.DirectorPersonality.Bully);
                            Director = dir;
                            Add(Director);
                            break;
                        }
                }
                
            }
        }

        public static void Add(GameEntity toadd)
        {
            //If the isupdating flag is false
            if(IsUpdating == false)
            {
                //Call the AddEntityToListsMethod
                AddEntityToLists(toadd);
            }
            else
            {
                //Add the entity to the added entities list
                AddedEntities.Add(toadd);
            }
        }

    }
}
