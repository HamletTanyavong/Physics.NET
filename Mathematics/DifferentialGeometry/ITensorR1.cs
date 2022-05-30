namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public interface ITensorR1<Coordinates, I> : ITensor
        where Coordinates : class, ICoordinateSystem, I3D
        where I : class, IIndexPosition
    {
        /// <summary>
        /// Give a tensor indicies with a specified name and location. Use <paramref name="true"/> for upper and <paramref name="false"/> for lower positions.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="position"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        void SetIndex(int location, string index);

        /// <summary>
        /// Raise <paramref name="index"/> with <paramref name="metric"/>.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="metric"></param>
        /// <returns></returns>
        FourVector<Coordinates, U> Raise(string index, Func<FourVector<Coordinates, L>, FourVector<Coordinates, U>> metric);

        /// <summary>
        /// Lower <paramref name="index"/> with <paramref name="metric"/>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="metric"></param>
        /// <returns></returns>
        FourVector<Coordinates, L> Lower(string index, Func<FourVector<Coordinates, U>, FourVector<Coordinates, L>> metric);
    }
}
