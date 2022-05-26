using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.NET.Mathematics;
using Physics.NET.Mathematics.Vectors;

namespace Physics.NET.Mathematics.DifferentialGeometry.Metrics
{
    public class Minkowski : IMetric
    {
        private static double[,] MetricS130 = Matrix.Diagonal(1, -1, -1, -1);
        private static double[,] MetricS310 = Matrix.Diagonal(-1, 1, 1, 1);

        internal static double[,] Calculate<T>(FourVector<T> fourVector)
            where T : class, ICoordinateSystem, I3D
        {
            return Matrix.Diagonal(-1, 1, 1, 1);
        }

        internal static double[,] CalculateTest<T>(FourVector<T> fourVector)
            where T : class, ICoordinateSystem, I3D
        {
            return Matrix.Diagonal(-1 * fourVector.Zeroth, fourVector.First, fourVector.Second, fourVector.Third);
        }

        //internal static Tensor Calculate(Tensor tensor)
        //{
        //    Tensor result = new();
        //    if (typeof(U).Name is "S130")
        //    {
        //        for (int i = 0; i < 4; i++)
        //        {
        //            for (int j = 0; j < 4; j++)
        //            {
        //                result[i, j] = MetricS130[i, i] * tensor[i, j];
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < 4; i++)
        //        {
        //            for (int j = 0; j < 4; j++)
        //            {
        //                result[i, j] = MetricS310[i, i] * tensor[i, j];
        //            }
        //        }
        //    }
        //    return result;
        //}
    }
}
