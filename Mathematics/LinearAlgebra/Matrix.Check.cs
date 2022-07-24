namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class Matrix
    {
        /// <summary>
        /// Check if a matrix is square.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns>True if the matrix is square.</returns>
        public static bool IsSquare<T>(T[,] matrix)
        {
            return matrix.GetLength(0) == matrix.GetLength(1);
        }

        /// <summary>
        /// Checks if matricies <paramref name="a"/> and <paramref name="b"/> can be added or subtracted from one another.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> can undergo addition and subtraction.</returns>
        public static bool CanAddSubtract<T>(T[,] a, T[,] b)
        {
            return a.GetLength(0) == b.GetLength(0) && a.GetLength(1) == b.GetLength(1);
        }

        /// <summary>
        /// Checks if matricies <paramref name="a"/> and <paramref name="b"/> can undergo matrix multiplication.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> can be multiplied.</returns>
        public static bool CanMultiply<T>(T[,] a, T[,] b)
        {
            return a.GetLength(1) == b.GetLength(0);
        }
    }
}
