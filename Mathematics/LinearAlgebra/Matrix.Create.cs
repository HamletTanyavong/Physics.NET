namespace Physics.NET.Mathematics.LinearAlgebra
{
    public static partial class Matrix
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
    }
}
