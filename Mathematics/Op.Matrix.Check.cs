namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        public static partial class Matrix
        {
            public static bool IsSquare<T>(T[,] matrix)
            {
                return matrix.GetLength(0) == matrix.GetLength(1);
            }
        }
    }
}
