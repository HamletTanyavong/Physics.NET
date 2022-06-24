namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        public static Vector2D<T> Multiply<T>(double a, Vector2D<T> b)
            where T : class, ICoordinateSystem, I2D
        {
            string coordinateSystem = typeof(T).Name;
            return coordinateSystem switch
            {
                "Cartesian" => Multiply<T>(a, (Vector2D<Cartesian>)b),
                "Polar" => Multiply<T>(a, (Vector2D<Polar>)b),
                _ => throw new TypeAccessException($"error: {coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static Vector2D<T> Multiply<T>(Vector2D<T> a, double b)
            where T : class, ICoordinateSystem, I2D
        {
            string coordinateSystem = typeof(T).Name;
            return coordinateSystem switch
            {
                "Cartesian" => Multiply<T>((Vector2D<Cartesian>)a, b),
                "Polar" => Multiply<T>((Vector2D<Polar>)a, b),
                _ => throw new TypeAccessException($"error: {coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static Vector2D<T> Multiply<T>(double a, Vector2D<Cartesian> b)
            where T : class, ICoordinateSystem, I2D
        {
            return new(a * b.X1, a * b.X2);
        }

        public static Vector2D<T> Multiply<T>(Vector2D<Cartesian> a, double b)
            where T : class, ICoordinateSystem, I2D
        {
            return new(b * a.X1, b * a.X2);
        }

        public static Vector2D<T> Multiply<T>(double a, Vector2D<Polar> b)
            where T : class, ICoordinateSystem, I2D
        {
            var r_1 = a * b.X1 * Math.Cos(b.X2);
            var r_2 = a * b.X1 * Math.Sin(b.X2);
            return new(
                Math.Sqrt(r_1 * r_1 + r_2 * r_2),
                Math.Atan2(r_2, r_1)
            );
        }

        public static Vector2D<T> Multiply<T>(Vector2D<Polar> a, double b)
            where T : class, ICoordinateSystem, I2D
        {
            var r_1 = b * a.X1 * Math.Cos(a.X2);
            var r_2 = b * a.X1 * Math.Sin(a.X2);
            return new(
                Math.Sqrt(r_1 * r_1 + r_2 * r_2),
                Math.Atan2(r_2, r_1)
            );
        }
    }
}
