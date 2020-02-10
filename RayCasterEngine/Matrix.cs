namespace RayCasterEngine
{
    public class Matrix
    {
        public double[,] Data { get; internal set; }

        public Matrix(double[,] data)
        {
            Data = data;
        }

        // Helper methods
        private static bool AreSameSize(Matrix a, Matrix b)
        {
            return a.Data.GetLength(0) == b.Data.GetLength(0) && a.Data.GetLength(1) == b.Data.GetLength(1);
        }

        private static bool AreEqual(Matrix a, Matrix b)
        {
            if (!AreSameSize(a, b))
                return false;
            
            var rowCount = a.Data.GetLength(0);
            var columnCount = b.Data.GetLength(1);
            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    if (a.Data[i,j] != b.Data[i,j])
                        return false;
                }
            }
            return true;
        }
        
        // Overloading operators
        public static bool operator ==(Matrix a, Matrix b)
        {
            return AreEqual(a, b);
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return !AreEqual(a, b);
        }

        // Overriding basic methods
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            
            var matrix = obj as Matrix;
            return AreEqual(this, matrix);
        }
    }
}