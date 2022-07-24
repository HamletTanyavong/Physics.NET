namespace Physics.NET.Mathematics.LinearAlgebra
{
    /// <summary>
    /// A square matrix with dimensions 3 x 3.
    /// </summary>
    public struct MatSq3 : IMatrix, IEquatable<MatSq3>
    {
        private static readonly int _N = 3;
        public int M { get { return _N; } }
        public int N { get { return _N; } }

        private Complex[,] Values;

        public MatSq3()
        {
            Values = new Complex[_N, _N];
        }

        public MatSq3(Complex[,] array)
        {
            if (!Matrix.IsSquare(array) || array.GetLength(0) != 3)
            {
                throw new ArgumentException("error: matrix must be of correct dimensions");
            }

            Values = array;
        }

        public static implicit operator MatSq3(Complex[,] array)
        {
            return new MatSq3(array);
        }

        public static MatSq3 operator +(MatSq3 a, MatSq3 b)
        {
            return Op.Add(a, b);
        }

        public static MatSq3 operator -(MatSq3 a, MatSq3 b)
        {
            return Op.Subtract(a, b);
        }

        public static MatSq3 operator *(Complex a, MatSq3 b)
        {
            return Op.Multiply(a, b);
        }

        public static MatSq3 operator *(MatSq3 a, Complex b)
        {
            return Op.Multiply(a, b);
        }

        public static MatSq3 operator *(MatSq3 a, MatSq3 b)
        {
            return Op.Multiply(a, b);
        }

        public bool Equals(MatSq3 other)
        {
            return Values[0, 0] == other[0, 0] && Values[0, 1] == other[0, 1] && Values[0, 2] == other[0, 2]
                && Values[1, 0] == other[1, 0] && Values[1, 1] == other[1, 1] && Values[1, 2] == other[1, 2]
                && Values[2, 0] == other[2, 0] && Values[2, 1] == other[2, 1] && Values[2, 2] == other[2, 2];
        }

        public override bool Equals(object? obj)
        {
            return obj is MatSq3 && Equals(this);
        }

        public static bool operator ==(MatSq3 a, MatSq3 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(MatSq3 a, MatSq3 b)
        {
            return !a.Equals(b);
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
