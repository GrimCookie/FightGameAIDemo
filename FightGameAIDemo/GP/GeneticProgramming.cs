using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using FluentBehaviourTree;
using FightGameAIDemo;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;

namespace FightGameAIDemo.GP
{


    /// <summary>
    /// Genetic programming Class.
    /// created by Steven Mcvey
    /// </summary>
    public class GeneticProgramming
    {
        //setting from the fight game 
        /// <summary>
        /// The crouched
        /// </summary>
        private bool crouched;
        /// <summary>
        /// The close
        /// </summary>
        private bool close;
        /// <summary>
        /// The medium
        /// </summary>
        private bool medium;
        /// <summary>
        /// The far
        /// </summary>
        private bool far;

        /// <summary>
        /// the Game World
        /// </summary>
        GameWorld gw;
        /// <summary>
        /// The AI
        /// </summary>
        AIFighter AI;
        /// <summary>
        /// The non-AI
        /// </summary>
        NonAIFighter NAI;

        //holds the tree created by the parser to be passed for the tick function
        /// <summary>
        /// The interpreted tree
        /// </summary>
        public IMyBehaviourTreeNode interp_tree;
        /// <summary>
        /// The interpreted tree builder
        /// </summary>
        public MyTreeBuilder interp_tree_builder;

        /// <summary>
        /// The generation counter
        /// </summary>
        int GenCounter = 0;
        /// <summary>
        /// The tree counter
        /// </summary>
        int treeCounter = 0;

        /// <summary>
        /// The tree depth
        /// </summary>
        int Tree_Depth;

        //max depth after the root node
        /// <summary>
        /// The max depth allowed for the tree being generated
        /// </summary>
        int Max_Depth = 2;

        //the program grown from the grow function
        /// <summary>
        /// The grow prog list to tempererly hold the tree while it grows
        /// </summary>
        List<byte> grow_prog = new List<byte>();

        //array copy of list above
        /// <summary>
        /// The grown program once it has grown collected from grow_prog
        /// </summary>
        byte[] grown_program;

        //number of individuals in a generation
        /// <summary>
        /// The population size
        /// </summary>
        int population_Size = 10;
        //number of generations
        /// <summary>
        /// The generation size
        /// </summary>
        int generation_Size = 10;

        //list of individuals for crossover into the next Generation
        /// <summary>
        /// The mating pool to be used in generating next generation of trees
        /// </summary>
        List<Indevidual> mating_pool;

        /// <summary>
        /// The program
        /// </summary>
        byte[] Program;
        //program Counter
        /// <summary>
        /// </summary>
        int PC;

        //number of other indeviduals to evaluate against during torniment
        /// <summary>
        /// The torniment size
        /// </summary>
        int torniment_size = 2;

        /// <summary>
        /// The generation list of indeviduals
        /// </summary>
        List<Indevidual> generation;

        //set up root node for interperter
        /// <summary>
        /// The root node
        /// </summary>
        const byte Root_Node = 1;

        //set of terminal nodes (Leaf nodes)
        /// <summary>
        /// The punch node byte
        /// </summary>
        const byte Punch = 2,
                    Kick = 3,
                    Special = 4;

        //stores the begining and end of the terminal node set
        /// <summary>
        /// The terminal set  start
        /// </summary>
        byte Terminal_set_Start = Punch;
        /// <summary>
        /// The terminal set  end
        /// </summary>
        byte Terminal_set_End = Special;

        //set of Functional nodes (option nodes)
        /// <summary>
        /// The is crouched node byte
        /// </summary>
        const byte isCrouched = 5,
                    isClose = 6,
                    isMedium = 7,
                    isFar = 8,
                    End = 9;

        //stores the begining and end of the functional node set
        /// <summary>
        /// The functional set start
        /// </summary>
        byte Functional_set_Start = isCrouched;
        /// <summary>
        /// The functional set end
        /// </summary>
        byte Functional_set_End = isFar;

        /// <summary>
        /// Sets a value indicating whether the distance of this <see cref="NonAIFighter"/> is crouched.
        /// </summary>
        /// <value>
        ///   <c>true</c> if crouched; otherwise, <c>false</c>.
        /// </value>
        public bool Crouched { set { crouched = value; } }
        /// <summary>
        /// Sets a value indicating whether the distance of this <see cref="NonAIFighter"/> is close.
        /// </summary>
        /// <value>
        ///   <c>true</c> if close; otherwise, <c>false</c>.
        /// </value>
        public bool Close { set { close = value; } }
        /// <summary>
        /// Sets a value indicating whether the distance of this <see cref="NonAIFighter"/> is medium.
        /// </summary>
        /// <value>
        ///   <c>true</c> if medium; otherwise, <c>false</c>.
        /// </value>
        public bool Medium { set { medium = value; } }
        /// <summary>
        /// Sets a value indicating whether the distance of this <see cref="NonAIFighter"/> is far.
        /// </summary>
        /// <value>
        ///   <c>true</c> if far; otherwise, <c>false</c>.
        /// </value>
        public bool Far { set { far = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneticProgramming"/> class.
        /// </summary>
        public GeneticProgramming()
        {
            generation = new List<Indevidual>();
            mating_pool = new List<Indevidual>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneticProgramming"/> class.
        /// </summary>
        /// <param name="gw">The gw.</param>
        /// <param name="AI">The ai.</param>
        /// <param name="NAI">The nai.</param>
        /// <param name="torniment_Size">Size of the torniment_.</param>
        /// <param name="pop_size">The pop_size.</param>
        public GeneticProgramming(GameWorld gw, AIFighter AI, NonAIFighter NAI, int torniment_Size, int pop_size)
        {
            generation = new List<Indevidual>();
            mating_pool = new List<Indevidual>();

            this.gw = gw;
            this.AI = AI;
            this.NAI = NAI;

            Torniment_size = torniment_Size;
            Population_size = pop_size;

        }

        /// <summary>
        /// Gets or sets the population_size.
        /// </summary>
        /// <value>
        /// The population_size.
        /// </value>
        public int Population_size
        {
            get { return population_Size; }
            set { population_Size = value; }
        }
        /// <summary>
        /// Gets or sets the torniment_size.
        /// </summary>
        /// <value>
        /// The torniment_size.
        /// </value>
        public int Torniment_size
        {
            get { return torniment_size; }
            set { torniment_size = value; }
        }

        /// <summary>
        /// Gets or sets the grown program.
        /// </summary>
        /// <value>
        /// The grown program.
        /// </value>
        public byte[] GrownProgram
        {
            get { return grown_program; }
            set { grown_program = value; }
        }
        /// <summary>
        /// Gets or sets the generation.
        /// </summary>
        /// <value>
        /// The generation.
        /// </value>
        public List<Indevidual> Generation
        {
            get { return generation; }
            set { generation = value; }
        }

        /// <summary>
        /// Parsers the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        public void parser(byte[] input)
        {
            //this is a parser that creates the tree by reading the 
            //byte array that is passed in as aperamiter
            var builder = new MyTreeBuilder(crouched, close, medium, far);
            IMyBehaviourTreeNode botTree;

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case Root_Node:
                        builder.Sequence("Root-Sequence-Node");
                        break;
                    case Punch:
                        builder.Punch(gw, AI, NAI);
                        break;
                    case Kick:
                        builder.Kick(gw, AI, NAI);
                        break;
                    case Special:
                        builder.Special(gw, AI, NAI);
                        break;

                    case isCrouched:
                        builder.Condition
                            ("is_Opponent_Crouched",
                            t =>
                            {
                                if (builder.Crouched == true)
                                { return true; }
                                return false;
                            });
                        builder.Selector("If_Crouched");
                        break;

                    case isClose:
                        builder.Condition
                             ("is_Opponent_Close",
                             t =>
                             {
                                 if (builder.Close == true)
                                 { return true; }
                                 return false;
                             });
                        builder.Selector("If_Close");
                        break;

                    case isMedium:
                        builder.Condition
                            ("is_Opponent_Medium",
                            t =>
                            {
                                if (builder.Medium == true)
                                { return true; }
                                return false;
                            });
                        builder.Selector("If_Medium");
                        break;

                    case isFar:
                        builder.Condition
                            ("is_Opponent_Far",
                            t =>
                            {
                                if (builder.Far == true)
                                { return true; }
                                return false;
                            });
                        builder.Selector("If_Far");
                        break;

                    case End:
                        builder.End().Build();
                        break;
                }
            }

            //will have gotten nodes from parser so should build
            botTree = builder.Build();

            interp_tree_builder = builder;

            interp_tree = botTree;
        }
        /// <summary>
        /// Gets the interp tree.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public IMyBehaviourTreeNode GetInterpTree(byte[] input)
        {
            parser(input);
            return interp_tree;
        }

        /// <summary>
        /// Grows this instance.
        /// </summary>
        public void Grow()
        {
            //clear the list of its elements and array
            grow_prog.Clear();
            GrownProgram = null;

            //set program tree depth to 0 to count up till max depth is reached
            Tree_Depth = 0;
            // add root node to program list for later conversion to array
            grow_prog.Add(Root_Node);
            //deepen tree
            Tree_Depth++;

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            //generate number of nodes to build
            int num = rnd.Next(1, 5);

            for (int i = 0; i != num; i++)
            {
                if (Tree_Depth > 0 && Tree_Depth < Max_Depth)
                {
                    rnd = new Random(Guid.NewGuid().GetHashCode());

                    int node = rnd.Next(Terminal_set_Start, Functional_set_End + 1);

                    if (node >= Functional_set_Start && node <= Functional_set_End)
                    {
                        grow_prog.Add((byte)node);
                        int sub_depth = Tree_Depth;
                        Gen_SubTree(sub_depth, Max_Depth);
                        grow_prog.Add(End);
                    }
                    else if (node >= Terminal_set_Start && node <= Terminal_set_End)
                    {
                        grow_prog.Add((byte)node);
                    }
                }
            }
            // add End node for the root to program list for 
            // later conversion to array
            grow_prog.Add(End);

            //Convert the program list to an array
            grown_program = grow_prog.ToArray();

            gw.ListEventsAlgorithm.Add(":: Program Grown :: ");
            gw.ListEventsAlgorithm.Add(Draw_tree(grown_program));

        }
        /// <summary>
        /// Generates the sub tree.
        /// </summary>
        /// <param name="Tree_Depth">The tree_ depth.</param>
        /// <param name="Max_Depth">The max_ depth.</param>
        public void Gen_SubTree(int Tree_Depth, int Max_Depth)
        {
            //seed randome generator with new Global unique Identifier
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            //generate which node it is
            //between range of all possible nodes (2 - 9)(upper bound is excluded)
            int node = rnd.Next(Terminal_set_Start, Functional_set_End + 1);

            //gen number of sub nodes
            int num = rnd.Next(1, 5);

            //generate for the number
            for (int i = 0; i != num; i++)
            {
                //if the next level is to be the last in the tree
                //make only Terminal nodes
                if (Tree_Depth == Max_Depth - 1)
                {
                    //add to branch depth
                    Tree_Depth++;
                    //generate the terminal node
                    node = rnd.Next(Terminal_set_Start, Terminal_set_End + 1);
                    //add node to grow_program list for later array conversion
                    grow_prog.Add((byte)node);
                }
                else
                {
                    if (node >= Functional_set_Start && node <= Functional_set_End)
                    {
                        //add to branch depth
                        Tree_Depth++;
                        //add node to grow_program list for later array conversion
                        grow_prog.Add((byte)node);
                        //if the randomely generated node is a Functional node
                        //recursivly run sub tree generator function
                        Gen_SubTree(Tree_Depth, Max_Depth);
                        //add to grow_program list for later array conversion
                        grow_prog.Add(End);
                    }
                    else
                    {
                        rnd = new Random(Guid.NewGuid().GetHashCode());
                        //add node to grow_program list for later array conversion
                        grow_prog.Add((byte)node);
                    }
                }

            }
        }
        /// <summary>
        /// Setups this instance.
        /// </summary>
        public void setup()
        {
            //add to generation counter
            GenCounter++;

            gw.ListEventsAlgorithm.Add("::Genetic programming SETUP::");
            gw.ListEventsAlgorithm.Add("::Generation: "+GenCounter+" ::");

            //generate a generation of specified size
            for (int i = 0; i != population_Size; i++)
            {

                Indevidual ind = new Indevidual();
                gw.ListEventsAlgorithm.Add(":: New Indevidual created for Generation ::");

                Grow();
                
                ind.TreeNo = i + 1;
                ind.Program = GrownProgram;
                ind.Tree = GetInterpTree(ind.Program);
                ind.TreeString = Draw_tree(ind.Program);

                gw.ListEventsAlgorithm.Add(":: indevidual " + treeCounter + " added to Generation ::");

                //ind.Fitness = ;
                //will have to guage trees fitness

                treeCounter++;

                //add tree to inital generation
                Generation.Add(ind);
            }
        }
        /// <summary>
        /// Selection_torniments the specified torniment_size.
        /// </summary>
        /// <param name="torniment_size">The torniment_size.</param>
        /// <returns></returns>
        public Indevidual selection_torniment(int torniment_size)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Indevidual best = null;

            //choose and indevidual at randome 
            Indevidual first = Generation[rnd.Next(0, population_Size)];

            //uses tornimnt size to search x number of indeviduals 
            //increases selection pressure (higher pressure fitter indeviduals)
            //equivalent to copetitive challange
            for (int i = 0; i < torniment_size; i++)
            {
                //choose second randome indevidual to compare with
                Indevidual second = Generation[rnd.Next(0, population_Size)];

                //if the first indevidual is fitter than the second 
                //then return the first
                if (first.Fitness > second.Fitness)
                {
                    best = first;
                }
                else
                {
                    //else return the second
                    best = second;
                }
            }

            gw.ListEventsAlgorithm.Add(":: Indevidual: "+best+" chosen through Torniment selection ::");

            //return best Indevidual
            return best;
        }

        /// <summary>
        /// Mutation using bit flit the specified program.
        /// </summary>
        /// <param name="Program">The program.</param>
        /// <returns></returns>
        public byte[] mutation_bit_flip(byte[] Program)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            //hold program to mutate
            byte[] program = Program, origional = Program;

            //mutate program by changing the type of node
            //based on the node selected (Terminal change to different terminal)
            //leaf changed to different leaf
            int node_index = rnd.Next(1, program.Length - 1);
            int node_value = program[node_index];

            //if the value at the slected node index is a 9 (End node)
            // generate a new number untill it isn't 9
            for (int k = 0; program[node_index] == End; k++)
            {
                node_index = rnd.Next(1, program.Length - 1);
            }

            //set the new node as 0
            int newNode = 0;

            rnd = new Random(Guid.NewGuid().GetHashCode());

            if (node_value >= Functional_set_Start && node_value <= Functional_set_End)
            {
                // generate the node in rage of finctional node set 
                // (uses end + 1 as .next() exluds upper bound from the generation
                // this would result in last node of functional set never getting made)
                newNode = rnd.Next(Functional_set_Start, Functional_set_End + 1);
                Program[node_index] = (byte)newNode;
                //return rnd.Next(5,9);
            }
            else if (node_value >= Terminal_set_Start && node_value <= Terminal_set_End)
            {
                newNode = rnd.Next(Terminal_set_Start, Terminal_set_End + 1);
                program[node_index] = (byte)newNode;
                //return rnd.Next(2, 5);
            }
            if (node_value == 9)
            {
                //Ilegal action to change an end node(9)
            }

            //add events to list
            gw.ListEventsAlgorithm.Add(":: Mutation ::");
            gw.ListEventsAlgorithm.Add(Draw_tree(origional));
            gw.ListEventsAlgorithm.Add(" mutated with Bit flip into: ");
            gw.ListEventsAlgorithm.Add(Draw_tree(program));

            //return program
            return program;

        }
        /// <summary>
        /// Crossover_subtrees the specified parent1.
        /// </summary>
        /// <param name="parent1">The parent1.</param>
        /// <param name="parent2">The parent2.</param>
        /// <returns>byte[] offspring</returns>
        public byte[] crossover_subtree(Indevidual parent1, Indevidual parent2)
        {
            //brings back length of list but take one away to access last element
            //(indexed from 0)
            int xoPoint1 = parent1.Program.Length - 1,
                //xoPoint1End,
                xoPoint2 = parent2.Program.Length - 1;
            //xoPoint2End;
            //byte[] 
            //parent1start = new byte[], 
            //subtree1 = null, 
            //parent1end = null, 
            //parent2start = null, 
            //subtree2 = null;
            //parent2end = null;
            List<byte>
                parent1start = new List<byte>(),
                subtree1 = new List<byte>(),
                parent1end = new List<byte>(),
                parent2start = new List<byte>(),
                subtree2 = new List<byte>(),
                parent2end = new List<byte>();

            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            //first random point is index of tree parent 1
            //keep generating untill its not an end node
            for (int k = 0; parent1.Program[xoPoint1] == End; k++)
            {
                xoPoint1 = rnd.Next(1, parent1.Program.Length - 1);
            }
            //second random point is index of tree parent 2
            //keep generating untill its not an end node
            for (int j = 0; parent2.Program[xoPoint2] == End; j++)
            {
                xoPoint2 = rnd.Next(1, parent2.Program.Length - 1);
            }

            //get first section of parent tree 1
            //add it to first section array
            for (int i = 0; i != xoPoint1; i++)
            {
                parent1start.Add(parent1.Program[i]);
            }

            //collect the sub tree or node from parent 1
            subtree1 = sub_tree_or_node_selection(parent1, xoPoint1, rnd, subtree1);
            //collect the sub tree or node from parent 2
            subtree2 = sub_tree_or_node_selection(parent2, xoPoint2, rnd, subtree2);

            //get the last section from parent tree 1
            //for offspring
            int point = (parent1start.Count + subtree1.Count);

            for (int i = point; i < parent1.Program.Length; i++)
            {
                parent1end.Add(parent1.Program[i]);
                //+1? to points
            }

            //create child of the right size
            byte[] child = new byte[parent1start.Count + subtree2.Count + parent1end.Count];

            parent1start.CopyTo(child, 0);
            subtree2.CopyTo(child, parent1start.Count);
            parent1end.CopyTo(child, parent1start.Count + subtree2.Count);

            //add events to list
            gw.ListEventsAlgorithm.Add(":: Crossover Sub Tree / Node ::");
            gw.ListEventsAlgorithm.Add(":: parent1: " + Draw_tree(parent1.Program) + " ::");
            gw.ListEventsAlgorithm.Add(":: Mutation " + Draw_tree(parent2.Program) + " ::");
            gw.ListEventsAlgorithm.Add(":: offspring: "+Draw_tree(child)+" ::");

            return child;

        }

        /// <summary>
        /// Sub_tree_or_node_selection from the specified parent.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="xoPoint">The xo point.</param>
        /// <param name="rnd">The random.</param>
        /// <param name="subtree">The subtree.</param>
        /// <returns></returns>
        public List<byte> sub_tree_or_node_selection(Indevidual parent, int xoPoint, Random rnd, List<byte> subtree)
        {


            //if the vale at that index is a functional node
            //then go about tracing the sub tree
            if (parent.Program[xoPoint] >= Functional_set_Start && parent.Program[xoPoint] <= Functional_set_End)
            {
                //lengh of the sub tree found
                int len = 1;

                subtree.Add((byte)parent.Program[xoPoint]);
                xoPoint++;

                for (int i = 0; len != 0; i++)
                {



                    //if the node is a functional node then trase the sub tree
                    if (parent.Program[xoPoint] >= Functional_set_Start && parent.Program[xoPoint] <= Functional_set_End)
                    {
                        subtree.Add((byte)parent.Program[xoPoint]);
                        len++;  //increase the length
                    }
                    else if (parent.Program[xoPoint] >= Terminal_set_Start && parent.Program[xoPoint] <= Terminal_set_End)
                    {
                        subtree.Add((byte)parent.Program[xoPoint]);
                    }
                    else if (parent.Program[xoPoint] == End)
                    {
                        subtree.Add((byte)parent.Program[xoPoint]);
                        len--;  //decrease the length
                    }


                    //add byte to sub tree1 array
                    //subtree.Add((byte)parent.Program[xoPoint]);
                    xoPoint++;
                }
            }
            else if (parent.Program[xoPoint] >= Terminal_set_Start && parent.Program[xoPoint] <= Terminal_set_End)
            {
                //if the node is a terminal node (leaf node) just add 
                //it to the array
                subtree.Add(parent.Program[xoPoint]);
            }

            //return what has been selected
            return subtree;
        }

        /// <summary>
        /// Tree_traverses the specified parent.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="start_point">The start_point.</param>
        /// <returns></returns>
        public int tree_traverse(Indevidual parent, int start_point)
        {
            //holds the trees legth from point given
            int counter = 1;
            int len = 1;

            for (int i = 0; len != 0; i++)
            {
                //add byte to sub tree1 array
                //subtree[i] = (byte)parent.Program[buffer];
                counter++;
                start_point++;

                if (parent.Program[start_point] < Terminal_set_Start && parent.Program[start_point] > Terminal_set_End)
                {
                    //if the node is a functional node then trase the sub tree
                    if (parent.Program[start_point] >= Functional_set_Start && parent.Program[start_point] <= Functional_set_End)
                    {
                        
                        len++;  //increase the length
                    }
                    else if (parent.Program[start_point] == End)
                    {
                        
                        len--;  //decrease the length
                    }
                }
                //if the node is a terminal node it will be 
                //counted on the next loop round
            }
            return counter;
        }
        /// <summary>
        /// Evolves the mating pool of this instance.
        /// </summary>
        public void evolve()
        {
            Indevidual parent1, parent2, childInd;

            gw.ListEventsAlgorithm.Add(":: Evolve ::");

            for (int i = 0; i != population_Size; i++)
            {
                treeCounter++;

                //take from the current generation using torniment
                parent1 = selection_torniment(torniment_size);
                parent2 = selection_torniment(torniment_size);

                //based on the mutation rate
                //crossover
                byte[] child = crossover_subtree(parent1, parent2);
                //mutation
                child = mutation_bit_flip(child);

                //create new indevidual for the mating pool
                childInd = new Indevidual();
                childInd.TreeNo = treeCounter;
                //childInd.Fitness
                childInd.Program = child;
                childInd.Tree = GetInterpTree(childInd.Program);
                childInd.TreeString = Draw_tree(childInd.Program);
                //add to the maiting pool
                mating_pool.Add(childInd);
                //crossover thouse in the mating pool and read to
                //generation for more evaluation
            }
            //add to the generation conter
            GenCounter++;
            //create a new list to copy the next generation into
            Generation = new List<Indevidual>(mating_pool);
            //clear mating pool
            mating_pool.Clear();
        }
        /// <summary>
        /// Fitness functions gives a tree its fitness rating.
        /// </summary>
        /// <param name="total_Damage">The total_ damage.</param>
        /// <param name="indevidual">The indevidual.</param>
        public void fitness_function(int total_Damage,Indevidual indevidual)
        {
            //here the fitness of an indevidual will be set
            // as the game intends to evaluate the AI's tree based on performace
            // this method will be used to update the fitnesses of the trees
            //in the list rather than evaluate them here directly
            int fitness = (total_Damage/indevidual.Program.Length);

            indevidual.Fitness = fitness;


            gw.ListEventsAlgorithm.Add(" ::Fitness calculated:: ");
            gw.ListEventsAlgorithm.Add(indevidual.ToString());

        }
        /// <summary>
        /// Draw_trees the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>String treeString</returns>
        public String Draw_tree(byte[] input)
        {
            //here the tree is parsed to a readable string format
            String treeString = "";

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case Root_Node:
                        treeString = "RootNode( ";
                        break;
                    case Punch:
                        treeString += "<Punch>";
                        break;
                    case Kick:
                        treeString += "<Kick>";
                        break;
                    case Special:
                        treeString += "<Special>";
                        break;

                    case isCrouched:
                        treeString += "ifCrouched( ";
                        break;
                    case isClose:
                        treeString += "ifClose( ";
                        break;
                    case isMedium:
                        treeString += "ifMedium( ";
                        break;
                    case isFar:
                        treeString += "ifFar( ";
                        break;

                    case End:
                        treeString += " )";
                        break;
                }
                
            }
            return treeString;
        }

    }
}
