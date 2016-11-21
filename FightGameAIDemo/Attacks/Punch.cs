using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightGameAIDemo.Attacks
{
    /// <summary>
    /// Sub Class of Attack, inherits propperties from Attack class
    /// </summary>
    /// <seealso cref="FightGameAIDemo.Attack" />
    public class Punch : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Punch"/> class.
        /// </summary>
        public Punch()
        {
            
            Name = "Punch";
            Distance = "Close";
            Damage = -10;
            LowDam = false;
        }

    }
}
