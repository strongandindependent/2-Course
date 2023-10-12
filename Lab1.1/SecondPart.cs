using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class SecondPart
    {
        private readonly int[,] matrix;

        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + " or " + nameof(cols));
            }

            matrix = new int[rows, cols];

            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }
        }

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
        }


        public int ColsWithZerosCount()
        {
            int counter = matrix.GetLength(0);

            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[i, j] >= 0)
                    {
                        counter--;
                        break;
                    }
                }
            }

            return counter;
        }

        public int GetMaxRepeatingNumber()
        {
            int maxSeriesLen = 1;
            int maxSeriesIdx = 0;
            for (int i = 0; i < matrix.Length; ++i)
            {
                int q = 1;
                int t = 0;
                for (int j = 0; j < matrix.Length; ++j)
                {
                    if (matrix[i, j] == matrix[i, j + 1]) ++t;

                    if (t > q) q = t;
                    else t = 1;

                    if (q > maxSeriesLen)
                    {
                        maxSeriesIdx = i;
                        maxSeriesLen = q;
                    }

                }

            }
            return maxSeriesLen;


        }

    }
}