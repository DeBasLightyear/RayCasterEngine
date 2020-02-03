using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayCasterEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var point1 = new Point3d(3, -2, 5);
            var vector1 = new Vector3d(-2, 3, 1);

            var addedTuple = point1 + vector1;
            var expectedResult1 = new Point3d(1, 1, 6);

            Console.WriteLine(addedTuple);
            Console.WriteLine(expectedResult1);
            Console.WriteLine(addedTuple == expectedResult1);
            Console.WriteLine(addedTuple != expectedResult1);

            var point2 = new Point3d(3, 2, 1);
            var vector2 = new Vector3d(5, 6, 7);

            var subtractedTuple = point2 - vector2;
            var expectedResult2 = new Point3d(-2, -4, -6);

            Console.WriteLine(subtractedTuple);
            Console.WriteLine(expectedResult2);
            Console.WriteLine(subtractedTuple == expectedResult2);
            Console.WriteLine(subtractedTuple != expectedResult2);

            var negatedTuple = -point1;
            Console.WriteLine(point1);
            Console.WriteLine(negatedTuple);
        }
    }
}
