namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public interface IFourVector : ITensorR1
    {
        /// <summary>
        /// The zeroth component of a four-vector.
        /// </summary>
        double Zeroth { get; set; }

        /// <summary>
        /// The first component of a four-vector.
        /// </summary>
        double First { get; set; }

        /// <summary>
        /// The second component of a four-vector.
        /// </summary>
        double Second { get; set; }

        /// <summary>
        /// The third component of a four-vector.
        /// </summary>
        double Third { get; set; }
    }
}