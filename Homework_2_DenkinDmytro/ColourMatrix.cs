using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//dfgksahdkfa
namespace Homework_2_DenkinDmytro
{
    public class ColourMatrix
    {
        public static void FindLongestColourStartEndIndexLength(int[,] colourMatrix,
                                                                out int colour,
                                                                out int startRowIndex, out int endRowIndex,
                                                                out int startColumnIndex, out int endColumnIndex,
                                                                out int maxLength)
        {
            colour = colourMatrix[0, 0];
            startRowIndex = 0;
            endRowIndex = 0;
            startColumnIndex = 0;
            endColumnIndex = 0;
            maxLength = 1;

            for (int i = 0, leni = colourMatrix.GetLength(0); i < leni; ++i)
            {
                int _length = 1;
                int j = 0;
                int lenj = colourMatrix.GetLength(1);
                int x = 0;
                for (j = x; j < lenj - 1; j = x)
                {
                    for (x = j + 1; x < lenj; ++x)
                    {
                        if (colourMatrix[i, j] == colourMatrix[i, x])
                        {
                            ++_length;
                        }
                        else
                        {
                            endColumnIndex = x;
                            break;
                        }
                    }

                    if (_length > maxLength)
                    {
                        maxLength = _length;

                        colour = colourMatrix[i, j];

                        startRowIndex = i;
                        endRowIndex = i;

                        startColumnIndex = j;
                        endColumnIndex = x - 1;
                    }
                }
            }
        }
    }
}
