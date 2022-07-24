namespace Physics.NET.Mathematics.LinearAlgebra
{
    public interface IMatrix
    {
        /// <summary>
        /// Number of rows in a matrix.
        /// </summary>
        int M { get; }

        /// <summary>
        /// Number of Columns in a matrix.
        /// </summary>
        int N { get; }

        Complex this[int m, int n] { get; set; }
    }
}
