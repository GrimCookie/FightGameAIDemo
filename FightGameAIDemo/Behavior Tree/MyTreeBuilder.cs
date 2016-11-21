//using FluentBehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;

namespace FightGameAIDemo.Behavior_Tree
{
    /// <summary>
    /// Fluent API for building a behaviour tree.
    /// Origionaly Developed by Ashley Davis. Modified for use in this project by Steven Mcvey.
    /// </summary>
    public class MyTreeBuilder //: BehaviourTreeBuilder
    {
        /// <summary>
        /// The crouched result, if true opponent is crouched
        /// </summary>
        public bool Crouched;
        /// <summary>
        /// The close result,  if true opponent is Close in Distance
        /// </summary>
        public bool Close;
        /// <summary>
        /// The medium result,  if true opponent is Medium in Distance
        /// </summary>
        public bool Medium;
        /// <summary>
        /// The far result,  if true opponent is Far in Distance
        /// </summary>
        public bool Far;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyTreeBuilder"/> class.
        /// Modified to accept the rules for the condition nodes
        /// </summary>
        /// <param name="crouched">if set to <c>true</c> [crouched].</param>
        /// <param name="close">if set to <c>true</c> [close].</param>
        /// <param name="medium">if set to <c>true</c> [medium].</param>
        /// <param name="far">if set to <c>true</c> [far].</param>
        public MyTreeBuilder(bool crouched, bool close, bool medium, bool far)
        {
            this.Crouched = crouched;
            this.Close = close;
            this.Medium = medium;
            this.Far = far;
        }

        /// <summary>
        /// Last node created.
        /// </summary>
        public IMyBehaviourTreeNode curNode = null;

        /// <summary>
        /// Stack node nodes that we are build via the fluent API.
        /// </summary>
        public Stack<IMyParentBehaviourTreeNode> parentNodeStack = new Stack<IMyParentBehaviourTreeNode>();

        /// <summary>
        /// Create an action node.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="fn">The function.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Can't create an unnested ActionNode, it must be a leaf node.</exception>
        public MyTreeBuilder Do(string name, Func<MyTimeData, MyBehaviourTreeStatus> fn)
        {
            if (parentNodeStack.Count <= 0)
            {
                throw new ApplicationException("Can't create an unnested ActionNode, it must be a leaf node.");
            }
            
            var actionNode = new ActionNode(name, fn);
            parentNodeStack.Peek().AddChild(actionNode);
            return this;
        }
        
        //+++++++++++++++++++++++++++++New Code++++++++++++++++++++++++++++++++++
        /// <summary>
        /// Create an action node which is Punch attack type.
        /// modified Do (action) Node.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="AI">The ai.</param>
        /// <param name="NAI">The nai.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Can't create an unnested ActionNode, it must be a leaf node.</exception>
        public MyTreeBuilder Punch(GameWorld context, AIFighter AI, NonAIFighter NAI)
        {
            if (parentNodeStack.Count <= 0)
            {
                throw new ApplicationException("Can't create an unnested ActionNode, it must be a leaf node.");
            }

            Func<MyTimeData, MyBehaviourTreeStatus> fr;
            fr = t =>
            {
                // A Punch Attack
                Punch punch = new Punch();

                GameWorld gw = context;
                gw.wAttack(AI, NAI, punch);

                gw.ListOfEvents.Add("Punch non AI player");
                return MyBehaviourTreeStatus.Success;
            };

            var actionNone = new ActionNode("Punch", fr);
            parentNodeStack.Peek().AddChild(actionNone);
            return this;
        }/// <summary>
        /// <summary>
        /// Create an action node which is Kick attack type.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="AI">The ai.</param>
        /// <param name="NAI">The nai.</param>
        /// <returns>MyTreeBuilder</returns>
        /// <exception cref="System.ApplicationException">Can't create an unnested ActionNode, it must be a leaf node.</exception>
        public MyTreeBuilder Kick(GameWorld context, AIFighter AI, NonAIFighter NAI)
        {
            if (parentNodeStack.Count <= 0)
            {
                throw new ApplicationException("Can't create an unnested ActionNode, it must be a leaf node.");
            }

            Func<MyTimeData, MyBehaviourTreeStatus> fr;
            fr = t =>
            {
                // A Kick attack
                Kick kick = new Kick();

                GameWorld gw = context;
                gw.wAttack(AI, NAI, kick);

                gw.ListOfEvents.Add("Kick non AI player");
                return MyBehaviourTreeStatus.Success;
            };

            var actionNone = new ActionNode("Kick", fr);
            parentNodeStack.Peek().AddChild(actionNone);
            return this;
        }
        /// <summary>
        /// Create an action node which is Special attack type.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="AI">The ai.</param>
        /// <param name="NAI">The nai.</param>
        /// <returns>MyTreeBuilder</returns>
        /// <exception cref="System.ApplicationException">Can't create an unnested ActionNode, it must be a leaf node.</exception>
        public MyTreeBuilder Special(GameWorld context, AIFighter AI, NonAIFighter NAI)
        {
            if (parentNodeStack.Count <= 0)
            {
                throw new ApplicationException("Can't create an unnested ActionNode, it must be a leaf node.");
            }

            Func<MyTimeData, MyBehaviourTreeStatus> fr;
            fr = t =>
            {
                // A Special move
                Special special = new Special();

                GameWorld gw = context;
                gw.wAttack(AI, NAI, special);

                gw.ListOfEvents.Add("Special non AI player");
                return MyBehaviourTreeStatus.Success;
            };

            var actionNone = new ActionNode("Special", fr);
            parentNodeStack.Peek().AddChild(actionNone);
            return this;
        }
        //+++++++++++++++++++++++++++++++++END++++++++++++++++++++++++++++++

        /// <summary>
        /// Like an action node... but the function can return true/false and is mapped to success/failure.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="fn">The function.</param>
        /// <returns>MyTreeBuilder</returns>
        public MyTreeBuilder Condition(string name, Func<MyTimeData, bool> fn)
        {
            return Do(name, t => fn(t) ? MyBehaviourTreeStatus.Success : MyBehaviourTreeStatus.Failure);
        }

        /// <summary>
        /// Create an inverter node that inverts the success/failure of its children.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public MyTreeBuilder Inverter(string name)
        {
            var inverterNode = new InverterNode(name);

            if (parentNodeStack.Count > 0)
            {
                parentNodeStack.Peek().AddChild(inverterNode);
            }

            parentNodeStack.Push(inverterNode);
            return this;
        }

        /// <summary>
        /// Create a sequence node.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>MyTreeBuilder</returns>
        public MyTreeBuilder Sequence(string name)
        {
            var sequenceNode = new SequenceNode(name);

            if (parentNodeStack.Count > 0)
            {
                parentNodeStack.Peek().AddChild(sequenceNode);
            }

            parentNodeStack.Push(sequenceNode);
            return this;
        }

        /// <summary>
        /// Create a parallel node.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="numRequiredToFail">The number required to fail.</param>
        /// <param name="numRequiredToSucceed">The number required to succeed.</param>
        /// <returns>MyTreeBuilder</returns>
        public MyTreeBuilder Parallel(string name, int numRequiredToFail, int numRequiredToSucceed)
        {
            var parallelNode = new ParallelNode(name, numRequiredToFail, numRequiredToSucceed);

            if (parentNodeStack.Count > 0)
            {
                parentNodeStack.Peek().AddChild(parallelNode);
            }

            parentNodeStack.Push(parallelNode);
            return this;
        }

        /// <summary>
        /// Create a selector node.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>MyTreeBuilder</returns>
        public MyTreeBuilder Selector(string name)
        {
            var selectorNode = new SelectorNode(name);

            if (parentNodeStack.Count > 0)
            {
                parentNodeStack.Peek().AddChild(selectorNode);
            }

            parentNodeStack.Push(selectorNode);
            return this;
        }

        /// <summary>
        /// Splice a sub tree into the parent tree.
        /// </summary>
        /// <param name="subTree">The sub tree.</param>
        /// <returns>MyTreeBuilder</returns>
        /// <exception cref="System.ArgumentNullException">subTree</exception>
        /// <exception cref="System.ApplicationException">Can't splice an unnested sub-tree, there must be a parent-tree.</exception>
        public MyTreeBuilder Splice(IMyBehaviourTreeNode subTree)
        {
            if (subTree == null)
            {
                throw new ArgumentNullException("subTree");
            }

            if (parentNodeStack.Count <= 0)
            {
                throw new ApplicationException("Can't splice an unnested sub-tree, there must be a parent-tree.");
            }

            parentNodeStack.Peek().AddChild(subTree);
            return this;
        }

        /// <summary>
        /// Build the actual tree.
        /// </summary>
        /// <returns>MyTreeBuilder</returns>
        /// <exception cref="System.ApplicationException">Can't create a behaviour tree with zero nodes</exception>
        public IMyBehaviourTreeNode Build()
        {
            if (curNode == null)
            {
                throw new ApplicationException("Can't create a behaviour tree with zero nodes");
            }
            return curNode;
        }

        /// <summary>
        /// Ends a sequence of children.
        /// </summary>
        /// <returns>MyTreeBuilder</returns>
        public MyTreeBuilder End()
        {
            curNode = parentNodeStack.Pop();
            return this;
        }
    }
}