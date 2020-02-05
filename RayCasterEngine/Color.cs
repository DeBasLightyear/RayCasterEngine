using System;
using System.Collections.Generic;
using System.Text;

namespace RayCasterEngine
{
    public class Color
    {
        public Tuple tuple { get; }
        public double Red
        {
            get { return tuple.Content[0]; }
        }
        public double Green
        {
            get { return tuple.Content[1]; }
        }
        public double Blue
        {
            get { return tuple.Content[2]; }
        }

        public Color(double red, double green, double blue)
        {
            tuple = new Tuple(new double[] { red, green, blue });
        }

        public Color(Tuple t)
        {
            tuple = t;
        }
    }
}
