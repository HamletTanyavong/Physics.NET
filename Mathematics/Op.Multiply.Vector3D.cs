namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        public static Vector3D<T> Multiply<T>(double a, Vector3D<T> b)
            where T : class, ICoordinateSystem, I3D
        {
            string coordinateSystem = typeof(T).Name;
            return coordinateSystem switch
            {
                "Cartesian" => Multiply<T>(a, (Vector3D<Cartesian>)b),
                "Cylindrical" => Multiply<T>(a, (Vector3D<Cylindrical>)b),
                "Spherical" => Multiply<T>(a, (Vector3D<Spherical>)b),
                _ => throw new TypeAccessException($"error: {coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static Vector3D<T> Multiply<T>(Vector3D<T> a, double b)
            where T : class, ICoordinateSystem, I3D
        {
            string coordinateSystem = typeof(T).Name;
            return coordinateSystem switch
            {
                "Cartesian" => Multiply<T>((Vector3D<Cartesian>)a, b),
                "Cylindrical" => Multiply<T>((Vector3D<Cylindrical>)a, b),
                "Spherical" => Multiply<T>((Vector3D<Spherical>)a, b),
                _ => throw new TypeAccessException($"error: {coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static Vector3D<T> Multiply<T>(double a, Vector3D<Cartesian> b)
            where T : class, ICoordinateSystem, I3D
        {
            return new(a * b.X1, a * b.X2, a * b.X3);
        }

        public static Vector3D<T> Multiply<T>(Vector3D<Cartesian> a, double b)
            where T : class, ICoordinateSystem, I3D
        {
            return new(b * a.X1, b * a.X2, b * a.X3);
        }

        public static Vector3D<T> Multiply<T>(double a, Vector3D<Cylindrical> b)
            where T : class, ICoordinateSystem, I3D
        {
            var r_1 = a * b.X1 * Math.Cos(b.X2);
            var r_2 = a * b.X1 * Math.Sin(b.X2);
            var r_3 = a * b.X3;
            return new(
                Math.Sqrt(r_1 * r_1 + r_2 * r_2),
                Math.Atan2(r_2, r_1),
                r_3
            );
        }

        public static Vector3D<T> Multiply<T>(Vector3D<Cylindrical> a, double b)
            where T : class, ICoordinateSystem, I3D
        {
            var r_1 = b * a.X1 * Math.Cos(a.X2);
            var r_2 = b * a.X1 * Math.Sin(a.X2);
            var r_3 = b * a.X3;
            return new(
                Math.Sqrt(r_1 * r_1 + r_2 * r_2),
                Math.Atan2(r_2, r_1),
                r_3
            );
        }

        public static Vector3D<T> Multiply<T>(double a, Vector3D<Spherical> b)
            where T : class, ICoordinateSystem, I3D
        {
            var r_1 = a * b.X1 * Math.Cos(b.X3) * Math.Sin(b.X2);
            var r_2 = a * b.X1 * Math.Sin(b.X3) * Math.Sin(b.X2);
            var r_3 = a * b.X1 * Math.Cos(b.X2);

            var radius = Math.Sqrt(r_1 * r_1 + r_2 * r_2 + r_3 * r_3);
            return new(
                radius,
                Math.Acos(r_3 / radius),
                Math.Atan2(r_2, r_1)
            );
        }

        public static Vector3D<T> Multiply<T>(Vector3D<Spherical> a, double b)
            where T : class, ICoordinateSystem, I3D
        {
            var r_1 = b * a.X1 * Math.Cos(a.X3) * Math.Sin(a.X2);
            var r_2 = b * a.X1 * Math.Sin(a.X3) * Math.Sin(a.X2);
            var r_3 = b * a.X1 * Math.Cos(a.X2);

            var radius = Math.Sqrt(r_1 * r_1 + r_2 * r_2 + r_3 * r_3);
            return new(
                radius,
                Math.Acos(r_3 / radius),
                Math.Atan2(r_2, r_1)
            );
        }
    }
}
