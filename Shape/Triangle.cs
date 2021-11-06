using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_P2.Shape
{
    class Triangle
    {
        public Point3d Point1 { get; set; }
        public Point3d Point2 { get; set; }
        public Point3d Point3 { get; set; }
        public Vector3d Normal { get; set; }

        public void Draw(PaintEventArgs e, Point light)
        {
            Color color = this.GetFillColor(light);

            e.Graphics.FillPolygon(new SolidBrush(color), new Point[]{this.Point1.ToPoint(), this.Point2.ToPoint(), this.Point3.ToPoint()});

            Pen pen = new Pen(Color.FromArgb(0, 10, 0, 0));
            e.Graphics.DrawLine(pen, Point1.ToPoint(), Point2.ToPoint());
            e.Graphics.DrawLine(pen, Point1.ToPoint(), Point3.ToPoint());
            e.Graphics.DrawLine(pen, Point2.ToPoint(), Point3.ToPoint());
        }

        private Color GetFillColor(Point light)
        {
            int[] lightColor = new int[] { 255, 255, 255 };
            int[] objectColor = new int[] { 200, 100, 120 };
            //int[] objectColor = new int[] { 80, 170, 120 };

            int[] returnColor = new int[] { 0, 0, 0 };

            Vector3d L = (new Vector3d(){ X = (light.X - this.Point1.X), Y = (light.Y - this.Point1.Y), Z = (Settings.LightZ - this.Point1.Z) }).ToVersor();
            Vector3d N = this.Normal.ToVersor();
            Vector3d V = (new Vector3d() { X = 0, Y = 0, Z = 1 }).ToVersor();

            double NLScalar = N.ScalarProduct(L);

            Vector3d R = N * (2 * NLScalar) - L;

            int? min = null, max = null;

            for (int i = 0; i < 3; i++)
            {
                double iL = (double)lightColor[i] / 250;
                double iO = (double)objectColor[i];


                returnColor[i] = (int)(Settings.Kd * iL * iO * N.GetCos(L) + Settings.Ks * iL * iO * Math.Pow(V.GetCos(R), Settings.M));
                //Debug.WriteLine(N.GetCos(L));
                returnColor[i] = Math.Min(255, returnColor[i]);
                returnColor[i] = Math.Max(0, returnColor[i]);

                if (min == null || returnColor[i] < min)
                    min = returnColor[i];

                if (max == null || returnColor[i] < max)
                    max = returnColor[i];
            }



            return Color.FromArgb(255, returnColor[0], returnColor[1], returnColor[2]);
        }
    }
}
