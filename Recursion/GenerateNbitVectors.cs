using System;

namespace Recursion
{
    public static class GenerateNBitVectors
    {
        public static void Generate(int index,int[] vector)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(' ', vector));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    Generate(index+1,vector);
                }
            }
        }
    }
}