namespace Physics.NET.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// Represents a tensor index.
    /// </summary>
    public struct Index<T> : IIndex where T : class, IIndexPosition
    {
        public int? Location { get; set; } = null;
        public string IndexName { get; set; } = string.Empty;

        public Index()
        {
            Location = null;
            IndexName = String.Empty;
        }
    }
}
