using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Physics.Graphics
{
    public static class Plot
    {
        [DllImport("lib/Functions.dll")]
        public static extern void HelloWorld();


        public static void Plot2D()
        {
            HelloWorld();
        }
    }
}
