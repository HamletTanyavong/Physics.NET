using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    public interface ITensor
    {
        /// <summary>
        /// The rank of a tensor.
        /// </summary>
        int Rank { get; }
    }
}
