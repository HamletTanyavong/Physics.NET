namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        /// <summary>
        /// Compute the factorial of a double <paramref name="n"/>. For large values of <paramref name="n"/>, use approximations.
        /// </summary>
        /// <param name="n"></param>
        /// <returns><paramref name="n"/> factorial as a double</returns>
        public static double Factorial(int n)
        {
            if (n == 0)
                return 1d;
            double result = 1;
            if (n <= 170)
            {
                for (double i = n; i > 1; i--)
                {
                    result *= i;
                }
            }
            else
            {
                throw new ArgumentException("error: n is too large, try using Stirling's approximation");
            }
            return result;
        }

        /// <summary>
        /// Compute the factorial of <paramref name="n"/> using the Stirling approximation to <paramref name="order"/> no more than 9.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="order"></param>
        /// <returns>Stirling's approximation of the factorial of <paramref name="n"/>.</returns>
        public static double Stirling(int n, int order)
        {
            if (order > 9)
            {
                throw new ArgumentException("error: choose an order less than 10");
            }
            if (n > 142)
            {
                throw new ArgumentException("error: choose n less than or equal to 142");
            }

            long[] Numerator = new long[] { 1, 1, 1, -139, -571, 163879, 5246819, -534703531, -4483131259, 432261921612371 };
            long[] Denominator = new long[] { 1, 12, 288, 51840, 2488320, 209018880, 75246796800, 902961561600, 86684309913600, 514904800886784000 };

            double constant = Math.Sqrt(2 * Math.PI * n) * Math.Pow(n, n) / Math.Pow(Math.E, n);
            double series = 0;
            for (int i = 0; i <= order; i++)
            {
                series += (Numerator[i]) / (Denominator[i] * Math.Pow(n, i));
            }
            return constant * series;
        }
    }
}
