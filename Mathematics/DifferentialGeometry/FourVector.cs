using Physics.NET.Mathematics.LinearAlgebra;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// Four-vector, with a specified index, in <typeparamref name="T"/> coordinates.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct FourVector<T, I> : IVector, ITensorR1<T, I>, IEquatable<FourVector<T, I>>
        where T : class, ICoordinateSystem, I3D
        where I : class, IIndexPosition
    {
        private static readonly string CoordinateSystem = typeof(T).Name;
        private static readonly string IndexPosition = typeof(I).Name;
        private Index<I> Indicies { get; set; }

        readonly public int Rank { get; } = 1;

        public double Zeroth { get; set; }
        public double First { get; set; }
        public double Second { get; set; }
        public double Third { get; set; }

        public FourVector(double zeroth, double first, double second, double third)
        {
            Indicies = new();

            Zeroth = zeroth;
            First = first;
            Second = second;
            Third = third;
        }

        public FourVector(double zeroth, Vector3D<T> vector)
        {
            Indicies = new();

            Zeroth = zeroth;
            First = vector.First;
            Second = vector.Second;
            Third = vector.Third;
        }

        public void SetIndex(int location, string index)
        {
            Indicies = new(location, index);
        }

        public string GetIndex()
        {
            return $"({Indicies!.IndexName}, {IndexPosition})";
        }

        public FourVector<T, U> Raise(string index, Func<FourVector<T, L>, FourVector<T, U>> metric)
        {
            CheckIndexPosition(index);

            if (IndexPosition is "U")
            {
                throw new ArgumentException($"error: {index} is already raised");
            }

            var value = metric(new FourVector<T, L>(Zeroth, First, Second, Third));
            var result = Matrix.Multiply(value, this);
            result.SetIndex(0, index);
            return result;
        }

        public FourVector<T, U> Raise(string index, Func<double, FourVector<T, L>, FourVector<T, U>> metric, double M)
        {
            CheckIndexPosition(index);

            if (IndexPosition is "U")
            {
                throw new ArgumentException($"error: {index} is already raised");
            }

            var value = metric(M, new FourVector<T, L>(Zeroth, First, Second, Third));
            var result = Matrix.Multiply(value, this);
            result.SetIndex(0, index);
            return result;
        }

        public FourVector<T, L> Lower(string index, Func<FourVector<T, U>, FourVector<T, L>> metric)
        {
            CheckIndexPosition(index);

            if (IndexPosition is "L")
            {
                throw new ArgumentException($"error: {index} is already lowered");
            }

            var value = metric(new FourVector<T, U>(Zeroth, First, Second, Third));
            var result = Matrix.Multiply(value, this);
            result.SetIndex(0, index);
            return result;
        }

        public FourVector<T, L> Lower(string index, Func<double, FourVector<T, U>, FourVector<T, L>> metric, double M)
        {
            CheckIndexPosition(index);

            if (IndexPosition is "L")
            {
                throw new ArgumentException($"error: {index} is already lowered");
            }

            var value = metric(M, new FourVector<T, U>(Zeroth, First, Second, Third));
            var result = Matrix.Multiply(value, this);
            result.SetIndex(0, index);
            return result;
        }

        private void CheckIndexPosition(string index)
        {
            if (Indicies.Location is null || Indicies.IndexName != index)
            {
                throw new ArgumentException("error: Index not found");
            }
        }

        public static FourVector<T, I> operator +(FourVector<T, I> a, FourVector<T, I> b)
        {
            return Selector.Coordinate(Selector.Operation, "Add", a, b);
        }

        public static FourVector<T, I> operator -(FourVector<T, I> a, FourVector<T, I> b)
        {
            return Selector.Coordinate(Selector.Operation, "Subtract", a, b);
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
