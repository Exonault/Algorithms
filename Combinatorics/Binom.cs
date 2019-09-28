using System.Numerics;

namespace Combinatorics
{
    public static class Binom // N choose K count
    {
        public static BigInteger NChooseKCount(int n, int k)
        {
            return Factoriel(n) / (Factoriel(n - k) * Factoriel(k));
        }

        private static BigInteger Factoriel(int number)
        {
            BigInteger fact = 1;
            for (int i = 2; i <= number; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }
}