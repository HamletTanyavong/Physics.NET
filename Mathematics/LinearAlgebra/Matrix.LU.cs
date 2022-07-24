namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class Matrix
    {
        /// <summary>
        /// Perform LU decomposition using Gaussian elimination with partial pivoting on a <paramref name="matrix"/>.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>An array containing the lower and upper triangular matricies, respectively.</returns>
        public static double[][,] LU(in double[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            double[,] l = new double[m, n];
            double[,] u = matrix;

            double[][,] lu = new double[2][,] { l, u };

            int h = 0; int k = 0;

            while (h < m && k < n)
            {
                int argMax = ArgMax(h, m, k, u);

                if (u[argMax, k] == 0)
                {
                    k++;
                }
                else
                {
                    SwapRows(l, u, n, h, argMax);
                    for (int i = h + 1; i < m; i++)
                    {
                        double a = u[i, k] / u[h, k];
                        l[i, k] = u[i, k] / u[k, k];
                        u[i, k] = 0;
                        for (int j = k + 1; j < n; j++)
                        {
                            u[i, j] = u[i, j] - u[h, j] * a;
                        }
                    }
                    h++; k++;
                }
            }

            return lu;

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

            static void SwapRows(double[,] l, double[,] u, int n, int i, int j)
            {
                for (int k = 0; k < n; k++)
                {
                    double hold = l[i, k];
                    l[i, k] = l[j, k];
                    l[j, k] = hold;

                    hold = u[i, k];
                    u[i, k] = u[j, k];
                    u[j, k] = hold;
                }
            }
        }
    }
}
