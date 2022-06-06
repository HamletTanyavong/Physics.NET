namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public interface ITensorR1 : ITensor
    {
        /// <summary>
        /// Give a tensor indicies with a specified name and location. Use <paramref name="true"/> for upper and <paramref name="false"/> for lower positions.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="position"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        void SetIndex(int location, string index);

        /// <summary>
        /// Returns the value of a rank one tensor at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        double this[int index] { get; set; }
    }
}
