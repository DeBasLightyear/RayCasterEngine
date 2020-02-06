namespace RayCasterEngine
{
    public class Tuple3d : TupleData
    {
        public double X { get { return Tuple[0]; } }
        public double Y { get { return Tuple[1]; } }
        public double Z { get { return Tuple[2]; } }
        public double W { get { return Tuple[3]; } }

        public Tuple3d(double x, double y, double z, double w)
        {
            Tuple = new double[] { x, y, z, w };
        }

        public Tuple3d(double[] tuple)
        {
            if (tuple.Length != 4)
                throw new System.ArgumentException("A point or a vector must have an x, y, z and w value");
            Tuple = tuple;
        }

        public Tuple3d()
        {
            Tuple = new double[4];
        }

        public static Tuple<Tuple3d> Point(double x, double y, double z)
        {
            var point = new Tuple3d(x, y, z, 1.0);
            return new Tuple<Tuple3d>(point);
        }

        public static Tuple<Tuple3d> Vector(double x, double y, double z)
        {
            var vector = new Tuple3d(x, y, z, 0.0);
            return new Tuple<Tuple3d>(vector);
        }

        public static Tuple<Tuple3d> CrossProduct(Tuple3d a, Tuple3d b) // a method specific to vectors
        {
            var tupleData = Tuple3d.Vector (
                                a.Y * b.Z - a.Z * b.Y, // x
                                a.Z * b.X - a.X * b.Z, // y
                                a.X * b.Y - a.Y * b.X  // z
                            );
            return tupleData;
        }
    }
}