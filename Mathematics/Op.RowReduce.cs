namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        /// <summary>
        /// Perform Gaussian elimination with partial pivoting on a <paramref name="matrix"/>.
        /// </summary>
        /// <param name="matrix"></param>
        public static void RowReduce(double[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int h = 0; int k = 0;

            while (h < m && k < n)
            {
                int iMax = ArgMax(h, m, k, matrix);

                if (matrix[iMax, k] == 0)
                {
                    k++;
                }
                else
                {
                    SwapRows(matrix, n, h, iMax);
                    for (int i = h + 1; i < m; i++)
                    {
                        double a = matrix[i, k] / matrix[h, k];
                        matrix[i, k] = 0;
                        for (int j = k + 1; j < n; j++)
                        {
                            matrix[i, j] = matrix[i, j] - matrix[h, j] * a;
                        }
                    }
                    h++; k++;
                }
            }

            static int ArgMax(int start, int stop, int column, double[,] matrix)
            {
                int iMax = start;
                for (int i = start + 1; i < stop; i++)
                {
                    if (matrix[iMax, column] < matrix[i, column])
                    {
                        iMax = i;
                    }
                }
                return iMax;
            }

            static void SwapRows(double[,] array, int n, int i, int j)
            {
                double hold;
                for (int k = 0; k < n; k++)
                {
                    hold = array[i, k];
                    array[i, k] = array[j, k];
                    array[j, k] = hold;
                }
            }
        }
    }
}
