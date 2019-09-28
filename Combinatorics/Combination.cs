using System;
using System.Linq;

namespace Combinatorics
{
    public static class Combination
    {
        public static void CombinationWithoutRepetition(string[] set, string[] combination, int index, int start)
        {
            if (index >= combination.Length)
            {
                Console.WriteLine(string.Join(" ", combination));
            }

            else
            {
                for (int i = start; i < set.Length; i++)
                {
                    combination[index] = set[i];
                    CombinationWithoutRepetition(set, combination, index + 1, i + 1);
                }
            }
        }

        public static void CombinationWithRepetition(string[] set, string[] combination, int index, int start)
        {
            if (index >= combination.Length)
            {
                Console.WriteLine(String.Join(" ", combination));
            }
            else
            {
                for (int i = start; i < set.Length; i++)
                {
                    combination[index] = set[i];
                    CombinationWithRepetition(set, combination, index + 1, i);
                }
            }
        }
    }
}