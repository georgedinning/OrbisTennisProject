using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbisTennisProject
{
    public class TennisMatch
    {
        private TennisSet[] sets;

        public TennisMatch()
        {
            this.sets = new TennisSet[3];
        }
        public void Play()
        {
            int winner=-1;
            for(int setIndex=0; setIndex<3; setIndex++)
            {
                this.sets[setIndex] = new TennisSet();
                this.sets[setIndex].Play();
                if ((winner=GetWinner()) != -1) break;
            }
            Console.WriteLine("Player{0} Wins the Match", winner);
        }
        public int GetWinner()
        {
            int player1Sets = 0;
            int player2Sets = 0;
            foreach (TennisSet set in this.sets)
            {
                if (set != null)
                {
                    if (set.GetWinner() == 1) player1Sets++;
                    if (set.GetWinner() == 2) player2Sets++;
                }
            }
            if (player1Sets >= 2) return 1;
            if (player2Sets >= 2) return 2;
            return -1;
        }
    }
}