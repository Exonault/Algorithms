namespace Recursion
{
    public static class RecursiveFactoriel
    {
       public static ulong Factoriel(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return (ulong) n * Factoriel(n - 1);
        }
    }
}