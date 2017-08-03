using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    abstract class Weapon : GameEntity
    {

        public int WeaponCoolDown;
        public Vector2 FiringOffset;
        public Vector2 WeaponOffset;
        public Survivor Origin;
        public int Ammunition;
        public SoundEffect Gunshot;

        public override void Update()
        {
           
            //Position is position
            Position = Position;
        }

        public abstract void Fire();


       
        
    

    }
}
