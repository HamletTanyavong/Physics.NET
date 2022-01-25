using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.CoordinateSystems
{
    /// <summary>
    /// Cartesian coordinates in the form (x, y, z) with optional parameter z.
    /// </summary>
    public class Cartesian
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Cartesian(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
