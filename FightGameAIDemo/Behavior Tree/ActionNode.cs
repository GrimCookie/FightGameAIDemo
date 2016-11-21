using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightGameAIDemo.Behavior_Tree
{
    /// <summary>
    /// A behaviour tree leaf node for running an action.
    /// Origionaly Developed by Ashley Davis. Modified for use in this project by Steven Mcvey.
    /// </summary>
    /// <seealso cref="FightGameAIDemo.IMyBehaviourTreeNode" />
    public class ActionNode : IMyBehaviourTreeNode
    {
        /// <summary>
        /// The name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// Function to invoke for the action.
        /// </summary>
        private Func<MyTimeData, MyBehaviourTreeStatus> fn;


        /// <summary>
        /// Initializes a new instance of the <see cref="ActionNode"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="fn">The function.</param>
        public ActionNode(string name, Func<MyTimeData, MyBehaviourTreeStatus> fn)
        {
            this.name=name;
            this.fn=fn;
        }

        /// <summary>
        /// Update the time of the behaviour tree.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public MyBehaviourTreeStatus Tick(MyTimeData time)
        {
            return fn(time);
        }
    }
}
