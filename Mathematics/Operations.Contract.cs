using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics
{
    public static partial class Operations
    {
        public static double Contract<T>(FourVector<T, U> a, FourVector<T, L> b)
            where T : class, ICoordinateSystem, I3D
        {
            return a.Zeroth * b.Zeroth + a.First * b.First + a.Second * b.Second + a.Third * b.Third;
        }

        public static double Contract<T>(FourVector<T, L> a, FourVector<T, U> b)
            where T : class, ICoordinateSystem, I3D
        {
            return a.Zeroth * b.Zeroth + a.First * b.First + a.Second * b.Second + a.Third * b.Third;
        }
    }
}
