using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightGameAIDemo.Behavior_Tree
{
    /// <summary>
    /// Runs child nodes in sequence, until one fails.
    /// Origionaly Developed by Ashley Davis. Modified for use in this project by Steven Mcvey.
    /// </summary>
    /// <seealso cref="FightGameAIDemo.IMyParentBehaviourTreeNode" />
    public class SequenceNode : IMyParentBehaviourTreeNode
    {
        /// <summary>
        /// Name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// List of child nodes.
        /// </summary>
        private List<IMyBehaviourTreeNode> children = new List<IMyBehaviourTreeNode>(); //todo: this could be optimized as a baked array.

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceNode"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public SequenceNode(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Update the time of the behaviour tree.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>MyBehaviourTreeStatus</returns>
        public MyBehaviourTreeStatus Tick(MyTimeData time)
        {
            foreach (var child in children)
            {
                var childStatus = child.Tick(time);
                if (childStatus != MyBehaviourTreeStatus.Success)
                {
                    return childStatus;
                }
            }

            return MyBehaviourTreeStatus.Success;
        }

        /// <summary>
        /// Add a child to the sequence.
        /// </summary>
        /// <param name="child">The child.</param>
        public void AddChild(IMyBehaviourTreeNode child)
        {
            children.Add(child);
        }
    }
}
