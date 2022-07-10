using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET
{
    /// <summary>
    /// Initialize session by setting defaults. SI units are used by default.
    /// </summary>
    public static class Session
    {
        internal static int _Cores = Environment.ProcessorCount;
        public static int Cores { get { return _Cores; } }

        internal readonly static Random _Random = new();
        public static double Random { get { return _Random.NextDouble(); } }

        internal static dynamic _Signature = new Signature<Spacelike>();
        internal static string? Units = "Natural";

        public static void SetUnits(string units)
        {
            Units = units;
        }

        /// <summary>
        /// Set the metric <paramref name="signature"/> to either <paramref name="Spacelike"/> or <paramref name="Timelike"/>; case-sensitive. Defaults to <paramref name="Spacelike"/> if not set.
        /// </summary>
        /// <param name="signature"></param>
        /// <exception cref="TypeAccessException"></exception>
        public static void SetSignature(string signature)
        {
            if (typeof(ISignature).IsAssignableFrom(Type.GetType($"Physics.NET.Mathematics.DifferentialGeometry.{signature}")))
            {
                if (signature == "Spacelike")
                {
                    _Signature = new Signature<Spacelike>();
                }
                else
                {
                    _Signature = new Signature<Timelike>();
                }
            }
            else
            {
                throw new ArgumentException($"error: {signature} is not a valid metric signature");
            }
        }
    }
}
