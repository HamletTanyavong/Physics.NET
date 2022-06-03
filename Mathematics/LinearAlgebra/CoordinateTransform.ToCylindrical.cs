using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class CoordinateTransform
    {
        public static Vector3D<Cylindrical> ToCylindrical(Vector3D<Cartesian> a)
        {
            return new Vector3D<Cylindrical>(Math.Sqrt(a.First * a.First + a.Second * a.Second), Math.Atan2(a.Second, a.First), a.Third);
        }

        public static Vector3D<Cylindrical> ToCylindrical(Vector3D<Spherical> a)
        {
            return new Vector3D<Cylindrical>(a.First * Math.Sin(a.Second), a.Third, a.First * Math.Cos(a.Second));
        }
    }
}
