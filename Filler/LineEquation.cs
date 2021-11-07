using System;
using System.Drawing;

namespace GK_P2.Filler
{
    class LineEquation
    {
        public double A;
        public double B;
        public bool verticalLine = false;
        private static int eps = 1;

        public LineEquation(Point a, Point b)
        {
            // Szczególny przypadek - pionowa linia
            if (Math.Abs(a.X - b.X) < LineEquation.eps)
            {
                this.verticalLine = true;
                this.A = a.X;
                return;
            }

            // Standardowe przypadki
            this.A = (double)(a.Y - b.Y) / (double)(a.X - b.X);
            this.B = a.Y - A * a.X;
        }
	}
}
