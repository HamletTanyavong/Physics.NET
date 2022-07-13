namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        /// <summary>
        /// Returns the square root of a complex number.
        /// </summary>
        /// <param name="z"></param>
        /// <returns>The principle square root of <paramref name="z"/>.</returns>
        public static Complex Sqrt(Complex z)
        {
            return Complex.Sqrt(z);
        }

        /// <summary>
        /// Returns the square roots of a complex number.
        /// </summary>
        /// <param name="z"></param>
        /// <returns>The square roots of a complex number.</returns>
        public static Complex[] SqrtAll(Complex z)
        {
            Complex result = Complex.Sqrt(z);
            return new Complex[2] { result, new Complex(-result.Real, -result.Imaginary) };
        }

        /// <summary>
        /// Returns the <paramref name="n"/>th root of a complex number, where <paramref name="n"/> is an integer.
        /// </summary>
        /// <param name="z"></param>
        /// <param name="n"></param>
        /// <returns>The principle <paramref name="n"/>th root of <paramref name="z"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Complex Sqrt(int n, Complex z)
        {
            if (n == 0)
            {
                throw new ArgumentException($"error: n must not be zero");
            }

            return Complex.FromPolarCoordinates(Math.Pow(z.Magnitude, 1d / n), z.Phase / n);
        }

        /// <summary>
        /// Returns the <paramref name="n"/>th roots of a complex number, where <paramref name="n"/> is an integer.
        /// </summary>
        /// <param name="z"></param>
        /// <param name="n"></param>
        /// <returns>All <paramref name="n"/>th roots of <paramref name="z"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Complex[] SqrtAll(int n, Complex z)
        {
            if (n == 0)
            {
                throw new ArgumentException($"error: n must not be zero");
            }

            double r = Math.Pow(z.Magnitude, 1d / n);
            double phase = z.Phase / n;
            Complex[] result = new Complex[n];
            if (n % 2 == 0)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    result[i] = Complex.FromPolarCoordinates(r, phase + 2 * Math.PI * i / n);
                    result[i + n / 2] = Complex.FromPolarCoordinates(r, phase + Math.PI + 2 * Math.PI * i / n);
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    result[i] = Complex.FromPolarCoordinates(r, phase + 2 * Math.PI * i / n);
                }
            }
            return result;
        }

        /// <summary>
        /// Returns the <paramref name="n"/>th root of a complex number, where <paramref name="n"/> is any real number.
        /// </summary>
        /// <param name="z"></param>
        /// <param name="n"></param>
        /// <returns>The principle <paramref name="n"/>th root of <paramref name="z"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Complex Sqrt(double n, Complex z)
        {
            if (n == 0)
            {
                throw new ArgumentException($"error: n must not be zero");
            }

            return Complex.FromPolarCoordinates(Math.Pow(z.Magnitude, 1 / n), z.Phase / n);
        }
    }
}
