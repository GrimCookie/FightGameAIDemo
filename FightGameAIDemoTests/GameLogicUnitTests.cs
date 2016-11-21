using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FightGameAIDemo;
using FightGameAIDemo.GP;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;

namespace FightGameAIDemoTests
{
    [TestClass]
    public class GameLogicUnitTests
    {
        [TestMethod]
        public void Handling_Fight_Event_Distance_Close_Attack_Type_Punch()
        {
            // make sure that in the event both the distance and the attack type are close the 
            // resut will be that of a close and close respons
            
            //arrange
            AIFighter attacker = new AIFighter(1);
            NonAIFighter defender = new NonAIFighter(1, false, false);

            IGameWorld gw = new GameWorld();

            //set up 
            gw.Distance = "Close";
            attacker.Attack = new Punch();

            String expected = "Close Damage: AI-Fighter <<Punch>> Non-AI-Fighter <<For>> <-10>";



            //act
            string actual = gw.wAttack(attacker, defender, attacker.Attack);

            //assert

            Assert.AreEqual(expected, actual, " the correct attack result was returned");
        }
        [TestMethod]
        public void Handling_Fight_Event_Distance_Close_Attack_Type_Kick()
        {
            // make sure that in the event both the distance and the attack type are close the 
            // resut will be that of a close and close respons

            //arrange
            AIFighter attacker = new AIFighter(1);
            NonAIFighter defender = new NonAIFighter(1, false, false);

            IGameWorld gw = new GameWorld();

            //set up 
            gw.Distance = "Close";
            attacker.Attack = new Kick();

            String expected = "Close Damage: AI-Fighter <<Kick>> Non-AI-Fighter <<For>> <-25>";



            //act
            string actual = gw.wAttack(attacker, defender, attacker.Attack);

            //assert

            Assert.AreEqual(expected, actual, " the correct attack result was returned");
        }
        [TestMethod]
        public void Handling_Fight_Event_Distance_Close_Attack_Type_Special()
        {
            // make sure that in the event both the distance and the attack type are close the 
            // resut will be that of a close and close respons

            //arrange
            AIFighter attacker = new AIFighter(1);
            NonAIFighter defender = new NonAIFighter(1, false, false);

            IGameWorld gw = new GameWorld();

            //set up 
            gw.Distance = "Close";
            attacker.Attack = new Special();

            String expected = "Close Damage: AI-Fighter <<Special Move>> Non-AI-Fighter <<For>> <-30>";



            //act
            string actual = gw.wAttack(attacker, defender, attacker.Attack);

            //assert

            Assert.AreEqual(expected, actual, " the correct attack result was returned");
        }
        [TestMethod]
        public void Handling_Fight_Event_Distance_Medium_Attack_Type_Punch()
        {
            // make sure that in the event both the distance and the attack type are close the 
            // resut will be that of a close and close respons

            //arrange
            AIFighter attacker = new AIFighter(1);
            NonAIFighter defender = new NonAIFighter(1, false, false);

            IGameWorld gw = new GameWorld();

            //set up 
            gw.Distance = "Medium";
            attacker.Attack = new Punch();

            String expected = "AI-Fighter <<Punch>> Non-AI-Fighter <<MISSED>>";



            //act
            string actual = gw.wAttack(attacker, defender, attacker.Attack);

            //assert

            Assert.AreEqual(expected, actual, " the correct attack result was returned");
        }
        [TestMethod]
        public void Handling_Fight_Event_Distance_Medium_Attack_Type_Kick()
        {
            // make sure that in the event both the distance and the attack type are close the 
            // resut will be that of a close and close respons

            //arrange
            AIFighter attacker = new AIFighter(1);
            NonAIFighter defender = new NonAIFighter(1, false, false);

            //Attack attack = attacker.GenAttack();

            IGameWorld gw = new GameWorld();

            //set up 
            gw.Distance = "Medium";
            attacker.Attack = new Kick();

            String expected = "Medium Damage: AI-Fighter <<Kick>> Non-AI-Fighter <<For>> <-25>";



            //act
            string actual = gw.wAttack(attacker, defender, attacker.Attack);

            //assert

            Assert.AreEqual(expected, actual, " the correct attack result was returned");
        }
        [TestMethod]
        public void Handling_Fight_Event_Distance_Medium_Attack_Type_Special()
        {
            
            //arrange
            AIFighter attacker = new AIFighter(1);
            NonAIFighter defender = new NonAIFighter(1, false, false);


            IGameWorld gw = new GameWorld();

            //set up 
            gw.Distance = "Medium";
            attacker.Attack = new Special();
            
            String expected = "Medium Damage: AI-Fighter <<Special Move>> Non-AI-Fighter <<For>> <-30>";

            //act
            string actual = gw.wAttack(attacker, defender, attacker.Attack);

            //assert
            Assert.AreEqual(expected, actual, " the correct attack result was returned");
        }

        [TestMethod]
        public void Handling_Fight_Event_Distance_Far_Attack_Type_Punch()
        {

            //arrange
            AIFighter attacker = new AIFighter(1);
            NonAIFighter defender = new NonAIFighter(1, false, false);


            IGameWorld gw = new GameWorld();

            //set up 
            gw.Distance = "Far";
            attacker.Attack = new Punch();

            String expected = "AI-Fighter <<Punch>> Non-AI-Fighter <<MISSED>>";

            //act
            string actual = gw.wAttack(attacker, defender, attacker.Attack);

            //assert
            Assert.AreEqual(expected, actual, "The correct attack result was returned");
        }
        [TestMethod]
        public void Handling_Fight_Event_Distance_Far_Attack_Type_Kick()
        {

            //arrange
            AIFighter attacker = new AIFighter(1);
            NonAIFighter defender = new NonAIFighter(1, false, false);


            IGameWorld gw = new GameWorld();

            //set up 
            gw.Distance = "Far";
            attacker.Attack = new Kick();

            String expected = "AI-Fighter <<Kick>> Non-AI-Fighter <<MISSED>>";

            //act
            string actual = gw.wAttack(attacker, defender, attacker.Attack);

            //assert
            Assert.AreEqual(expected, actual, "The correct attack result was returned");
        }
        [TestMethod]
        public void Handling_Fight_Event_Distance_Far_Attack_Type_Special()
        {

            //arrange
            AIFighter attacker = new AIFighter(1);
            NonAIFighter defender = new NonAIFighter(1, false, false);

            IGameWorld gw = new GameWorld();

            //set up 
            gw.Distance = "Far";
            attacker.Attack = new Special();

            String expected = "Far Damage: AI-Fighter <<Special Move>> Non-AI-Fighter <<For>> <-30>";

            //act
            string actual = gw.wAttack(attacker, defender, attacker.Attack);

            //assert
            Assert.AreEqual(expected, actual, "The correct attack result was returned");
        }

        public void Handling_Fight_Event_Distance_Close_Attack_Type_Punch_Blocking()
        {
           
            //arrange
            AIFighter attacker = new AIFighter(1);
            NonAIFighter defender = new NonAIFighter(1, true, false);

            //Attack attack = attacker.GenAttack();

            IGameWorld gw = new GameWorld();

            //set up 
            gw.Distance = "Close";
            attacker.Attack = new Punch();

            String expected = "Close Damage: AI-Fighter <<Punch>> Non-AI-Fighter <<For>> <-5>";

            //act
            string actual = gw.wAttack(attacker, defender, attacker.Attack);

            //assert

            Assert.AreEqual(expected, actual, " the incorrect attack result was returned");
        }

        [TestMethod]
        public void Set_Up_Non_AI_Fighter()
        {

            //arrange
            IGameWorld gw = new GameWorld();

            //set up
            gw.SetUp(false, false, 2, 10);

            String expected = "//:Non-AI-Fighter //Fighter number:1\\ Health = 100, is Crouched = False, is Blocking = False";

            //act
            String actual = gw.ListOfEvents[2];

            //assert
            Assert.AreEqual(expected, actual, "The Non_AI_fighter wasn't set up");
        }
        [TestMethod]
        public void Set_Up_AI_Fighter()
        {

            //arrange
            IGameWorld gw = new GameWorld();

            //set up
            gw.SetUp(false, false,2,10);

            String expected = "//:AI-Fighter //Fighter number:1\\ Health = 100, is Crouched = False, is Blocking = False";

            //act
            String actual = gw.ListOfEvents[3];

            //assert
            Assert.AreEqual(expected, actual, "The AI_fighter wasn't set up");
        }
    }
}
