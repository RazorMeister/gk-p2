using System;
using System.Drawing;

namespace GK_P2.Filler
{
    class NodeAET
    {
        public Point a;
        public Point b;
        public int yMax;
        public double x; // punkt przecięcia ze scanlinią
        public double d; // d = 1 / m, tj. odwrotność współczynnika kierunkowego prostej

        public NodeAET(Point a, Point b, int yScanLine)
        {
            this.a = a;
            this.b = b;

            LineEquation eq = new LineEquation(a, b);
            this.d = 1 / eq.A;
            this.yMax = Math.Max(a.Y, b.Y);
            if (eq.verticalLine) this.x = eq.A;
            else this.x = ((double)yScanLine - eq.B) / eq.A;
        }

        public void UpdateX(int yScanLine)
        {
            LineEquation eq = new LineEquation(a, b);
            if (eq.verticalLine) this.x = eq.A;
            else this.x = ((double)yScanLine - eq.B) / eq.A;
        }
	}
}
