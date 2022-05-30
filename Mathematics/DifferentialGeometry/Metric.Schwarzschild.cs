namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public static partial class Metric
    {
        /// <summary>
        /// Calculate the value of the Schwarzschild metric for an object of mass <paramref name="M"/> at a point in spacetime represented by <paramref name="fourvector"/>. If <paramref name="inverse"/> is true, then the inverse metric will be used for the calculation. Coordinates must be spherical.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inverse"></param>
        /// <param name="M"></param>
        /// <param name="fourvector"></param>
        /// <returns></returns>
        public static FourVector<T, L> Schwarzschild<T>(double M, FourVector<T, U> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            if (typeof(T).Name is not "Spherical")
            {
                throw new TypeAccessException("error: Method uses spherical spatial coordinates");
            }
            var schwarzschildRadius = 2 * SI.G * M / SI.cSquared;
            var firstSquared = fourvector.First * fourvector.First;
            var sinSquared = Math.Sin(fourvector.Second) * Math.Sin(fourvector.Second);
            FourVector<T, L> result = new()
            {
                Zeroth = sc * (schwarzschildRadius / fourvector.First - 1),
                First = sc / (1 - schwarzschildRadius / fourvector.First),
                Second = sc * firstSquared,
                Third = sc * firstSquared * sinSquared
            };
            return result;
        }

        /// <summary>
        /// Calculate the value of the Schwarzschild metric for an object of mass <paramref name="M"/> at a point in spacetime represented by <paramref name="fourvector"/>. If <paramref name="inverse"/> is true, then the inverse metric will be used for the calculation. Coordinates must be spherical.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inverse"></param>
        /// <param name="M"></param>
        /// <param name="fourvector"></param>
        /// <returns></returns>
        public static FourVector<T, U> Schwarzschild<T>(double M, FourVector<T, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            if (typeof(T).Name is not "Spherical")
            {
                throw new TypeAccessException("error: Method uses spherical spatial coordinates");
            }
            var schwarzschildRadius = 2 * SI.G * M / SI.cSquared;
            var firstSquared = fourvector.First * fourvector.First;
            var sinSquared = Math.Sin(fourvector.Second) * Math.Sin(fourvector.Second);
            FourVector<T, U> result = new()
            {
                Zeroth = sc / (schwarzschildRadius / fourvector.First - 1),
                First = sc * (1 - schwarzschildRadius / fourvector.First),
                Second = sc / firstSquared,
                Third = sc / (firstSquared * sinSquared)
            };
            return result;
        }
    }
}
