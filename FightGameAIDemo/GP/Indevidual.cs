using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;

namespace FightGameAIDemo.GP
{
    /// <summary>
    /// Indevidual hold AI tree information
    /// </summary>
    public class Indevidual
    {
        /// <summary>
        /// The tree number
        /// </summary>
        private int treeNo;
        /// <summary>
        /// The program
        /// </summary>
        private byte[] program;
        /// <summary>
        /// The tree
        /// </summary>
        private IMyBehaviourTreeNode tree;
        /// <summary>
        /// The fitness
        /// </summary>
        private float fitness;
        /// <summary>
        /// The tree string
        /// </summary>
        private String treeString;

        /// <summary>
        /// Initializes a new instance of the <see cref="Indevidual"/> class.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="program">The program.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fitness">The fitness.</param>
        public Indevidual(int number,byte[] program, IMyBehaviourTreeNode tree, float fitness)
        {
            treeNo = number;
            Program = program;
            Tree = tree;
            Fitness = fitness;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Indevidual"/> class.
        /// </summary>
        public Indevidual()
        {
            
        }

        /// <summary>
        /// Gets or sets the tree number.
        /// </summary>
        /// <value>
        /// The tree number.
        /// </value>
        public int TreeNo
        {
            get {return treeNo;}
            set { treeNo = value; }
        }
        /// <summary>
        /// Gets or sets the program.
        /// </summary>
        /// <value>
        /// The program.
        /// </value>
        public byte[] Program
        {
            get { return program; }
            set { program = value; }
        }
        /// <summary>
        /// Gets or sets the tree.
        /// </summary>
        /// <value>
        /// The tree.
        /// </value>
        public IMyBehaviourTreeNode Tree
        {
            get { return tree; }
            set { tree = value; }
        }
        /// <summary>
        /// Gets or sets the fitness.
        /// </summary>
        /// <value>
        /// The fitness.
        /// </value>
        public float Fitness
        {
            get { return fitness; }
            set { fitness = value; }
        }
        /// <summary>
        /// Gets or sets the tree string.
        /// </summary>
        /// <value>
        /// The tree string.
        /// </value>
        public String TreeString
        {
            get { return treeString; }
            set { treeString = value; }
        }
        /// <summary>
        /// Print_programs this instance.
        /// </summary>
        /// <returns>String prog</returns>
        public String print_program()
        {
            String prog = "";
            for (int i = 0; i < program.Length; i++ )
            {
                prog += program[i].ToString();
            }
                return prog;
        }
        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public String ToString()
        {
            String prog = print_program();

            return  "Tree No: " + treeNo +
                    ", Program byte's: " + prog + 
                    ", Tree Fitness: " + fitness + 
                    ", Tree: " + treeString;
        }
    }
}
