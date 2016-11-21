using FluentBehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
//using FluentBehaviourTree;
using Fluent_behavior_tree.mehNodes;
using Fluent_behavior_tree;

namespace tests
{
    public class ActionNodeTests
    {
        [Fact]
        public void can_run_action()
        {
            var time = new MyTimeData();

            var invokeCount = 0;
            var testObject = 
                new ActionNode(
                    "some-action", 
                    t =>
                    {
                        Assert.Equal(time, t);

                        ++invokeCount;
                        return MyBehaviourTreeStatus.Running;
                    }
                );

            Assert.Equal(MyBehaviourTreeStatus.Running, testObject.Tick(time));
            Assert.Equal(1, invokeCount);            
        }
    }
}
