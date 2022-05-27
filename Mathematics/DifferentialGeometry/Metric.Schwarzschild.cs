namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public static partial class Metric
    {
        /// <summary>
        /// Calculate the value of the Schwarzschild metric for an object of mass <paramref name="M"/> at a point in spacetime represented by <paramref name="fourVector"/>. <typeparamref name="T"/> must be spherical.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="M"></param>
        /// <param name="fourVector"></param>
        /// <returns></returns>
        public static FourVector<T> Schwarzschild<T>(double M, FourVector<T> fourVector)
            where T : class, ICoordinateSystem, I3D
        {
            var schwarzschildRadius = 2 * SI.G * M / SI.cSquared;
            if (Session.Signature is "Spacelike")
            {
                FourVector<T> result = new(
                    schwarzschildRadius / fourVector.First - 1,
                    1 / (1 - schwarzschildRadius / fourVector.First),
                    fourVector.First * fourVector.First,
                    fourVector.First * fourVector.First * Math.Pow(Math.Sin(fourVector.Second), 2)
                );
                return result;
            }
            else
            {
                FourVector<T> result = new(
                    1 - schwarzschildRadius / fourVector.First,
                    1 / (schwarzschildRadius / fourVector.First - 1),
                    -1 * fourVector.First * fourVector.First,
                    -1 * fourVector.First * fourVector.First * Math.Pow(Math.Sin(fourVector.Second), 2)
                );
                return result;
            }
        }
    }
}
