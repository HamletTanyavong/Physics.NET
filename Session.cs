using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.NET.Units;
using Physics.NET.Mathematics.DifferentialGeometry.Metrics;

namespace Physics.NET
{
    /// <summary>
    /// Initialize session by setting defaults. SI units are used by default.
    /// </summary>
    public static class Session
    {
        internal static string? Signature { get; set; } = "Spacelike";
        internal static string? Units { get; set; } = "SI";

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
            if (typeof(ISignature).IsAssignableFrom(Type.GetType($"Physics.NET.Mathematics.DifferentialGeometry.Metrics.I{signature}")))
            {
                Signature = signature;
            }
            else
            {
                throw new ArgumentException($"error: {signature} is not a valid metric signature");
            }
        }
    }
}
