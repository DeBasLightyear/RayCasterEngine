using System;
using System.Collections.Generic;
using System.Text;

namespace RayCasterEngine
{
    public class Color : Tuple<Color>
    {
        public double Red { get { return Data[0]; } }
        public double Green { get { return Data[1]; } }
        public double Blue { get { return Data[2]; } }

        public Color() : base(new double[3])
        {
        }

        public Color(double red, double green, double blue) : base(new double[] { red, green, blue })
        {
        }

        public Color(double[] tuple) : base(tuple)
        {
            if (tuple.Length != 3)
                throw new System.ArgumentException("A color must have a red, green and blue value");
        }
    }
}
