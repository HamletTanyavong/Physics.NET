namespace Physics.NET.Mathematics.LinearAlgebra
{
    /// <summary>
    /// A square matrix with dimensions 2 x 2.
    /// </summary>
    public struct MatSq2 : IMatrix, IEquatable<MatSq2>
    {
        private static readonly int _N = 2;
        public int M { get { return _N; } }
        public int N { get { return _N; } }

        private Complex[,] Values;

        public MatSq2()
        {
            Values = new Complex[_N, _N];
        }

        public MatSq2(Complex[,] array)
        {
            if (!Matrix.IsSquare(array) || array.GetLength(0) != 2)
            {
                throw new ArgumentException("error: matrix must be of correct dimensions");
            }

            Values = array;
        }

        public static implicit operator MatSq2(Complex[,] array)
        {
            return new MatSq2(array);
        }

        public static MatSq2 operator +(MatSq2 a, MatSq2 b)
        {
            return Op.Add(a, b);
        }

        public static MatSq2 operator -(MatSq2 a, MatSq2 b)
        {
            return Op.Subtract(a, b);
        }

        public static MatSq2 operator *(Complex a, MatSq2 b)
        {
            return Op.Multiply(a, b);
        }

        public static MatSq2 operator *(MatSq2 a, Complex b)
        {
            return Op.Multiply(a, b);
        }

        public static MatSq2 operator *(MatSq2 a, MatSq2 b)
        {
            return Op.Multiply(a, b);
        }

        public bool Equals(MatSq2 other)
        {
            return Values[0, 0] == other[0, 0] && Values[0, 1] == other[0, 1] && Values[1, 0] == other[1, 0] && Values[1, 1] == other[1, 1];
        }

        public override bool Equals(object? obj)
        {
            return obj is MatSq2 && Equals(this);
        }

        public static bool operator ==(MatSq2 a, MatSq2 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(MatSq2 a, MatSq2 b)
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
