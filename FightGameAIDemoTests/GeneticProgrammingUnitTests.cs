using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FightGameAIDemo;
using FluentBehaviourTree;
using FightGameAIDemo.GP;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;

namespace FightGameAIDemoTests
{
    /// <summary>
    /// Summary description for GeneticProgrammingUnitTests
    /// </summary>
    [TestClass]
    public class GeneticProgrammingUnitTests
    {
        public GeneticProgrammingUnitTests()
        {
            //
            // TODO: Add constructor logic here
            //
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void InterpreterTest()
        {
            //
            // TODO: Add test logic here
            //
            byte[] program = { 1, 2, 9};
           // byte[] program = { 1,8,8,5,2,9,5,6,6,4,4,4,9,9,6,5,8,3,3,3,9,8,3,9,9,5,6,6,4,9,9,9,5,3,9,9,9,5,4,9,9,9,8,8,2,2,9,9,3,9 };

            GeneticProgramming gp = new GeneticProgramming();

            String Expected = "RootNode( <Punch> ) )";

            IMyBehaviourTreeNode test_tree = gp.GetInterpTree(program);

            MyTreeBuilder test = gp.interp_tree_builder;

            String[] list;
            Stack<IMyParentBehaviourTreeNode> nodes = new Stack<IMyParentBehaviourTreeNode>();
            //String Actual = test_tree.ToString();
            foreach(IMyParentBehaviourTreeNode i in test.parentNodeStack)
            {
                nodes.Push(i);
            }
            Stack<IMyParentBehaviourTreeNode> Actual = nodes;

            Assert.AreEqual(Expected, Actual, " Error incorrect result");
        }

        [TestMethod]
        public void Test()
        {
            
            GeneticProgramming gp = new GeneticProgramming();
            IMyBehaviourTreeNode test_tree;

            String Expected = "Test";

            gp.Grow();
            byte[]program = gp.GrownProgram;



            //MyTreeBuilder test = gp.interp_tree_builder;
            String Actual="";

            for(int i =0;i!=program.Length;i++)
            {
                Actual += program[i].ToString()+", ";
            }

            Assert.AreEqual(Expected, Actual, " Error incorrect result");
        }
    }
}
