using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.Mathematics.DifferentialGeometry.Metrics;

namespace Physics.Mathematics.DifferentialGeometry
{
    public interface ITensor
    {
        /// <summary>
        /// The rank of a tensor.
        /// </summary>
        int Rank { get; set; }

        /// <summary>
        /// Raise an <paramref name="index"/> with a <paramref name="metric"/> of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="metric"></param>
        /// <param name="index"></param>
        void Raise<T>(T metric, string index) where T : IMetric;

        /// <summary>
        /// Lower an <paramref name="index"/> with a <paramref name="metric"/> of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="metric"></param>
        /// <param name="index"></param>
        void Lower<T>(T metric, string index) where T : IMetric;
    }
}
