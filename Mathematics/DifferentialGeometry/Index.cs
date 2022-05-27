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
    public class Index
    {
        public int Location { get; set; }
        public string? IndexName { get; set; }
        public bool? Position { get; set; }

        public Index()
        {
            Location = 0;
            IndexName = null;
            Position = null;
        }

        public Index(int location, string index, bool position)
        {
            Location = location;
            IndexName = index;
            Position = position;
        }
    }
}
