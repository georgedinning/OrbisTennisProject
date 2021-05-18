using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class BoolRandomiser : IBoolPicker
    {
        private Random random;
        public BoolRandomiser()
        {
            this.random = new Random();
        }
        public bool nextBool()
        {
            return this.random.Next(0, 2) == 0;
        }
    }
}
