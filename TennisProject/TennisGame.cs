using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbisTennisProject
{
    public class TennisGame
    {
        private Random random;
        int points1, points2;
        public TennisGame()
        {
            this.random = new Random();
            this.points1 = 0;
            this.points2 = 0;
        }
        public void Play()
        {
            int pointCount = 0;
            int winner;
            while ((winner=this.GetWinner()) == -1)
            {
                pointCount++;
                if (this.RandomBool())
                {
                    this.Player1ScorePoint();
                }
                else
                {
                    this.Player2ScorePoint();
                }
            }
            Console.WriteLine("Player{0} Wins the Game {1}-{2}", winner, this.points1, this.points2);
        }

        public void Player1ScorePoint()
        {
            this.points1++;
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

        public bool RandomBool()
        {
            return this.random.Next(0, 2) == 0;
        }
    }
}
