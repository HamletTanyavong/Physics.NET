using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Services
{
    public static partial class LaTeX
    {
        private static readonly string Prefix = @"\begin{align}";
        private static readonly string Suffix = @"\end{align}";
        public static string ToLaTeX<T>(Vector3D<T> vector)
            where T : class, ICoordinateSystem, I3D
        {
            if (true)
            {

            }
            string a = new("test");
            return a;
        }
    }
}
