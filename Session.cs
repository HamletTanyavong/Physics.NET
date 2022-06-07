using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET
{
    /// <summary>
    /// Initialize session by setting defaults. SI units are used by default.
    /// </summary>
    public static class Session
    {
        internal static dynamic Signature = new Signature<Spacelike>();
        internal static string? Units { get; set; } = "Natural";

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
                    Signature = new Signature<Spacelike>();
                }
                else
                {
                    Signature = new Signature<Timelike>();
                }
            }
            else
            {
                throw new ArgumentException($"error: {signature} is not a valid metric signature");
            }
        }
    }
}
