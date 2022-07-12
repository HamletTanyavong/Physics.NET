namespace Physics.NET.Mathematics.Statistics
{
    public static partial class Distribution
    {
        /// <summary>
        /// The normal distribution probability density function.
        /// </summary>
        /// <param name="μ"></param>
        /// <param name="σ"></param>
        /// <param name="x"></param>
        /// <returns>Value of the normal distribution probability density function at the point <paramref name="x"/> with mean <paramref name="μ"/> and standard deviation <paramref name="σ"/>.</returns>
        public static double Normal(double μ, double σ, double x)
        {
            return (Math.Exp(-1 / 2 * Math.Pow((x - μ) / σ, 2))) / (σ * Math.Sqrt(2 * Math.PI));
        }
    }
}
