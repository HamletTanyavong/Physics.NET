namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class Matrix
    {
        /// <summary>
        /// Transpose a 2 x 2 <paramref name="matrix"/> with overwrite.
        /// </summary>
        /// <param name="matrix"></param>
        public static void Transpose(MatSq2 matrix)
        {
            Complex hold = matrix[0, 1];
            matrix[0, 1] = matrix[1, 0];
            matrix[1, 0] = hold;
        }

        public static void Transpose(MatSq2 matrix, out MatSq2 tMatrix)
        {
            tMatrix = new();
            tMatrix[0, 0] = matrix[0, 0];
            tMatrix[0, 1] = matrix[1, 0];
            tMatrix[1, 0] = matrix[0, 1];
            tMatrix[1, 1] = matrix[1, 1];
        }

        /// <summary>
        /// Transpose a 3 x 3 <paramref name="matrix"/> with overwrite.
        /// </summary>
        /// <param name="matrix"></param>
        public static void Transpose(MatSq3 matrix)
        {
            Complex hold = matrix[0, 1];
            matrix[0, 1] = matrix[1, 0];
            matrix[1, 0] = hold;

            hold = matrix[0, 2];
            matrix[0, 2] = matrix[2, 0];
            matrix[2, 0] = hold;

            hold = matrix[1, 2];
            matrix[1, 2] = matrix[2, 1];
            matrix[2, 1] = hold;
        }

        public static void Transpose(MatSq3 matrix, out MatSq3 tMatrix)
        {
            tMatrix = new();
            tMatrix[0, 0] = matrix[0, 0];
            tMatrix[0, 1] = matrix[1, 0];
            tMatrix[1, 0] = matrix[0, 1];
            tMatrix[1, 1] = matrix[1, 1];
        }

        /// <summary>
        /// Transpose an m x n <paramref name="matrix"/>.
        /// </summary>
        /// <param name="matrix"></param>
        public static double[,] Transpose(double[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            double[,] result = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = matrix[j, i];
                }
            }
            return result;
        }

        private static void TransposeElement<T>(T[,] mat, int i, int j)
        {
            T hold = mat[i, j];
            mat[i, j] = mat[j, i];
            mat[j, i] = hold;
        }
    }
}
