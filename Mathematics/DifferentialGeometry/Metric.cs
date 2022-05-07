using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.Units.SI;
using Physics.Mathematics.CoordinateSystems;
using Physics.Mathematics.DifferentialGeometry.Metrics;

namespace Physics.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// The <typeparamref name="Name"/> metric in <typeparamref name="Coordinates"/> coordinates with signature (-1, 1, 1, 1) and specified indicies.
    /// </summary>
    /// <typeparam name="Name"></typeparam>
    public struct Metric<Name, Coordinates> : IMetric, ITensor
        where Name : class, IMetric
        where Coordinates : class, ICoordinateSystem
    {
        private static string? _name;
        public int Rank { get; set; } = 2;
        private double[,] MetricTensor { get; set; }
        private Indicies _indicies { get; set; }

        public Metric(Indicies indicies, FourVector<Coordinates> fourVector)
        {
            _name = typeof(Name).Name;
            _indicies = indicies;

            if (_name is "Minkowski")
            {
                MetricTensor = Minkowski.Calculate<Coordinates>(fourVector);
            }
            else
            {
                throw new TypeAccessException($"{_name} is not a valid metric.");
            }
        }

        public Metric(Indicies indicies, double M, FourVector<Coordinates> fourVector)
        {
            _name = typeof(Name).Name;
            _indicies = indicies;

            if (_name is "Schwarzschild")
            {
                MetricTensor = Schwarzschild.Calculate<Coordinates>(M, fourVector);
            }
            else
            {
                throw new TypeAccessException($"{_name} is not a valid type.");
            }
        }

        public Metric(Indicies indicies, double[,] metric)
        {
            _name = typeof(Name).Name;
            _indicies = indicies;

            MetricTensor = metric;
        }

        public Metric (Indicies indicies, double zeroth, double first, double second, double third)
        {
            _name = typeof(Name).Name;
            _indicies = indicies;

            MetricTensor = Matrix.Diagonal(zeroth, first, second, third);
        }

        public void Raise<T>(T metric, string index)
            where T : IMetric
        {

        }

        public void Lower<T>(T metric, string index)
            where T : IMetric
        {

        }

        public double this[int index1, int index2]
        {
            get => MetricTensor[index1, index2];
            set => MetricTensor[index1, index2] = value;
        }
    }
}
