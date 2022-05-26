using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.NET.Mathematics
{
    /// <summary>
    /// General Mathematical Functions.
    /// </summary>
    public static class General
    {
        private static long[] Numerator  = new long[] {1, 1, 1, -139, -571, 163879, 5246819, -534703531, -4483131259, 432261921612371};
        private static long[] Denominator = new long[] {1, 12, 288, 51840, 2488320, 209018880, 75246796800, 902961561600, 86684309913600, 514904800886784000};
        
        /// <summary>
        /// Computes the factorial of <paramref name="n"/> for <paramref name="n"/> less than or equal to 65. For larger values of <paramref name="n"/>, use approximations.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Factorial(int n)
        {
            if (n == 0)
                return 1;
            int result = 1;
            if (n <= 65)
            {
                for (int i = n; i > 1; i--)
                {
                    result *= i;
                }
            }
            else
            {
                throw new ArgumentException("n must be less than or equal to 65");
            }
            return result;
        }

        /// <summary>
        /// Computes the factorial of <paramref name="n"/> using the Stirling approximation to <paramref name="order"/> no more than 9. Use <paramref name="n"/> less than or equal to 142.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static double Stirling(int n, int order)
        {
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
