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

        public TennisScoreable CreateTennisScorable(int round, IBoolPicker boolPicker, IOutputLogger outputLogger)
        {
            TennisScoreable tennisScoreable = null;
            if (this.type.Equals("Game"))
            {
                tennisScoreable = new TennisGame(round);
            }else if (this.type.Equals("Set"))
            {
                tennisScoreable = new TennisSet(round);
            }
            if (tennisScoreable != null)
            {
                tennisScoreable.Play(boolPicker, outputLogger);
            }
            return tennisScoreable;
        }
    }
}
