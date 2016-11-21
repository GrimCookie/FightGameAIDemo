using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;

namespace FightGameAIDemo.Fighter_Classes
{
    /// <summary>
    /// Abstract base class Fighter
    /// </summary>
    public abstract class Fighter
    {
        /// <summary>
        /// The number of the fighter
        /// </summary>
        private int number;
        /// <summary>
        /// The type of fighter
        /// </summary>
        private string type;
        /// <summary>
        /// The health of fighter
        /// </summary>
        private int health;
        /// <summary>
        /// The state of crouching for the fighter
        /// </summary>
        private bool isCrouching;
        /// <summary>
        /// The state of blocking for the fighter
        /// </summary>
        private bool isBlocking;

        /// <summary>
        /// The attack
        /// </summary>
        private Attack attack;

        /// <summary>
        /// Initializes a new instance of the <see cref="Fighter" /> class.
        /// </summary>
        public Fighter() 
        {
            Type = "Fighter";
            Health = 1;
            GenAttack();
            //isBlocking = false;
            //isCrouching = false;
        }

        //public Fighter(int num)
        //{
        //    Number = num;
        //    Type = "Fighter";
        //    Health = 100;
        //    isBlocking = false;
        //    isCrouching = false;
        //}

        /// <summary>
        /// Gets or sets the number of the fighter.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        /// <summary>
        /// Gets or sets the type of the fighter.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        /// <summary>
        /// Gets or sets the health of the fighter.
        /// </summary>
        /// <value>
        /// The health.
        /// </value>
        public int Health 
        { 
            get { return health; } 
            set { health = value; } 
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Fighter" /> is crouching.
        /// </summary>
        /// <value>
        ///   <c>true</c> if crouching; otherwise, <c>false</c>.
        /// </value>
        public bool Crouching
        {
            get { return isCrouching; }
            set { isCrouching = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Fighter" /> is blocking.
        /// </summary>
        /// <value>
        ///   <c>true</c> if blocking; otherwise, <c>false</c>.
        /// </value>
        public bool Blocking
        {
            get { return isBlocking; }
            set { isBlocking = value; }
        }

        /// <summary>
        /// Gets or sets the attack.
        /// </summary>
        /// <value>
        /// The attack.
        /// </value>
        public Attack Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        /// <summary>
        /// Generates the attack of the fighter.
        /// </summary>
        /// <returns>
        /// Attack type
        /// </returns>
        public virtual Attack GenAttack()
        {
            //Fighter opponent

            //int a = 10;
            Attack attk;
            Random rnd = new Random();

            if (rnd.Next(0,3) == 0) 
            { 
                attk = new Punch();
            }
            else if(rnd.Next(0,3)==1)
            { 
                attk = new Kick();
            }
            else
            {
                attk = new Special();
            }

            //return attack
            Attack = attk;
            return attk;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "//:" + type + " //Fighter number:" + number + "\\ Health = " + health + ", is Crouched = " + isCrouching + ", is Blocking = " + isBlocking;
        }

    }
}
