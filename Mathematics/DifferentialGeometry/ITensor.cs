namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public interface ITensor
    {
        /// <summary>
        /// The rank of a tensor.
        /// </summary>
        static int Rank;

        string GetIndex();
        string ToString();
    }
}
