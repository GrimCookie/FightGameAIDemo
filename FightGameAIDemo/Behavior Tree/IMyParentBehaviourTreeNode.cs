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
    /// <seealso cref="FightGameAIDemo.IMyBehaviourTreeNode" />
    public interface IMyParentBehaviourTreeNode : IMyBehaviourTreeNode
    {
        /// <summary>
        /// Add a child to the parent node.
        /// </summary>
        /// <param name="child">The child.</param>
        void AddChild(IMyBehaviourTreeNode child);
    }
}
