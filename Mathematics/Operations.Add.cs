namespace Physics.NET.Mathematics
{
    public static partial class Operations
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
            return new(a.First + b.First, a.Second + b.Second, a.Third + b.Third);
        }

        public static Vector3D<T> Add<T>(Vector3D<Cylindrical> a, Vector3D<Cylindrical> b)
            where T : class, ICoordinateSystem, I3D
        {
            var r_1 = a.First * Math.Cos(a.Second) + b.First * Math.Cos(b.Second);
            var r_2 = a.First * Math.Sin(a.Second) + b.First * Math.Sin(b.Second);
            var r_3 = a.Third + b.Third;
            return new(
                Math.Sqrt(r_1 * r_1 + r_2 * r_2),
                Math.Atan2(r_2, r_1),
                r_3
            );
        }

        public static Vector3D<T> Add<T>(Vector3D<Spherical> a, Vector3D<Spherical> b)
            where T : class, ICoordinateSystem, I3D
        {
            var r_1 = a.First * Math.Cos(a.Third) * Math.Sin(a.Second) + b.First * Math.Cos(b.Third) * Math.Sin(b.Second);
            var r_2 = a.First * Math.Sin(a.Third) * Math.Sin(a.Second) + b.First * Math.Sin(b.Third) * Math.Sin(b.Second);
            var r_3 = a.First * Math.Cos(a.Second) + b.First * Math.Cos(b.Second);

            var radius = Math.Sqrt(r_1 * r_1 + r_2 * r_2 + r_3 * r_3);
            return new(
                radius,
                Math.Acos(r_3 / radius),
                Math.Atan2(r_2, r_1)
            );
        }
    }
}
