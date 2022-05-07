using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.Mathematics.CoordinateSystems;

namespace Physics.Types
{
    /// <summary>
    /// Vector in <typeparamref name="Coordinates"/> coordinates.
    /// </summary>
    /// <remarks>
    /// Components must be doubles. <typeparamref name="Cartesian"/>, <typeparamref name="Cylindrical"/>, and <typeparamref name="Spherical"/> coordinates are all valid. For Polar coordinates, use Cylindrical type with an empty third argument. For vectors of n dimensions, use <typeparamref name="General"/>.
    /// </remarks>
    /// <typeparam name="Coordinates"></typeparam>
    /// <typeparam name="Cartesian"></typeparam>
    /// <typeparam name="Cylindrical"></typeparam>
    /// <typeparam name="Spherical"></typeparam>
    /// <typeparam name="General"></typeparam>
    public struct Vector<Coordinates> : IEquatable<Vector<Coordinates>>
        where Coordinates : class, ICoordinateSystem
    {
        private static string? _coordinateSystem;

        public double First { get; set; }
        public double Second { get; set; }
        public double Third { get; set; }
        
        public Vector(double first, double second, double third = 0)
        {
            _coordinateSystem = typeof(Coordinates).Name;

            First = first;
            Second = second;
            Third = third;
        }

        public static Vector<Coordinates> operator +(Vector<Coordinates> left, Vector<Coordinates> right)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector<Coordinates>(left.First + right.First, left.Second + right.Second, left.Third + right.Third);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                var result = (left.ToCartesian() + right.ToCartesian()).ToCylindrical();
                return new Vector<Coordinates>(result.First, result.Second, result.Third);
            }
            else
            {
                var result = (left.ToCartesian() + right.ToCartesian()).ToSpherical();
                return new Vector<Coordinates>(result.First, result.Second, result.Third);
            }
        }

        public static Vector<Coordinates> operator -(Vector<Coordinates> left, Vector<Coordinates> right)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector<Coordinates>(left.First - right.First, left.Second - right.Second, left.Third - right.Third);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                var result = (left.ToCartesian() - right.ToCartesian()).ToCylindrical();
                return new Vector<Coordinates>(result.First, result.Second, result.Third);
            }
            else
            {
                var result = (left.ToCartesian() - right.ToCartesian()).ToSpherical();
                return new Vector<Coordinates>(result.First, result.Second, result.Third);
            }
        }

        public static Vector<Coordinates> operator *(double left, Vector<Coordinates> vector)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector<Coordinates>(left * vector.First, left * vector.Second, left * vector.Third);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                return new Vector<Coordinates>(left * vector.First, vector.Second, left * vector.Third);
            }
            else
            {
                return new Vector<Coordinates>(left * vector.First, vector.Second, vector.Third);
            }
        }

        public static Vector<Coordinates> operator *(Vector<Coordinates> vector, double right)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector<Coordinates>(right * vector.First, right * vector.Second, right * vector.Third);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                return new Vector<Coordinates>(right * vector.First, vector.Second, right * vector.Third);
            }
            else
            {
                return new Vector<Coordinates>(right * vector.First, vector.Second, vector.Third);
            }
        }

        public double Length()
        {
            if (_coordinateSystem is "Cartesian")
            {
                return System.Math.Sqrt(First * First + Second * Second + Third * Third);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                return System.Math.Sqrt(First * First + Third * Third);
            }
            else
            {
                return First;
            }
        }

        public Vector<Coordinates> Normalize()
        {
            var length = Length();
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector<Coordinates>(First / length, Second / length, Third / length);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                return new Vector<Coordinates>(First / length, Second, Third / length);
            }
            else
            {
                return new Vector<Coordinates>(1, Second, Third);
            }
        }

        public bool Equals(Vector<Coordinates> vector)
        {
            return First == vector.First && Second == vector.Second && Third == vector.Third;
        }

        public Vector<Cartesian> ToCartesian()
        {
            if (_coordinateSystem is "Cylindrical")
            {
                return new Vector<Cartesian>(First * Math.Cos(Second), First * Math.Sin(Second), Third);
            }
            else
            {
                return new Vector<Cartesian>(First * Math.Cos(Third) * Math.Sin(Second), First * Math.Sin(Third) * Math.Sin(Second), First * Math.Cos(Second));
            }
        }

        public Vector<Cylindrical> ToCylindrical()
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector<Cylindrical>(Math.Sqrt(First * First + Second * Second), Math.Atan2(Second, First), Third);
            }
            else
            {
                return new Vector<Cylindrical>(First * Math.Sin(Second), Third, First * Math.Cos(Second));
            }
        }

        public Vector<Spherical> ToSpherical()
        {
            if (_coordinateSystem is "Cartesian")
            {
                var radius = Math.Sqrt(First * First + Second * Second + Third * Third);
                return new Vector<Spherical>(radius, Math.Acos(Third / radius), Math.Atan2(Second, First));
            }
            else
            {
                var radius = Math.Sqrt(First * First + Third * Third);
                return new Vector<Spherical>(radius, Math.Acos(Third / radius), Second);
            }
        }

        public override string ToString()
        {
            return $"({First.ToString()}, {Second.ToString()}, {Third.ToString()})";
        }

        public ValueTuple<double, double, double> ToTuple()
        {
            return (First, Second, Third);
        }
    }
}
