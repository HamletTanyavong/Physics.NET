using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics
{
    public static partial class Operations
    {
        public static double Contract<T>(FourVector<T, U> a, FourVector<T, L> b)
            where T : class, ICoordinateSystem, I3D
        {
            if (a._Index.IndexName != b._Index.IndexName)
            {
                throw new IndexMismatchException($"error: Indicies do not match");
            }
            return a.X0 * b.X0 + a.X1 * b.X1 + a.X2 * b.X2 + a.X3 * b.X3;
        }

        public static double Contract<T>(FourVector<T, L> a, FourVector<T, U> b)
            where T : class, ICoordinateSystem, I3D
        {
            if (a._Index.IndexName != b._Index.IndexName)
            {
                throw new IndexMismatchException($"error: Indicies do not match");
            }
            return a.X0 * b.X0 + a.X1 * b.X1 + a.X2 * b.X2 + a.X3 * b.X3;
        }
    }
}
