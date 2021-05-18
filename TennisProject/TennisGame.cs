using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class TennisGame : TennisScoreable
    {
        public TennisGame(int gameNumber) : base(gameNumber, null)
        {

        }
        public override void Output(int winner, IOutputLogger outputLogger)
        {
            outputLogger.Output(String.Format("Player{0} Wins Game {1}   Player1 {2} points - Player2 {3} points", winner, this.label, this.player1Count, this.player2Count));
        }

        public override int GetWinner()
        {
            if (this.player1Count >= 4 && this.player1Count - this.player2Count >=2)
            {
                return 1;
            }
            else if (this.player2Count >= 4 && this.player2Count - this.player1Count >= 2)
            {
                return 2;
            }
            return -1;
        }

    }
}
