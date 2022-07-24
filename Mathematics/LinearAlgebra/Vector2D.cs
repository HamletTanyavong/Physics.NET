namespace Physics.NET.Mathematics.LinearAlgebra
{
    /// <summary>
    /// 2D Vector in <typeparamref name="T"/> coordinates.
    /// </summary>
    /// <remarks>
    /// Components must be doubles. <typeparamref name="Cartesian"/> and <typeparamref name="Polar"/> coordinates are valid.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Cartesian"></typeparam>
    /// <typeparam name="Polar"></typeparam>
    public struct Vector2D<T> : IVector, IEquatable<Vector2D<T>>
        where T : class, ICoordinateSystem, I2D
    {
        public double X1 { get; set; }
        public double X2 { get; set; }

        public Vector2D(double x1, double x2)
        {
            X1 = x1;
            X2 = x2;
        }

        public static explicit operator Vector2D<Cartesian>(Vector2D<T> a)
        {
            var result = new Vector2D<Cartesian>(a.X1, a.X2);
            return result;
        }

        public static explicit operator Vector2D<Polar>(Vector2D<T> a)
        {
            var result = new Vector2D<Polar>(a.X1, a.X2);
            return result;
        }

        public static Vector2D<T> operator +(Vector2D<T> a, Vector2D<T> b)
        {
            return Op.Add(a, b);
        }

        public static Vector2D<T> operator -(Vector2D<T> a, Vector2D<T> b)
        {
            return Op.Subtract(a, b);
        }

        public static Vector2D<T> operator *(double a, Vector2D<T> b)
        {
            return Op.Multiply(a, b);
        }

        public static Vector2D<T> operator *(Vector2D<T> a, double b)
        {
            return Op.Multiply(a, b);
        }

        public double Norm()
        {
            return Math.Sqrt(X1 * X1 + X2 * X2);
        }

        public Vector2D<T> Normalize()
        {
            var norm = Norm();
            return new Vector2D<T>(X1 / norm, X2 / norm);
        }

        public bool Equals(Vector2D<T> other)
        {
            return X1 == other.X1 && X2 == other.X2;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector2D<T> && Equals(this);
        }

        public static bool operator ==(Vector2D<T> a, Vector2D<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector2D<T> a, Vector2D<T> b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X1, X2);
        }

        public override string ToString()
        {
            return $"({X1}, {X2})";
        }
    }
}
