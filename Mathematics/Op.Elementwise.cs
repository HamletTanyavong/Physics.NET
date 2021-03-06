using Physics.NET.GeneralRelativity;
using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics
{
    public static partial class Op
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
                return new FourVector<T, L>(a.X0 * b.X0, a.X1 * b.X1, a.X2 * b.X2, a.X3 * b.X3);
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
                return new FourVector<T, U>(a.X0 * b.X0, a.X1 * b.X1, a.X2 * b.X2, a.X3 * b.X3);
            }
        }
    }
}
