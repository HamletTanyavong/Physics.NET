namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public static partial class Metric
    {
        public static FourVector<T, L> Minkowski<T>(FourVector<T, U> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            string coordinateSystem = typeof(T).Name;
            return coordinateSystem switch
            {
                "Cartesian" => Minkowski<T>(Session.Signature, (FourVector<Cartesian, U>)fourvector),
                "Cylindrical" => Minkowski<T>(Session.Signature, (FourVector<Cylindrical, U>)fourvector),
                "Spherical" => Minkowski<T>(Session.Signature, (FourVector<Spherical, U>)fourvector),
                _ => throw new TypeAccessException($"error: {coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static FourVector<T, L> Minkowski<T>(Signature<Spacelike> _, FourVector<Cartesian, U> _1)
            where T : class, ICoordinateSystem, I3D
        {
            return new FourVector<T, L>(-1, 1, 1, 1);
        }

        public static FourVector<T, L> Minkowski<T>(Signature<Timelike> _, FourVector<Cartesian, U> _1)
            where T : class, ICoordinateSystem, I3D
        {
            return new FourVector<T, L>(1, -1, -1, -1);
        }

        public static FourVector<T, L> Minkowski<T>(Signature<Spacelike> _, FourVector<Cylindrical, U> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            return new FourVector<T, L>(-1, 1, fourvector.X1 * fourvector.X1, 1);
        }

        public static FourVector<T, L> Minkowski<T>(Signature<Timelike> _, FourVector<Cylindrical, U> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            return new FourVector<T, L>(1, -1, -1 * fourvector.X1 * fourvector.X1, -1);
        }

        public static FourVector<T, L> Minkowski<T>(Signature<Spacelike> _, FourVector<Spherical, U> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            var rSquared = fourvector.X1 * fourvector.X1;
            var sinSquared = Math.Sin(fourvector.X2) * Math.Sin(fourvector.X2);
            return new FourVector<T, L>(-1, 1, rSquared, rSquared * sinSquared);
        }

        public static FourVector<T, L> Minkowski<T>(Signature<Timelike> _, FourVector<Spherical, U> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            var rSquared = fourvector.X1 * fourvector.X1;
            var sinSquared = Math.Sin(fourvector.X2) * Math.Sin(fourvector.X2);
            return new FourVector<T, L>(1, -1, -1 * rSquared, -1 * rSquared * sinSquared);
        }
    }
}
