namespace Physics.NET.Mathematics.Statistics
{
    public static partial class Statistics
    {
        public delegate double Distribution(int k, int n, double p);

        public static double Probability(Distribution function, int k, int n, double p)
        {
            double partialSum = 0;
            for (int i = 0; i < k; i++)
            {
                partialSum += function(i, n, p);
            }
            return partialSum;
        }
    }
}
