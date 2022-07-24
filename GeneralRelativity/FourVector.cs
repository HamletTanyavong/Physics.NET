using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.GeneralRelativity
{
    /// <summary>
    /// Four-vector, with a specified index, in <typeparamref name="T"/> coordinates.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct FourVector<T, I> : IFourVector, IFourVectorIndexManager<T>, IEquatable<FourVector<T, I>>
        where T : class, ICoordinateSystem, I3D
        where I : class, IIndexPosition
    {
        private readonly string IndexPosition = typeof(I).Name;
        internal readonly IIndex _Index;

        public static readonly int Rank = 1;

        public double X0 { get; set; }
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }

        public FourVector(double x0, double x1, double x2, double x3)
        {
            _Index = IndexFactory.CreateIndex<I>();

            X0 = x0;
            X1 = x1;
            X2 = x2;
            X3 = x3;
        }

        public FourVector(double x0, Vector3D<T> a)
        {
            _Index = IndexFactory.CreateIndex<I>();

            X0 = x0;
            X1 = a.X1;
            X2 = a.X2;
            X3 = a.X3;
        }

        public static explicit operator FourVector<T, L>(FourVector<T, I> a)
        {
            var result = new FourVector<T, L>(a.X0, a.X1, a.X2, a.X3);
            result.SetIndex(0, a._Index.IndexName);
            return result;
        }

        public static explicit operator FourVector<T, U>(FourVector<T, I> a)
        {
            var result = new FourVector<T, U>(a.X0, a.X1, a.X2, a.X3);
            result.SetIndex(0, a._Index.IndexName);
            return result;
        }

        public static explicit operator FourVector<Cartesian, I>(FourVector<T, I> a)
        {
            var result = new FourVector<Cartesian, I>(a.X0, a.X1, a.X2, a.X3);
            result.SetIndex(0, a._Index.IndexName);
            return result;
        }

        public static explicit operator FourVector<Cylindrical, I>(FourVector<T, I> a)
        {
            var result = new FourVector<Cylindrical, I>(a.X0, a.X1, a.X2, a.X3);
            result.SetIndex(0, a._Index.IndexName);
            return result;
        }

        public static explicit operator FourVector<Spherical, I>(FourVector<T, I> a)
        {
            var result = new FourVector<Spherical, I>(a.X0, a.X1, a.X2, a.X3);
            result.SetIndex(0, a._Index.IndexName);
            return result;
        }

        public void SetIndex(int location, string index)
        {
            _Index.Location = location;
            _Index.IndexName = index;
        }

        public string GetIndex()
        {
            return $"({_Index!.IndexName}, {IndexPosition})";
        }

        public FourVector<T, U> Raise(string index, Func<FourVector<T, L>, FourVector<T, U>> metric)
        {
            CheckIndexPosition(index);

            if (IndexPosition == "U")
            {
                throw new ArgumentException($"error: {index} is already raised");
            }

            var value = metric((FourVector<T, L>)this);
            var result = Op.Elementwise.Multiply(value, this);
            result.SetIndex(0, index);
            return result;
        }

        public FourVector<T, U> Raise(string index, Func<double, FourVector<T, L>, FourVector<T, U>> metric, double M)
        {
            CheckIndexPosition(index);

            if (IndexPosition == "U")
            {
                throw new ArgumentException($"error: {index} is already raised");
            }

            var value = metric(M, (FourVector<T, L>)this);
            var result = Op.Elementwise.Multiply(value, this);
            result.SetIndex(0, index);
            return result;
        }

        public FourVector<T, L> Lower(string index, Func<FourVector<T, U>, FourVector<T, L>> metric)
        {
            CheckIndexPosition(index);

            if (IndexPosition == "L")
            {
                throw new ArgumentException($"error: {index} is already lowered");
            }

            var value = metric((FourVector<T, U>)this);
            var result = Op.Elementwise.Multiply(value, this);
            result.SetIndex(0, index);
            return result;
        }

        public FourVector<T, L> Lower(string index, Func<double, FourVector<T, U>, FourVector<T, L>> metric, double M)
        {
            CheckIndexPosition(index);

            if (IndexPosition == "L")
            {
                throw new ArgumentException($"error: {index} is already lowered");
            }

            var value = metric(M, (FourVector<T, U>)this);
            var result = Op.Elementwise.Multiply(value, this);
            result.SetIndex(0, index);
            return result;
        }

        private void CheckIndexPosition(string index)
        {
            if (_Index.Location is null || _Index.IndexName != index)
            {
                throw new ArgumentException("error: Index either not found or already set");
            }
        }

        public bool Equals(FourVector<T, I> other)
        {
            return X0 == other.X0 && X1 == other.X1 && X2 == other.X2 && X3 == other.X3;
        }

        public override bool Equals(object? obj)
        {
            return obj is FourVector<T, I> && Equals(this);
        }

        public static bool operator ==(FourVector<T, I> a, FourVector<T, I> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(FourVector<T, I> a, FourVector<T, I> b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X0, X1, X2, X3);
        }

        public override string ToString()
        {
            return $"({X0}, {X1}, {X2}, {X3})";
        }

        public double this[int index]
        {
            get
            {
                return index switch
                {
                    0 => X0,
                    1 => X1,
                    2 => X2,
                    3 => X3,
                    _ => throw new ArgumentOutOfRangeException(nameof(index)),
                };
            }
            set
            {
                switch (index)
                {
                    case 0: X0 = value; break;
                    case 1: X1 = value; break;
                    case 2: X2 = value; break;
                    case 3: X3 = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}
