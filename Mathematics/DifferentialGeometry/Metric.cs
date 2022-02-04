using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.Core;
using Physics.Mathematics.DifferentialGeometry.Metrics;
using Physics.Mathematics.DifferentialGeometry.Signatures;

namespace Physics.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// The <typeparamref name="Name"/> metric with signature <typeparamref name="Signature"/> and spedified indicies.
    /// </summary>
    /// <typeparam name="Name"></typeparam>
    /// <typeparam name="Signature"></typeparam>
    public struct Metric<Name, Signature> : IMetric, ITensor
        where Name : class, IMetric
        where Signature : class, ISignature
    {
        private static string? _name;
        private static string? _signature;
        public int Rank { get; set; } = 2;
        private double[,] MetricTensor { get; set; }
        private Indicies _indicies { get; set; }

        public Metric(Indicies indicies)
        {
            _name = typeof(Name).Name;
            _signature = typeof(Signature).Name;
            _indicies = indicies;

            MetricTensor = new double[4,4];
        }

        public Metric(Indicies indicies, double[,] metric)
        {
            _name = typeof(Name).Name;
            _signature = typeof(Signature).Name;
            _indicies = indicies;

            MetricTensor = metric;
        }

        public Metric (Indicies indicies, double zeroth, double first, double second, double third)
        {
            _name = typeof(Name).Name;
            _signature = typeof(Signature).Name;
            _indicies = indicies;

            MetricTensor = Matrix.Diagonal(zeroth, first, second, third);
        }

        public static FourVector Input(FourVector coordinate)
        {
            return Minkowski<Signature>.Calculate(coordinate);
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
