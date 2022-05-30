using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public struct TensorR2
    {
        public int Rank { get; } = 2;

        private double[,] GeneralTensor { get; set; }

        public TensorR2()
        {
            GeneralTensor = new double[4, 4];
        }

        public TensorR2(double[,] tensor)
        {
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
