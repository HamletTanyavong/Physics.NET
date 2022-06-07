using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class CoordinateTransform
    {
        public static Vector3D<Cylindrical> ToCylindrical(Vector3D<Cartesian> a)
        {
            return new Vector3D<Cylindrical>(Math.Sqrt(a.X1 * a.X1 + a.X2 * a.X2), Math.Atan2(a.X2, a.X1), a.X3);
        }

        public static Vector3D<Cylindrical> ToCylindrical(Vector3D<Spherical> a)
        {
            return new Vector3D<Cylindrical>(a.X1 * Math.Sin(a.X2), a.X3, a.X1 * Math.Cos(a.X2));
        }
    }
}
