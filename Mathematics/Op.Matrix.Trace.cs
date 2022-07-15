namespace Physics.NET.Mathematics
{
    public static partial class Op
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
        }
    }
}
