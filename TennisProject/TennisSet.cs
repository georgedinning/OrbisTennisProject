using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class TennisSet
    {
        private int setNumber;
        private List<TennisGame> games;
        private int player1GameCount = 0;
        private int player2GameCount = 0;
        public TennisSet(int setNumber)
        {
            this.setNumber = setNumber;
            this.games = new List<TennisGame>();
        }

        public void Play()
        {
            int setWinner;
            int gameNumber = 0;
            while ((setWinner = GetWinner()) == -1)
            {
                gameNumber++;
                TennisGame game = new TennisGame(gameNumber);
                game.Play();
                int gameWinner = game.GetWinner();
                if (gameWinner == 1)
                {
                    player1GameCount++;
                }
                else
                {
                    player2GameCount++;
                }
                this.games.Add(game);
            }
            Console.WriteLine("Player{0} Wins Set {1}   Player1 {2} Games - Player2 {3} Games", setWinner, this.setNumber, this.player1GameCount, this.player2GameCount);
            Console.WriteLine();
        }
        public int GetWinner()
        {
            if (player1GameCount >= 6) return 1;
            if (player2GameCount >= 6) return 2;
            return -1;
        }
    }
}