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

        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }

        /// <summary>
        /// Create a 3D vector with components (<paramref name="x1"/>, <paramref name="x2"/>, <paramref name="x3"/>).
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        public Vector3D(double x1, double x2, double x3)
        {
            X1 = x1;
            X2 = x2;
            X3 = x3;
        }

        public static explicit operator Vector3D<Cartesian>(Vector3D<T> a)
        {
            var result = new Vector3D<Cartesian>(a.X1, a.X2, a.X3);
            return result;
        }

        public static explicit operator Vector3D<Cylindrical>(Vector3D<T> a)
        {
            var result = new Vector3D<Cylindrical>(a.X1, a.X2, a.X3);
            return result;
        }

        public static explicit operator Vector3D<Spherical>(Vector3D<T> a)
        {
            var result = new Vector3D<Spherical>(a.X1, a.X2, a.X3);
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
            return Math.Sqrt(X1 * X1 + X2 * X2 + X3 * X3);
        }

        public Vector3D<T> Normalize()
        {
            var norm = Norm();
            return new Vector3D<T>(X1 / norm, X2 / norm, X3 / norm);
        }

        public bool Equals(Vector3D<T> other)
        {
            return X1 == other.X1 && X2 == other.X2 && X3 == other.X3;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector3D<T> && Equals(this);
        }

        public static bool operator ==(Vector3D<T> a, Vector3D<T> b)
        {
            return a.X1 == b.X1 && a.X2 == b.X2 && a.X3 == b.X3;
        }

        public static bool operator !=(Vector3D<T> a, Vector3D<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X1, X2, X3);
        }

        public override string ToString()
        {
            return $"({X1}, {X2}, {X3})";
        }
    }
}
