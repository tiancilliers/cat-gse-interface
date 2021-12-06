using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_V2
{
    class Utilities
    {
        public static double Map(double value, double fromA, double fromB, double toA, double toB)
        {
            return toA + (value - fromA) * (toB - toA) / (fromB - fromA);
        }
    }
}
