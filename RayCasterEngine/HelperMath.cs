using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayCasterEngine
{
    public static class HelperMath
    {
        private static double Epsilon = 0.00001;

        public static bool NearlyEqual(double a, double b)
        {
            return Math.Abs(a - b) < Epsilon;
        }
    }
}
