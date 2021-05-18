using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisProject;

namespace TennisProjectTests
{
    [TestClass]
    public class TennisGameTests
    {
        [TestMethod]
        public void Tests()
        {
            TestGameScores(2, 1, 2, 1, -1);
            TestGameScores(2, 4, 2, 4, 2);
            TestGameScores(4, 0, 4, 0, 1);
            TestGameScores(2, 3, 2, 3, -1);
        }

        public void TestGameScores(int score1Calls, int score2Calls, int expectedScore1, int expectedScore2, int expectedWinner)
        {
            TennisGame game = new TennisGame(0);
            for(int i=0; i<score1Calls; i++)
            {
                game.Player1ScorePoint();
            }
            for (int i = 0; i < score2Calls; i++)
            {
                game.Player2ScorePoint();
            }
            Assert.AreEqual(game.GetPlayer1Points(), expectedScore1, 0.001, "Player1 Score incorrect");
            Assert.AreEqual(game.GetPlayer2Points(), expectedScore2, 0.001, "Player2 Score incorrect");
            Assert.AreEqual(game.GetWinner(), expectedWinner, 0.001, "Winner incorrect");
        }
    }
}
