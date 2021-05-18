using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisProject;
using System.Collections.Generic;
using System.Linq;

namespace TennisProjectTests
{
    [TestClass]
    public class TennisGameTests
    {
        [TestMethod]
        public void Tests()
        {
            //Each match comprises of a up to three sets

            //A player wins a match if they win two sets in a match

            //Each set should comprise of a number of games

            //A player wins a set if they have won at least 6 games by a margin of 2 or more.

            //Sets should be played until there is a winner – there should not be any tie breaks

            //Each game should have a valid test score, as described in https://en.wikipedia.org/wiki/Tennis_scoring_system

            //The result of each game should be randomly determined

            //On starting the application, it should run a sample tennis match

            //The application should be well tested


            IOutputLogger outputLogger = new ConsoleLogger();
            TestGameScores(new List<bool> {true, true, true, false, false, true}, 4, 2, 1, outputLogger);
            TestGameScores(new List<bool> {false, false, false, false, true, true }, 0, 4, 2, outputLogger);
        }

        public void TestGameScores(List<bool> booleans, int expectedScore1, int expectedScore2, int expectedWinner, IOutputLogger outputLogger)
        {
            TennisGame game = new TennisGame(0);

            game.Play(new BoolListPicker(booleans), outputLogger);

            Assert.AreEqual(game.GetPlayer1Count(), expectedScore1, 0.001, "Player1 Score incorrect");
            Assert.AreEqual(game.getPlayer2Count(), expectedScore2, 0.001, "Player2 Score incorrect");
            Assert.AreEqual(game.GetWinner(), expectedWinner, 0.001, "Winner incorrect");
        }
    }
}
