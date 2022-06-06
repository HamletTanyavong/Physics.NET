namespace Physics.NET.Mathematics.LinearAlgebra
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

        public static explicit operator Vector3D<Cartesian>(Vector3D<T> a)
        {
            var result = new Vector3D<Cartesian>(a.First, a.Second, a.Third);
            return result;
        }

        public static explicit operator Vector3D<Cylindrical>(Vector3D<T> a)
        {
            var result = new Vector3D<Cylindrical>(a.First, a.Second, a.Third);
            return result;
        }

        public static explicit operator Vector3D<Spherical>(Vector3D<T> a)
        {
            var result = new Vector3D<Spherical>(a.First, a.Second, a.Third);
            return result;
        }

        public static Vector3D<T> operator +(Vector3D<T> a, Vector3D<T> b)
        {
            return Operations.Add(a, b);
        }

        public static Vector3D<T> operator -(Vector3D<T> a, Vector3D<T> b)
        {
            return Operations.Subtract(a, b);
        }

        public static Vector3D<T> operator *(double a, Vector3D<T> b)
        {
            return Operations.Multiply(a, b);
        }

        public static Vector3D<T> operator *(Vector3D<T> a, double b)
        {
            return Operations.Multiply(a, b);
        }

        public double Norm()
        {
            return Math.Sqrt(First * First + Second * Second + Third * Third);
        }

        public Vector3D<T> Normalize()
        {
            var norm = Norm();
            return new Vector3D<T>(First / norm, Second / norm, Third / norm);
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
