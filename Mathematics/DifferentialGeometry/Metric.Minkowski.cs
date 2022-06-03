namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public static partial class Metric
    {
        private readonly static int sc = Session.SigConst;

        /// <summary>
        /// Calculate the value of the Minkowski metric at a point in spacetime represented by a <paramref name="fourvector"/> with a contravariant index. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fourvector"></param>
        /// <returns></returns>
        public static FourVector<T, L> Minkowski<T>(FourVector<T, U> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            string coordinateSystem = typeof(T).Name;

            if (coordinateSystem is "Cartesian")
            {
                return new FourVector<T, L>(-1 * sc, sc, sc, sc);
            }
            else if (coordinateSystem is "Cylindrical")
            {
                return new FourVector<T, L>(-1 * sc, sc, fourvector.First * fourvector.First * sc, sc);
            }
            else
            {
                var firstSquared = fourvector.First * fourvector.First;
                var sinSquared = Math.Sin(fourvector.Second) * Math.Sin(fourvector.Second);
                return new FourVector<T, L>(-1 * sc, sc, firstSquared * sc, firstSquared * sinSquared * sc);
            }
        }

        /// <summary>
        /// Calculate the value of the Minkowski metric at a point in spacetime represented by a <paramref name="fourvector"/> with a covariant index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fourvector"></param>
        /// <returns></returns>
        public static FourVector<T, U> Minkowski<T>(FourVector<T, L> fourvector)
            where T : class, ICoordinateSystem, I3D
        {
            string coordinateSystem = typeof(T).Name;

            if (coordinateSystem is "Cartesian")
            {
                return new FourVector<T, U>(-1 * sc, sc, sc, sc);
            }
            else if (coordinateSystem is "Cylindrical")
            {
                return new FourVector<T, U>(-1 * sc, sc, sc / (fourvector.First * fourvector.First), sc);
            }
            else
            {
                var firstSquared = fourvector.First * fourvector.First;
                var sinSquared = Math.Sin(fourvector.Second) * Math.Sin(fourvector.Second);
                return new FourVector<T, U>(-1 * sc, sc, sc / firstSquared, sc / (firstSquared * sinSquared));
            }
        }
    }
}
