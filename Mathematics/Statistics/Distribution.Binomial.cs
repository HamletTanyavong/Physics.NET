namespace Physics.NET.Mathematics.Statistics
{
    public static partial class Distribution
    {
        /// <summary>
        /// The binomial distribution probability mass function.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <returns>Value of the binomial distribution probability mass function for <paramref name="k"/> successes out of <paramref name="n"/> independent trials, where <paramref name="k"/> has the probability <paramref name="p"/> of success.</returns>
        public static double Binomial(int k, int n, double p)
        {
            return Op.Binomial(n, k) * Math.Pow(p, k) * Math.Pow(1 - p, n - k);
        }
    }
}
