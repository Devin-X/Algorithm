using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing all ones and return its area. 
    /// </summary>
    class MaxRectangle
    {
        

        public static int getMaxRectangle(char[,] matrix)
        {
            int len = matrix.GetLength(1);
            int[] left = new int[matrix.GetLength(1)];
            int[] right = new int[matrix.GetLength(1)];
            int[] height = new int[matrix.GetLength(1)];
            int currentLeft = 0;
            int currentRight = len;

            for (int i = 0; i < len; i++)
            {
                left[i] = 0;
                right[i] = len;
                height[i] = 0;
            }

            int maxArea = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                currentLeft = 0;
                currentRight = len;

                for(int j = 0; j < len; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                    if (matrix[i,j] == '1') height[j]++;
                    else height[j] = 0;
                }
                Console.WriteLine();

                for(int j = 0; j < len; j++)
                {
                    if(matrix[i,j] == '1') left[j] = Math.Max(left[j], currentLeft);
                    else { currentLeft = j+1; left[j] = 0; }

                    Console.Write(left[j] + " ");
                }
                Console.WriteLine();

                for(int j = len-1; j >= 0; j--)
                {
                    if (matrix[i, j] == '1') right[j] = Math.Min(right[j], currentRight);
                    else { currentRight = j; right[j] = len; }
                    
                }


                for(int j = 0; j < len; j++)
                {
                    Console.Write(right[j] + " ");
                    maxArea = Math.Max(maxArea, (right[j] - left[j]) * height[j]);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            return maxArea;
        }

        public static void Test()
        {
            char[,] matrix = new char[,] { 
            {'0','1','0','1','1', '1'},
            {'0','1','0','1','1', '1'},
            {'0','1','0','1','1', '1'},
            {'0','1','0','1','1', '1'},
            {'0','1','0','1','1', '1'},
            {'0','1','0','1','1', '1'},
            {'0','1','0','1','1', '1'},};

            Console.WriteLine(getMaxRectangle(matrix));


            matrix = new char[,] { 
            {'0','1','0','1','1', '1'},
            {'0','1','0','0','1', '1'},
            {'0','0','0','1','0', '1'},
            {'0','1','1','1','1', '0'},
            {'1','1','0','1','1', '1'},
            {'1','1','0','1','1', '1'},
            {'1','1','0','1','1', '1'},};

            Console.WriteLine(getMaxRectangle(matrix));
        }
    }
}
