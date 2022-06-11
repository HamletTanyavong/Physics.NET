namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        public static double Integrate(Func<double, double, bool> domain, Func<double, double, double> function, ValueTuple<string, double, double> rangeX, ValueTuple<string, double, double> rangeY, int N)
        {
            Random random = new();

            if (rangeX.Item2 > rangeX.Item3 || rangeY.Item2 > rangeY.Item3)
            {
                throw new ArgumentException("error: invalid bounds");
            }

            double mx = rangeX.Item3 - rangeX.Item2;
            double bx = rangeX.Item2;
            double my = rangeY.Item3 - rangeY.Item2;
            double by = rangeY.Item2;

            double Area = rangeX.Item3 - rangeX.Item2 * rangeY.Item3 - rangeY.Item2;
            double partialSum = 0;

            for (int i = 0; i < N; i++)
            {
                double x = random.NextDouble() * mx + bx;
                double y = random.NextDouble() * my + by;

                if (domain(x, y))
                {
                    partialSum += function(x, y);
                }
            }
            return partialSum * Area / N;
        }

        public static double Integrate(Func<Vector2D<Cartesian>, bool> domain, Func<Vector2D<Cartesian>, double> function, ValueTuple<string, double, double> rangeX, ValueTuple<string, double, double> rangeY, int N)
        {
            Random random = new();

            if (rangeX.Item2 > rangeX.Item3 || rangeY.Item2 > rangeY.Item3)
            {
                throw new ArgumentException("error: invalid bounds");
            }

            double mx = rangeX.Item3 - rangeX.Item2;
            double bx = rangeX.Item2;
            double my = rangeY.Item3 - rangeY.Item2;
            double by = rangeY.Item2;

            double Area = rangeX.Item3 - rangeX.Item2 * rangeY.Item3 - rangeY.Item2;
            double partialSum = 0;

            Vector2D<Cartesian> input = new();

            for (int i = 0; i < N; i++)
            {
                double x = random.NextDouble() * mx + bx;
                double y = random.NextDouble() * my + by;

                input.X1 = x;
                input.X2 = y;

                if (domain(input))
                {
                    partialSum += function(input);
                }
            }
            return partialSum * Area / N;
        }
    }
}
