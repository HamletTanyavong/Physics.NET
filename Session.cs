using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    public static class Session
    {
        internal static int Signature { get; set; }
        internal static string? Units { get; set; }

        public static void Initialize(string units)
        {
            SetUnits(units);
        }

        private static void SetUnits(string units)
        {
            Units = units;
        }
    }
}
