using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class TennisGame
    {
        private int gameNumber;
        private int points1, points2;
        public TennisGame(int gameNumber)
        {
            this.gameNumber = gameNumber;
            this.points1 = 0;
            this.points2 = 0;
        }

        public void Play(IBoolPicker boolPicker, IOutputLogger outputLogger)
        {
            int pointCount = 0;
            int winner;
            while ((winner=this.GetWinner()) == -1)
            {
                pointCount++;
                if (boolPicker.nextBool())
                {
                    this.Player1ScorePoint();
                }
                else
                {
                    this.Player2ScorePoint();
                }
            }
            outputLogger.Output(String.Format("Player{0} Wins Game {1}   Player1 {2} points - Player2 {3} points", winner, this.gameNumber, this.points1, this.points2));
        }

        public void Player1ScorePoint()
        {
            this.points1++;
        }

        public int GetPlayer1Points()
        {
            return this.points1;
        }
        public int GetPlayer2Points()
        {
            return this.points2;
        }

        public void Player2ScorePoint()
        {
            this.points2++;
        }

        public int GetWinner()
        {
            if (this.points1 >= 4 && this.points1 - this.points2>=2)
            {
                return 1;
            }
            else if (this.points2 >= 4 && this.points2 - this.points1 >= 2)
            {
                return 2;
            }
            return -1;
        }
    }
}
