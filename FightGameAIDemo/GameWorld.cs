using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FightGameAIDemo.GP;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;

namespace FightGameAIDemo
{
    /// <summary>
    /// Game world Class
    /// </summary>
    /// <seealso cref="FightGameAIDemo.IGameWorld" />
    public class GameWorld : IGameWorld
    {
        /// <summary>
        /// The total_ damage
        /// </summary>
        int total_Damage;

        /// <summary>
        /// The crouched position setting
        /// </summary>
        private bool crouched;
        /// <summary>
        /// The close distance setting
        /// </summary>
        private bool close;
        /// <summary>
        /// The medium distance setting
        /// </summary>
        private bool medium;
        /// <summary>
        /// The far distance setting
        /// </summary>
        private bool far;

        /// <summary>
        /// The population_size
        /// </summary>
        public int population_size;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GameWorld"/> is crouched.
        /// </summary>
        /// <value>
        ///   <c>true</c> if crouched; otherwise, <c>false</c>.
        /// </value>
        public bool Crouched { set { crouched = value; } get { return crouched; } }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GameWorld"/> is close.
        /// </summary>
        /// <value>
        ///   <c>true</c> if close; otherwise, <c>false</c>.
        /// </value>
        public bool Close { set { close = value; } get { return close; } }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GameWorld"/> is medium.
        /// </summary>
        /// <value>
        ///   <c>true</c> if medium; otherwise, <c>false</c>.
        /// </value>
        public bool Medium { set { medium = value; } get { return medium; } }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GameWorld"/> is far.
        /// </summary>
        /// <value>
        ///   <c>true</c> if far; otherwise, <c>false</c>.
        /// </value>
        public bool Far { set { far = value; } get { return far; } }

        /// <summary>
        /// </summary>
        GeneticProgramming gp;

        //counter incramented to move to next tree
        /// <summary>
        /// The tree counter
        /// </summary>
        int treeCounter;

        //updated in next round
        /// <summary>
        /// The fighter counter
        /// </summary>
        int fighterCounter;

        //holds tree fitness
        /// <summary>
        /// The fitness
        /// </summary>
        float fitness = 0.0f;

        /// <summary>
        /// The round number
        /// </summary>
        int roundNum = 0;

        /// <summary>
        /// the loop counter to prevent infinet loop during fight
        /// </summary>
        int lc = 0;

        /// <summary>
        /// The list of events for the fight
        /// </summary>
        List<String> listOfEvents = new List<String>();
        /// <summary>
        /// The of list events for algorithm
        /// </summary>
        List<String> listEventsAlgorithm = new List<string>();
        //listEventsAlgorithm.Add("TBA...");

        /// <summary>
        /// The no ai fighter
        /// </summary>
        public NonAIFighter NoAiFighter;

        /// <summary>
        /// The ai fighter
        /// </summary>
        public AIFighter AiFighter;

        //distance between opponenet and AI
        /// <summary>
        /// The distance between fighters
        /// </summary>
        private string distance;

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public string Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        /// <summary>
        /// Gets or sets the list of events.
        /// </summary>
        /// <value>
        /// The list of events.
        /// </value>
        public List<String> ListOfEvents
        {
            get { return listOfEvents; }
            set { listOfEvents = value; }
        }
        /// <summary>
        /// Gets or sets the list events algorithm.
        /// </summary>
        /// <value>
        /// The list events algorithm.
        /// </value>
        public List<String> ListEventsAlgorithm
        {
            get { return listEventsAlgorithm; }
            set { listEventsAlgorithm = value; }
        }
        /// <summary>
        /// Gets or sets the population_size.
        /// </summary>
        /// <value>
        /// The population_size.
        /// </value>
        public int Population_size
        {
            get { return population_size; }
            set { population_size = value; }
        }

        /// <summary>
        /// Set up fighters for fight.
        /// </summary>
        /// <param name="isBlocking">if set to <c>true</c> [is blocking].</param>
        /// <param name="isCrouched">if set to <c>true</c> [is crouched].</param>
        /// <param name="torn_size"></param>
        /// <param name="pop_size"></param>
        public void SetUp(bool isBlocking, bool isCrouched, int torn_size, int pop_size) 
        {
            //reset the counters
            treeCounter = 0;
            fighterCounter = 0;
            roundNum = 0;

            ListEventsAlgorithm.Clear();
            ListOfEvents.Clear();

            listOfEvents.Add(":: SET-UP FIGHTERS ::");

            roundNum++;

            listOfEvents.Add("Round NO: " + roundNum);

            //CREATE new NON_AI_FIGHTER
            NoAiFighter = new NonAIFighter(roundNum, isBlocking, isCrouched);

            //set relevent values for NON_AI_FIGHTER
            //NoAiFighter.Blocking = isBlocking;
            //NoAiFighter.Crouching = isCrouched;
            //add new fighter o event list
            listOfEvents.Add(NoAiFighter.ToString());

            //CREATE new AI_FIGHTER
            AiFighter = new AIFighter(roundNum);

             //create a new connection to Genetic programming class
            gp = new GeneticProgramming(this, AiFighter, NoAiFighter,torn_size,pop_size);

            gp.Crouched = Crouched;
            gp.Close = Close;
            gp.Medium = Medium;
            gp.Far = Far;

            //set up the Genetic programming class
            gp.setup();

            //set tree to first in generation list
            treeCounter = 0;
            AiFighter.Tree = gp.Generation[treeCounter];

            //add AI fighter to list
            listOfEvents.Add(AiFighter.ToString());
        }
        /// <summary>
        /// Move onto the nexts round.
        /// </summary>
        public void nextRound()
        {
            //add to the number of the AI fighters
            fighterCounter += 1;
            AiFighter.Number = fighterCounter;
            NoAiFighter.Number = fighterCounter;
            

            //reset both fighter for next round
            AiFighter.Health = 100;
            NoAiFighter.Health = 100;
            //update round information
            roundNum++;
            treeCounter++;

            if (treeCounter == population_size) { treeCounter = 1; }
            //10
            //handle selection of next Behaiour tree for AI player
            AiFighter.Tree = gp.Generation[treeCounter-1];
            //

            //add non ai fighter to next round in list
            listOfEvents.Add(NoAiFighter.ToString());
            //add AI fighter to list
            listOfEvents.Add(AiFighter.ToString());
            //listOfEvents.Add(":: ROUND "+roundNum+" FIGHT ::");
        }
        //********************************FIGHT***************************************
        /// <summary>
        /// Runs the fight.
        /// </summary>
        public void RunFight()
        {
            //here one round will occure (both will fight till one reaches 0 health)

            //set up is handled in the button click event on the main fight screen

            //print declaration of fight added to event list
            listOfEvents.Add(":: ROUND: "+roundNum+", FIGHT ::");

            //while either fighter is not dead
            while (!HasAIDied() && !HasNonAIDied())
            {
                //each step round the loop is a turn

                //evaluate fitness of tree = average damage delt per turn over
                //a match


                //AI fighter attacks Non_AI fighter + event added to list
                //listOfEvents.Add(AiFighter.Attack(NoAiFighter));
                //listOfEvents.Add(wAttack(AiFighter,NoAiFighter));

                int beforeDam = NoAiFighter.Health;

                //tick the AI's tree during combat
                listOfEvents.Add(AiFighter.Tree.Tree.Tick(new MyTimeData((float)1)).ToString());

                int afterDam = NoAiFighter.Health;

                int damage = beforeDam - afterDam;

                total_Damage += damage;

                //Non-AI fighter attacks AI fighter + event added to list
                //listOfEvents.Add(NoAiFighter.Attack(AiFighter));
                listOfEvents.Add(wAttack(NoAiFighter, AiFighter, null));

                //ToDo TEST output
                listOfEvents.Add("AI Health: " + AiFighter.Health.ToString());
                listOfEvents.Add("non AI Health: " + NoAiFighter.Health.ToString());
            }

            if (HasNonAIDied())
            {
                listOfEvents.Add("Non-AI-Fighter HAS Died");
                listOfEvents.Add("==================================================================");
            }
            else
            {
                listOfEvents.Add("AI-Fighter HAS Died");
                listOfEvents.Add("==================================================================");
            }

            //System.Threading.Thread.Sleep(1000);
            //update the trees fitness
            gp.fitness_function(total_Damage,AiFighter.Tree);

            //reset counter
            total_Damage = 0;

            //move to next round and alter settings as needed.
            nextRound();

        }
        /// <summary>
        /// Triggers the evolution.
        /// </summary>
        public void triggerEvolution()
        {
            gp.evolve();
        }
        //****************************************************************************
        /// <summary>
        /// Determines whether [has ai died].
        /// </summary>
        /// <returns>
        /// true or false
        /// </returns>
        public bool HasAIDied()
        {
            if (AiFighter.Health <= 0)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Determines whether [has non ai died].
        /// </summary>
        /// <returns>
        /// true or false
        /// </returns>
        public bool HasNonAIDied()
        {
            if (NoAiFighter.Health <= 0)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// handles the attacks in world calss.
        /// </summary>
        /// <param name="attacker">The attacker.</param>
        /// <param name="defender">The defender.</param>
        /// <param name="attack"></param>
        /// <returns>
        /// event for the event list
        /// </returns>
        public String wAttack(Fighter attacker,Fighter defender, Attack attack)
        {
            Attack attk;

            //if the attack peramiter is null (not from the behaviour tree)
            //then generate an attack randomely
            if (attack == null)
            {
                //Attack attk = attacker.GenAttack();
                attk = attacker.Attack;
            }
            else 
            { 
                attk = attack;
            }

            String dist = "";

            //if defender is blocking half the damage done
            if (defender.Blocking) { attk.Damage = (attk.Damage / 2); }

            // If they are close then everything hits
            if (Distance == "Close")
            {
                dist = "Close Damage: ";

                //if there crouching and NOT low damage
                if (defender.Crouching == true && attk.LowDam == false)
                {
                    //if attack is not low damage dealing reduce amount of damage delt
                    attk.Damage = (attk.Damage / 2);
                    defender.Health += attk.Damage;
                    return "Crouching and NOT low attack :::::: " + attacker.Type + " <<" + attk.Name + ">> " + defender.Type + " <<For>> <" + attk.Damage + "> <Damage was reduced due to ducking opponent>";
                }
                if (defender.Crouching == true && attk.LowDam == false)
                {
                    // otherwise full damage delt to opponent
                    defender.Health += attk.Damage;
                    return "Crouching and low attack :::::: " + attacker.Type + " <<" + attk.Name + ">> " + defender.Type + " <<For>> <" + attk.Damage + ">";
                }
                else
                    //otherwise return
                    defender.Health += attk.Damage;
                    return dist + attacker.Type + " <<" + attk.Name + ">> " + defender.Type + " <<For>> <" + attk.Damage + ">";
            }
            // Distance is Far and attack is far
            else if (Distance == "Far" && attk.Distance == "Far")
            {
                dist = "Far Damage: ";
                defender.Health += attk.Damage;
            }
            //Distance is medium and attack is medium
            else if (Distance == "Medium" && attk.Distance == "Medium" || attk.Distance == "Far")
            {
                dist = "Medium Damage: ";
                defender.Health += attk.Damage;
            }
            else
            {
                //safty loop counter to provent infinate loop
                lc++;

                //kill ai to end loop
                if (lc >= 50)
                {
                    AiFighter.Health = 0;
                    //reset loop conter
                    lc = 0;
                    return "<<AI_Fighter_TERMINATED>> <<LOOP ERROR>>";
                }

                //DEAL NO damage as attacked missed
                return attacker.Type + " <<" + attk.Name + ">> " + defender.Type + " <<MISSED>>";

            }

            return dist + attacker.Type + " <<" + attk.Name + ">> " + defender.Type + " <<For>> <" + attk.Damage + ">";
            
        }
    }
    
}
