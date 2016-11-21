using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightGameAIDemo.Attacks
{
    /// <summary>
    ///  Sub Class of Attack, inherits propperties from Attack class
    /// </summary>
    /// <seealso cref="FightGameAIDemo.Attack" />
    public class Kick : Attack
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Kick"/> class.
        /// </summary>
        public Kick()
        {
            
            Name = "Kick";
            Distance = "Medium";
            Damage = -25;
            LowDam = true;
        }
    }
}
