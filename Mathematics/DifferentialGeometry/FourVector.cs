using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.CoordinateSystems;
using Physics.Mathematics.DifferentialGeometry.Metrics;
using Physics.Mathematics.DifferentialGeometry.Signatures;
using Physics.Types;

namespace Physics.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// Four-vector of type (<typeparamref name="Contravariant"/>, <typeparamref name="Covariant"/>).
    /// </summary>
    /// <remarks>
    /// These can either be Covariant or Contravariant.
    /// </remarks>
    /// <typeparam name="Contravariant"></typeparam>
    /// <typeparam name="Covariant"></typeparam>
    public struct FourVector : ITensor
    {
        public int Rank { get; set; } = 1;

        public double Zeroth { get; set; }
        public double First { get; set; }
        public double Second { get; set; }
        public double Third { get; set; }

        public FourVector(double zeroth, double first, double second, double third)
        {
            Zeroth = zeroth;
            First = first;
            Second = second;
            Third = third;
        }

        public FourVector(double zeroth, Vector<Cartesian> vector)
        {
            Zeroth = zeroth;
            First = vector.First;
            Second = vector.Second;
            Third = vector.Third;
        }

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
