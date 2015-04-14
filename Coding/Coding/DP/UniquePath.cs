using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
    /// The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
    /// How many possible unique paths are there?

    /// </summary>
    public class UniquePath
    {
        public static uint uniquePaths(int m, int n)
        {
            uint[,] matrix = new uint[m, n];
            if (m == 1 || n == 1)
                return 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            matrix[0, 0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i - 1 >= 0)
                    {
                        matrix[i, j] += matrix[i - 1, j];
                    }

                    if (j - 1 >= 0)
                    {
                        matrix[i, j] += matrix[i, j - 1];
                    }
                }
            }

            return matrix[m - 1, n - 1];

        }

        //public static int uniquePathsII(int[,] matrix, int m, int n)
        public static int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            if (obstacleGrid[0, 0] == 1)
                return 0;

            int m = obstacleGrid.GetLength(0);
            int n = obstacleGrid.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (m == 1 && obstacleGrid[i, j] == 1 || n == 1 && obstacleGrid[i, j] == 1) return 0;
                    Console.Write(obstacleGrid[i, j]);
                    Console.Write(" ");
                    if (obstacleGrid[i, j] == 1)
                    {
                        obstacleGrid[i, j] = int.MinValue;
                    }
                }

                Console.WriteLine();
            }

            obstacleGrid[0, 0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (obstacleGrid[i, j] == int.MinValue && i == m - 1 && j == n - 1) return 0;
                    if (obstacleGrid[i, j] == int.MinValue)
                        continue;
                    if (i - 1 >= 0)
                    {
                        if (obstacleGrid[i - 1, j] != int.MinValue)
                        {
                            obstacleGrid[i, j] += obstacleGrid[i - 1, j];
                        }
                    }

                    if (j - 1 >= 0)
                    {
                        if (obstacleGrid[i, j - 1] != int.MinValue)
                        {
                            obstacleGrid[i, j] += obstacleGrid[i, j - 1];
                        }
                    }
                }
            }

            return obstacleGrid[m - 1, n - 1];
        }

        public static void Test()
        {
            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 2, 2, uniquePaths(2, 2)));

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 4, 4, uniquePaths(4, 4)));

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 3, 3, uniquePaths(3, 3)));

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 4, 5, uniquePaths(4, 5)));
            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 100, 100, uniquePaths(100, 100)));

            int[,] matrix = new int[3, 3] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 3, 3, UniquePathsWithObstacles(matrix)));

            matrix = new int[3, 3] { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 } };

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 3, 3, UniquePathsWithObstacles(matrix)));

            matrix = new int[3, 3] { { 0, 0, 1 }, { 0, 1, 0 }, { 0, 0, 0 } };

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 3, 3, UniquePathsWithObstacles(matrix)));


            matrix = new int[3, 4] { { 0, 0, 0, 0 }, { 0, 1, 0, 0}, { 0, 0, 0, 0} };

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 3, 4, UniquePathsWithObstacles(matrix)));
        }
    }
}
