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
            TestGameScores(new List<bool> {true, true, true, false, false, true}, 4, 2, 1);
        }

        public void TestGameScores(List<bool> booleans, int expectedScore1, int expectedScore2, int expectedWinner)
        {
            TennisGame game = new TennisGame(new BoolListPicker(booleans), 0);

            game.Play();

            Assert.AreEqual(game.GetPlayer1Points(), expectedScore1, 0.001, "Player1 Score incorrect");
            Assert.AreEqual(game.GetPlayer2Points(), expectedScore2, 0.001, "Player2 Score incorrect");
            Assert.AreEqual(game.GetWinner(), expectedWinner, 0.001, "Winner incorrect");
        }
    }
}
