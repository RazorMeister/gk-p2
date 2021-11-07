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
        public Point3d MidPoint { get; set; }

        public Point3d SelectedPoint { get; set; } = null;

        public Vector3d Normal { get; set; }

        public static double PointsDistance(Point p1, Point p2)
            => Math.Sqrt(Math.Pow(Math.Abs(p2.X - p1.X), 2) + Math.Pow(Math.Abs(p2.Y - p1.Y), 2));

        public Point3d GetNearestPoint(Point p)
        {
            if (PointsDistance(p, this.Point1.ToPoint()) <= 3)
                return this.Point1;

            if (PointsDistance(p, this.Point2.ToPoint()) <= 3)
                return this.Point2;

            if (PointsDistance(p, this.Point3.ToPoint()) <= 3)
                return this.Point3;

            return null;
        }

        public void SetMidPoint()
        {
            double x = (this.Point1.X + this.Point2.X + this.Point3.X) / 3.0;
            double y = (this.Point1.Y + this.Point2.Y + this.Point3.Y) / 3.0;
            double z = (this.Point1.Z + this.Point2.Z + this.Point3.Z) / 3.0;

            this.MidPoint = new Point3d() { X = x, Y = y, Z = z };
        } 

        public void Draw(PaintEventArgs e, FastBitmap bm, Point light)
        {
            Color color = this.GetFillColorForPixel(light, this.MidPoint.X, this.MidPoint.Y, this.MidPoint.Z);

            var points = new List<Point>();
            points.Add(this.Point1.ToPoint());
            points.Add(this.Point2.ToPoint());
            points.Add(this.Point3.ToPoint());

            if (Settings.EditMode)
            {
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                e.Graphics.DrawLine(pen, Point1.ToPoint(), Point2.ToPoint());
                e.Graphics.DrawLine(pen, Point1.ToPoint(), Point3.ToPoint());
                e.Graphics.DrawLine(pen, Point2.ToPoint(), Point3.ToPoint());

                e.Graphics.FillEllipse(Brushes.Black, new Rectangle((int)(this.Point1.X - 3), (int)(this.Point1.Y - 3), 6, 6));
                e.Graphics.FillEllipse(Brushes.Black, new Rectangle((int)(this.Point2.X - 3), (int)(this.Point2.Y - 3), 6, 6));
                e.Graphics.FillEllipse(Brushes.Black, new Rectangle((int)(this.Point3.X - 3), (int)(this.Point3.Y - 3), 6, 6));
            }
            else
                Filler.Filler.FillPolygon(points, color, bm);
        }

        private int[] GetObjectColor(double x, double y, double z)
        {
            switch (Settings.ObjectFillType)
            {
                case Settings.ObjectFillTypeEnum.SOLID_COLOR:
                    Color solidColor = Settings.ObjectSolidColor;
                    return new int[] { solidColor.R, solidColor.G, solidColor.B };
                case Settings.ObjectFillTypeEnum.TEXTURE:
                    return new int[]
                    {
                        (int)(((x - (Settings.CENTER_X - Settings.SPHERE_R)) / (Settings.SPHERE_R * 2)) * 255),
                        (int)((((Settings.CENTER_Y + Settings.SPHERE_R) - y) / (Settings.SPHERE_R * 2)) * 255),
                        (int)((z / Settings.SPHERE_R) * 255)
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

        private Color GetFillColorForPixel(Point light, double x, double y, double z)
        {
            int[] lightColor = new int[] { Settings.LightColor.R, Settings.LightColor.G, Settings.LightColor.B };
            int[] objectColor = this.GetObjectColor(x, y, z);

            if (!Settings.WithLight)
                return Color.FromArgb(255, objectColor[0], objectColor[1], objectColor[2]);

            int[] returnColor = new int[] { 0, 0, 0 };

            Vector3d L = (new Vector3d() { X = (light.X - x), Y = (light.Y - y), Z = (Settings.LightZ - z) }).ToVersor();
            Vector3d N = this.GetNormalVersor();
            Vector3d V = (new Vector3d() { X = 0, Y = 0, Z = 1 });

            double NLScalar = N.ScalarProduct(L);

            Vector3d R = N * (2 * NLScalar) - L;

            for (int i = 0; i < 3; i++)
            {
                double iL = (double)lightColor[i] / 255;
                double iO = (double)objectColor[i];

                returnColor[i] = (int)(Settings.Kd * iL * iO * N.GetCos(L) + Settings.Ks * iL * iO * Math.Pow(V.GetCos(R), Settings.M));

                returnColor[i] = Math.Min(255, returnColor[i]);
                returnColor[i] = Math.Max(0, returnColor[i]);
            }

            return Color.FromArgb(255, returnColor[0], returnColor[1], returnColor[2]);
        }
    }
}
