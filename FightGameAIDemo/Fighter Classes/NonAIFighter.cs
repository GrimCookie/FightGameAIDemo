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
    /// NoN-AI-Fighter sub-class of fighter class, inherits propperties from Fighter class
    /// </summary>
    /// <seealso cref="FightGameAIDemo.Fighter" />
    public class NonAIFighter : Fighter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonAIFighter" /> class.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="isBlocking">if set to <c>true</c> [is blocking].</param>
        /// <param name="isCrouched">if set to <c>true</c> [is crouched].</param>
        public NonAIFighter(int num, bool isBlocking, bool isCrouched) : base()
        {
            Type = "Non-AI-Fighter";
            Health = 100;
            Number = num;
            Crouching = isCrouched;
            Blocking = isBlocking;
            GenAttack();
        }
        //public override String Attack(Fighter opponent)
        //{
        //    opponent.Health -= 5;

        //    return "NON-AI-Fighter <<attacks>> AI-Fighter <<For>> -5";
        //}
        
    }
}
