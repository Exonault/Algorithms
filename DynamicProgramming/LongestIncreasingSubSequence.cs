using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
    public static class LongestIncreasingSubSequence
    {
        private static int[] sequence;
        private static int[] previous;
        private static int[] lenghtLIS;
        
        public static void LIS()
        {
            sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            previous = new int[sequence.Length];
            lenghtLIS = new int[sequence.Length];

            int lastIndex = GenerateLIS();

            List<int> longestSequence = RecreateLIS(ref lastIndex);

            Console.WriteLine(string.Join(" ", longestSequence));
        }

        private static int GenerateLIS()
        {
            int maxLenght = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                lenghtLIS[i] = 1;
                previous[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && lenghtLIS[j] + 1 > lenghtLIS[i])
                    {
                        lenghtLIS[i] = lenghtLIS[j] + 1;
                        previous[i] = j;
                    }
                }

                if (lenghtLIS[i] > maxLenght)
                {
                    maxLenght = lenghtLIS[i];
                    lastIndex = i;
                }
            }

            return lastIndex;
        }

        private static List<int> RecreateLIS(ref int lastIndex)
        {
            var longestSequence = new List<int>();

            while (lastIndex != -1)
            {
            longestSequence.Add(sequence[lastIndex]);
            lastIndex = previous[lastIndex];
            }

            longestSequence.Reverse();
            return longestSequence;
        }
    }
}