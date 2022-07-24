namespace Physics.NET
{
    public enum Units
    {
        /// <summary>
        /// International System of Units
        /// </summary>
        SI,

        /// <summary>
        /// Natural Units
        /// </summary>
        Natural,

        /// <summary>
        /// CGS Units
        /// </summary>
        CGS
    }

    /// <summary>
    /// Metric signature.
    /// </summary>
    public enum Signature
    {
        /// <summary>
        /// Spacelike: (-1, 1, 1, 1)
        /// </summary>
        Spacelike,

        /// <summary>
        /// Timelike: (1, -1, -1, -1)
        /// </summary>
        Timelike
    }

    /// <summary>
    /// Align elements in output.
    /// </summary>
    public enum Align
    {
        Left,
        Right
    }
}
