using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
    public static  class Fibonacci
    {
        
        public static void Fib()
        {
            int n = int.Parse(Console.ReadLine());
            
            List<int> nums = new List<int>();
            nums.Add(0);
            nums.Add(1);

            for (int i = 1; i < n; i++)
            {
                nums.Add(nums[i]+nums[i-1]);
            }

            Console.WriteLine(nums.Last());
        }
    }
}