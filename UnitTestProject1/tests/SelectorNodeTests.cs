using FluentBehaviourTree;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Fluent_behavior_tree.mehNodes;

namespace tests
{
    public class SelectorNodeTests
    {
        SelectorNode testObject;

        void Init()
        {
            testObject = new SelectorNode("some-selector");
        }

        [Fact]
        public void runs_the_first_node_if_it_succeeds()
        {
            Init();

            var time = new MyTimeData();

            var mockChild1 = new Mock<IMyBehaviourTreeNode>();
            mockChild1
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Success);

            var mockChild2 = new Mock<IMyBehaviourTreeNode>();

            testObject.AddChild(mockChild1.Object);
            testObject.AddChild(mockChild2.Object);

            Assert.Equal(MyBehaviourTreeStatus.Success, testObject.Tick(time));

            mockChild1.Verify(m => m.Tick(time), Times.Once());
            mockChild2.Verify(m => m.Tick(time), Times.Never());
        }

        [Fact]
        public void stops_on_the_first_node_when_it_is_running()
        {
            Init();

            var time = new MyTimeData();

            var mockChild1 = new Mock<IMyBehaviourTreeNode>();
            mockChild1
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Running);

            var mockChild2 = new Mock<IMyBehaviourTreeNode>();

            testObject.AddChild(mockChild1.Object);
            testObject.AddChild(mockChild2.Object);

            Assert.Equal(MyBehaviourTreeStatus.Running, testObject.Tick(time));

            mockChild1.Verify(m => m.Tick(time), Times.Once());
            mockChild2.Verify(m => m.Tick(time), Times.Never());
        }

        [Fact]
        public void runs_the_second_node_if_the_first_fails()
        {
            Init();

            var time = new MyTimeData();

            var mockChild1 = new Mock<IMyBehaviourTreeNode>();
            mockChild1
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Failure);

            var mockChild2 = new Mock<IMyBehaviourTreeNode>();
            mockChild2
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Success);

            testObject.AddChild(mockChild1.Object);
            testObject.AddChild(mockChild2.Object);

            Assert.Equal(MyBehaviourTreeStatus.Success, testObject.Tick(time));

            mockChild1.Verify(m => m.Tick(time), Times.Once());
            mockChild2.Verify(m => m.Tick(time), Times.Once());
        }

        [Fact]
        public void fails_when_all_children_fail()
        {
            Init();

            var time = new MyTimeData();

            var mockChild1 = new Mock<IMyBehaviourTreeNode>();
            mockChild1
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Failure);

            var mockChild2 = new Mock<IMyBehaviourTreeNode>();
            mockChild2
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Failure);

            testObject.AddChild(mockChild1.Object);
            testObject.AddChild(mockChild2.Object);

            Assert.Equal(MyBehaviourTreeStatus.Failure, testObject.Tick(time));

            mockChild1.Verify(m => m.Tick(time), Times.Once());
            mockChild2.Verify(m => m.Tick(time), Times.Once());
        }

    }
}

