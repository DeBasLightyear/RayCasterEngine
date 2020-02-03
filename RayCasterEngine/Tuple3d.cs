using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayCasterEngine
{
    public class Tuple3d
    {
        protected (double x, double y, double z, double w) coord { get; set; }

        public Tuple3d(double x, double y, double z, double w)
        {
            coord = (x: x, y: y, z: z, w: w);
        }

        public double GetMagnitude()
        {
            var magX = Math.Pow(coord.x, 2);
            var magY = Math.Pow(coord.y, 2);
            var magZ = Math.Pow(coord.z, 2);

            return Math.Sqrt(magX + magY + magZ);
        }

        // Helper method
        private static Tuple3d GetNewTuple(double x, double y, double z, double w)
        {
            switch (w)
            {
                case 1:
                    return new Point3d(x, y, z);
                case 0:
                    return new Vector3d(x, y, z);
                default:
                    throw new System.InvalidOperationException("Invalid operation. Result is neither a point or a vector");
            }
        }

        // Overloading computation and comparison to make life easier
        public static bool operator ==(Tuple3d a, Tuple3d b) // return true if Tuple3d is equal to other Tuple3d
        {
            return (HelperMath.NearlyEqual(a.coord.x, b.coord.x) && HelperMath.NearlyEqual(a.coord.y, b.coord.y) && HelperMath.NearlyEqual(a.coord.z, b.coord.z) && a.coord.w == b.coord.w);
        }

        public static bool operator != (Tuple3d a, Tuple3d b)
        {
            return (!HelperMath.NearlyEqual(a.coord.x, b.coord.x) || !HelperMath.NearlyEqual(a.coord.y, b.coord.y) || !HelperMath.NearlyEqual(a.coord.z, b.coord.z) || a.coord.w != b.coord.w);
        }

        public static Tuple3d operator +(Tuple3d a, Tuple3d b)
        {
            var newX = a.coord.x + b.coord.x;
            var newY = a.coord.y + b.coord.y;
            var newZ = a.coord.z + b.coord.z;
            var newW = a.coord.w + b.coord.w;

            return GetNewTuple(newX, newY, newZ, newW);
        }

        public static Tuple3d operator -(Tuple3d a, Tuple3d b)
        {
            var newX = a.coord.x - b.coord.x;
            var newY = a.coord.y - b.coord.y;
            var newZ = a.coord.z - b.coord.z;
            var newW = a.coord.w - b.coord.w;

            return GetNewTuple(newX, newY, newZ, newW);
        }

        public static Tuple3d operator -(Tuple3d tup)
        {
            var newX = -tup.coord.x;
            var newY = -tup.coord.y;
            var newZ = -tup.coord.z;

            return GetNewTuple(newX, newY, newZ, tup.coord.w);
        }

        public static Tuple3d operator *(Tuple3d a, Tuple3d b)
        {
            var newX = a.coord.x * b.coord.x;
            var newY = a.coord.y * b.coord.y;
            var newZ = a.coord.z * b.coord.z;
            var newW = a.coord.w * b.coord.w;

            return GetNewTuple(newX, newY, newZ, newW);
        }

        public static Tuple3d operator /(Tuple3d a, Tuple3d b)
        {
            var newX = a.coord.x / b.coord.x;
            var newY = a.coord.y / b.coord.y;
            var newZ = a.coord.z / b.coord.z;
            var newW = a.coord.w / b.coord.w;

            return GetNewTuple(newX, newY, newZ, newW);
        }

        // Overriding basic methods
        public override string ToString()
        {
            return $"x: {coord.x}, y: {coord.y}, z: {coord.z}, w: {coord.w}";
        }
    }

    public class Point3d : Tuple3d
    {
        public Point3d(double x, double y, double z) : base(x, y, z, 1.0)
        {
        }
    }

    public class Vector3d : Tuple3d
    {
        public Vector3d(double x, double y, double z) : base(x, y, z, 0.0)
        {
        }
    }
}
