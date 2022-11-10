using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_DenkinDmytro
{
    public class RectangularMatrixService
    {
        public int[,] FillVerticalSnake(int n, int m)
        {
            int[,] resMatrix = new int[n, m];

            int number = 1;

            // Main loop through columns, that's why i < m
            for (int i = 0; i < m; ++i)
            {
                // Loop from top to bottom row
                for (int j = 0; j < n; ++j)
                {
                    resMatrix[j, i] = number++;
                }

                // Without this check __++i and then access by it__ throw the System.IndexOutOfRangeException
                if (i + 1 != m)
                {
                    ++i;

                    // Loop from bottom to top row, that's why k = n - 1; k >= 0;
                    for (int k = n - 1; k >= 0; --k)
                    {
                        resMatrix[k, i] = number++;
                    }
                }
            }

            return resMatrix;
        }

        // http://cppstudio.com/post/4991/
        // https://habr.com/ru/post/672198/
        public int[,] FillDiagonalSnakeSquare(int n, int m)
        {
            int[,] resMatrix = new int[n, m];

            // This method should only work with a square matrix
            if (n != m)
            {
                throw new ArgumentException("Arguments n and m must be equal. Matrix must be square. n == m");
            }

            if (n == m)
            {
                int i = 0;
                int j = 0;
                int number = 1;

                // Loop through the first half, from top-left to antidiagonal incl.
                for (int d = 0; d < n; ++d)
                {
                    // Even -- парний
                    if ((d & 1) == 0)
                    {
                        // filling diagonal starts at the bottom
                        i = d;
                        j = 0;

                        while (i >= 0)
                        {
                            resMatrix[i, j] = number++;
                            --i;
                            ++j;
                        }
                    }
                    else
                    {
                        // filling diagonal starts at the top
                        i = 0;
                        j = d;

                        while (j >= 0)
                        {
                            resMatrix[i, j] = number++;
                            ++i;
                            --j;
                        }
                    }
                }

                // Loop through the second half, from the next diagonal after the antidiagonal to bottom-right.
                for (int d = 1; d < n; ++d)
                {
                    if ((n & 1) == 0)
                    {
                        // Even -- парний
                        if ((d & 1) == 0)
                        {
                            // filling diagonal starts at the top
                            i = d;
                            j = n - 1;

                            while (i <= n - 1)
                            {
                                resMatrix[i, j] = number++;
                                ++i;
                                --j;
                            }
                        }
                        else
                        {
                            // filling diagonal starts at the bottom
                            i = n - 1;
                            j = d;

                            while (j <= n - 1)
                            {
                                resMatrix[i, j] = number++;
                                --i;
                                ++j;
                            }
                        }
                    }
                    else
                    {
                        // Even -- парний
                        if ((d & 1) == 0)
                        {
                            // filling diagonal starts at the bottom
                            i = n - 1;
                            j = d;

                            while (j <= n - 1)
                            {
                                resMatrix[i, j] = number++;
                                --i;
                                ++j;
                            }
                        }
                        else
                        {
                            // filling diagonal starts at the top
                            i = d;
                            j = n - 1;

                            while (i <= n - 1)
                            {
                                resMatrix[i, j] = number++;
                                ++i;
                                --j;
                            }
                        }
                    }
                }
            }

            return resMatrix;
        }

        public int[,] FillSpiralSnake(int n, int m)
        {
            int[,] resMatrix = new int[n, m];

            int squeeze = 0;

            for (int number = 1; number <= n * m; )
            {
                int col = squeeze;

                // Fill from top to bottom, i. e. left lines
                for (int topdown = squeeze; topdown < n - squeeze; ++topdown)
                {
                    resMatrix[topdown, col] = number++;
                }

                ++squeeze;

                int row = n - squeeze;

                // Fill from left to right, i. e. bottom lines
                for (int leftright = col + 1; leftright <= m - squeeze; ++leftright)
                {
                    resMatrix[row, leftright] = number++;
                }

                col = m - squeeze;

                // Fill from down to top, i. e. right lines
                // TODO: downtop >= squeeze - 1; fails when n > m
                for (int downtop = row - 1; downtop >= squeeze - 1; --downtop)
                {
                    // I have no idea how to handle (n > m) case properly with my algorithm, so this condition saves it
                    if (resMatrix[downtop, col] != 0)
                    {
                        break;
                    }

                    resMatrix[downtop, col] = number++;
                }

                row = squeeze - 1;

                // Fill from right to left, i. e. top lines
                for (int rightleft = col - 1; rightleft >= squeeze; --rightleft)
                {
                    resMatrix[row, rightleft] = number++;
                }
            }

            return resMatrix;
        }

        public string MatrixToString(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    sb.Append(matrix[i, j] + " ");
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}
