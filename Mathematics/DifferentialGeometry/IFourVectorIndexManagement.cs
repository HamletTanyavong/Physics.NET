using Physics.NET.Mathematics.LinearAlgebra;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public interface IFourVectorIndexManagement<T>
        where T : class, ICoordinateSystem, I3D
    {
        FourVector<T, L> Lower(string index, Func<double, FourVector<T, U>, FourVector<T, L>> metric, double M);
        FourVector<T, L> Lower(string index, Func<FourVector<T, U>, FourVector<T, L>> metric);
        FourVector<T, U> Raise(string index, Func<double, FourVector<T, L>, FourVector<T, U>> metric, double M);
        FourVector<T, U> Raise(string index, Func<FourVector<T, L>, FourVector<T, U>> metric);
    }
}