using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class CoordinateTransform
    {
        public static Vector3D<Cartesian> ToCartesian(Vector3D<Cylindrical> a)
        {
            return new Vector3D<Cartesian>(a.First * Math.Cos(a.Second), a.First * Math.Sin(a.Second), a.Third);
        }

        public static Vector3D<Cartesian> ToCartesian(Vector3D<Spherical> a)
        {
            return new Vector3D<Cartesian>(a.First * Math.Cos(a.Third) * Math.Sin(a.Second), a.First * Math.Sin(a.Third) * Math.Sin(a.Second), a.First * Math.Cos(a.Second));
        }
    }
}
