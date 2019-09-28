using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DynamicProgramming
{
    public static class RodCutting
    {
        private static int[] price;
        private static int[] bestCombo;
        private static int[] bestPrice;
        
        public static void RodCuttingProblem()
        {
            price = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            bestCombo = new int[price.Length];
            bestPrice = new int[price.Length];

            int n = int.Parse(Console.ReadLine());
            
            int totalBest = RodCuttingSolution(n);
            
            List<int> result = new List<int>();


            while (n>0)
            {
                int next = bestCombo[n];
                result.Add(next);
                n -= next;
            }

            Console.WriteLine(totalBest);
            Console.WriteLine(String.Join(" ",result));
        }

        private static int RodCuttingSolution(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                int currBest = bestPrice[i];
                for (int j = 1; j <= i; j++)
                {
                    currBest =
                        Math.Max(bestPrice[i], price[j] + bestPrice[i - j]);

                    if (currBest> bestPrice[i])
                    {
                        bestPrice[i] = currBest;
                        bestCombo[i] = j;
                    }
                }
            }

            return bestPrice[n];
        }
    }
}