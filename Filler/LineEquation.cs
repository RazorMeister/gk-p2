using System;
using System.Drawing;

namespace GK_P2.Filler
{
    public class LineEquation
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public bool VerticalLine { get; private set; } = false;

        public LineEquation(Point a, Point b)
        {
            if (Math.Abs(a.X - b.X) < 1) // 1 - some epsilon
            {
                this.VerticalLine = true;
                this.A = a.X;
                return;
            }

            this.A = (double)(a.Y - b.Y) / (double)(a.X - b.X);
            this.B = a.Y - A * a.X;
        }
	}
}
