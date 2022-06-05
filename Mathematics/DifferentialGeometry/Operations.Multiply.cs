namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public static partial class Operations
    {
        public static FourVector<T, I> Multiply<T, I>(double a, FourVector<T, I> b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            string coordinateSystem = typeof(T).Name;
            return coordinateSystem switch
            {
                "Cartesian" => Multiply<T, I>(a, (FourVector<Cartesian, I>)b),
                "Cylindrical" => Multiply<T, I>(a, (FourVector<Cylindrical, I>)b),
                "Spherical" => Multiply<T, I>(a, (FourVector<Spherical, I>)b),
                _ => throw new TypeAccessException($"{coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static FourVector<T, I> Multiply<T, I>(FourVector<T, I> a, double b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            string coordinateSystem = typeof(T).Name;
            return coordinateSystem switch
            {
                "Cartesian" => Multiply<T, I>(b, (FourVector<Cartesian, I>)a),
                "Cylindrical" => Multiply<T, I>(b, (FourVector<Cylindrical, I>)a),
                "Spherical" => Multiply<T, I>(b, (FourVector<Spherical, I>)a),
                _ => throw new TypeAccessException($"{coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static FourVector<T, I> Multiply<T, I>(double a, FourVector<Cartesian, I> b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            return new(a * b.Zeroth, a * b.First, a * b.Second, a * b.Third);
        }

        public static FourVector<T, I> Multiply<T, I>(double a, FourVector<Cylindrical, I> b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            var r_0 = a * b.Zeroth;
            var r_1 = a * b.First * Math.Cos(b.Second);
            var r_2 = a * b.First * Math.Sin(b.Second);
            var r_3 = a * b.Third;
            return new(
                r_0,
                Math.Sqrt(r_1 * r_1 + r_2 * r_2),
                Math.Atan2(r_2, r_1),
                r_3
            );
        }

        public static FourVector<T, I> Multiply<T, I>(double a, FourVector<Spherical, I> b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            var r_0 = a * b.Zeroth;
            var r_1 = a * b.First * Math.Cos(b.Third) * Math.Sin(b.Second);
            var r_2 = a * b.First * Math.Sin(b.Third) * Math.Sin(b.Second);
            var r_3 = a * b.First * Math.Cos(b.Second);

            var radius = Math.Sqrt(r_1 * r_1 + r_2 * r_2 + r_3 * r_3);
            return new(
                r_0,
                radius,
                Math.Acos(r_3 / radius),
                Math.Atan2(r_2, r_1)
            );
        }
    }
}
