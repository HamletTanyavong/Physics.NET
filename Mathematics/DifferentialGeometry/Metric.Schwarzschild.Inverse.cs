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
                "Spherical" => Schwarzschild<T>(Session.Signature, M, (FourVector<Spherical, L>)fourvector),
                _ => throw new TypeAccessException($"error: {coordinateSystem} is not a valid coordinate system"),
            };
        }

        public static FourVector<T, U> Schwarzschild<T>(Signature<Spacelike> _, double M, FourVector<Spherical, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            var schwarzschildRadius = 2 * SI.G * M;
            var rSquared = fourvector.First * fourvector.First;
            var sinSquared = Math.Sin(fourvector.Second) * Math.Sin(fourvector.Second);
            return new
            (
                1 / (schwarzschildRadius / fourvector.First - 1),
                1 - schwarzschildRadius / fourvector.First,
                1 / rSquared,
                1 / (rSquared * sinSquared)
            );
        }

        public static FourVector<T, U> Schwarzschild<T>(Signature<Timelike> _, double M, FourVector<Spherical, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            var schwarzschildRadius = 2 * SI.G * M;
            var rSquared = fourvector.First * fourvector.First;
            var sinSquared = Math.Sin(fourvector.Second) * Math.Sin(fourvector.Second);
            return new
            (
                1 / (1 - schwarzschildRadius / fourvector.First),
                schwarzschildRadius / fourvector.First - 1,
                -1 / rSquared,
                -1 / (rSquared * sinSquared)
            );
        }
    }
}
