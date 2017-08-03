using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    static class CollisionEngine
    {
        //Tuple<List<Zombie>,List<Bullet>>
        public static void collisionHandler(List<Zombie> zombieList, List<Bullet> bulletList, List<Survivor> survivorList, List<Weapon> weaponList)
        {

            //Go through enemies
            for (int x = 0; x < zombieList.Count; x++)
            {
                for (int y = x + 1; y < zombieList.Count; y++)
                {
                    //Check if the two entities are colliding
                    if (IsColliding(zombieList[x], zombieList[y]))
                    {
                        //Handle the zombie collision
                        zombieCollision(zombieList[x], zombieList[y]);
                    }
                }
            }

            //Go through bullets
            foreach (Bullet bullet in bulletList)
            {
                //If the bullet is outside the map
                if (bullet.Position.X < 0 || bullet.Position.X > 1920 || bullet.Position.Y < 0 || bullet.Position.Y > 1080)
                {
                    bullet.IsAlive = false;
                }
            }
            
            //Go through the enemies
            for (int x = 0; x < zombieList.Count; x++)
            {
                //Go through the bullets
                for(int y = 0; y < bulletList.Count; y++)
                {
                    //Check if the bullet is colliding with enemy
                    if(IsColliding(zombieList[x],bulletList[y]))
                    {
                        //If the zombie is an exploder
                        if(zombieList[x] is Exploder)
                        {
                            //Explode
                            Explode(zombieList[x] as Exploder, survivorList);
                        }
                        //Kill the bullet
                        bulletList[y].IsAlive = false;
                        //Deduct health from the zombie
                        zombieList[x].deductHealth(1);
                        //Increment the survivors kills by one
                        bulletList[y].SurvOrigin.Kills++;
                    }
                }
            }
            //Go through the enemies
            for(int x = 0; x < zombieList.Count; x++)
            {
                //Go through the survivors
                for (int y = 0; y < survivorList.Count; y++)
                {
                    //If the zombie is colliding with the player
                    if (zombieList[x].IsAlive && IsColliding(survivorList[y], zombieList[x]))
                    {
                        //Set the player to not being alive anymore
                        survivorList[y].IsAlive = false;
                    }
                }
            }
            //Go through every weapon
            for(int x = 0; x < weaponList.Count; x++)
            {
                //Go through the survivors
                for (int y = 0; y < survivorList.Count; y++)
                {
                    //If the weapon is colliding with the player
                    if (weaponList[x].IsAlive && IsColliding(survivorList[y], weaponList[x]))
                    {
                        //Set the origin of the weapon
                        weaponList[x].Origin = survivorList[y];
                        //Give the player that weapon
                        survivorList[y].HolsteredWeapon = weaponList[x];
                        //Kill the weapon, don't need it anymore
                        weaponList[x].IsAlive = false;
                    }
                }
            }

        }

        //Generic collision algorithim
        static bool IsColliding(GameEntity entityX, GameEntity entityY)
        {
            //Total radius
            float radius = entityX.CollisionRadius + entityY.CollisionRadius;
            //If both entities are alive, and their radisues are colliding
            if (entityX.IsAlive == true && entityY.IsAlive == true && Vector2.DistanceSquared(entityX.Position, entityY.Position) < (radius * radius))
            {
                return true;
            }
            //Otherwise return false
            return false;

        }

        //Check if two entities are near each other
        public static bool IsNear(GameEntity entityX, GameEntity entityY)
        {
            //Calculate radius
            float nearradius = 2000;
            //Check if both are colliding
            if (Vector2.DistanceSquared(entityX.Position, entityY.Position) < (nearradius * nearradius))
            {
                //They are near each other, return true
                return true;
            }
            else
            {
                //They aren't near each other, return false
                return false;
            }
        }

        static void Explode(Exploder exploder, List<Survivor> listofsurvivors)
        {
            //Go through the survivors in the game
            foreach(Survivor surv in listofsurvivors)
            {
                //Calculate radius
                float explosionradius = (exploder.CollisionRadius * 10) + surv.CollisionRadius;
                //Check if both are colliding
                if (Vector2.DistanceSquared(exploder.Position, surv.Position) < (explosionradius * explosionradius))
                {
                    //Kill the player and the exploder
                    surv.IsAlive = false;
                }
                //Explode the exploder
                exploder.Explode();
            }
        }

        //I don't think this ever ended up working as I intended
        static void zombieCollision(Zombie main, Zombie other)
        {
            //Variable that holds the difference between the two different positions
            var difference1 = main.Position - other.Position;
            //Set the velocity of the main zombie to go up and around the one its colliding with
            main.Velocity += 10 * difference1 / (difference1.LengthSquared() + 1);
            //Difference 2, same thing but reversed
            var difference2 = other.Position - main.Position;
            //Set the velocity of the other zombie to go up and avoid the one its colliding with
            other.Velocity += 10 * difference2 / (difference2.LengthSquared() + 1);
        }



    }
}
