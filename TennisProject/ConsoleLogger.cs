using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class ConsoleLogger : IOutputLogger
    {
        public void Output(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
