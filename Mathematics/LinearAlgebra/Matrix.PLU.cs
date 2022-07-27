namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class Matrix
    {
        /// <summary>
        /// Perform LU decomposition using Gaussian elimination with partial pivoting on a <paramref name="matrix"/>. This method does not overwrite the original <paramref name="matrix"/>.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>An array containing the permutation matrix and the lower and upper triangular matricies, respectively.</returns>
        public static double[][,] PLU(double[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int min = Math.Min(m, n);

            double[,] copy = new double[m, n];
            Array.Copy(matrix, copy, m * n);

            double[,] p = new double[m, m];
            Matrix.Populate(p, Elements.Diagonal, 1);
            double[,] l = new double[m, min];
            double[,] u = new double[min, n];

            int h = 0; int k = 0;
            while (h < m && k < n)
            {
                int argMax = ArgMax(h, m, k, copy);

                if (copy[argMax, k] == 0)
                {
                    k++;
                }
                else
                {
                    SwapRows(p, m, k, argMax);
                    SwapRows(l, min, h, argMax);
                    SwapRows(copy, n, h, argMax);
                    l[h, k] = 1;
                    for (int i = h + 1; i < m; i++)
                    {
                        double a = copy[i, k] / copy[h, k];
                        l[i, k] = copy[i, k] / copy[k, k];
                        for (int j = k + 1; j < n; j++)
                        {
                            copy[i, j] = copy[i, j] - copy[h, j] * a;
                        }
                    }
                    h++; k++;
                }
            }

            p = Transpose(p);
            Array.Copy(copy, u, min * n);
            Matrix.Populate(u, Elements.Below, 0);
            double[][,] plu = new double[3][,] { p, l, u };
            return plu;

            static int ArgMax(int start, int stop, int column, double[,] matrix)
            {
                int iMax = start;
                for (int i = start + 1; i < stop; i++)
                {
                    if (Math.Abs(matrix[iMax, column]) < Math.Abs(matrix[i, column]))
                    {
                        iMax = i;
                    }
                }
                return iMax;
            }
            
            static void SwapRows(double[,] matrix, int n, int i, int j)
            {
                for (int k = 0; k < n; k++)
                {
                    double hold = matrix[i, k];
                    matrix[i, k] = matrix[j, k];
                    matrix[j, k] = hold;
                }
            }
        }
    }
}
