namespace Physics.NET.Mathematics.Statistics
{
    public static partial class Statistics
    {
        /// <summary>
        /// Calculates the standard deviation of an array of doubles if the mean <paramref name="μ"/> is known.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="μ"></param>
        /// <returns></returns>
        public static double StandardDeviation(double[] array, double μ)
        {
            double len = array.Length;
            double partialSum = 0;
            for (int i = 0; i < len; i++)
            {
                partialSum += Math.Pow(array[i] - μ, 2);
            }
            return Math.Sqrt(partialSum / array.Length);
        }

        /// <summary>
        /// Calculates the standard deviation of an array of doubles if the average is unknown.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double StandardDeviation(double[] array)
        {
            double ave = Enumerable.Average(array);
            double len = array.Length;
            double partialSum = 0;
            for (int i = 0; i < len; i++)
            {
                partialSum += Math.Pow(array[i] - ave, 2);
            }
            return Math.Sqrt(partialSum / (array.Length - 1));
        }
    }
}
