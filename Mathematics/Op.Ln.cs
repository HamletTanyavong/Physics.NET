namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        /// <summary>
        /// Calculates the principle value natural log of a complex number <paramref name="z"/>.
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Returns the result in polar form.</returns>
        public static Complex Ln(Complex z)
        {
            return Complex.Log(z);
        }
    }
}
