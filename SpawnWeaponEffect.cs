using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UndeadDirector
{
    class SpawnWeaponEffect : EnvironmentalEffect
    {
        /// <summary>
        /// Static instance of this
        /// </summary>
        public static SpawnWeaponEffect speedeffect;
        public static SpawnWeaponEffect Instance
        {
            get
            {
                if (speedeffect == null)
                {
                    speedeffect = new SpawnWeaponEffect();
                }
                return speedeffect;
            }
        }
        public int Reward;

        public SpawnWeaponEffect()
        {
            Reward = 1000;
        }

        //Make every zombie in the game world faster
        public override void Activate()
        {
            //If the director can spawn a weapon
            if (World.Director.CanSpawnWeapon)
            {
                //Spawn the weapon
                WorldDirector.SpawnWeapon();
                //Reward the director
                World.Director.Resources += Reward;
                //Reset the directors ability to spawn a weapon
                World.Director.CanSpawnWeapon = false;
            }
        }
    }
}


