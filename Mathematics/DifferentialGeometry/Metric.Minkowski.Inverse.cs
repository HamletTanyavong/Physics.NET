namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public static partial class Metric
    {
        public static FourVector<T, U> Minkowski<T>(FourVector<T, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            string coordinateSystem = typeof(T).Name;
            return coordinateSystem switch
            {
                "Cartesian" => Minkowski<T>(Session._Signature, (FourVector<Cartesian, L>)fourvector),
                "Cylindrical" => Minkowski<T>(Session._Signature, (FourVector<Cylindrical, L>)fourvector),
                "Spherical" => Minkowski<T>(Session._Signature, (FourVector<Spherical, L>)fourvector),
                _ => throw new TypeAccessException($"error: {coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static FourVector<T, U> Minkowski<T>(Signature<Spacelike> _, FourVector<Cartesian, L> _1)
            where T : class, ICoordinateSystem, I3D
        {
            return new FourVector<T, U>(-1, 1, 1, 1);
        }

        public static FourVector<T, U> Minkowski<T>(Signature<Timelike> _, FourVector<Cartesian, L> _1)
            where T : class, ICoordinateSystem, I3D
        {
            return new FourVector<T, U>(1, -1, -1, -1);
        }

        public static FourVector<T, U> Minkowski<T>(Signature<Spacelike> _, FourVector<Cylindrical, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            return new FourVector<T, U>(-1, 1, 1 / (fourvector.X1 * fourvector.X1), 1);
        }

        public static FourVector<T, U> Minkowski<T>(Signature<Timelike> _, FourVector<Cylindrical, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            return new FourVector<T, U>(1, -1, -1 / (fourvector.X1 * fourvector.X1), -1);
        }

        public static FourVector<T, U> Minkowski<T>(Signature<Spacelike> _, FourVector<Spherical, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            var rSquared = fourvector.X1 * fourvector.X1;
            var sinSquared = Math.Sin(fourvector.X2) * Math.Sin(fourvector.X2);
            return new FourVector<T, U>(-1, 1, 1 / rSquared, 1 / (rSquared * sinSquared));
        }

        public static FourVector<T, U> Minkowski<T>(Signature<Timelike> _, FourVector<Spherical, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            var rSquared = fourvector.X1 * fourvector.X1;
            var sinSquared = Math.Sin(fourvector.X2) * Math.Sin(fourvector.X2);
            return new FourVector<T, U>(1, -1, -1 / rSquared, -1 / (rSquared * sinSquared));
        }
    }
}
