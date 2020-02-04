using System;

namespace RayCasterEngine
{
    public class Tuple3d
    {
        public (double x, double y, double z, double w) coord { get; internal set; }

        public Tuple3d(double x, double y, double z, double w)
        {
            coord = (x: x, y: y, z: z, w: w);
        }

        // Static methods
        private static Tuple3d GetNewTuple3d(double x, double y, double z, double w)
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

        public static double GetDotProduct(Tuple3d a, Tuple3d b)
        {
            return a.coord.x * b.coord.x + a.coord.y * b.coord.y + a.coord.z * b.coord.z + a.coord.w * b.coord.w;
        }

        public static Vector3d GetCrossProduct(Tuple3d a, Tuple3d b)
        {
            return new Vector3d(a.coord.y * b.coord.z - a.coord.z * b.coord.y,
                                a.coord.z * b.coord.x - a.coord.x * b.coord.z,
                                a.coord.x * b.coord.y - a.coord.y * b.coord.x);
        }

        // Non-static methods
        private double GetMagnitude()
        {
            var magX = Math.Pow(coord.x, 2);
            var magY = Math.Pow(coord.y, 2);
            var magZ = Math.Pow(coord.z, 2);

            return Math.Sqrt(magX + magY + magZ);
        }

        public Tuple3d GetNormalizedTuple3d()
        {
            var magnitude = GetMagnitude();
            var newX = coord.x / magnitude;
            var newY = coord.y / magnitude;
            var newZ = coord.z / magnitude;

            return GetNewTuple3d(x: newX, y: newY, z: newZ, w: coord.w);
        }

        // Overloading computation and comparison to make life easier
        public static bool operator ==(Tuple3d a, Tuple3d b) // return true if Tuple3d is equal to other Tuple3d
        {
            return (HelperMath.NearlyEqual(a.coord.x, b.coord.x) && HelperMath.NearlyEqual(a.coord.y, b.coord.y) && HelperMath.NearlyEqual(a.coord.z, b.coord.z) && a.coord.w == b.coord.w);
        }

        public static bool operator !=(Tuple3d a, Tuple3d b)
        {
            return (!HelperMath.NearlyEqual(a.coord.x, b.coord.x) || !HelperMath.NearlyEqual(a.coord.y, b.coord.y) || !HelperMath.NearlyEqual(a.coord.z, b.coord.z) || a.coord.w != b.coord.w);
        }

        public static Tuple3d operator +(Tuple3d a, Tuple3d b)
        {
            var newX = a.coord.x + b.coord.x;
            var newY = a.coord.y + b.coord.y;
            var newZ = a.coord.z + b.coord.z;
            var newW = a.coord.w + b.coord.w;

            return GetNewTuple3d(newX, newY, newZ, newW);
        }

        public static Tuple3d operator -(Tuple3d a, Tuple3d b)
        {
            var newX = a.coord.x - b.coord.x;
            var newY = a.coord.y - b.coord.y;
            var newZ = a.coord.z - b.coord.z;
            var newW = a.coord.w - b.coord.w;

            return GetNewTuple3d(newX, newY, newZ, newW);
        }

        public static Tuple3d operator -(Tuple3d tup)
        {
            var newX = -tup.coord.x;
            var newY = -tup.coord.y;
            var newZ = -tup.coord.z;

            return GetNewTuple3d(newX, newY, newZ, tup.coord.w);
        }

        public static Tuple3d operator *(Tuple3d a, Tuple3d b)
        {
            var newX = a.coord.x * b.coord.x;
            var newY = a.coord.y * b.coord.y;
            var newZ = a.coord.z * b.coord.z;
            var newW = a.coord.w * b.coord.w;

            return GetNewTuple3d(newX, newY, newZ, newW);
        }

        public static Tuple3d operator /(Tuple3d a, Tuple3d b)
        {
            var newX = a.coord.x / b.coord.x;
            var newY = a.coord.y / b.coord.y;
            var newZ = a.coord.z / b.coord.z;
            var newW = a.coord.w / b.coord.w;

            return GetNewTuple3d(newX, newY, newZ, newW);
        }

        // Overriding basic methods
        public override string ToString()
        {
            return $"x: {coord.x}, y: {coord.y}, z: {coord.z}, w: {coord.w}";
        }

        public override bool Equals(object obj) // override to make the compiler happy
        {
            if (obj is null)
                return false;

            var tup = obj as Tuple3d;
            return (HelperMath.NearlyEqual(this.coord.x, tup.coord.x) && HelperMath.NearlyEqual(this.coord.y, tup.coord.y) && HelperMath.NearlyEqual(this.coord.z, tup.coord.z) && this.coord.w == tup.coord.w);
        }

        public override int GetHashCode() // override to make the compiler happy
        {
            return (int)(coord.x + coord.y + coord.z + coord.w);
        }
    }
}
