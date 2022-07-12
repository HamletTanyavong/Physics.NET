namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        /// <summary>
        /// The binomial coefficient.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns><paramref name="n"/> choose <paramref name="k"/></returns>
        public static double Binomial(int n, int k)
        {
            return Op.Factorial(n) / (Op.Factorial(k) * Op.Factorial(n - k));
        }

        /// <summary>
        /// The multinomial coefficient.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="α"></param>
        /// <returns><paramref name="n"/> choose (<paramref name="α"/>₁ . . . <paramref name="α"/>ₛ)</returns>
        public static double Multinomial(int n, int[] α)
        {
            int order = α.Length;
            double partialResult = Op.Factorial(n);
            for (int i = 0; i < order; i++)
            {
                partialResult /= Op.Factorial(α[i]);
            }
            return partialResult;
        }
    }
}
