using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.GeneralRelativity
{
    public interface IFourVector : ITensorR1
    {
        /// <summary>
        /// The zeroth component of a four-vector.
        /// </summary>
        double X0 { get; set; }

        /// <summary>
        /// The first component of a four-vector.
        /// </summary>
        double X1 { get; set; }

        /// <summary>
        /// The second component of a four-vector.
        /// </summary>
        double X2 { get; set; }

        /// <summary>
        /// The third component of a four-vector.
        /// </summary>
        double X3 { get; set; }
    }
}