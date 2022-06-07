using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.GeneralRelativity
{
    public static class Lorentz
    {
        public static FourVector<Cartesian, U> Boost(Vector3D<Cartesian> v, FourVector<Cartesian, U> a)
        {
            var Matrix = TransformationMatrix(v);
            FourVector<Cartesian, U> result = new();
            for (int i = 0; i < 4; i++)
            {
                result[i] = Matrix[i, 0] * a.X0 + Matrix[i, 1] * a.X1 + Matrix[i, 2] * a.X2 + Matrix[i, 3] * a.X3;
            }
            return result;
        }

        public static double[,] TransformationMatrix(Vector3D<Cartesian> v)
        {
            double vSquared = v.X1 * v.X1 + v.X2 * v.X2 + v.X3 * v.X3;
            double gamma = Gamma(v);
            double gv;

            if (vSquared != 0)
                gv = (gamma - 1) / vSquared;
            else
                gv = 0;

            return new double[4, 4]
            {
                {        gamma,        -gamma * v.X1,        -gamma * v.X2,        -gamma * v.X3},
                {-gamma * v.X1, 1 + gv * v.X1 * v.X1,     gv * v.X1 * v.X2,     gv * v.X1 * v.X3},
                {-gamma * v.X2,     gv * v.X1 * v.X2, 1 + gv * v.X2 * v.X2,     gv * v.X2 * v.X3},
                {-gamma * v.X3,     gv * v.X1 * v.X3,     gv * v.X2 * v.X3, 1 + gv * v.X3 * v.X3}
            };
        }

        public static double Gamma(Vector3D<Cartesian> v)
        {
            double vSquared = v.X1 * v.X1 + v.X2 * v.X2 + v.X3 * v.X3;
            if (vSquared >= 1)
            {
                throw new ArgumentException($"error: The magnitude of {v} meets or exceeds speed of light in natural units.");
            }
            return 1 / Math.Sqrt(1 - v.X1 * v.X1 + v.X2 * v.X2 + v.X3 * v.X3);
        }

        public static double Rapidity(Vector3D<Cartesian> v)
        {
            return Math.Atanh(Math.Sqrt(v.X1 * v.X1 + v.X2 * v.X2 + v.X3 * v.X3));
        }
    }
}
