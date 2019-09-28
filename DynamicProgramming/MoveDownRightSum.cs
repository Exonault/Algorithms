using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
    public static class MoveDownRightSum
    {
        private static long[,] cells;
        private static long[,] sum;

        public static void MDRS()
        {
            InitializeMatrix();
            FillSums();
            IEnumerable<string> path = FindPath();

            Console.WriteLine(string.Join(" ", path));
        }

        private static List<string> FindPath()
        {
            List<string> path = new List<string>();

            int rows = cells.GetLength(0) - 1;
            int cols = cells.GetLength(1) - 1;

            while (rows + cols > 0)
            {
                if (cols == 0)
                {
                    path.Add($"[{rows--}, {cols}]");
                    continue;
                }

                if (rows == 0)
                {
                    path.Add($"[{rows}, {cols--}]");
                    continue;
                }

                if (sum[rows, cols - 1] >= sum[rows - 1, cols])
                {
                    path.Add($"[{rows}, {cols--}]");
                }
                else
                {
                    path.Add($"[{rows--}, {cols}]");
                }
            }

            path.Add($"[{rows}, {cols}]");
            path.Reverse();
            return path;
        }

        private static void InitializeMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            cells = sum = new long[rows, cols];

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                long[] row = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = row[j];
                }
            }
        }

        private static void FillSums()
        {
            for (int row = 0; row < cells.GetLength(0); row++)
            {
                for (int col = 0; col < cells.GetLength(1); col++)
                {
                    long maxPrevCell = long.MinValue;
                    if (col > 0 && sum[row, col - 1] > maxPrevCell)
                    {
                        maxPrevCell = sum[row, col - 1];
                    }

                    if (row > 0 && sum[row - 1, col] > maxPrevCell)
                    {
                        maxPrevCell = sum[row - 1, col];
                    }

                    sum[row, col] = cells[row, col];

                    if (maxPrevCell != long.MinValue)
                    {
                        sum[row, col] += maxPrevCell;
                    }
                }
            }
        }
    }
}