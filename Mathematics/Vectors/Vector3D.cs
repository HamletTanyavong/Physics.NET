namespace Physics.NET.Mathematics.Vectors
{
    /// <summary>
    /// 3D Vector in <typeparamref name="T"/> coordinates.
    /// </summary>
    /// <remarks>
    /// Components must be doubles. <typeparamref name="Cartesian"/>, <typeparamref name="Cylindrical"/>, and <typeparamref name="Spherical"/> coordinates are all valid.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Cartesian"></typeparam>
    /// <typeparam name="Cylindrical"></typeparam>
    /// <typeparam name="Spherical"></typeparam>
    public struct Vector3D<T> : IVector, IEquatable<Vector3D<T>>
        where T : class, ICoordinateSystem, I3D
    {
        private static readonly string CoordinateSystem = typeof(T).Name;

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
            First = first;
            Second = second;
            Third = third;
        }

        public static Vector3D<T> operator +(Vector3D<T> a, Vector3D<T> b)
        {
            if (CoordinateSystem is "Cartesian")
            {
                return new Vector3D<T>(a.First + b.First, a.Second + b.Second, a.Third + b.Third);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                var result = (a.ToCartesian() + b.ToCartesian()).ToCylindrical();
                return new Vector3D<T>(result.First, result.Second, result.Third);
            }
            else
            {
                var result = (a.ToCartesian() + b.ToCartesian()).ToSpherical();
                return new Vector3D<T>(result.First, result.Second, result.Third);
            }
        }

        public static Vector3D<T> operator -(Vector3D<T> a, Vector3D<T> b)
        {
            if (CoordinateSystem is "Cartesian")
            {
                return new Vector3D<T>(a.First - b.First, a.Second - b.Second, a.Third - b.Third);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                var result = (a.ToCartesian() - b.ToCartesian()).ToCylindrical();
                return new Vector3D<T>(result.First, result.Second, result.Third);
            }
            else
            {
                var result = (a.ToCartesian() - b.ToCartesian()).ToSpherical();
                return new Vector3D<T>(result.First, result.Second, result.Third);
            }
        }

        public static Vector3D<T> operator *(double a, Vector3D<T> b)
        {
            if (CoordinateSystem is "Cartesian")
            {
                return new Vector3D<T>(a * b.First, a * b.Second, a * b.Third);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return new Vector3D<T>(a * b.First, b.Second, a * b.Third);
            }
            else
            {
                return new Vector3D<T>(a * b.First, b.Second, b.Third);
            }
        }

        public static Vector3D<T> operator *(Vector3D<T> a, double b)
        {
            if (CoordinateSystem is "Cartesian")
            {
                return new Vector3D<T>(b * a.First, b * a.Second, b * a.Third);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return new Vector3D<T>(b * a.First, a.Second, b * a.Third);
            }
            else
            {
                return new Vector3D<T>(b * a.First, a.Second, a.Third);
            }
        }

        public double Length()
        {
            if (CoordinateSystem is "Cartesian")
            {
                return Math.Sqrt(First * First + Second * Second + Third * Third);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return Math.Sqrt(First * First + Third * Third);
            }
            else
            {
                return First;
            }
        }

        public Vector3D<T> Normalize()
        {
            var length = Length();
            if (CoordinateSystem is "Cartesian")
            {
                return new Vector3D<T>(First / length, Second / length, Third / length);
            }
            else if (CoordinateSystem is "Cylindrical")
            {
                return new Vector3D<T>(First / length, Second, Third / length);
            }
            else
            {
                return new Vector3D<T>(1, Second, Third);
            }
        }

        public Vector3D<Cartesian> ToCartesian()
        {
            if (CoordinateSystem is "Cylindrical")
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
            if (CoordinateSystem is "Cartesian")
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
            if (CoordinateSystem is "Cartesian")
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

        public bool Equals(Vector3D<T> other)
        {
            return First == other.First && Second == other.Second && Third == other.Third;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector3D<T> && Equals(this);
        }

        public static bool operator ==(Vector3D<T> a, Vector3D<T> b)
        {
            return a.First == b.First && a.Second == b.Second && a.Third == b.Third;
        }

        public static bool operator !=(Vector3D<T> a, Vector3D<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(First, Second, Third);
        }

        public override string ToString()
        {
            return $"({First}, {Second}, {Third})";
        }
    }
}
