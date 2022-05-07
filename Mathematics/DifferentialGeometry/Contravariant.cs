using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.Mathematics.DifferentialGeometry.Metrics;

namespace Physics.Mathematics.DifferentialGeometry
{
    public class Contravariant : ITensor
    {
        public int Rank { get; set; } = 1;

        public void Raise<T>(T metric, string index)
            where T : IMetric
        {

        }

        public void Lower<T>(T metric, string index)
            where T : IMetric
        {

        }
    }
}
