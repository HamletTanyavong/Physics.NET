using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class CoordinateTransform
    {
        public static Vector3D<Spherical> ToSpherical(Vector3D<Cartesian> a)
        {
            var radius = Math.Sqrt(a.X1 * a.X1 + a.X2 * a.X2 + a.X3 * a.X3);
            return new Vector3D<Spherical>(radius, Math.Acos(a.X3 / radius), Math.Atan2(a.X2, a.X1));
        }

        public static Vector3D<Spherical> ToSpherical(Vector3D<Cylindrical> a)
        {
            var radius = Math.Sqrt(a.X1 * a.X1 + a.X3 * a.X3);
            return new Vector3D<Spherical>(radius, Math.Acos(a.X3 / radius), a.X2);
        }
    }
}
