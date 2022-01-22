using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.Constants
{
    public class Structure
    {
        double Value { get; set; }
        double Error { get; set; }
        Dictionary<string, UnitForm>? Units { get; set; }

        public Structure()
        {
            this.Units = new Dictionary<string, UnitForm>()
            {
                { "Second", 0, 1 },
                { "Meter", UnitForm.Empty }
            };
        }
    }

    public class UnitName
    {
        public string? Second { get; set; }
        public string? Meter { get; set; }
        public string? Kilogram { get; set; }
        public string? Ampere { get; set; }
        public string? Kelvin { get; set; }
        public string? Mole { get; set; }
        public string? Candela { get; set; }
    }

    public class UnitForm
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public UnitForm(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
    }
}
