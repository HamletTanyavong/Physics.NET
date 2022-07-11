using Physics.NET.GeneralRelativity;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public static partial class Metric
    {
        public static FourVector<T, U> Schwarzschild<T>(double M, FourVector<T, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            string coordinateSystem = typeof(T).Name;
            return coordinateSystem switch
            {
                "Spherical" => Schwarzschild<T>(Session._Signature, M, (FourVector<Spherical, L>)fourvector),
                _ => throw new TypeAccessException($"error: {coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static FourVector<T, U> Schwarzschild<T>(Signature<Spacelike> _, double M, FourVector<Spherical, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            var schwarzschildRadius = 2 * SI.G * M;
            var rSquared = fourvector.X1 * fourvector.X1;
            var sinSquared = Math.Sin(fourvector.X2) * Math.Sin(fourvector.X2);
            return new
            (
                1 / (schwarzschildRadius / fourvector.X1 - 1),
                1 - schwarzschildRadius / fourvector.X1,
                1 / rSquared,
                1 / (rSquared * sinSquared)
            );
        }

        public static FourVector<T, U> Schwarzschild<T>(Signature<Timelike> _, double M, FourVector<Spherical, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            var schwarzschildRadius = 2 * SI.G * M;
            var rSquared = fourvector.X1 * fourvector.X1;
            var sinSquared = Math.Sin(fourvector.X2) * Math.Sin(fourvector.X2);
            return new
            (
                1 / (1 - schwarzschildRadius / fourvector.X1),
                schwarzschildRadius / fourvector.X1 - 1,
                -1 / rSquared,
                -1 / (rSquared * sinSquared)
            );
        }
    }
}
