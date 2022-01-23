using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.Math
{
    public static class Integrate
    {
        public static double Trapezoid(Func<double, double> function, double min, double max, int N)
        {
            var partialSum = new ConcurrentBag<double>();
            double delta = (max - min) / N;
            Parallel.For<double>(1, N, () => 0,
            (k, state, subtotal) => {
                return subtotal += function(min + (k * delta));
            },
            (x) => {
                partialSum.Add(x);
            }
            );
            return (partialSum.Sum() + ((function(min) + function(max)) / 2)) * delta;
        }
    }
}
