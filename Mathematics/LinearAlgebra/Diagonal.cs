namespace Physics.NET.Mathematics.LinearAlgebra
{
    /// <summary>
    /// Instantiate a diagonal matrix.
    /// </summary>
    public static class Diagonal
    {
        /// <summary>
        /// Instatiate a 2 x 2 diagonal matrix.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A 2 x 2 matrix with elements <paramref name="a"/> and <paramref name="b"/> along the diagonal.</returns>
        public static MatSq2 MatSq2(Complex a, Complex b)
        {
            return new(new Complex[,] { { a, 0 }, { 0, b } });
        }
    }
}
