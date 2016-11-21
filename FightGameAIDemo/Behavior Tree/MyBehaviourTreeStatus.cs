using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightGameAIDemo.Behavior_Tree
{

    /// <summary>
    /// The return type when invoking behaviour tree nodes.
    /// Origionaly Developed by Ashley Davis. Modified for use in this project by Steven Mcvey.
    /// </summary>
    public enum MyBehaviourTreeStatus
        {
            /// <summary>
            /// The success
            /// </summary>
            Success,
            /// <summary>
            /// The failure
            /// </summary>
            Failure,
            /// <summary>
            /// The running
            /// </summary>
            Running
        }
    
}
