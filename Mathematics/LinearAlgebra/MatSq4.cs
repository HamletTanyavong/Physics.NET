namespace Physics.NET.Mathematics.LinearAlgebra
{
    /// <summary>
    /// A square matrix with dimensions 4 x 4.
    /// </summary>
    public struct MatSq4 : IMatrix, IEquatable<MatSq4>
    {
        private static readonly int _N = 4;
        public int M { get { return _N; } }
        public int N { get { return _N; } }

        private Complex[,] Values;

        public MatSq4()
        {
            Values = new Complex[_N, _N];
        }

        public MatSq4(Complex[,] array)
        {
            if (!Matrix.IsSquare(array) || array.GetLength(0) != 4)
            {
                throw new ArgumentException("error: matrix must be of correct dimensions");
            }

            Values = array;
        }

        public static implicit operator MatSq4(Complex[,] array)
        {
            return new MatSq4(array);
        }

        public static MatSq4 operator +(MatSq4 a, MatSq4 b)
        {
            return Op.Add(a, b);
        }

        public static MatSq4 operator -(MatSq4 a, MatSq4 b)
        {
            return Op.Subtract(a, b);
        }

        public static MatSq4 operator *(Complex a, MatSq4 b)
        {
            return Op.Multiply(a, b);
        }

        public static MatSq4 operator *(MatSq4 a, Complex b)
        {
            return Op.Multiply(a, b);
        }

        public static MatSq4 operator *(MatSq4 a, MatSq4 b)
        {
            return Op.Multiply(a, b);
        }

        public bool Equals(MatSq4 other)
        {
            return Values[0, 0] == other.Values[0, 0] && Values[0, 1] == other.Values[0, 1] && Values[0, 2] == other.Values[0, 2] && Values[0, 3] == other.Values[0, 3]
                && Values[1, 0] == other.Values[1, 0] && Values[1, 1] == other.Values[1, 1] && Values[1, 2] == other.Values[1, 2] && Values[1, 3] == other.Values[1, 3]
                && Values[2, 0] == other.Values[2, 0] && Values[2, 1] == other.Values[2, 1] && Values[2, 2] == other.Values[2, 2] && Values[2, 3] == other.Values[2, 3]
                && Values[3, 0] == other.Values[3, 0] && Values[3, 1] == other.Values[3, 1] && Values[3, 2] == other.Values[3, 2] && Values[3, 3] == other.Values[3, 3];
        }

        public override bool Equals(object? obj)
        {
            return obj is MatSq4 && Equals(this);
        }

        public static bool operator ==(MatSq4 a, MatSq4 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(MatSq4 a, MatSq4 b)
        {
            return !(a.Equals(b));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(M, N, Values);
        }

        public Complex this[int m, int n]
        {
            get { return Values[m, n]; }
            set { Values[m, n] = value; }
        }
    }
}
