using Physics.NET.Mathematics.DifferentialGeometry;

namespace Physics.NET.Mathematics.Helper
{
    internal static partial class Selector
    {
        internal static FourVector<T, I> Coordinate<T, I>(OperationMethod<T, I> method, string operation, FourVector<T, I> a, FourVector<T, I> b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition
        {
            var coordinateSystem = typeof(T).Name;
            return typeof(T).Name switch
            {
                "Cartesian" => method("Cartesian", operation, a, b),
                "Cylindrical" => method("Cylindrical", operation, a, b),
                "Spherical" => method("Spherical", operation, a, b),
                _ => throw new TypeAccessException($"{coordinateSystem} is not a valid coordinate system"),
            };
        }

        internal delegate FourVector<T, I> OperationMethod<T, I>(string coordinate, string operation, FourVector<T, I> a, FourVector<T, I> b)
            where T : class, ICoordinateSystem, I3D
            where I : class, IIndexPosition;
    }
}
