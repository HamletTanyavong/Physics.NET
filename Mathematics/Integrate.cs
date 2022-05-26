using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.NET.Exceptions;
using Physics.NET.Types;

namespace Physics.NET.Mathematics
{
    /// <summary>
    /// Numerical integration methods for physics calculations.
    /// </summary>
    public static class Integrate
    {
        public static double Trapezoidal(Func<double, double> function, double a, double b, int N)
        {
            try
            {
                double partialSum = 0;
                double delta = (b - a) / N;
                for (int i = 1; i < N; i++)
                {
                    partialSum += function(a + (i * delta));
                }
                return (partialSum + ((function(a) + function(b)) / 2)) * delta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Integrate a one-dimensional <paramref name="function"/> using the trapezoidal rule.
        /// </summary>
        /// <remarks>
        /// <para>This method utilizes parallel computing to quicken integration but may use more system memory. For a system with 16 processors, the parellel method is quicker than sequential methods for roughly <paramref name="N"/> greater than 250000.</para>
        /// </remarks>
        /// <param name="function">One-dimensional function to be integrated.</param>
        /// <param name="a">Lower integration bound.</param>
        /// <param name="b">Upper integration bound.</param>
        /// <param name="N">N must be an integer greater than zero.</param>
        /// <exception cref="ResolutionException"></exception>
        /// <returns>The value of the integral between the bounds <paramref name="a"/> and <paramref name="b"/>.</returns>
        public static double Trapezoidal(Func<double, double> function, double a, double b, int N, string parallel)
        {
            try
            {
                if (N < 1)
                {
                    throw new ResolutionException($"The number of partitions N must be an integar and greater than zero.", N);
                }
                if (parallel is "CPU")
                {
                    var partialSum = new ConcurrentBag<double>();
                    double delta = (b - a) / N;
                    Parallel.For<double>(1, N, () => 0,
                        (k, loopState, subtotal) =>
                        {
                            return subtotal += function(a + (k * delta));
                        },
                        (result) =>
                        {
                            partialSum.Add(result);
                        });
                    return (partialSum.Sum() + ((function(a) + function(b)) / 2)) * delta;
                }
                else if (parallel is "GPU")
                {
                    Console.WriteLine("GPU implementation not ready");
                    return double.NaN;
                }
                else
                {
                    throw new ArgumentException("Must specifiy either 'CPU' or 'GPU' for parallelization");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Monte Carlo method of integration for multivariable integrals with importance sampling.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="N"></param>
        public static double MonteCarlo(Func<double, double> function, double a, double b, int N)
        {
            var partialSum = new ConcurrentBag<double>();
            Parallel.For<double>(0, N, () => 0,
                (k, state, subtotal) =>
                {
                    return subtotal += function(a + k);
                },
                (x) =>
                {
                    partialSum.Add(x);
                }
            );
            return double.NaN;
        }

        public static double MonteCarlo(Func<double, double, double> function, Domain domain, int N)
        {
            return double.NaN;
        }
    }
}
