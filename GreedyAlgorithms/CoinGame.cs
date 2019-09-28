using System;
using System.Collections.Generic;

namespace GreedyAlgorithms
{
    public static class CoinGame
    {
        public static void Sollution(int finalSum, int[] coins)
        {
            int currentSum = 0;
            Queue<int> resultCoins = new Queue<int>();
            for (int i = 0; i < coins.Length; i++)
            {
                if (currentSum + coins[i] > finalSum)
                    continue;

                resultCoins.Enqueue(coins[i]);

                currentSum += coins[i];

                Console.WriteLine($"Added {coins[i]}");

                if (currentSum == finalSum)
                {
                    Console.WriteLine("Sum found");
                }
                else Console.WriteLine("Sum not found");
            }
        }
    }
}