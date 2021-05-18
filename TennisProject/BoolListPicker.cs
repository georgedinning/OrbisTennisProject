using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class BoolListPicker : IBoolPicker
    {
        private int index;
        private List<bool> booleans;

        public BoolListPicker(List<bool> booleans)
        {
            this.booleans = booleans;
            this.index = 0;
        }
        public bool nextBool()
        {
            bool result = this.booleans[this.index];
            this.index++;
            if (this.index >= this.booleans.Count)
            {
                this.index = 0;
            }
            return result;
        }
    }
}
