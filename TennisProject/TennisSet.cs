using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class TennisSet : TennisScoreable
    {
        public TennisSet(int setNumber) : base(setNumber, new TennisScoreableFactory("Game"))
        {

        }
        public override void EndOutput(int winner, IOutputLogger outputLogger)
        {
            outputLogger.Output(String.Format("Player{0} Wins Set {1}   Player1 {2} Games - Player2 {3} Games", winner, this.label, this.player1Count, this.player2Count));
            outputLogger.Output("");
        }

        public override int GetWinner()
        {
            if (player1Count >= 6 && player1Count - player2Count >= 2) return 1;
            if (player2Count >= 6 && player2Count - player1Count >= 2) return 2;
            return -1;
        }

    }
}