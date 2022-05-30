using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class Matrix
    {
        /// <summary>
        /// Perform element-wise multiplication of two four-vectors <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <typeparam name="Coordinates"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static FourVector<Coordinates, L> Multiply<Coordinates, I>(FourVector<Coordinates, L> a, FourVector<Coordinates, I> b)
            where Coordinates : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            return new FourVector<Coordinates, L>(a.Zeroth * b.Zeroth, a.First * b.First, a.Second * b.Second, a.Third * b.Third);
        }

        /// <summary>
        /// Perform element-wise multiplication of two four-vectors <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <typeparam name="Coordinates"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static FourVector<Coordinates, U> Multiply<Coordinates, I>(FourVector<Coordinates, U> a, FourVector<Coordinates, I> b)
            where Coordinates : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            return new FourVector<Coordinates, U>(a.Zeroth * b.Zeroth, a.First * b.First, a.Second * b.Second, a.Third * b.Third);
        }
    }
}
