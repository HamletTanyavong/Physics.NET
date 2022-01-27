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
    public struct Vector<Coordinates> : IEquatable<Vector<Coordinates>>
        where Coordinates : class
    {
        private static string? CoordinateSystem;

        public double X { get; set; } = double.NaN;
        public double Y { get; set; } = double.NaN;
        public double Z { get; set; } = double.NaN;

        public double R { get; set; } = double.NaN;
        public double Theta { get; set; } = double.NaN;
        public double Phi { get; set; } = double.NaN;
        
        public Vector(double x1, double x2, double x3 = 0)
        {
            CoordinateSystem = typeof(Coordinates).Name;

            if (typeof(Coordinates).Namespace is not "Physics.CoordinateSystems")
            {
                throw new TypeAccessException($"{CoordinateSystem} is not a valid coordinate system.");
            }

            if (CoordinateSystem is "Cartesian")
            {
                X = x1;
                Y = x2;
                Z = x3;
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                R = x1;
                Theta = x2;
                Z = x3;
            }
            else
            {
                R = x1;
                Theta = x2;
                Phi = x3;
            }
        }

        public static Vector<Coordinates> operator +(Vector<Coordinates> left, Vector<Coordinates> right)
        {
            if (CoordinateSystem is "Cartesian")
            {
                return new Vector<Coordinates>(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return new Vector<Coordinates>(System.Math.Sqrt(left.R * left.R + right.R * right.R + 2 * left.R * right.R * Math.Cos(right.Theta - left.Theta)), left.Theta + Math.Atan2(right.R * Math.Sin(right.Theta - left.Theta), left.R + right.R * Math.Cos(right.Theta - left.Theta)), left.Z + right.Z);
            }
            else
            {
                return new Vector<Coordinates>(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
            }
        }

        public static Vector<Coordinates> operator -(Vector<Coordinates> left, Vector<Coordinates> right)
        {
            return new Vector<Coordinates>(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vector<Coordinates> operator *(double left, Vector<Coordinates> vector)
        {
            return new Vector<Coordinates>(left * vector.X, left * vector.Y, left * vector.Z);
        }

        public static Vector<Coordinates> operator *(Vector<Coordinates> vector, double right)
        {
            return new Vector<Coordinates>(right * vector.X, right * vector.Y, right * vector.Z);
        }

        public Vector<Coordinates> Add(Vector<Coordinates> vector)
        {
            return new Vector<Coordinates>(X + vector.X, Y + vector.Y, Z + vector.Z);
        }

        public double Length()
        {
            if (CoordinateSystem is "Cartesian")
            {
                return System.Math.Sqrt(X * X + Y * Y + Z * Z);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return System.Math.Sqrt(R * R + Z * Z);
            }
            else
            {
                return R;
            }
        }

        public Vector<Coordinates> Normalize()
        {
            var length = Length();
            if (CoordinateSystem is "Cartesian")
            {
                return new Vector<Coordinates>(X / length, Y / length, Z / length);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return new Vector<Coordinates>(R / length, Y, Z / length);
            }
            else
            {
                return new Vector<Coordinates>(1, Theta, Phi);
            }
        }

        public bool Equals(Vector<Coordinates> vector)
        {
            return (X == vector.X || R == vector.R) && (Y == vector.Y || Theta == vector.Theta) && (Z == vector.Z || Phi == vector.Phi);
        }

        public override string ToString()
        {
            if (CoordinateSystem is "Cartesian")
            {
                return $"({this.X.ToString()}, {this.Y.ToString()}, {this.Z.ToString()})";
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return $"({this.R.ToString()}, {this.Theta.ToString()}, {this.Z.ToString()})";
            }
            else
            {
                return $"({this.R.ToString()}, {this.Theta.ToString()}, {this.Phi.ToString()})";
            }
        }

        public ValueTuple<double, double, double> ToTuple()
        {
            if (CoordinateSystem is "Cartesian")
            {
                return (X, Y, Z);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return (R, Theta, Z);
            }
            else
            {
                return (R, Theta, Phi);
            }
        }
    }
}
