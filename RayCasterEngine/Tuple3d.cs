// using System;

// namespace RayCasterEngine
// {
//     public class Tuple3d
//     {
//         public Tuple tuple { get; }
//         public double X
//         { 
//             get { return tuple.Content[0]; }
//         }
//         public double Y
//         {
//             get { return tuple.Content[1]; }
//         }
//         public double Z
//         {
//             get { return tuple.Content[2]; }
//         }
//         public double W
//         {
//             get { return tuple.Content[3]; }
//         }

//         public Tuple3d(double x, double y, double z, double w)
//         {
//             tuple = new Tuple(new double[] { x, y, z, w });
//         }

//         public Tuple3d(Tuple t)
//         {
//             tuple = t;
//         }

//         // Public methods
//         public static Tuple3d Point(double x, double y, double z)
//         {
//             return new Tuple3d(x, y, z, 1.0);
//         }

//         public static Tuple3d Vector(double x, double y, double z)
//         {
//             return new Tuple3d(x, y, z, 0.0);
//         }

//         public static Tuple3d CrossProduct(Tuple3d a, Tuple3d b)
//         {
//             return Vector(a.Y * b.Z - a.Z * b.Y,
//                           a.Z * b.X - a.X * b.Z,
//                           a.X * b.Y - a.Y * b.X);
//         }

//         public static double DotProduct(Tuple3d a, Tuple3d b)
//         {
//             return Tuple.DotProduct(a.tuple, b.tuple);
//         }

//         public static double Magnitude(Tuple3d t)
//         {
//             return Tuple.Magnitude(t.tuple);
//         }

//         public static Tuple3d Normalize(Tuple3d t)
//         {
//             return new Tuple3d(Tuple.Normalize(t.tuple));
//         }

//         // Overloading operators (again)
//         public static bool operator ==(Tuple3d a, Tuple3d b)
//         {
//             return a.tuple == b.tuple;
//         }

//         public static bool operator !=(Tuple3d a, Tuple3d b)
//         {
//             return a.tuple != b.tuple;
//         }

//         public static Tuple3d operator +(Tuple3d a, Tuple3d b)
//         {
//             return new Tuple3d(a.tuple + b.tuple);
//         }

//         public static Tuple3d operator -(Tuple3d a, Tuple3d b)
//         {
//             return new Tuple3d(a.tuple - b.tuple);
//         }

//         public static Tuple3d operator -(Tuple3d t)
//         {
//             return new Tuple3d(-t.tuple);
//         }

//         public static Tuple3d operator *(Tuple3d a, Tuple3d b)
//         {
//             return new Tuple3d(a.tuple * b.tuple);
//         }

//         public static Tuple3d operator *(Tuple3d t, double d)
//         {
//             return new Tuple3d(t.tuple * d);
//         }

//         public static Tuple3d operator /(Tuple3d a, Tuple3d b)
//         {
//             return new Tuple3d(a.tuple / b.tuple);
//         }

//         public static Tuple3d operator /(Tuple3d t, double d)
//         {
//             return new Tuple3d(t.tuple / d);
//         }

//         // Overriding basic methods
//         public override string ToString()
//         {
//             return tuple.ToString();
//         }

//         public override bool Equals(object obj)
//         {
//             var toTest = obj as Tuple3d;
//             return Tuple.TuplesAreEqual(toTest.tuple, this.tuple);
//         }

//         public override int GetHashCode()
//         {
//             return tuple.GetHashCode();
//         }
//     }
// }
