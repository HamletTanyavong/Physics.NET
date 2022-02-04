using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.Mathematics
{
    public static class Matrix
    {
        public static double[,] Diagonal(double zeroth, double first, double second, double third)
        {
            return new double[,]
            {
                { zeroth, 0,     0,      0     },
                { 0,      first, 0,      0     },
                { 0,      0,     second, 0     },
                { 0,      0,     0,      third }
            };
        }

        //public static double[,] DiagonalMultiply<T>(double[,] object1, T object2)
        //    where T : 
        //{
        //    U result = new();
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 4; j++)
        //        {
        //            result[i, j] = object1[i, i] * object2[i, j];
        //        }
        //    }
        //}
    }
}
