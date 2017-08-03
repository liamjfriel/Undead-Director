using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndeadDirector
{
    abstract class AIPersonality
    {
        /// <summary>
        /// Target survivor for the AI
        /// </summary>
        public Survivor Target;
        /// <summary>
        /// Override Activate method, as typical in subclass sandbox design pattern
        /// </summary>
        public abstract void Logic();
    }
}
