using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.NET.Mathematics.DifferentialGeometry.Metrics;
using Physics.NET.Mathematics.Vectors;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// Four-vector of type (<typeparamref name="Contravariant"/>, <typeparamref name="Covariant"/>) in <typeparamref name="Coordinates"/> coordinates.
    /// </summary>
    /// <remarks>
    /// These can either be Covariant or Contravariant.
    /// </remarks>
    /// <typeparam name="Coordinates"></typeparam>
    /// <typeparam name="Contravariant"></typeparam>
    /// <typeparam name="Covariant"></typeparam>
    public struct FourVector<Coordinates> : IVector, ITensor
        where Coordinates : class, ICoordinateSystem, I3D
    {
        readonly public int Rank { get; } = 1;

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

        public FourVector(double zeroth, Vector3D<Coordinates> vector)
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
