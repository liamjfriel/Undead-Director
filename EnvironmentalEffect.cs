using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    abstract class EnvironmentalEffect
    {
        /// <summary>
        /// Cost of the environmental effect
        /// </summary>
        public int Cost {get; set; }

        /// <summary>
        /// Override Activate method, as typical in subclass sandbox design pattern
        /// </summary>
        public abstract void Activate();




    }
}
