using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightGameAIDemo.Behavior_Tree
{

    /// <summary>
    /// Represents time. Used to pass time values to behaviour tree nodes.
    /// Origionaly Developed by Ashley Davis. Modified for use in this project by Steven Mcvey.
    /// </summary>
    public struct MyTimeData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyTimeData"/> struct.
        /// </summary>
        /// <param name="deltaTime">The delta time.</param>
        public MyTimeData(float deltaTime)
        {
            this.deltaTime = deltaTime;
        }

        /// <summary>
        /// The delta time
        /// </summary>
        public float deltaTime;
    }

}
