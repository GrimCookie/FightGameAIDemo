using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FightGameAIDemo.GP;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;

namespace FightGameAIDemo.Fighter_Classes
{
    /// <summary>
    /// AI-Fighter sub-class of fighter class, inherits propperties from Fighter class
    /// </summary>
    /// <seealso cref="FightGameAIDemo.Fighter" />
    public class AIFighter : Fighter
    {
        /// <summary>
        /// Used to hold the tree for AI behaviour.
        /// </summary>
        private Indevidual tree;

        /// <summary>
        /// Initializes a new instance of the <see cref="AIFighter" /> class.
        /// </summary>
        /// <param name="num">The number.</param>
        public AIFighter(int num)
        {
            Number = num;
            Health = 100;
            Type = "AI-Fighter";
            GenAttack();
            Tree = new Indevidual();
            
        }
        /// <summary>
        /// Gets or sets the tree.
        /// </summary>
        /// <value>
        /// The tree.
        /// </value>
        public Indevidual Tree
        {
            get { return tree; }
            set { tree = value; }
        }
    }
}
