namespace Recursion
{
    public static class RecursionSum
    {
        public static int Sum(int[] array, int index)
        {
            if (index == array.Length-1)
            {
                return array[index];
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}