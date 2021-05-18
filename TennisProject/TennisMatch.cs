using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class TennisMatch
    {
        private int player1SetCount, player2SetCount;

        public TennisMatch()
        {
            this.player1SetCount = 0;
            this.player2SetCount = 0;
        }

        public void Play(IBoolPicker boolPicker, IOutputLogger outputLogger)
        {
            int matchWinner = -1;
            for(int setIndex=0; setIndex<3; setIndex++)
            {
                TennisSet set = new TennisSet(setIndex+1);
                set.Play(boolPicker, outputLogger);
                int setWinner = set.GetWinner();
                if (setWinner == 1)
                {
                    player1SetCount++;
                }
                else
                {
                    player2SetCount++;
                }
                if ((matchWinner = GetWinner()) != -1) break;
            }
            outputLogger.Output(String.Format("Player{0} Wins the Match   Player1 {1} Sets - Player2 {2} Sets", matchWinner, this.player1SetCount, this.player2SetCount));
        }
        public int GetWinner()
        {
            if (player1SetCount >= 2) return 1;
            if (player2SetCount >= 2) return 2;
            return -1;
        }
    }
}