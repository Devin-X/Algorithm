using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class MinPath
    {
        public static int minPathSum(int[,] grid, int m, int n)
        {

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(grid[i, j]);
                    Console.Write(" ");
                    if (i - 1 >= 0 && j-1 < 0)
                    {
                        grid[i, j] += grid[i - 1, j];
                    }

                    if (j - 1 >= 0 && i - 1 < 0)
                    {
                        grid[i, j] += grid[i, j - 1];
                    }

                    if(i-1 >= 0 && j-1 >= 0)
                    {
                        grid[i, j] = Math.Min(grid[i - 1, j] + grid[i, j], grid[i, j - 1] + grid[i, j]);
                    }
                }

                Console.WriteLine();
            }

            return grid[m - 1, n - 1];
        }

        public static void Test()
        {
            int[,] matrix = new int[3, 4] { 
            { 0, 0, 0, 0 }, 
            { 0, 1, 0, 0 }, 
            { 0, 0, 0, 0 } };

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 3, 4, minPathSum(matrix, 3, 4)));


            matrix = new int[3, 4] { 
            { 1, 2, 0, 2 }, 
            { 0, 1, 0, 0 }, 
            { 1, 0, 1, 0 } };

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 3, 4, minPathSum(matrix, 3, 4)));


            matrix = new int[3, 4] { 
            { 0, 0, 1, 0 }, 
            { 0, 1, 0, 0 }, 
            { 1, 0, 0, 0 } };

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 3, 4, minPathSum(matrix, 3, 4)));


            matrix = new int[3, 4] { 
            { 2, 3, 1, 1 }, 
            { 6, 1, 7, 9 }, 
            { 1, 0, 0, 0 } };

            Console.WriteLine(string.Format("{0} * {1}  --> {2}", 3, 4, minPathSum(matrix, 3, 4)));
        }
    }
}
