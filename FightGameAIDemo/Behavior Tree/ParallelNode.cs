using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightGameAIDemo.Behavior_Tree
{
    /// <summary>
    /// Runs childs nodes in parallel.
    /// Origionaly Developed by Ashley Davis. Modified for use in this project by Steven Mcvey.
    /// </summary>
    /// <seealso cref="FightGameAIDemo.IMyParentBehaviourTreeNode" />
    public class ParallelNode : IMyParentBehaviourTreeNode
    {
        /// <summary>
        /// Name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// List of child nodes.
        /// </summary>
        private List<IMyBehaviourTreeNode> children = new List<IMyBehaviourTreeNode>();

        /// <summary>
        /// Number of child failures required to terminate with failure.
        /// </summary>
        private int numRequiredToFail;

        /// <summary>
        /// Number of child successess require to terminate with success.
        /// </summary>
        private int numRequiredToSucceed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParallelNode"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="numRequiredToFail">The number required to fail.</param>
        /// <param name="numRequiredToSucceed">The number required to succeed.</param>
        public ParallelNode(string name, int numRequiredToFail, int numRequiredToSucceed)
        {
            this.name = name;
            this.numRequiredToFail = numRequiredToFail;
            this.numRequiredToSucceed = numRequiredToSucceed;
        }

        /// <summary>
        /// Update the time of the behaviour tree.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        public MyBehaviourTreeStatus Tick(MyTimeData time)
        {
            var numChildrenSuceeded = 0;
            var numChildrenFailed = 0;

            foreach (var child in children)
            {
                var childStatus = child.Tick(time);
                switch (childStatus)
                {
                    case MyBehaviourTreeStatus.Success: ++numChildrenSuceeded; break;
                    case MyBehaviourTreeStatus.Failure: ++numChildrenFailed; break;
                }
            }

            if (numRequiredToSucceed > 0 && numChildrenSuceeded >= numRequiredToSucceed)
            {
                return MyBehaviourTreeStatus.Success;
            }

            if (numRequiredToFail > 0 && numChildrenFailed >= numRequiredToFail)
            {
                return MyBehaviourTreeStatus.Failure;
            }

            return MyBehaviourTreeStatus.Running;
        }

        /// <summary>
        /// Add a child to the parent node.
        /// </summary>
        /// <param name="child">The child.</param>
        public void AddChild(IMyBehaviourTreeNode child)
        {
            children.Add(child);
        }
    }
}
