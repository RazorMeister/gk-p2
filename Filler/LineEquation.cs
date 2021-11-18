using System;
using System.Drawing;

namespace GK_P2.Filler
{
    public class LineEquation
    {
        private static int eps = 1;

        public double A;
        public double B;
        public bool verticalLine = false;

        public LineEquation(Point a, Point b)
        {
            if (Math.Abs(a.X - b.X) < LineEquation.eps)
            {
                this.verticalLine = true;
                this.A = a.X;
                return;
            }

            this.A = (double)(a.Y - b.Y) / (double)(a.X - b.X);
            this.B = a.Y - A * a.X;
        }
	}
}
