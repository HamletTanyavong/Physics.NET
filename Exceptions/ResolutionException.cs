using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.Exceptions
{
    [Serializable]
    public class ResolutionException : Exception
    {
        public uint Value { get; }

        public ResolutionException()
        {
        }

        public ResolutionException(string message)
            : base(message)
        {
        }

        public ResolutionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ResolutionException(string message, uint value)
            : this(message)
        {
            Value = value;
        }
    }
}
