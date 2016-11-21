using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;

namespace FightGameAIDemo
{
    /// <summary>
    /// Interface that connects the front end to the back end GameWorld class
    /// </summary>
    public interface IGameWorld
    {

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGameWorld"/> is crouched.
        /// </summary>
        /// <value>
        ///   <c>true</c> if crouched; otherwise, <c>false</c>.
        /// </value>
        bool Crouched { set; get; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGameWorld"/> is close.
        /// </summary>
        /// <value>
        ///   <c>true</c> if close; otherwise, <c>false</c>.
        /// </value>
        bool Close { set; get; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGameWorld"/> is medium.
        /// </summary>
        /// <value>
        ///   <c>true</c> if medium; otherwise, <c>false</c>.
        /// </value>
        bool Medium { set; get; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGameWorld"/> is far.
        /// </summary>
        /// <value>
        ///   <c>true</c> if far; otherwise, <c>false</c>.
        /// </value>
        bool Far { set; get; }

        /// <summary>
        /// Triggers the evolution.
        /// </summary>
        void triggerEvolution();

        /// <summary>
        /// Gets or sets the population_size.
        /// </summary>
        /// <value>
        /// The population_size.
        /// </value>
        int Population_size { set; get; }

        /// <summary>
        /// Gets or sets the list of events.
        /// </summary>
        /// <value>
        /// The list of events.
        /// </value>
        List<String> ListOfEvents { get; set; }
        /// <summary>
        /// Gets or sets the list events algorithm.
        /// </summary>
        /// <value>
        /// The list events algorithm.
        /// </value>
        List<String> ListEventsAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        string Distance { get; set; }

        /// <summary>
        /// Set up the fighters for the fight.
        /// </summary>
        /// <param name="isBlocking">if set to <c>true</c> [is blocking].</param>
        /// <param name="isCrouched">if set to <c>true</c> [is crouched].</param>
        /// <param name="torn_size">The torn_size.</param>
        /// <param name="pop_size">The pop_size.</param>
        void SetUp(bool isBlocking, bool isCrouched, int torn_size, int pop_size);
        /// <summary>
        /// Runs the fight.
        /// </summary>
        void RunFight();

        /// <summary>
        /// Determines whether [has ai died].
        /// </summary>
        /// <returns>
        /// true or false
        /// </returns>
        bool HasAIDied();
        /// <summary>
        /// Determines whether [has non ai died].
        /// </summary>
        /// <returns>
        /// true or false
        /// </returns>
        bool HasNonAIDied();

        /// <summary>
        /// handles the attack.
        /// </summary>
        /// <param name="attacker">The attacker.</param>
        /// <param name="defender">The defender.</param>
        /// <param name="attack">The attack.</param>
        /// <returns>
        /// String for event list
        /// </returns>
        String wAttack(Fighter attacker, Fighter defender, Attack attack);
    }
}
