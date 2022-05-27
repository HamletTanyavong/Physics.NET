using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.NET.Units
{
    /// <summary>
    /// International System of Units
    /// </summary>
    public static partial class SI
    {
        /// <summary>
        /// Fine-structure constant
        /// </summary>
        public const double alpha = 7.2793525693e-3;

        /// <summary>
        /// Speed of light in a vacuum
        /// </summary>
        public const double c = 299792458;

        /// <summary>
        /// Speed of light in a vacuum squared
        /// </summary>
        public const double cSquared = 89875517873681764;

        /// <summary>
        /// Vacuum electric permittivity
        /// </summary>
        public const double epsilon = 1 / (mu * c * c);

        /// <summary>
        /// Gravitational constant
        /// </summary>
        public const double G = 6.67430e-11;

        /// <summary>
        /// Planck's constant
        /// </summary>
        public const double h = 6.62607015e-34;

        /// <summary>
        /// Reduced Planck's constant
        /// </summary>
        public const double hbar = 1.0545718e-34;

        /// <summary>
        /// Vacuum magnetic permeability
        /// </summary>
        public const double mu = System.Math.PI * 4e-7;

        /// <summary>
        /// Rest masses for various fundamental particles.
        /// </summary>
        public static class Mass
        {
            /// <summary>
            /// Rest mass of an electron
            /// </summary>
            public const double e = 9.1093837015e-31;

            /// <summary>
            /// Rest mass of a neutron
            /// </summary>
            public const double n = 1.67492749804e-27;

            /// <summary>
            /// Rest mass of a proton
            /// </summary>
            public const double p = 1.67262192369e-27;
        }
    }
}
