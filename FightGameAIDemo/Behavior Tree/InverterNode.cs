using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightGameAIDemo.Behavior_Tree
{
    /// <summary>
    /// Decorator node that inverts the success/failure of its child.
    /// Origionaly Developed by Ashley Davis. Modified for use in this project by Steven Mcvey.
    /// </summary>
    /// <seealso cref="FightGameAIDemo.IMyParentBehaviourTreeNode" />
    public class InverterNode : IMyParentBehaviourTreeNode
    {
        /// <summary>
        /// Name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// The child to be inverted.
        /// </summary>
        private IMyBehaviourTreeNode childNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="InverterNode"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public InverterNode(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Update the time of the behaviour tree.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">InverterNode must have a child node!</exception>
        public MyBehaviourTreeStatus Tick(MyTimeData time)
        {
            if (childNode == null)
            {
                throw new ApplicationException("InverterNode must have a child node!");
            }

            var result = childNode.Tick(time);
            if (result == MyBehaviourTreeStatus.Failure)
            {
                return MyBehaviourTreeStatus.Success;
            }
            else if (result == MyBehaviourTreeStatus.Success)
            {
                return MyBehaviourTreeStatus.Failure;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Add a child to the parent node.
        /// </summary>
        /// <param name="child">The child.</param>
        /// <exception cref="System.ApplicationException">Can't add more than a single child to InverterNode!</exception>
        public void AddChild(IMyBehaviourTreeNode child)
        {
            if (this.childNode != null)
            {
                throw new ApplicationException("Can't add more than a single child to InverterNode!");
            }

            this.childNode = child;
        }
    }
}
