using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics
{
    public static partial class Operations
    {
        /// <summary>
        /// Perform element-wise operations on tensors.
        /// </summary>
        public static partial class Elementwise
        {
            /// <summary>
            /// Perform element-wise multiplication of two four-vectors <paramref name="a"/> and <paramref name="b"/>.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static FourVector<T, L> Multiply<T, I>(FourVector<T, L> a, FourVector<T, I> b)
                where T : class, ICoordinateSystem, I3D
                where I : class, IIndexPosition
            {
                return new FourVector<T, L>(a.Zeroth * b.Zeroth, a.First * b.First, a.Second * b.Second, a.Third * b.Third);
            }

            /// <summary>
            /// Perform element-wise multiplication of two four-vectors <paramref name="a"/> and <paramref name="b"/>.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static FourVector<T, U> Multiply<T, I>(FourVector<T, U> a, FourVector<T, I> b)
                where T : class, ICoordinateSystem, I3D
                where I : class, IIndexPosition
            {
                return new FourVector<T, U>(a.Zeroth * b.Zeroth, a.First * b.First, a.Second * b.Second, a.Third * b.Third);
            }
        }
    }
}
