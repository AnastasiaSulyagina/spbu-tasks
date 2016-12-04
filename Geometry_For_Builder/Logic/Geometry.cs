using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Circle
    {
        public double X;
        public double Y;
        public double Radius;
        public Circle(double x, double y, double r)
        {
            X = x;
            Y = y;
            Radius = r;
        }
    }
    public class Geometry
    {
        public static bool Check(Circle a, Circle b)
        {
            return a.Radius + b.Radius > Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
}
