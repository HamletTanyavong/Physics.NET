using System.Collections.Concurrent;

namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        public static double Integrate(Func<double, double, bool> domain, Func<double, double, double> function, ValueTuple<string, double, double> rangeX, ValueTuple<string, double, double> rangeY, int N)
        {
            if (rangeX.Item2 > rangeX.Item3 || rangeY.Item2 > rangeY.Item3)
            {
                throw new ArgumentException("error: invalid bounds");
            }

            Random random = Session._Random;

            double mx = rangeX.Item3 - rangeX.Item2;
            double bx = rangeX.Item2;
            double my = rangeY.Item3 - rangeY.Item2;
            double by = rangeY.Item2;

            double Area = (rangeX.Item3 - rangeX.Item2) * (rangeY.Item3 - rangeY.Item2);
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

        public static double Integrate(Func<double, double, bool> domain, Func<double, double, double> function, ValueTuple<string, double, double> rangeX, ValueTuple<string, double, double> rangeY, int N, int threads)
        {
            if (threads > Environment.ProcessorCount)
            {
                throw new ArgumentException($"error: {threads} exceeds threads available on computer");
            }

            if (rangeX.Item2 > rangeX.Item3 || rangeY.Item2 > rangeY.Item3)
            {
                throw new ArgumentException("error: invalid bounds");
            }

            Random random = Session._Random;
            double Area = (rangeX.Item3 - rangeX.Item2) * (rangeY.Item3 - rangeY.Item2);

            List<Task<double>> Tasks = new();
            for (int i = 0; i < threads; i++)
            {
                int seed = random.Next();
                Tasks.Add(Task<double>.Run(() => PartialIntegrate(seed, domain, function, rangeX, rangeY, N)));
            }
            Task.WhenAll(Tasks);

            double partialSum = 0;
            foreach (var task in Tasks)
            {
                partialSum += task.Result;
            }
            return partialSum * Area / (N * threads);
        }

        private static double PartialIntegrate(int seed, Func<double, double, bool> domain, Func<double, double, double> function, ValueTuple<string, double, double> rangeX, ValueTuple<string, double, double> rangeY, int N)
        {
            Random random = new(seed * Guid.NewGuid().GetHashCode());

            double m_x = rangeX.Item3 - rangeX.Item2;
            double b_x = rangeX.Item2;
            double m_y = rangeY.Item3 - rangeY.Item2;
            double b_y = rangeY.Item2;

            double subtotal = 0;
            for (int i = 0; i < N; i++)
            {
                double x = random.NextDouble() * m_x + b_x;
                double y = random.NextDouble() * m_y + b_y;

                if (domain(x, y))
                {
                    subtotal += function(x, y);
                }
            }
            return subtotal;
        }

        public static double Integrate(Func<Vector2D<Cartesian>, bool> domain, Func<Vector2D<Cartesian>, double> function, ValueTuple<string, double, double> rangeX, ValueTuple<string, double, double> rangeY, int N)
        {
            if (rangeX.Item2 > rangeX.Item3 || rangeY.Item2 > rangeY.Item3)
            {
                throw new ArgumentException("error: invalid bounds");
            }

            Random random = Session._Random;

            double mx = rangeX.Item3 - rangeX.Item2;
            double bx = rangeX.Item2;
            double my = rangeY.Item3 - rangeY.Item2;
            double by = rangeY.Item2;

            double Area = (rangeX.Item3 - rangeX.Item2) * (rangeY.Item3 - rangeY.Item2);
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
