namespace Physics.NET.Mathematics.LinearAlgebra
{
    /// <summary>
    /// Parts of a matrix.
    /// </summary>
    public enum Elements
    {
        /// <summary>
        /// All elements.
        /// </summary>
        All,

        /// <summary>
        /// Diagonal elements.
        /// </summary>
        Diagonal,

        /// <summary>
        /// Anitdiagonal elements.
        /// </summary>
        Antidiagonal,

        /// <summary>
        /// Lower triangular portion.
        /// </summary>
        Lower,

        /// <summary>
        /// Upper triangular portion.
        /// </summary>
        Upper,

        /// <summary>
        /// Portion below the diagonal.
        /// </summary>
        Below,

        /// <summary>
        /// Portion above the diagonal.
        /// </summary>
        Above
    }

    public static partial class Matrix
    {
        /// <summary>
        /// Populate a <paramref name="matrix"/> with a <paramref name="value"/>.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="elements"></param>
        /// <param name="value"></param>
        public static void Populate(double[,] matrix, Elements elements, double value)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            switch (elements)
            {
                case Elements.All:
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = value;
                        }
                    }
                    break;
                case Elements.Diagonal:
                    for (int i = 0; i < m; i++)
                    {
                        matrix[i, i] = value;
                    }
                    break;
                case Elements.Antidiagonal:
                    for (int i = 0; i < m; i++)
                    {
                        matrix[i, m - i - 1] = value;
                    }
                    break;
                case Elements.Lower:
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < Math.Min(i + 1, n); j++)
                        {
                            matrix[i, j] = value;
                        }
                    }
                    break;
                case Elements.Upper:
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = i; j < n; j++)
                        {
                            matrix[i, j] = value;
                        }
                    }
                    break;
                case Elements.Below:
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < Math.Min(i, n); j++)
                        {
                            matrix[i, j] = value;
                        }
                    }
                    break;
                case Elements.Above:
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = i + 1; j < n; j++)
                        {
                            matrix[i, j] = value;
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("error: Select a valid matrix population method");
            }
        }
    }
}
