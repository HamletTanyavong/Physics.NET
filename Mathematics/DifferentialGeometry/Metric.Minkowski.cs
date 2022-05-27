namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public static partial class Metric
    {
        /// <summary>
        /// Calculate the value of the Minkowski metric at a point in spacetime represented by <paramref name="fourVector"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fourVector"></param>
        /// <returns></returns>
        public static FourVector<T> Minkowski<T>(FourVector<T> fourVector)
            where T : class, ICoordinateSystem, I3D
        {
            if (Session.Signature is "Spacelike")
            {
                FourVector<T> result = new(-1 * fourVector.Zeroth, fourVector.First, fourVector.Second, fourVector.Third);
                return result;
            }
            else
            {
                FourVector<T> result = new(fourVector.Zeroth, -1 * fourVector.First, -1 * fourVector.Second, -1 * fourVector.Third);
                return result;
            }
        }
    }
}
