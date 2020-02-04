using System;

namespace RayCasterEngine
{
    public class Tuple3d
    {
        // public (double x, double y, double z, double w) coord { get; internal set; }
        public double X { get; internal set; }
        public double Y { get; internal set; }
        public double Z { get; internal set; }
        public double W { get; internal set; }

        public Tuple3d(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        // Static methods
        public static Tuple3d Point(double x, double y, double z)
        {
            return new Tuple3d(x, y, z, 1.0);
        }

        public static Tuple3d Vector(double x, double y, double z)
        {
            return new Tuple3d(x, y, z, 0.0);
        }

        public static double DotProduct(Tuple3d a, Tuple3d b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
        }

        public static Tuple3d CrossProduct(Tuple3d a, Tuple3d b)
        {
            return Vector(a.Y * b.Z - a.Z * b.Y,
                          a.Z * b.X - a.X * b.Z,
                          a.X * b.Y - a.Y * b.X);
        }

        public static double Magnitude(Tuple3d tup)
        {
            var magX = Math.Pow(tup.X, 2);
            var magY = Math.Pow(tup.Y, 2);
            var magZ = Math.Pow(tup.Z, 2);

            return Math.Sqrt(magX + magY + magZ);
        }

        public static Tuple3d Normalize(Tuple3d tup)
        {
            var magnitude = Magnitude(tup);
            var newX = tup.X / magnitude;
            var newY = tup.Y / magnitude;
            var newZ = tup.Z / magnitude;

            return new Tuple3d(x: newX, y: newY, z: newZ, w: tup.W);
        }

        // Overloading computation and comparison to make life easier
        public static bool operator ==(Tuple3d a, Tuple3d b) // return true if Tuple3d is equal to other Tuple3d
        {
            return (HelperMath.NearlyEqual(a.X, b.X) && HelperMath.NearlyEqual(a.Y, b.Y) && HelperMath.NearlyEqual(a.Z, b.Z) && a.W == b.W);
        }

        public static bool operator !=(Tuple3d a, Tuple3d b)
        {
            return (!HelperMath.NearlyEqual(a.X, b.X) || !HelperMath.NearlyEqual(a.Y, b.Y) || !HelperMath.NearlyEqual(a.Z, b.Z) || a.W != b.W);
        }

        public static Tuple3d operator +(Tuple3d a, Tuple3d b)
        {
            var newX = a.X + b.X;
            var newY = a.Y + b.Y;
            var newZ = a.Z + b.Z;
            var newW = a.W + b.W;

            return new Tuple3d(newX, newY, newZ, newW);
        }

        public static Tuple3d operator -(Tuple3d a, Tuple3d b)
        {
            var newX = a.X - b.X;
            var newY = a.Y - b.Y;
            var newZ = a.Z - b.Z;
            var newW = a.W - b.W;

            return new Tuple3d(newX, newY, newZ, newW);
        }

        public static Tuple3d operator -(Tuple3d tup)
        {
            var newX = -tup.X;
            var newY = -tup.Y;
            var newZ = -tup.Z;
            var newW = -tup.W;

            return new Tuple3d(newX, newY, newZ, newW);
        }

        public static Tuple3d operator *(Tuple3d a, Tuple3d b)
        {
            var newX = a.X * b.X;
            var newY = a.Y * b.Y;
            var newZ = a.Z * b.Z;
            var newW = a.W * b.W;

            return new Tuple3d(newX, newY, newZ, newW);
        }

        public static Tuple3d operator *(Tuple3d a, double b)
        {
            var newX = a.X * b;
            var newY = a.Y * b;
            var newZ = a.Z * b;
            var newW = a.W * b;

            return new Tuple3d(newX, newY, newZ, newW);
        }

        public static Tuple3d operator /(Tuple3d a, Tuple3d b)
        {
            var newX = a.X / b.X;
            var newY = a.Y / b.Y;
            var newZ = a.Z / b.Z;
            var newW = a.W / b.W;

            return new Tuple3d(newX, newY, newZ, newW);
        }

        public static Tuple3d operator /(Tuple3d a, double b)
        {
            var newX = a.X / b;
            var newY = a.Y / b;
            var newZ = a.Z / b;
            var newW = a.W / b;

            return new Tuple3d(newX, newY, newZ, newW);
        }

        // Overriding basic methods
        public override string ToString()
        {
            return $"x: {X}, y: {Y}, z: {Z}, w: {W}";
        }

        public override bool Equals(object obj) // override to make the compiler happy
        {
            if (obj is null)
                return false;

            var tup = obj as Tuple3d;
            return (HelperMath.NearlyEqual(this.X, tup.X) && HelperMath.NearlyEqual(this.Y, tup.Y) && HelperMath.NearlyEqual(this.Z, tup.Z) && this.W == tup.W);
        }

        public override int GetHashCode() // override to make the compiler happy
        {
            return (int)(X + Y + Z + W);
        }
    }
}
