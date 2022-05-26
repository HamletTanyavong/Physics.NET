using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.NET.Units.SI;
using Physics.NET.Mathematics;
using Physics.NET.Mathematics.Vectors;

namespace Physics.NET.Mathematics.DifferentialGeometry.Metrics
{
    /// <summary>
    /// The metric for a gravitiational field created by an object of mass M, assuming no angular momentum or electric charge. Signature (-1, 1, 1, 1).
    /// </summary>
    public class Schwarzschild : IMetric
    {
        /// <summary>
        /// Calculate the value of a metric at a specific point in spacetime.
        /// </summary>
        /// <param name="M"></param>
        /// <param name="fourvector"></param>
        /// <returns></returns>
        internal static double[,] Calculate<T>(double M, FourVector<T> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            var schwarzschildRadius = 2 * Constant.G * M / Constant.cSquared;
            return Matrix.Diagonal
            (
                schwarzschildRadius / fourvector.First - 1,
                1 / (1 - schwarzschildRadius / fourvector.First),
                fourvector.First * fourvector.First,
                fourvector.First * fourvector.First * Math.Pow(Math.Sin(fourvector.Second), 2)
            );
        }
    }
}
