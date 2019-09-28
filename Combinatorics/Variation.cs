using System;

namespace Combinatorics
{
    public static class Variation
    {
        public static void VariateWithoutRepetition(string[] set, string[] variation, bool[] used, int index)
        {
            if (index>=variation.Length)
            {
                Console.WriteLine(string.Join(" ",variation));
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variation[index] = set[i];
                        VariateWithoutRepetition(set,variation,used,index+1);
                        used[i] = false;
                    }
                }
            }
            
        }

        public static void VariateWithRepetition(string[] set, string[] variation,int index)
        {
            if (index >= variation.Length)
            {
                Console.WriteLine(String.Join(" ",variation));
            }

            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    variation[index] = set[i];
                    VariateWithRepetition(set,variation,index+1);
                }
            }
        }
        
    }
}