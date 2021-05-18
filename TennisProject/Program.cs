using System;

namespace TennisProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IOutputLogger outputLogger = new ConsoleLogger();
            outputLogger.Output("Tennis Project Starting...");
            TennisMatch match = new TennisMatch();
            match.Play(new BoolRandomiser(), outputLogger);
        }
    }
}