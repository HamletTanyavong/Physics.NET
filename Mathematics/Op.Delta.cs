namespace Physics.NET.Mathematics
{
    public static partial class Op
    {
        /// <summary>
        /// Kronecker delta with indicies <paramref name="i"/> and <paramref name="j"/>.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>1 if <paramref name="i"/> = <paramref name="j"/>. Otherwise returns 0.</returns>
        public static int Delta(int i, int j)
        {
            return i != j ? 0 : 1;
        }
    }
}
