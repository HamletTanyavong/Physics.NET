namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        /// <summary>
        /// Calculates the principle value natural log of a complex number <paramref name="z"/>.
        /// </summary>
        /// <param name="z"></param>
        /// <returns>The natural log of <paramref name="z"/>.</returns>
        public static Complex Ln(Complex z)
        {
            return Complex.Log(z);
        }
    }
}
