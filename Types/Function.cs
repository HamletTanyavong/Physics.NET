using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.Types
{
    public class Function<Coordinates>
        where Coordinates : class
    {
        public object Expression { get; set; }
        public string? Variables { get; set; }

        public Function(object expression, string variables)
        {
            Expression = expression;
            Variables = variables;
        }
    }
}
