namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public static partial class Metric
    {
        private readonly static int sc = Session.SigConst;

        /// <summary>
        /// Calculate the value of the Minkowski metric at a point in spacetime represented by <paramref name="fourvector"/>. If <paramref name="inverse"/> is true, then the inverse metric will be used for the calculation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fourvector"></param>
        /// <returns></returns>
        public static FourVector<T> Minkowski<T>(bool inverse, FourVector<T> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            string coordinateSystem = typeof(T).Name;

            if (coordinateSystem is "Cartesian")
            {
                return new FourVector<T>(-1 * sc, sc, sc, sc);
            }
            else if (coordinateSystem is "Cylindrical")
            {
                if (inverse is false)
                {
                    return new FourVector<T>(-1 * sc, sc, fourvector.First * fourvector.First * sc, sc);
                }
                else
                {
                    return new FourVector<T>(-1 * sc, sc, sc / (fourvector.First * fourvector.First), sc);
                }
            }
            else
            {
                var firstSquared = fourvector.First * fourvector.First;
                var sinSquared = Math.Sin(fourvector.Second) * Math.Sin(fourvector.Second);
                if (inverse is false)
                {
                    return new FourVector<T>(-1 * sc, sc, firstSquared * sc, firstSquared * sinSquared * sc);
                }
                else
                {
                    return new FourVector<T>(-1 * sc, sc, sc / firstSquared, sc / (firstSquared * sinSquared));
                }
            }
        }
    }
}
