namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        public static Vector3D<T> Add<T>(Vector3D<T> a, Vector3D<T> b)
            where T : class, ICoordinateSystem, I3D
        {
            string coordinateSystem = typeof(T).Name;
            return coordinateSystem switch
            {
                "Cartesian" => Add<T>((Vector3D<Cartesian>)a, (Vector3D<Cartesian>)b),
                "Cylindrical" => Add<T>((Vector3D<Cylindrical>)a, (Vector3D<Cylindrical>)b),
                "Spherical" => Add<T>((Vector3D<Spherical>)a, (Vector3D<Spherical>)b),
                _ => throw new TypeAccessException($"error: {coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static Vector3D<T> Add<T>(Vector3D<Cartesian> a, Vector3D<Cartesian> b)
            where T : class, ICoordinateSystem, I3D
        {
            return new(a.X1 + b.X1, a.X2 + b.X2, a.X3 + b.X3);
        }

        public static Vector3D<T> Add<T>(Vector3D<Cylindrical> a, Vector3D<Cylindrical> b)
            where T : class, ICoordinateSystem, I3D
        {
            var r_1 = a.X1 * Math.Cos(a.X2) + b.X1 * Math.Cos(b.X2);
            var r_2 = a.X1 * Math.Sin(a.X2) + b.X1 * Math.Sin(b.X2);
            var r_3 = a.X3 + b.X3;
            return new(
                Math.Sqrt(r_1 * r_1 + r_2 * r_2),
                Math.Atan2(r_2, r_1),
                r_3
            );
        }

        public static Vector3D<T> Add<T>(Vector3D<Spherical> a, Vector3D<Spherical> b)
            where T : class, ICoordinateSystem, I3D
        {
            var r_1 = a.X1 * Math.Cos(a.X3) * Math.Sin(a.X2) + b.X1 * Math.Cos(b.X3) * Math.Sin(b.X2);
            var r_2 = a.X1 * Math.Sin(a.X3) * Math.Sin(a.X2) + b.X1 * Math.Sin(b.X3) * Math.Sin(b.X2);
            var r_3 = a.X1 * Math.Cos(a.X2) + b.X1 * Math.Cos(b.X2);

            var radius = Math.Sqrt(r_1 * r_1 + r_2 * r_2 + r_3 * r_3);
            return new(
                radius,
                Math.Acos(r_3 / radius),
                Math.Atan2(r_2, r_1)
            );
        }
    }
}
