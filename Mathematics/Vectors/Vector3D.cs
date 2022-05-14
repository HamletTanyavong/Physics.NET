using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.Mathematics.Vectors
{
    /// <summary>
    /// 3D Vector in <typeparamref name="Coordinates"/> coordinates.
    /// </summary>
    /// <remarks>
    /// Components must be doubles. <typeparamref name="Cartesian"/>, <typeparamref name="Cylindrical"/>, and <typeparamref name="Spherical"/> coordinates are all valid.
    /// </remarks>
    /// <typeparam name="Coordinates"></typeparam>
    /// <typeparam name="Cartesian"></typeparam>
    /// <typeparam name="Cylindrical"></typeparam>
    /// <typeparam name="Spherical"></typeparam>
    public struct Vector3D<Coordinates> : IVector, IEquatable<Vector3D<Coordinates>>
        where Coordinates : class, ICoordinateSystem, I3D
    {
        private static string? _coordinateSystem;

        public double First { get; set; }
        public double Second { get; set; }
        public double Third { get; set; }

        /// <summary>
        /// Create a 3D vector with components (<paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>).
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        public Vector3D(double first, double second, double third)
        {
            _coordinateSystem = typeof(Coordinates).Name;

            First = first;
            Second = second;
            Third = third;
        }

        public static Vector3D<Coordinates> operator +(Vector3D<Coordinates> left, Vector3D<Coordinates> right)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector3D<Coordinates>(left.First + right.First, left.Second + right.Second, left.Third + right.Third);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                var result = (left.ToCartesian() + right.ToCartesian()).ToCylindrical();
                return new Vector3D<Coordinates>(result.First, result.Second, result.Third);
            }
            else
            {
                var result = (left.ToCartesian() + right.ToCartesian()).ToSpherical();
                return new Vector3D<Coordinates>(result.First, result.Second, result.Third);
            }
        }

        public static Vector3D<Coordinates> operator -(Vector3D<Coordinates> left, Vector3D<Coordinates> right)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector3D<Coordinates>(left.First - right.First, left.Second - right.Second, left.Third - right.Third);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                var result = (left.ToCartesian() - right.ToCartesian()).ToCylindrical();
                return new Vector3D<Coordinates>(result.First, result.Second, result.Third);
            }
            else
            {
                var result = (left.ToCartesian() - right.ToCartesian()).ToSpherical();
                return new Vector3D<Coordinates>(result.First, result.Second, result.Third);
            }
        }

        public static Vector3D<Coordinates> operator *(double left, Vector3D<Coordinates> vector)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector3D<Coordinates>(left * vector.First, left * vector.Second, left * vector.Third);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                return new Vector3D<Coordinates>(left * vector.First, vector.Second, left * vector.Third);
            }
            else
            {
                return new Vector3D<Coordinates>(left * vector.First, vector.Second, vector.Third);
            }
        }

        public static Vector3D<Coordinates> operator *(Vector3D<Coordinates> vector, double right)
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector3D<Coordinates>(right * vector.First, right * vector.Second, right * vector.Third);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                return new Vector3D<Coordinates>(right * vector.First, vector.Second, right * vector.Third);
            }
            else
            {
                return new Vector3D<Coordinates>(right * vector.First, vector.Second, vector.Third);
            }
        }

        public double Length()
        {
            if (_coordinateSystem is "Cartesian")
            {
                return Math.Sqrt(First * First + Second * Second + Third * Third);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                return Math.Sqrt(First * First + Third * Third);
            }
            else
            {
                return First;
            }
        }

        public Vector3D<Coordinates> Normalize()
        {
            var length = Length();
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector3D<Coordinates>(First / length, Second / length, Third / length);
            }
            else if (_coordinateSystem is "Cylindrical")
            {
                return new Vector3D<Coordinates>(First / length, Second, Third / length);
            }
            else
            {
                return new Vector3D<Coordinates>(1, Second, Third);
            }
        }

        public bool Equals(Vector3D<Coordinates> vector)
        {
            return First == vector.First && Second == vector.Second && Third == vector.Third;
        }

        public Vector3D<Cartesian> ToCartesian()
        {
            if (_coordinateSystem is "Cylindrical")
            {
                return new Vector3D<Cartesian>(First * Math.Cos(Second), First * Math.Sin(Second), Third);
            }
            else
            {
                return new Vector3D<Cartesian>(First * Math.Cos(Third) * Math.Sin(Second), First * Math.Sin(Third) * Math.Sin(Second), First * Math.Cos(Second));
            }
        }

        public Vector3D<Cylindrical> ToCylindrical()
        {
            if (_coordinateSystem is "Cartesian")
            {
                return new Vector3D<Cylindrical>(Math.Sqrt(First * First + Second * Second), Math.Atan2(Second, First), Third);
            }
            else
            {
                return new Vector3D<Cylindrical>(First * Math.Sin(Second), Third, First * Math.Cos(Second));
            }
        }

        public Vector3D<Spherical> ToSpherical()
        {
            if (_coordinateSystem is "Cartesian")
            {
                var radius = Math.Sqrt(First * First + Second * Second + Third * Third);
                return new Vector3D<Spherical>(radius, Math.Acos(Third / radius), Math.Atan2(Second, First));
            }
            else
            {
                var radius = Math.Sqrt(First * First + Third * Third);
                return new Vector3D<Spherical>(radius, Math.Acos(Third / radius), Second);
            }
        }

        public override string ToString()
        {
            return $"({First}, {Second}, {Third})";
        }
    }
}
