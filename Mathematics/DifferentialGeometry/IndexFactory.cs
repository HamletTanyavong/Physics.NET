using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    internal static class IndexFactory
    {
        internal static IIndex CreateIndex<I>()
            where I : class, IIndexPosition
        {
            return new Index<I>();
        }
    }
}
