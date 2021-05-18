using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class TennisScoreableFactory
    {
        private String type;
        public TennisScoreableFactory(String type)
        {
            this.type = type;
        }

        public TennisScoreable CreateTennisScorable(int round)
        {
            if (this.type.Equals("Game"))
            {
                return new TennisGame(round);
            }else if (this.type.Equals("Set"))
            {
                return new TennisSet(round);
            }
            return null;
        }
    }
}
