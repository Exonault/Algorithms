using System;
using System.Collections.Generic;

namespace Combinatorics
{
    public static class Permutation
    {
        // If you have problem with the last 2 perms in ABC input, use sorted list
        public static void PermutationWithoutRepetition(string[] elements, int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(String.Join(' ', elements));
            }
            else
            {
                PermutationWithoutRepetition(elements, index + 1);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(elements, index, i);
                    PermutationWithoutRepetition(elements, index + 1);
                    Swap(elements, index, i);
                }
            }
        }

        public static void PermutationWithRepetition(string[] elements, int index)
        {
            if (index>=elements.Length-1)
            {
                Console.WriteLine(String.Join(" ",elements));
                return;
            }
            else
            {
                PermutationWithRepetition(elements,index+1);
                HashSet<string> swapped = new HashSet<string>(){elements[index]};
                for (int i = index+1; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        swapped.Add(elements[i]);
                        Swap(elements,index,i);
                        PermutationWithRepetition(elements,index+1);
                        Swap(elements,index,i);
                    }
                }
            }
        }


        private static void Swap(string[] elements, int index, int i)
        {
            var temp = elements[i];
            elements[i] = elements[index];
            elements[index] = temp;
        }
    }
}