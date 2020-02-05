using System;

namespace RayCasterEngine
{
    public class Tuple<T> where T : TupleData, new() // T must be a tuple type and must have a constructor without parameters
    {
        private T Data { get; }

        public Tuple(T tupleData)
        {
            Data = tupleData;
        }

        // Private helper methods
        private static bool NearlyEqual(double a, double b)
        {
            var Epsilon = 0.00001;
            return Math.Abs(a - b) < Epsilon;
        }
        
        private static void CheckTupleSizeMatch(double[] a, double[] b)
        {
            if (a.Length != b.Length)
                throw new System.ArgumentException("Tuples must be of same length.");
        }

        public static bool TuplesAreEqual(double[] a, double[] b)
        {
            CheckTupleSizeMatch(a, b);
            
            for (var i = 0; i < a.Length; i++)
            {   
                if (!NearlyEqual(a[i], b[i])) // if anything is not nearly equal, the tuples aren't equal
                    return false;
            }
            return true; // if everything is nearly equal, the tuples are equal
        }
        
        private static double[] OperateOnArray(Func<double, double, double> f, double[] a, double[] b)
        {
            CheckTupleSizeMatch(a, b);
            
            var tupleContent = new double[a.Length];
            for (var i = 0; i < a.Length; i++)
                tupleContent[i] = f(a[i], b[i]);
            
            return tupleContent;
        }

        private static double[] OperateOnArray(Func<double, double> f, double[] t)
        {
            var tupleContent = new double[t.Length];
            for (var i = 0; i < t.Length; i++)
                tupleContent[i] = f(t[i]);

            return tupleContent;
        }

        // Public methods
        public static double DotProduct(double[] a, double[] b)
        {
            // First check if same size tuples
            CheckTupleSizeMatch(a, b);
            
            // Calculate dot product and return
            var result = 0.0;
            for (var i = 0; i < a.Length; i++)
                result += a[i] * b[i];

            return result;
        }

        public static double Magnitude(double[] t)
        {
            // Calculate sum of each element to the power of 2
            var sumPow = 0.0;
            for (var i = 0; i < t.Length; i++)
                sumPow += Math.Pow(t[i], 2);
            
            // Return the magnitude
            return Math.Sqrt(sumPow);
        }

        public static double[] Normalize(double[] t)
        {
            var magnitude = Magnitude(t);
            
            var tupleContent = new double[t.Length];
            for (var i = 0; i < t.Length; i++)
                tupleContent[i] = t[i] / magnitude;
            
            return tupleContent;
        }

        // Overloading operators
        public static bool operator ==(Tuple<T> a, Tuple<T> b)
        {
            return TuplesAreEqual(a.Data.Tuple, b.Data.Tuple);
        }

        public static bool operator !=(Tuple<T> a, Tuple<T> b)
        {
            return !TuplesAreEqual(a.Data.Tuple, b.Data.Tuple);
        }

        public static Tuple<T> operator +(Tuple<T> a, Tuple<T> b)
        {
            // Create new TupleData
            Func<double, double, double> add = (double x, double y) => x + y;
            var tupleData = new T();
            tupleData.Tuple = OperateOnArray(add, a.Data.Tuple, b.Data.Tuple);

            // Return new Tuple
            return new Tuple<T>(tupleData);
        }

        public static Tuple<T> operator -(Tuple<T> a, Tuple<T> b)
        {
            // Create new TupleData
            Func<double, double, double> subtract = (double x, double y) => x - y;
            var tupleData = new T();
            tupleData.Tuple = OperateOnArray(subtract, a.Data.Tuple, b.Data.Tuple);
            
            // Return new Tuple
            return new Tuple<T>(tupleData);
        }

        public static Tuple<T> operator -(Tuple<T> t)
        {
            // Create new TupleData
            Func<double, double> negate = (double x) => -x;
            var tupleData = new T();
            tupleData.Tuple = OperateOnArray(negate, t.Data.Tuple);
            
            // Return new Tuple
            return new Tuple<T>(tupleData);
        }

        public static Tuple<T> operator *(Tuple<T> a, Tuple<T> b)
        {
            // Create new TupleData
            Func<double, double, double> multiply = (double x, double y) => x * y;
            var tupleData = new T();
            tupleData.Tuple = OperateOnArray(multiply, a.Data.Tuple, b.Data.Tuple);
            
            // Return new Tuple
            return new Tuple<T>(tupleData);
        }

        public static Tuple<T> operator *(Tuple<T> t, double d)
        {
            // Create new TupleData
            Func<double, double> multiplyByScalar = (double x) => x * d;
            var tupleData = new T();
            tupleData.Tuple = OperateOnArray(multiplyByScalar, t.Data.Tuple);
            
            // Return new Tuple
            return new Tuple<T>(tupleData);
        }

        public static Tuple<T> operator /(Tuple<T> a, Tuple<T> b)
        {
            // Create new TupleData
            Func<double, double, double> divide = (double x, double y) => x / y;
            var tupleData = new T();
            tupleData.Tuple = OperateOnArray(divide, a.Data.Tuple, b.Data.Tuple);
            
            // Return new Tuple
            return new Tuple<T>(tupleData);
        }

        public static Tuple<T> operator /(Tuple<T> t, double d)
        {
            // Create new TupleData
            Func<double, double> divideByScalar = (double x) => x / d;
            var tupleData = new T();
            tupleData.Tuple = OperateOnArray(divideByScalar, t.Data.Tuple);
            
            // Return new Tuple
            return new Tuple<T>(tupleData);
        }

        // Overriding basic methods
        public override string ToString()
        {
            return String.Join(", ", Data.Tuple);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            
            var tuple = obj as Tuple<T>;
            return TuplesAreEqual(Data.Tuple, tuple.Data.Tuple);
        }

        public override int GetHashCode()
        {
            var sum = 0.0;
            for (var i = 0; i < Data.Tuple.Length; i++)
            {
                sum += Data.Tuple[i];
            }
            return (int)sum;
        }
    }
}