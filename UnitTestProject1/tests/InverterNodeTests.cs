using Fluent_behavior_tree;
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
    public class InverterNodeTests
    {
        InverterNode testObject;

        void Init()
        {
            testObject = new InverterNode("some-node");
        }

        [Fact]
        public void ticking_with_no_child_node_throws_exception()
        {
            Init();

            Assert.Throws<ApplicationException>(
                () => testObject.Tick(new MyTimeData())
            );
        }

        [Fact]
        public void inverts_success_of_child_node()
        {
            Init();

            var time = new MyTimeData();

            var mockChildNode = new Mock<IMyBehaviourTreeNode>();
            mockChildNode
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Success);

            testObject.AddChild(mockChildNode.Object);

            Assert.Equal(MyBehaviourTreeStatus.Failure, testObject.Tick(time));

            mockChildNode.Verify(m => m.Tick(time), Times.Once());
        }

        [Fact]
        public void inverts_failure_of_child_node()
        {
            Init();

            var time = new MyTimeData();

            var mockChildNode = new Mock<IMyBehaviourTreeNode>();
            mockChildNode
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Failure);

            testObject.AddChild(mockChildNode.Object);

            Assert.Equal(MyBehaviourTreeStatus.Success, testObject.Tick(time));

            mockChildNode.Verify(m => m.Tick(time), Times.Once());
        }

        [Fact]
        public void pass_through_running_of_child_node()
        {
            Init();

            var time = new MyTimeData();

            var mockChildNode = new Mock<IMyBehaviourTreeNode>();
            mockChildNode
                .Setup(m => m.Tick(time))
                .Returns(MyBehaviourTreeStatus.Running);

            testObject.AddChild(mockChildNode.Object);

            Assert.Equal(MyBehaviourTreeStatus.Running, testObject.Tick(time));

            mockChildNode.Verify(m => m.Tick(time), Times.Once());
        }

        [Fact]
        public void adding_more_than_a_single_child_throws_exception()
        {
            Init();

            var mockChildNode1 = new Mock<IMyBehaviourTreeNode>();
            testObject.AddChild(mockChildNode1.Object);

            var mockChildNode2 = new Mock<IMyBehaviourTreeNode>();
            Assert.Throws<ApplicationException>(() => 
                testObject.AddChild(mockChildNode2.Object)
            );
        }


    }
}
