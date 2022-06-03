using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class CoordinateTransform
    {
        public static Vector3D<Spherical> ToSpherical(Vector3D<Cartesian> a)
        {
            var radius = Math.Sqrt(a.First * a.First + a.Second * a.Second + a.Third * a.Third);
            return new Vector3D<Spherical>(radius, Math.Acos(a.Third / radius), Math.Atan2(a.Second, a.First));
        }

        public static Vector3D<Spherical> ToSpherical(Vector3D<Cylindrical> a)
        {
            var radius = Math.Sqrt(a.First * a.First + a.Third * a.Third);
            return new Vector3D<Spherical>(radius, Math.Acos(a.Third / radius), a.Second);
        }
    }
}
