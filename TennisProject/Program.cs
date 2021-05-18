using System;

namespace TennisProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tennis Project Starting...");
            TennisMatch match = new TennisMatch();
            match.Play();
        }
    }
}