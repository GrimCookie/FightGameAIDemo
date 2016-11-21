using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightGameAIDemo.Behavior_Tree
{
    /// <summary>
    /// Selects the first node that succeeds. Tries successive nodes until it finds one that doesn't fail.
    /// Origionaly Developed by Ashley Davis. Modified for use in this project by Steven Mcvey.
    /// </summary>
    /// <seealso cref="FightGameAIDemo.IMyParentBehaviourTreeNode" />
    public class SelectorNode : IMyParentBehaviourTreeNode
    {
        /// <summary>
        /// The name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// List of child nodes.
        /// </summary>
        private List<IMyBehaviourTreeNode> children = new List<IMyBehaviourTreeNode>(); //todo: optimization, bake this to an array.

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectorNode"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public SelectorNode(string name)
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
                if (childStatus != MyBehaviourTreeStatus.Failure)
                {
                    return childStatus;
                }
            }

            return MyBehaviourTreeStatus.Failure;
        }

        /// <summary>
        /// Add a child node to the selector.
        /// </summary>
        /// <param name="child">The child.</param>
        public void AddChild(IMyBehaviourTreeNode child)
        {
            children.Add(child);
        }
    }
}
