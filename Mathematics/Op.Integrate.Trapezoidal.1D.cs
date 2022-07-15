using System.Collections.Concurrent;

namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        /// <summary>
        /// Integrate functions using various methods.
        /// </summary>
        public static partial class Integrate
        {
            /// <summary>
            /// Integrate a one-dimensional <paramref name="function"/> using the trapezoidal rule with <paramref name="N"/> points.
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <param name="N"></param>
            /// <param name="function"></param>
            /// <returns>The value of the integral between the bounds <paramref name="a"/> and <paramref name="b"/>.</returns>
            public static double Trapezoidal(Func<double, double> function, double a, double b, int N)
            {
                if (N < 1)
                {
                    throw new ArgumentException($"error: number of partitions N must be an integer greater than zero");
                }

                double partialSum = 0;
                double delta = (b - a) / N;
                for (int i = 1; i < N; i++)
                {
                    partialSum += function(a + (i * delta));
                }
                return (partialSum + ((function(a) + function(b)) / 2)) * delta;
            }

            /// <summary>
            /// Parallel integrate a one-dimensional <paramref name="function"/> using the trapezoidal rule with <paramref name="N"/> points and a specified amount of <paramref name="threads"/>.
            /// </summary>
            /// <remarks>
            /// <para>Threads must not exceed total threads available minus 2.</para>
            /// </remarks>
            /// <param name="function">One-dimensional function to be integrated.</param>
            /// <param name="a">Lower integration bound.</param>
            /// <param name="b">Upper integration bound.</param>
            /// <param name="N">N must be an integer greater than zero.</param>
            /// <param name="threads"></param>
            /// <exception cref="ResolutionException"></exception>
            /// <returns>The value of the integral between the bounds <paramref name="a"/> and <paramref name="b"/>.</returns>
            public static double Trapezoidal(Func<double, double> function, double a, double b, int N, int threads)
            {
                if (N < 1)
                {
                    throw new ArgumentException($"error: number of partitions N must be an integer greater than zero");
                }
                if (threads > Environment.ProcessorCount - 2)
                {
                    throw new ArgumentException($"error: {threads} exceeds recommended value");
                }

                var partialSum = new ConcurrentBag<double>();
                double delta = (b - a) / N;
                Parallel.For<double>(1, N, new ParallelOptions() { MaxDegreeOfParallelism = threads },
                    () => 0,
                    (k, loop, subtotal) => { return subtotal += function(a + (k * delta)); },
                    (result) => partialSum.Add(result)
                );
                return (partialSum.Sum() + ((function(a) + function(b)) / 2)) * delta;
            }
        }
    }
}
