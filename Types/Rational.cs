using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.Types
{
    public class Rational
    {
        public long Numerator { get; set; }
        public long Denominator { get; set; } = 1;

        public Rational(long numerator, long denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
    }
}
