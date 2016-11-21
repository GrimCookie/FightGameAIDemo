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
    public class Special : Attack
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Special"/> class.
        /// </summary>
        public Special() 
        {
            Name = "Special Move";
            Distance = "Far";
            Damage = -30;
            LowDam = false;
        }
    }
}
