// using System;
// using System.Linq;

// namespace RayCasterEngine
// {
//     public class Tuple
//     {
//         public double[] Content { get; set; }

//         public Tuple(double[] fieldValues)
//         {
//             Content = new double[fieldValues.Length];
//             Content = fieldValues;
//         }

//         // Private helper methods
//         private static void CheckTupleSizeMatch(Tuple a, Tuple b)
//         {
//             if (a.Content.Length != b.Content.Length)
//                 throw new System.ArgumentException("Tuples must be of same length.");
//         }
//         private static bool NearlyEqual(double a, double b)
//         {
//             var Epsilon = 0.00001;
//             return Math.Abs(a - b) < Epsilon;
//         }

//         public static bool TuplesAreEqual(Tuple a, Tuple b)
//         {
//             CheckTupleSizeMatch(a, b);
            
//             for (var i = 0; i < a.Content.Length; i++)
//             {   
//                 if (!NearlyEqual(a.Content[i], b.Content[i])) // if anything is not nearly equal, the tuples aren't equal
//                     return false;
//             }
//             return true; // if everything is nearly equal, the tuples are equal
//         }
        
//         private static Tuple OperateOnArray(Func<double, double, double> f, Tuple a, Tuple b)
//         {
//             CheckTupleSizeMatch(a, b);
            
//             var tupleContent = new double[a.Content.Length];
//             for (var i = 0; i < a.Content.Length; i++)
//                 tupleContent[i] = f(a.Content[i], b.Content[i]);
            
//             return new Tuple(tupleContent);
//         }

//         private static Tuple OperateOnArray(Func<double, double> f, Tuple t)
//         {
//             var tupleContent = new double[t.Content.Length];
//             for (var i = 0; i < t.Content.Length; i++)
//                 tupleContent[i] = f(t.Content[i]);

//             return new Tuple(tupleContent);
//         }

//         // Public methods
//         public static double DotProduct(Tuple a, Tuple b)
//         {
//             // First check if same size tuples
//             CheckTupleSizeMatch(a, b);
            
//             // Calculate dot product and return
//             var result = 0.0;
//             for (var i = 0; i < a.Content.Length; i++)
//                 result += a.Content[i] * b.Content[i];

//             return result;
//         }

//         public static double Magnitude(Tuple t)
//         {
//             // Calculate sum of each element to the power of 2
//             var sumPow = 0.0;
//             for (var i = 0; i < t.Content.Length; i++)
//                 sumPow += Math.Pow(t.Content[i], 2);
            
//             // Return the magnitude
//             return Math.Sqrt(sumPow);
//         }

//         public static Tuple Normalize(Tuple t)
//         {
//             var magnitude = Magnitude(t);
            
//             var tupleContent = new double[t.Content.Length];
//             for (var i = 0; i < t.Content.Length; i++)
//                 tupleContent[i] = t.Content[i] / magnitude;
            
//             return new Tuple(tupleContent);
//         }
        
//         // Overloading operators
//         public static bool operator ==(Tuple a, Tuple b)
//         {
//             return TuplesAreEqual(a, b);
//         }

//         public static bool operator !=(Tuple a, Tuple b)
//         {
//             return !TuplesAreEqual(a, b);
//         }

//         public static Tuple operator +(Tuple a, Tuple b)
//         {
//             Func<double, double, double> add = (double x, double y) => x + y;
//             return OperateOnArray(add, a, b);
//         }

//         public static Tuple operator -(Tuple a, Tuple b)
//         {
//             Func<double, double, double> subtract = (double x, double y) => x - y;
//             return OperateOnArray(subtract, a, b);
//         }

//         public static Tuple operator -(Tuple t)
//         {
//             Func<double, double> negate = (double x) => -x;
//             return OperateOnArray(negate, t);
//         }

//         public static Tuple operator *(Tuple a, Tuple b)
//         {
//             Func<double, double, double> multiply = (double x, double y) => x * y;
//             return OperateOnArray(multiply, a, b);
//         }

//         public static Tuple operator *(Tuple t, double d)
//         {
//             Func<double, double> multiplyByScalar = (double x) => x * d;
//             return OperateOnArray(multiplyByScalar, t);
//         }

//         public static Tuple operator /(Tuple a, Tuple b)
//         {
//             Func<double, double, double> divide = (double x, double y) => x / y;
//             return OperateOnArray(divide, a, b);
//         }

//         public static Tuple operator /(Tuple t, double d)
//         {
//             Func<double, double> divideByScalar = (double x) => x / d;
//             return OperateOnArray(divideByScalar, t);
//         }

//         // Overriding basic methods
//         public override string ToString()
//         {
//             return String.Join(", ", Content);
//         }

//         public override bool Equals(object obj)
//         {
//             if (obj is null)
//                 return false;
            
//             var tuple = obj as Tuple;
//             return TuplesAreEqual(this, tuple);
//         }

//         public override int GetHashCode()
//         {
//             var sum = 0.0;
//             for (var i = 0; i < Content.Length; i++)
//             {
//                 sum += Content[i];
//             }
//             return (int)sum;
//         }
//     }
// }