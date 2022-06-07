using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class CoordinateTransform
    {
        public static Vector3D<Cartesian> ToCartesian(Vector3D<Cylindrical> a)
        {
            return new Vector3D<Cartesian>(a.X1 * Math.Cos(a.X2), a.X1 * Math.Sin(a.X2), a.X3);
        }

        public static Vector3D<Cartesian> ToCartesian(Vector3D<Spherical> a)
        {
            return new Vector3D<Cartesian>(a.X1 * Math.Cos(a.X3) * Math.Sin(a.X2), a.X1 * Math.Sin(a.X3) * Math.Sin(a.X2), a.X1 * Math.Cos(a.X2));
        }
    }
}
