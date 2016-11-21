using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightGameAIDemo.Attacks
{
    /// <summary>
    /// base class for the attack types
    /// </summary>
    public class Attack
    {
        /// <summary>
        /// The name of the attack
        /// </summary>
        String name;
        /// <summary>
        /// The damage of the attack
        /// </summary>
        int damage;
        /// <summary>
        /// The distance of the attack, effects damage
        /// </summary>
        String distance;
        /// <summary>
        /// The low attack, If true attack hits while defender is crouching
        /// </summary>
        bool lowDam;

        /// <summary>
        /// Initializes a new instance of the <see cref="Attack"/> class.
        /// </summary>
        public Attack()
        {}

        /// <summary>
        /// Gets or sets the name of the attack.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Gets or sets the damage of the attack.
        /// </summary>
        /// <value>
        /// The damage.
        /// </value>
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        /// <summary>
        /// Gets or sets the distance of the attack.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public String Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [low dam] is true or false.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [low dam]; otherwise, <c>false</c>.
        /// </value>
        public bool LowDam
        {
            get { return lowDam; }
            set { lowDam = value; }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public String ToString()
        {
            return name + ": <" + damage + ">";
        }

    }
}
