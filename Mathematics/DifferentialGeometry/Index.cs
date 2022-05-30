using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// Represents a tensor index.
    /// </summary>
    public struct Index<T> where T : class, IIndexPosition
    {
        public int? Location { get; set; } = null;
        public string IndexName { get; set; } = string.Empty;

        public Index()
        {
            Location = null;
            IndexName = String.Empty;
        }

        public Index(int location, string index)
        {
            Location = location;
            IndexName = index;
        }
    }
}
