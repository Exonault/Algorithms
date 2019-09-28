using System;

namespace Combinatorics
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine( Binom.NChooseKCount(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
           
        }
    }
}