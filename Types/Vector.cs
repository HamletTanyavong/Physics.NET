using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.CoordinateSystems;

namespace Physics.Types
{
    /// <summary>
    /// Vectors represented in Cartersian, Polar, Spherical, etc. <typeparamref name="Coordinates"/>.
    /// </summary>
    /// <remarks>
    /// Components must be doubles.
    /// </remarks>
    /// <typeparam name="Coordinates"></typeparam>
    public struct Vector<Coordinates>
        where Coordinates : class
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }

        public Vector(double x1, double x2, double x3 = 0)
        {
            X1 = x1;
            X2 = x2;
            X3 = x3;
        }

        // public static Vector<T> operator +(Vector<T> left, Vector<T> right);

        public Vector<Cartesian> Add(Vector<Cartesian> vector)
        {
            return new Vector<Cartesian>(X1 + vector.X1, X2 + vector.X2, X3 + vector.X3);
        }

        public double Length()
        {
            return System.Math.Sqrt(X1 * X1 + X2 * X2 + X3 * X3);
        }

        public Vector<Cartesian> Normalize()
        {
            var length = Length();
            return new Vector<Cartesian>(X1 / length, X2 / length, X3 / length);
        }

        public ValueTuple<double, double, double> ToTuple()
        {
            return (X1, X2, X3);
        }
    }
}
