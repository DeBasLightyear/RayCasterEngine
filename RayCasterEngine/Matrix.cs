using System.Linq;

namespace RayCasterEngine
{
  public class Matrix
  {
    public double[,] Data { get; internal set; }

    public Matrix(double[,] data)
    {
      Data = data;
    }

    public Matrix Transpose()
    {
      var result = new double[Data.GetLength(0), Data.GetLength(1)];
      var rowCount = Data.GetLength(0);
      var columnCount = Data.GetLength(1);

      for (var i = 0; i < rowCount; i++)
      {
        var column = GetColumn(Data, i);
        for (var j = 0; j < columnCount; j++)
        {
          result[i, j] = column[j];
        }
      }

      Data = result;
      return this;
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
          if (a.Data[i, j] != b.Data[i, j])
            return false;
        }
      }
      return true;
    }

    private static double[] GetRow(double[,] m, int rowNumber)
    {
      return Enumerable.Range(0, m.GetLength(1))
        .Select(columnNumber => m[rowNumber, columnNumber])
        .ToArray();
    }

    private static double[] GetColumn(double[,] m, int columnNumber)
    {
      return Enumerable.Range(0, m.GetLength(0))
        .Select(rowNumber => m[rowNumber, columnNumber])
        .ToArray();
    }

    private static double GetProduct(Matrix a, Matrix b, int row, int column)
    {
      var length = a.Data.GetLength(0);

      double result = 0;
      for (var i = 0; i < length; i++)
      {
        result += a.Data[row, i] * b.Data[i, column];
      }

      return result;
    }

    private static double GetProduct(double[] row, double[] column)
    {
      double result = 0;

      for (var i = 0; i < row.Length; i++)
      {
        result += row[i] * column[i];
      }

      return result;
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

    public static Matrix operator *(Matrix a, Matrix b)
    {
      var rowCount = a.Data.GetLength(0);
      var columnCount = b.Data.GetLength(1);
      double[,] result = new double[rowCount, columnCount];

      for (var i = 0; i < rowCount; i++)
      {
        for (var j = 0; j < columnCount; j++)
        {
          result[i, j] = GetProduct(a, b, i, j);
        }
      }

      return new Matrix(result);
    }

    public static Tuple3d operator *(Matrix matrix, Tuple3d tuple)
    {
      // takes rows from matrix
      // multiple with tuple as if it was a single column from a matrix
      var result = new double[4];

      for (var i = 0; i < tuple.Data.Length; i++)
      {
        var row = GetRow(matrix.Data, i);
        result[i] = GetProduct(row, tuple.Data);
      }

      return new Tuple3d(result);
    }

    // Overriding basic methods
    public override bool Equals(object obj)
    {
      if (obj is null)
        return false;

      var matrix = obj as Matrix;
      return AreEqual(this, matrix);
    }

    public override int GetHashCode()
    {
      return Data.GetHashCode();
    }
  }
}