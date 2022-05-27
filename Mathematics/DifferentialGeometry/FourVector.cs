using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.NET.Mathematics.DifferentialGeometry.Metrics;
using Physics.NET.Mathematics.Vectors;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// Four-vector, with a specified index, in <typeparamref name="Coordinates"/> coordinates.
    /// </summary>
    /// <typeparam name="Coordinates"></typeparam>
    public struct FourVector<Coordinates> : IVector, IEquatable<FourVector<Coordinates>>
        where Coordinates : class, ICoordinateSystem, I3D
    {
        readonly public int Rank { get; } = 1;
        private List<Index> IndexList { get; set; }
        private Index IndividualIndex { get; set; }

        public double Zeroth { get; set; }
        public double First { get; set; }
        public double Second { get; set; }
        public double Third { get; set; }

        public FourVector(double zeroth, double first, double second, double third)
        {
            IndexList = new();
            IndividualIndex = new();

            Zeroth = zeroth;
            First = first;
            Second = second;
            Third = third;
        }

        public FourVector(double zeroth, Vector3D<Coordinates> vector)
        {
            IndexList = new();
            IndividualIndex = new();

            Zeroth = zeroth;
            First = vector.First;
            Second = vector.Second;
            Third = vector.Third;
        }

        public void SetIndex(string index, bool position)
        {
            if (IndexList.Count < Rank)
            {
                IndividualIndex.Location = 0; IndividualIndex.IndexName = index; IndividualIndex.Position = position;
                IndexList.Add(IndividualIndex);
            }
            else
            {
                throw new IndexOutOfRangeException("error: Index already set");
            }
        }

        public List<Index> GetIndicies()
        {
            return IndexList;
        }

        public void Raise(string index, Func<FourVector<Coordinates>, FourVector<Coordinates>> metric)
        {
            if (IndividualIndex.Position is null || IndividualIndex.IndexName != index)
            {
                throw new ArgumentException("error: Index not found");
            }

            if (IndividualIndex.Position is true)
            {
                throw new ArgumentException("error: index is already raised");
            }
            else
            {
                var result = metric(this);
                Zeroth = result.Zeroth; First = result.First; Second = result.Second; Third = result.Third;
                IndividualIndex.Position = true;
            }
        }

        public void Raise(string index, Func<double, FourVector<Coordinates>, FourVector<Coordinates>> metric, double M)
        {
            if (IndividualIndex.Position is null || IndividualIndex.IndexName != index)
            {
                throw new ArgumentException("error: Index not found");
            }

            if (IndividualIndex.Position is true)
            {
                throw new ArgumentException("error: Index is already raised");
            }
            else
            {
                var result = metric(M, this);
                Zeroth = result.Zeroth; First = result.First; Second = result.Second; Third = result.Third;
                IndividualIndex.Position= true;
            }
        }

        public void Lower(string index, Func<FourVector<Coordinates>, FourVector<Coordinates>> metric)
        {
            if (IndividualIndex.Position is null || IndividualIndex.IndexName != index)
            {
                throw new ArgumentException("error: Index not found");
            }

            if (IndividualIndex.Position is false)
            {
                throw new ArgumentException("error: index is already lowered");
            }
            else
            {
                var result = metric(this);
                Zeroth = result.Zeroth; First = result.First; Second = result.Second; Third = result.Third;
                IndividualIndex.Position = false;
            }
        }

        public void Lower(string index, Func<double, FourVector<Coordinates>, FourVector<Coordinates>> metric, double M)
        {
            if (IndividualIndex.Position is null || IndividualIndex.IndexName != index)
            {
                throw new ArgumentException("error: Index not found");
            }

            if (IndividualIndex.Position is false)
            {
                throw new ArgumentException("error: Index is already lowered");
            }
            else
            {
                var result = metric(M, this);
                Zeroth = result.Zeroth; First = result.First; Second = result.Second; Third = result.Third;
                IndividualIndex.Position = false;
            }
        }

        public bool Equals(FourVector<Coordinates> other)
        {
            return Zeroth == other.Zeroth && First == other.First && Second == other.Second && Third == other.Third;
        }

        public override bool Equals(object? obj)
        {
            return obj is FourVector<Coordinates> && Equals(this);
        }

        public static bool operator ==(FourVector<Coordinates> a, FourVector<Coordinates> b)
        {
            return a.Zeroth == b.Zeroth && a.First == b.First && a.Second == b.Second && a.Third == b.Third;
        }

        public static bool operator !=(FourVector<Coordinates> a, FourVector<Coordinates> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Zeroth, First, Second, Third);
        }

        public override string ToString()
        {
            return $"({Zeroth}, {First}, {Second}, {Third})";
        }
    }
}
