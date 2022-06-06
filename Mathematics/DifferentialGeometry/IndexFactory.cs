namespace Physics.NET.Mathematics.DifferentialGeometry
{
    internal static class IndexFactory
    {
        internal static IIndex CreateIndex<I>()
            where I : class, IIndexPosition
        {
            return new Index<I>();
        }
    }
}
