using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.CoordinateSystems;

namespace Physics.Types
{
    /// <summary>
    /// Vectors represented in Cartesian, Cylindrical, Spherical, etc. coordinates.
    /// </summary>
    /// <remarks>
    /// Components must be doubles.
    /// </remarks>
    /// <typeparam name="Coordinates"></typeparam>
    public struct Vector<Coordinates>
        where Coordinates : class
    {
        public string CoordinateSystem;
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }

        public Vector(double x1, double x2, double x3 = 0)
        {
            CoordinateSystem = typeof(Coordinates).Name;

            if (typeof(Coordinates).Namespace is not "Physics.CoordinateSystems")
            {
                throw new TypeAccessException($"{CoordinateSystem} is not a valid coordinate system.");
            }

            X1 = x1;
            X2 = x2;
            X3 = x3;
        }

        //public static Vector<Coordinates> operator +(Vector<Coordinates> left, Vector<Coordinates> right);

        public Vector<Coordinates> Add(Vector<Coordinates> vector)
        {
            return new Vector<Coordinates>(X1 + vector.X1, X2 + vector.X2, X3 + vector.X3);
        }

        public double Length()
        {
            if (CoordinateSystem is "Cartesian")
            {
                return System.Math.Sqrt(X1 * X1 + X2 * X2 + X3 * X3);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return System.Math.Sqrt(X1 * X1 + X3 * X3);
            }
            else
            {
                return X1;
            }
        }

        public Vector<Coordinates> Normalize()
        {
            var length = Length();
            if (CoordinateSystem is "Cartesian")
            {
                return new Vector<Coordinates>(X1 / length, X2 / length, X3 / length);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return new Vector<Coordinates>(X1 / length, X2, X3 / length);
            }
            else
            {
                return new Vector<Coordinates>(1, X2, X3);
            }
        }

        public ValueTuple<double, double, double> ToTuple()
        {
            return (X1, X2, X3);
        }
    }
}
