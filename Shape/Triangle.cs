using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GK_P2.Bitmap;

namespace GK_P2.Shape
{
    class Triangle
    {
        public Point3d Point1 { get; set; }
        public Point3d Point2 { get; set; }
        public Point3d Point3 { get; set; }
        public Vector3d Normal { get; set; }

        public void Draw(PaintEventArgs e, FastBitmap bm, Point light)
        {
            Color color = this.GetFillColor(light);

            var points = new List<Point>();
            points.Add(this.Point1.ToPoint());
            points.Add(this.Point2.ToPoint());
            points.Add(this.Point3.ToPoint());

            Filler.Filler.FillPolygon(points, color, bm);

            //e.Graphics.FillPolygon(new SolidBrush(color), new Point[]{});
            /*Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, Point1.ToPoint(), Point2.ToPoint());
            e.Graphics.DrawLine(pen, Point1.ToPoint(), Point3.ToPoint());
            e.Graphics.DrawLine(pen, Point2.ToPoint(), Point3.ToPoint());*/
        }

        private int[] GetObjectColor()
        {
            switch (Settings.ObjectFillType)
            {
                case Settings.ObjectFillTypeEnum.SOLID_COLOR:
                    Color solidColor = Settings.ObjectSolidColor;
                    return new int[] { solidColor.R, solidColor.G, solidColor.B };
                case Settings.ObjectFillTypeEnum.TEXTURE:
                    return new int[]
                    {
                        (int)(((this.Point1.X - 10) / 480) * 255),
                        (int)(((490 - this.Point1.Y) / 480)*255),
                        (int)(((this.Point1.Z) / 240) * 255)
                    };
                default:
                    throw new Exception("Invalid ObjectFillType");
            }
        }

        private Vector3d GetNormalVersor()
        {
            if (Settings.ObjectFillType == Settings.ObjectFillTypeEnum.SOLID_COLOR || !Settings.TextureLoaded)
                return this.Normal.ToVersor();

            return (Settings.K * this.Normal.ToVersor() + (1 - Settings.K) * Settings.NormalMap[(int)this.Point1.X, (int)this.Point1.Y].ToVersor()).ToVersor();
        }

        private Color GetFillColor(Point light)
        {
            int[] lightColor = new int[] { Settings.LightColor.R, Settings.LightColor.G, Settings.LightColor.B };
            int[] objectColor = this.GetObjectColor();

            if (!Settings.WithLight)
                return Color.FromArgb(255, objectColor[0], objectColor[1], objectColor[2]);

            int[] returnColor = new int[] { 0, 0, 0 };

            Vector3d L = (new Vector3d(){ X = (light.X - this.Point1.X), Y = (light.Y - this.Point1.Y), Z = (Settings.LightZ - this.Point1.Z) }).ToVersor();
            Vector3d N = this.GetNormalVersor();
            Vector3d V = (new Vector3d() { X = 0, Y = 0, Z = 1 }).ToVersor();

            double NLScalar = N.ScalarProduct(L);

            Vector3d R = N * (2 * NLScalar) - L;

            int? min = null, max = null;

            for (int i = 0; i < 3; i++)
            {
                double iL = (double)lightColor[i] / 255;
                double iO = (double)objectColor[i];

                returnColor[i] = (int)(Settings.Kd * iL * iO * N.GetCos(L) + Settings.Ks * iL * iO * Math.Pow(V.GetCos(R), Settings.M));
                
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
