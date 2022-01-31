using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.CoordinateSystems;
using Physics.Types;

namespace Physics.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// Four-vector of type <typeparamref name="IndexType"/>.
    /// </summary>
    /// <remarks>
    /// These can either be Covariant or Contravariant.
    /// </remarks>
    /// <typeparam name="IndexType"></typeparam>
    public struct FourVector<IndexType>
        where IndexType : class
    {
        private static string? Indicies;
        public double Zeroth { get; set; }
        public double First { get; set; }
        public double Second { get; set; }
        public double Third { get; set; }

        public FourVector(double zeroth, double first, double second, double third)
        {
            Indicies = typeof(IndexType).Name;

            if (typeof(IndexType).Namespace is not "Physics.Mathematics.DifferentialGeometry")
            {
                throw new TypeAccessException($"'{Indicies}' is not a valid four-vector type.");
            }

            Zeroth = zeroth;
            First = first;
            Second = second;
            Third = third;
        }

        public FourVector(double zeroth, Vector<Cartesian> vector)
        {
            Indicies = typeof(IndexType).Name;
            if (typeof(IndexType).Namespace is not "Physics.Mathematics.DifferentialGeometry")
            {
                throw new TypeAccessException($"'{Indicies}' is not a valid four-vector type.");
            }

            Zeroth = zeroth;
            First = vector.First;
            Second = vector.Second;
            Third = vector.Third;
        }
    }
}
