using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.Mathematics;
using Physics.Mathematics.DifferentialGeometry.Signatures;

namespace Physics.Mathematics.DifferentialGeometry.Metrics
{
    public class Minkowski<Signature> : IMetric
        where Signature : ISignature
    {
        private static string _signature = typeof(Signature).Name;
        private static double[,] MetricS130 = Matrix.Diagonal(1, -1, -1, -1);
        private static double[,] MetricS310 = Matrix.Diagonal(-1, 1, 1, 1);
        public static FourVector Calculate(FourVector coordinate)
        {
            if (_signature is "S130")
                return new FourVector(coordinate.Zeroth, -1 * coordinate.First, -1 * coordinate.Second, -1 * coordinate.Third);
            else
                return new FourVector(-1 * coordinate.Zeroth, coordinate.First, coordinate.Second, coordinate.Third);
        }

        public static Tensor Calculate(Tensor tensor)
        {
            Tensor result = new();
            if (_signature is "S130")
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        result[i, j] = MetricS130[i, i] * tensor[i, j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        result[i, j] = MetricS310[i, i] * tensor[i, j];
                    }
                }
            }
            return result;
        }
    }
}
