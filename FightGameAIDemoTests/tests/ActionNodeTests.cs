using FightGameAIDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

using FightGameAIDemo.GP;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;

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
