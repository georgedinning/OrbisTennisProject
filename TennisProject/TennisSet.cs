using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbisTennisProject
{
    public class TennisSet
    {
        private List<TennisGame> games;
        public TennisSet()
        {
            this.games = new List<TennisGame>();
        }
        public void Play()
        {
            int winner;
            while ((winner=GetWinner()) == -1)
            {
                TennisGame game = new TennisGame();
                game.Play();
                this.games.Add(game);
            }
            Console.WriteLine("Player{0} Wins the Set", winner);
        }
        public int GetWinner()
        {
            int player1Games = 0;
            int player2Games = 0;
            foreach(TennisGame game in this.games){
                if (game.GetWinner() == 1) player1Games++;
                if (game.GetWinner() == 2) player2Games++;
            }
            if (player1Games >= 6) return 1;
            if (player2Games >= 6) return 2;
            return -1;
        }
    }
}