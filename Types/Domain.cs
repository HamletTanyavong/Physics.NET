using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.NET.Types;
using Physics.NET.Mathematics.Vectors;

namespace Physics.NET.Types
{
    public struct Domain
    {
        public Domain()
        {
        }

        public static double[] CreateDomain()
        {
            return new double[] { 0, 0 };
        }
    }
}
