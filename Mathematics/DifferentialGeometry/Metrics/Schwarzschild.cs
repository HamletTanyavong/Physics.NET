using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.Mathematics;

namespace Physics.Mathematics.DifferentialGeometry.Metrics
{
    /// <summary>
    /// The metric for a gravitiational field created by an object of mass M, assuming no angular momentum or electric charge.
    /// </summary>
    public class Schwarzschild : IMetric
    {
        public static double[,] Schwarzschild(FourVector fourvector, double M)
        {
            return Matrix.Diagonal
            (
                -1 * (1 - (Constant.G * M) / (Constant.c * Constant.c * fourvector.First)),
                1 / (1 - (Constant.G * M) / (Constant.c * Constant.c * fourvector.First)),
                fourvector.First * fourvector.First,
                fourvector.First * fourvector.First * Math.Pow(Math.Sin(fourvector.Second), 2)
            );
        }
    }
}
