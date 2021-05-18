using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class TennisMatch : TennisScoreable
    {
        public TennisMatch() : base(0, new TennisScoreableFactory("Set"))
        {

        }

        public override void Output(int winner, IOutputLogger outputLogger)
        {
            outputLogger.Output(String.Format("Player{0} Wins the Match   Player1 {1} Sets - Player2 {2} Sets", winner, this.player1Count, this.player2Count));
        }
        public override int GetWinner()
        {
            if (player1Count >= 2) return 1;
            if (player2Count >= 2) return 2;
            return -1;
        }
    }
}