using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    abstract class Zombie : GameEntity
    {
        //Integer that stores zombies health
        public int Health { get; set; }
        
        public void deductHealth(int deduction)
        {
            //Take off the health deduction from the health
            Health = Health - deduction;
            //Check if health is 0 or below
            if(Health <= 0)
            {
                //Kill the zombie
                IsAlive = false;
            }
        }
        




    }
}
