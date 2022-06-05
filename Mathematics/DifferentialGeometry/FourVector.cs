using Physics.NET.Mathematics.LinearAlgebra;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// Four-vector, with a specified index, in <typeparamref name="T"/> coordinates.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct FourVector<T, I> : IFourVector, IFourVectorIndexManagement<T>, IEquatable<FourVector<T, I>>
        where T : class, ICoordinateSystem, I3D
        where I : class, IIndexPosition
    {
        private static readonly string IndexPosition = typeof(I).Name;
        private readonly IIndex _Index;

        readonly public int Rank { get; } = 1;

        public double Zeroth { get; set; }
        public double First { get; set; }
        public double Second { get; set; }
        public double Third { get; set; }

        public FourVector(double zeroth, double first, double second, double third)
        {
            _Index = IndexFactory.CreateIndex<I>();

            Zeroth = zeroth;
            First = first;
            Second = second;
            Third = third;
        }

        public FourVector(double zeroth, Vector3D<T> vector)
        {
            _Index = IndexFactory.CreateIndex<I>();

            Zeroth = zeroth;
            First = vector.First;
            Second = vector.Second;
            Third = vector.Third;
        }

        public static explicit operator FourVector<T, L>(FourVector<T, I> a)
        {
            var result = new FourVector<T, L>(a.Zeroth, a.First, a.Second, a.Third);
            result.SetIndex(0, a._Index.IndexName);
            return result;
        }

        public static explicit operator FourVector<T, U>(FourVector<T, I> a)
        {
            var result = new FourVector<T, U>(a.Zeroth, a.First, a.Second, a.Third);
            result.SetIndex(0, a._Index.IndexName);
            return result;
        }

        public static explicit operator FourVector<Cartesian, I>(FourVector<T, I> a)
        {
            var result = new FourVector<Cartesian, I>(a.Zeroth, a.First, a.Second, a.Third);
            result.SetIndex(0, a._Index.IndexName);
            return result;
        }

        public static explicit operator FourVector<Cylindrical, I>(FourVector<T, I> a)
        {
            var result = new FourVector<Cylindrical, I>(a.Zeroth, a.First, a.Second, a.Third);
            result.SetIndex(0, a._Index.IndexName);
            return result;
        }

        public static explicit operator FourVector<Spherical, I>(FourVector<T, I> a)
        {
            var result = new FourVector<Spherical, I>(a.Zeroth, a.First, a.Second, a.Third);
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
            var result = Matrix.Multiply(value, this);
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
            var result = Matrix.Multiply(value, this);
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
            var result = Matrix.Multiply(value, this);
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
            var result = Matrix.Multiply(value, this);
            result.SetIndex(0, index);
            return result;
        }

        private void CheckIndexPosition(string index)
        {
            if (_Index.Location is null || _Index.IndexName != index)
            {
                throw new ArgumentException("error: Index not found");
            }
        }

        public static FourVector<T, I> operator +(FourVector<T, I> a, FourVector<T, I> b)
        {
            return Operations.Add(a, b);
        }

        public static FourVector<T, I> operator -(FourVector<T, I> a, FourVector<T, I> b)
        {
            return Operations.Subtract(a, b);
        }

        public static FourVector<T, I> operator *(double a, FourVector<T, I> b)
        {
            return Operations.Multiply(a, b);
        }

        public static FourVector<T, I> operator *(FourVector<T, I> a, double b)
        {
            return Operations.Multiply(a, b);
        }

        public bool Equals(FourVector<T, I> other)
        {
            return Zeroth == other.Zeroth && First == other.First && Second == other.Second && Third == other.Third;
        }

        public override bool Equals(object? obj)
        {
            return obj is FourVector<T, I> && Equals(this);
        }

        public static bool operator ==(FourVector<T, I> a, FourVector<T, I> b)
        {
            return a.Zeroth == b.Zeroth && a.First == b.First && a.Second == b.Second && a.Third == b.Third;
        }

        public static bool operator !=(FourVector<T, I> a, FourVector<T, I> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Zeroth, First, Second, Third);
        }

        public override string ToString()
        {
            return $"({Zeroth}, {First}, {Second}, {Third})";
        }

        public double this[int index]
        {
            get
            {
                return index switch
                {
                    0 => Zeroth,
                    1 => First,
                    2 => Second,
                    3 => Third,
                    _ => throw new ArgumentOutOfRangeException(nameof(index)),
                };
            }
            set
            {
                switch (index)
                {
                    case 0: Zeroth = value; break;
                    case 1: First = value; break;
                    case 2: Second = value; break;
                    case 3: Third = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }
}
