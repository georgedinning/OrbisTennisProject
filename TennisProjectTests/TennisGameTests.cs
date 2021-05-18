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
            IOutputLogger outputLogger = new ConsoleLogger();
            //Each match comprises of a up to three sets
            TestTennisScoreableScores(new TennisMatch(), GetBooleanSets(new List<int> { 1, 1, 1}), 2, 0, 1, outputLogger);
            TestTennisScoreableScores(new TennisMatch(), GetBooleanSets(new List<int> { 1, 2, 1}), 2, 1, 1, outputLogger);
            TestTennisScoreableScores(new TennisMatch(), GetBooleanSets(new List<int> { 1, 2, 2 }), 1, 2, 2, outputLogger);
            TestTennisScoreableScores(new TennisMatch(), GetBooleanSets(new List<int> { 2, 2, 2 }), 0, 2, 2, outputLogger);

            //A player wins a match if they win two sets in a match
            TestTennisScoreableScores(new TennisMatch(), new List<bool> { true }, 2, 0, 1, outputLogger);
            TestTennisScoreableScores(new TennisMatch(), new List<bool> { false }, 0, 2, 2, outputLogger);

            //Each set should comprise of a number of games
            TestTennisScoreableScores(new TennisSet(0), new List<bool> { true }, 6, 0, 1, outputLogger);
            TestTennisScoreableScores(new TennisSet(0), new List<bool> { false }, 0, 6, 2, outputLogger);
            TestTennisScoreableScores(new TennisSet(0), new List<bool> { true, true, true, true, true, true, true, true, false, false, false, false }, 6, 2, 1, outputLogger);
            TestTennisScoreableScores(new TennisSet(0), new List<bool> { false, false, false, false, true, true, true, true, false, false, false, false }, 3, 6, 2, outputLogger);

            //A player wins a set if they have won at least 6 games by a margin of 2 or more.
            TestTennisScoreableScores(new TennisSet(0), GetBooleanGames(new List<int> { 1,1,1,1,1,2,2,2,2,2,1,2,1,2,1,2,1,2,1,1 }), 11, 9, 1, outputLogger);
            TestTennisScoreableScores(new TennisSet(0), GetBooleanGames(new List<int> { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 1, 2, 1, 2, 1, 2, 1, 2, 2, 2 }), 9, 11, 2, outputLogger);

            //Sets should be played until there is a winner – there should not be any tie breaks

            //Each game should have a valid test score, as described in https://en.wikipedia.org/wiki/Tennis_scoring_system
            TestTennisScoreableScores(new TennisGame(0), new List<bool> { true, true, true, false, false, true }, 4, 2, 1, outputLogger);
            TestTennisScoreableScores(new TennisGame(0), new List<bool> { false, false, false, false, true, true }, 0, 4, 2, outputLogger);

            //The result of each game should be randomly determined

            //On starting the application, it should run a sample tennis match

            //The application should be well tested


        }

        public void TestTennisScoreableScores(TennisScoreable tennisScoreable, List<bool> booleans, int expectedScore1, int expectedScore2, int expectedWinner, IOutputLogger outputLogger)
        {
            tennisScoreable.Play(new BoolListPicker(booleans), outputLogger);

            Assert.AreEqual(tennisScoreable.GetPlayer1Count(), expectedScore1, 0.001, "Player1 Score incorrect");
            Assert.AreEqual(tennisScoreable.getPlayer2Count(), expectedScore2, 0.001, "Player2 Score incorrect");
            Assert.AreEqual(tennisScoreable.GetWinner(), expectedWinner, 0.001, "Winner incorrect");
        }

        public List<bool> GetBooleanList(int trueCount, int falseCount)
        {
            List<bool> booleans = new List<bool>();
            for(int i=0; i<trueCount; i++)
            {
                booleans.Add(true);
            }
            for (int i = 0; i < falseCount; i++)
            {
                booleans.Add(false);
            }
            return booleans;
        }

        public List<bool> GetBooleanGame(int winner)
        {
            if (winner == 1)
            {
                return GetBooleanList(4, 0);
            }
            else
            {
                return GetBooleanList(0, 4);
            }
        }
        public List<bool> GetBooleanGames(List<int> winners)
        {
            List<bool> booleans = new List<bool>();
            foreach(int winner in winners)
            {
                booleans.AddRange(GetBooleanGame(winner));
            }
            return booleans;
        }
        public List<bool> GetBooleanSet(int winner)
        {
            if (winner == 1)
            {
                return GetBooleanList(4*6, 0);
            }
            else
            {
                return GetBooleanList(0, 4*6);
            }
        }
        public List<bool> GetBooleanSets(List<int> winners)
        {
            List<bool> booleans = new List<bool>();
            foreach (int winner in winners)
            {
                booleans.AddRange(GetBooleanSet(winner));
            }
            return booleans;
        }
    }
}
