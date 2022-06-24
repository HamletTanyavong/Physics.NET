namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        /// <summary>
        /// Integrate a 2D <paramref name="function"/> in cartesian coordinates with <paramref name="N"/> points uniformly sampled from a <paramref name="domain"/>. Provide bounds to the sample area with <paramref name="rangeX"/> and <paramref name="rangeY"/>. The <paramref name="domain"/> must be a method that takes in variables x and y and returns a boolean; the method should return true if the points sampled are inside the <paramref name="domain"/>.
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="function"></param>
        /// <param name="rangeX"></param>
        /// <param name="rangeY"></param>
        /// <param name="N"></param>
        /// <returns>Value of a 2D definite integral.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double Integrate(Func<double, double, bool> domain, Func<double, double, double> function, ValueTuple<string, double, double> rangeX, ValueTuple<string, double, double> rangeY, int N)
        {
            if (rangeX.Item2 > rangeX.Item3 || rangeY.Item2 > rangeY.Item3)
            {
                throw new ArgumentException("error: invalid bounds");
            }

            Random random = Session._Random;

            double m_x = rangeX.Item3 - rangeX.Item2;
            double b_x = rangeX.Item2;
            double m_y = rangeY.Item3 - rangeY.Item2;
            double b_y = rangeY.Item2;

            double partialSum = 0;

            for (int i = 0; i < N; i++)
            {
                double x = random.NextDouble() * m_x + b_x;
                double y = random.NextDouble() * m_y + b_y;

                if (domain(x, y))
                {
                    partialSum += function(x, y);
                }
            }
            double Area = (rangeX.Item3 - rangeX.Item2) * (rangeY.Item3 - rangeY.Item2);
            return partialSum * Area / N;
        }

        /// <summary>
        /// Parallel integrate a 2D <paramref name="function"/> in cartesian coordinates with points uniformly sampled from a <paramref name="domain"/>. The total number of points used is <paramref name="N"/> times the number of <paramref name="threads"/> specified. Provide bounds to the sample area with <paramref name="rangeX"/> and <paramref name="rangeY"/>. The <paramref name="domain"/> must be a method that takes in variables x and y and returns a boolean; the method should return true if the points sampled are inside the <paramref name="domain"/>.
        /// </summary>
        /// <remarks>
        /// It is recomended not to specify more threads than are available on the current system.
        /// </remarks>
        /// <param name="domain"></param>
        /// <param name="function"></param>
        /// <param name="rangeX"></param>
        /// <param name="rangeY"></param>
        /// <param name="N"></param>
        /// <param name="threads"></param>
        /// <returns>Value of a 2D definite integral.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double Integrate(Func<double, double, bool> domain, Func<double, double, double> function, ValueTuple<string, double, double> rangeX, ValueTuple<string, double, double> rangeY, int N, int threads)
        {
            if (threads > Environment.ProcessorCount)
            {
                throw new ArgumentException($"error: {threads} exceeds available threads");
            }

            if (rangeX.Item2 > rangeX.Item3 || rangeY.Item2 > rangeY.Item3)
            {
                throw new ArgumentException("error: invalid bounds");
            }

            Random random = Session._Random;

            List<Task<double>> Tasks = new();
            for (int i = 0; i < threads; i++)
            {
                int seed = random.Next();
                Tasks.Add(Task<double>.Run(() => ParallelIntegrateComponent(seed, domain, function, rangeX, rangeY, N)));
            }
            Task.WhenAll(Tasks);

            double partialSum = 0;
            foreach (var task in Tasks)
            {
                partialSum += task.Result;
            }
            double Area = (rangeX.Item3 - rangeX.Item2) * (rangeY.Item3 - rangeY.Item2);
            return partialSum * Area / (N * threads);
        }

        private static double ParallelIntegrateComponent(int seed, Func<double, double, bool> domain, Func<double, double, double> function, ValueTuple<string, double, double> rangeX, ValueTuple<string, double, double> rangeY, int N)
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
            double Area = (rangeX.Item3 - rangeX.Item2) * (rangeY.Item3 - rangeY.Item2);
            return partialSum * Area / N;
        }
    }
}
