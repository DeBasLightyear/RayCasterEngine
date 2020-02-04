using System;

namespace RayCasterEngine
{
    class HelperMath
    {
        private static double Epsilon = 0.00001;

        public static bool NearlyEqual(double a, double b)
        {
            return Math.Abs(a - b) < Epsilon;
        }
    }
}
