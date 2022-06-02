using Physics.NET.Mathematics.LinearAlgebra;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    internal static partial class Operations
    {
        internal static FourVector<T, I> AddCartesian<T, I>(FourVector<T, I> a, FourVector<T, I> b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            return new(a.Zeroth + b.Zeroth, a.First + b.First, a.Second + b.Second, a.Third + b.Third);
        }

        internal static FourVector<T, I> AddCylindrical<T, I>(FourVector<T, I> a, FourVector<T, I> b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            var r_0 = a.Zeroth + b.Zeroth;
            var r_1 = a.First * Math.Cos(a.Second) + b.First * Math.Cos(b.Second);
            var r_2 = a.First * Math.Sin(a.Second) + b.First * Math.Sin(b.Second);
            var r_3 = a.Third + b.Third;
            return new(
                r_0,
                Math.Sqrt(r_1 * r_1 + r_2 * r_2),
                Math.Atan2(r_2, r_1),
                r_3
            );
        }

        internal static FourVector<T, I> AddSpherical<T, I>(FourVector<T, I> a, FourVector<T, I> b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            var r_0 = a.Zeroth + b.Zeroth;
            var r_1 = a.First * Math.Cos(a.Third) * Math.Sin(a.Second) + b.First * Math.Cos(b.Third) * Math.Sin(b.Second);
            var r_2 = a.First * Math.Sin(a.Third) * Math.Sin(a.Second) + b.First * Math.Sin(b.Third) * Math.Sin(b.Second);
            var r_3 = a.First * Math.Cos(a.Second) + b.First * Math.Cos(b.Second);

            var radius = Math.Sqrt(r_1 * r_1 + r_2 * r_2 + r_3 * r_3);
            return new(
                r_0,
                radius,
                Math.Acos(r_3 / radius),
                Math.Atan2(r_2, r_1)
            );
        }
    }
}
