using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics.Helper
{
   internal static partial class Selector
    {
        internal static FourVector<T, I> Operation<T, I>(string coordinate, string operation, FourVector<T, I> a, FourVector<T, I> b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            string command = operation + coordinate;
            return command switch
            {
                "AddCartesian" => Operations.AddCartesian(a, b),
                "AddCylindrical" => Operations.AddCylindrical(a, b),
                "AddSpherical" => Operations.AddSpherical(a, b),
                "SubtractCartesian" => Operations.SubtractCartesian(a, b),
                "SubtractCylindrical" => Operations.SubtractCylindrical(a, b),
                "SubtractSpherical" => Operations.SubtractSpherical(a, b),
                "Multiply" => Operations.AddSpherical(a, b),
                _ => throw new ArgumentException($"{operation} is not a valid operation"),
            };
        }
    }
}
