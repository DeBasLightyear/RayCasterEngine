namespace RayCasterEngine
{
     public class Point : TupleData
    {
        public double X { get { return Tuple[0]; } }
        public double Y { get { return Tuple[1]; } }
        public double Z { get { return Tuple[2]; } }
        public double W { get { return Tuple[3]; } }
        public int TupleLength { get { return Tuple.Length; } }

        public Point(double x, double y, double z)
        {
            Tuple = new double[] { x, y, z, 1.0 };
        }

        public Point()
        {
            Tuple = new double[4];
        }
    }
}