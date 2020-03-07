using System;

namespace RayCasterEngine
{
    public class Tuple<T> where T : Tuple<T>, new()
    {
        public double[] Data { get; internal set; }

        public Tuple(double[] tupleData)
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
        public static double DotProduct(Tuple<T> a, Tuple<T> b)
        {
            // First check if same size tuples
            CheckTupleSizeMatch(a.Data, b.Data);
            
            // Calculate dot product and return
            var result = 0.0;
            for (var i = 0; i < a.Data.Length; i++)
                result += a.Data[i] * b.Data[i];

            return result;
        }

        public static double Magnitude(Tuple<T> t)
        {
            // Calculate sum of each element to the power of 2
            var sumPow = 0.0;
            for (var i = 0; i < t.Data.Length; i++)
                sumPow += Math.Pow(t.Data[i], 2);
            
            // Return the magnitude
            return Math.Sqrt(sumPow);
        }

        public static T Normalize(Tuple<T> t)
        {
            // Normalize tuple
            var data = t.Data;
            var magnitude = Magnitude(t);
            var tupleContent = new double[data.Length];
            for (var i = 0; i < data.Length; i++)
                tupleContent[i] = data[i] / magnitude;
            
            // Put result in new tuple and return
            var newTuple = new T();
            newTuple.Data = tupleContent;
            return newTuple;
        }

        // Overloading operators
        public static bool operator ==(Tuple<T> a, Tuple<T> b)
        {
            return TuplesAreEqual(a.Data, b.Data);
        }

        public static bool operator !=(Tuple<T> a, Tuple<T> b)
        {
            return !TuplesAreEqual(a.Data, b.Data);
        }

        public static T operator +(Tuple<T> a, Tuple<T> b)
        {
            // Create new TupleData
            Func<double, double, double> add = (double x, double y) => x + y;
            var newTuple = new T();
            newTuple.Data = OperateOnArray(add, a.Data, b.Data);

            // Return new Tuple
            return newTuple;
        }

        public static T operator -(Tuple<T> a, Tuple<T> b)
        {
            // Create new TupleData
            Func<double, double, double> subtract = (double x, double y) => x - y;
            var newTuple = new T();
            newTuple.Data = OperateOnArray(subtract, a.Data, b.Data);
            
            // Return new Tuple
            return newTuple;
        }

        public static T operator -(Tuple<T> t)
        {
            // Create new TupleData
            Func<double, double> negate = (double x) => -x;
            var newTuple = new T();
            newTuple.Data = OperateOnArray(negate, t.Data);
            
            // Return new Tuple
            return newTuple;
        }

        public static T operator *(Tuple<T> a, Tuple<T> b)
        {
            // Create new TupleData
            Func<double, double, double> multiply = (double x, double y) => x * y;
            var newTuple = new T();
            newTuple.Data = OperateOnArray(multiply, a.Data, b.Data);
            
            // Return new Tuple
            return newTuple;
        }

        public static T operator *(Tuple<T> t, double d)
        {
            // Create new TupleData
            Func<double, double> multiplyByScalar = (double x) => x * d;
            var newTuple = new T();
            newTuple.Data = OperateOnArray(multiplyByScalar, t.Data);
            
            // Return new Tuple
            return newTuple;
        }

        public static T operator /(Tuple<T> a, Tuple<T> b)
        {
            // Create new TupleData
            Func<double, double, double> divide = (double x, double y) => x / y;
            var newTuple = new T();
            newTuple.Data = OperateOnArray(divide, a.Data, b.Data);
            
            // Return new Tuple
            return newTuple;
        }

        public static T operator /(Tuple<T> t, double d)
        {
            // Create new TupleData
            Func<double, double> divideByScalar = (double x) => x / d;
            var newTuple = new T();
            newTuple.Data = OperateOnArray(divideByScalar, t.Data);
            
            // Return new Tuple
            return newTuple;
        }

        // Overriding basic methods
        public override string ToString()
        {
            return String.Join(", ", Data);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            
            var tuple = obj as T;
            return TuplesAreEqual(Data, tuple.Data);
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }
    }
}