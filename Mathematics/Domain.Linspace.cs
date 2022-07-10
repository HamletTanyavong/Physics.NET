namespace Physics.NET.Mathematics
{
    public static partial class Domain
    {
        public static double[] Linspace(double start, double stop, int n, bool endpoint=true)
        {
            double[] result = endpoint ? new double[n] : new double[n - 1];
            int points = endpoint ? n : n - 1;
            double delta = (stop - start) / n;
            for (int i = 0; i < points; i++)
            {
                result[i] = start + (i * delta);
            }
            return result;
        }
    }
}
