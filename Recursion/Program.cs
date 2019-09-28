using System;
using System.Linq;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
         GenerateNBitVectors.Generate(0,new int[int.Parse(Console.ReadLine())]);
        }
    }
}