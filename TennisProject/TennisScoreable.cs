using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public abstract class TennisScoreable
    {
        public int label;
        public TennisScoreableFactory tennisScoreableFactory;
        public int player1Count, player2Count;

        public TennisScoreable(int label, TennisScoreableFactory tennisScoreableFactory)
        {
            this.label = label;
            this.tennisScoreableFactory = tennisScoreableFactory;
            this.player1Count = 0;
            this.player2Count = 0;
        }

        public virtual void Play(IBoolPicker boolPicker, IOutputLogger outputLogger)
        {
            int round = 0;
            int winner;
            while ((winner = GetWinner()) == -1)
            {
                round++;
                int roundWinner = 1;
                if (this.tennisScoreableFactory == null)
                {
                    if (!boolPicker.nextBool()) roundWinner = 2;
                }
                else
                {
                    TennisScoreable tennisScoreable = tennisScoreableFactory.CreateTennisScorable(round, boolPicker, outputLogger);
                    roundWinner = tennisScoreable.GetWinner();
                }
                if (roundWinner == 1)
                {
                    player1Count++;
                }
                else
                {
                    player2Count++;
                }
            }
            this.Output(winner, outputLogger);
        }
        public abstract int GetWinner();
        public abstract void Output(int winner, IOutputLogger outputLogger);

        public virtual int GetPlayer1Count()
        {
            return this.player1Count;
        }
        public virtual int getPlayer2Count()
        {
            return this.player2Count;
        }
    }
}
