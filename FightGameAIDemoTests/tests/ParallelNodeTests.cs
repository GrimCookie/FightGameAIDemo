//using Fluent_behavior_tree;
using FightGameAIDemo;
using Moq;
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
    public class ParallelNodeTests
    {
        FightGameAIDemo.Behavior_Tree.ParallelNode testObject;

        void Init(int numRequiredToFail = 0, int numRequiredToSucceed = 0)
        {
            testObject = new ParallelNode("some-parallel", numRequiredToFail, numRequiredToSucceed);
        }

        [Fact]
        public void runs_all_nodes_in_order()
        {
            Init();

            var time = new MyTimeData();

            var callOrder = 0;

            var mockChild1 = new Mock<IMyBehaviourTreeNode>();
            mockChild1
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Running)
                .Callback(() =>
                {
                    Assert.Equal(1, ++callOrder);
                });

            var mockChild2 = new Mock<IMyBehaviourTreeNode>();
            mockChild2
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Running)
                .Callback(() =>
                 {
                     Assert.Equal(2, ++callOrder);
                 });

            testObject.AddChild(mockChild1.Object);
            testObject.AddChild(mockChild2.Object);

            Assert.Equal(MyBehaviourTreeStatus.Running, testObject.Tick(time));

            Assert.Equal(2, callOrder);

            mockChild1.Verify(m => m.Tick(time), Times.Once());
            mockChild2.Verify(m => m.Tick(time), Times.Once());
        }

        [Fact]
        public void fails_when_required_number_of_children_fail()
        {
            Init(2, 2);

            var time = new MyTimeData();

            var mockChild1 = new Mock<IMyBehaviourTreeNode>();
            mockChild1
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Failure);

            var mockChild2 = new Mock<IMyBehaviourTreeNode>();
            mockChild2
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Failure);

            var mockChild3 = new Mock<IMyBehaviourTreeNode>();
            mockChild3
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Running);

            testObject.AddChild(mockChild1.Object);
            testObject.AddChild(mockChild2.Object);
            testObject.AddChild(mockChild3.Object);

            Assert.Equal(MyBehaviourTreeStatus.Failure, testObject.Tick(time));

            mockChild1.Verify(m => m.Tick(time), Times.Once());
            mockChild2.Verify(m => m.Tick(time), Times.Once());
            mockChild3.Verify(m => m.Tick(time), Times.Once());
        }

        [Fact]
        public void succeeeds_when_required_number_of_children_succeed()
        {
            Init(2, 2);

            var time = new MyTimeData();

            var mockChild1 = new Mock<IMyBehaviourTreeNode>();
            mockChild1
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Success);

            var mockChild2 = new Mock<IMyBehaviourTreeNode>();
            mockChild2
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Success);

            var mockChild3 = new Mock<IMyBehaviourTreeNode>();
            mockChild3
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Running);

            testObject.AddChild(mockChild1.Object);
            testObject.AddChild(mockChild2.Object);
            testObject.AddChild(mockChild3.Object);

            Assert.Equal(MyBehaviourTreeStatus.Success, testObject.Tick(time));

            mockChild1.Verify(m => m.Tick(time), Times.Once());
            mockChild2.Verify(m => m.Tick(time), Times.Once());
            mockChild3.Verify(m => m.Tick(time), Times.Once());
        }

        [Fact]
        public void continues_to_run_if_required_number_children_neither_succeed_or_fail()
        {
            Init(2, 2);

            var time = new MyTimeData();

            var mockChild1 = new Mock<IMyBehaviourTreeNode>();
            mockChild1
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Success);

            var mockChild2 = new Mock<IMyBehaviourTreeNode>();
            mockChild2
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Failure);

            testObject.AddChild(mockChild1.Object);
            testObject.AddChild(mockChild2.Object);

            Assert.Equal(MyBehaviourTreeStatus.Running, testObject.Tick(time));

            mockChild1.Verify(m => m.Tick(time), Times.Once());
            mockChild2.Verify(m => m.Tick(time), Times.Once());
        }
    }
}
