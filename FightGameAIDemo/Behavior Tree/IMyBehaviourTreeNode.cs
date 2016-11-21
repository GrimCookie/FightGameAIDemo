using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FightGameAIDemo.Behavior_Tree
{

    /// <summary>
    /// Interface for behaviour tree nodes.
    /// Origionaly Developed by Ashley Davis. Modified for use in this project by Steven Mcvey.
    /// </summary>
    public interface IMyBehaviourTreeNode
    {
        /// <summary>
        /// Update the time of the behaviour tree.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        MyBehaviourTreeStatus Tick(MyTimeData time);
    }
}
