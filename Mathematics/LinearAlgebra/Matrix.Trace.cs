namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class Matrix
    {
        public static double Trace(double[,] matrix)
        {
            if (!IsSquare(matrix))
            {
                throw new ArgumentException("error: matrix is not square");
            }

            double partialSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                partialSum += matrix[i, i];
            }
            return partialSum;
        }

        public static Complex Trace(MatSq2 matrix)
        {
            return matrix[0, 0] + matrix[1, 1];
        }

        public static Complex Trace(MatSq3 matrix)
        {
            return matrix[0, 0] + matrix[1, 1] + matrix[2, 2];
        }

        public static Complex Trace(Complex[,] matrix)
        {
            if (!IsSquare(matrix))
            {
                throw new ArgumentException("error: matrix is not square");
            }

            Complex partialSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                partialSum += matrix[i, i];
            }
            return partialSum;
        }
    }
}
