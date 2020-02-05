namespace RayCasterEngine
{
    public class Vector : TupleData
    {
        public double X { get { return Tuple[0]; } }
        public double Y { get { return Tuple[1]; } }
        public double Z { get { return Tuple[2]; } }
        public double W { get { return Tuple[3]; } }

        public Vector(double x, double y, double z)
        {
            Tuple = new double[] { x, y, z, 0.0 };
        }

        public Vector()
        {
            Tuple = new double[4];
        }

        public static Tuple<Vector> CrossProduct(Vector a, Vector b) // a method specific to vectors
        {
            var tupleData = new Vector (
                                a.Y * b.Z - a.Z * b.Y,
                                a.Z * b.X - a.X * b.Z,
                                a.X * b.Y - a.Y * b.X
                            );
            var tuple = new Tuple<Vector>(tupleData);
            return tuple;
        }
    }
}