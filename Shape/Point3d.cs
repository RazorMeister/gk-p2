using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_P2.Shape
{
    class Point3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point ToPoint()
        {
            return new Point((int)this.X, (int)this.Y);
        }
    }
}
