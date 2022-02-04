using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.Mathematics.DifferentialGeometry.Metrics;
using Physics.Mathematics.DifferentialGeometry.Signatures;

namespace Physics.Mathematics.DifferentialGeometry
{
    public struct Tensor : ITensor
    {
        public int Rank { get; set; }

        private double[,] GeneralTensor { get; set; }

        public Tensor(Indicies indicies)
        {
            Rank = indicies.Rank;
            GeneralTensor = new double[4, 4];
        }

        public Tensor(Indicies indicies, double[,] tensor)
        {
            Rank = indicies.Rank;
            GeneralTensor = tensor;
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
            get => GeneralTensor[index1, index2];
            set => GeneralTensor[index1, index2] = value;
        }
    }
}
