using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void Draw(PaintEventArgs e, AbstractBitmap bm, Point light)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, Point1.ToPoint(), Point2.ToPoint());
            e.Graphics.DrawLine(pen, Point1.ToPoint(), Point3.ToPoint());
            e.Graphics.DrawLine(pen, Point2.ToPoint(), Point3.ToPoint());

            e.Graphics.FillEllipse(Brushes.Black, new Rectangle((int)(this.Point1.X - 3), (int)(this.Point1.Y - 3), 6, 6));
            e.Graphics.FillEllipse(Brushes.Black, new Rectangle((int)(this.Point2.X - 3), (int)(this.Point2.Y - 3), 6, 6));
            e.Graphics.FillEllipse(Brushes.Black, new Rectangle((int)(this.Point3.X - 3), (int)(this.Point3.Y - 3), 6, 6));

        }//(x, y) => this.GetFillColorForPixel(light, x, y, this.MidPoint.Z)

        public void Generate(AbstractBitmap bm, Point light)
        {
            /*Color color = this.GetFillColorForPixel(light, this.MidPoint.X, this.MidPoint.Y, this.MidPoint.Z);*/

            var points = new List<Point>();
            points.Add(this.Point1.ToPoint());
            points.Add(this.Point2.ToPoint());
            points.Add(this.Point3.ToPoint());

            Filler.Filler.FillPolygon(
                points: points, 
                color: Color.Black,
                bm: bm,
                getColorFunc: (x, y) => this.GetFillColorForPixel(light, x, y, this.MidPoint.Z),
                getPixelStructFunc: (x, y) => this.GetPixelStructForPixel(light, x, y, this.MidPoint.Z)
            );
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

        private Vector3d GetNormalVersor(int x, int y)
        {
            if (Settings.ObjectFillType == Settings.ObjectFillTypeEnum.SOLID_COLOR || !Settings.TextureLoaded)
                return this.Normal.ToVersor();

            return (Settings.K * this.Normal.ToVersor() + (1 - Settings.K) * Settings.NormalMap[x, y]).ToVersor();
        }

        private PixelStruct GetPixelStructForPixel(Point light, double x, double y, double z)
        {
            int[] objectColor = this.GetObjectColor(x, y, z);
            Vector3d N = this.GetNormalVersor((int)x, (int)y);

            return new PixelStruct(
                new ColorStruct(objectColor[0], objectColor[1], objectColor[2]),
                (float)z,
                new PointStruct((float)N.X, (float)N.Y, (float)N.Z)
            );
        }

        private Color GetFillColorForPixel(Point light, double x, double y, double z)
        {
            double[] lightColor = new double[] { Settings.LightColor.R / (double)255, Settings.LightColor.G / (double)255, Settings.LightColor.B / (double)255 };
            int[] objectColor = this.GetObjectColor(x, y, z);

            if (!Settings.WithLight)
                return Color.FromArgb(255, objectColor[0], objectColor[1], objectColor[2]);

            int[] returnColor = new int[] { 0, 0, 0 };

            Vector3d L = (new Vector3d() { X = (light.X - x), Y = (light.Y - y), Z = (Settings.LightZ - z) }).ToVersor();

            Vector3d N = this.GetNormalVersor((int)x, (int)y);

            double nCosL = N.ScalarProduct(L);

            Vector3d R = (N * (2 * nCosL) - L).ToVersor();

            double first = Settings.Kd * Math.Max(nCosL, 0.0);

            // Because vCosR = v scalar product r, and v.x = v.y = 0 and v.z = 1
            double vCosR = R.Z;

            double second = Settings.Ks * Math.Pow(vCosR, Settings.M);

            for (int i = 0; i < 3; i++)
            {
                double iL = (double)lightColor[i];
                double iO = (double)objectColor[i];

                double iLiO = iL * iO;

                returnColor[i] = (int)(first * iLiO  + second * iLiO);

                returnColor[i] = Math.Min(255, returnColor[i]);
                returnColor[i] = Math.Max(0, returnColor[i]);
            }

            return Color.FromArgb(255, returnColor[0], returnColor[1], returnColor[2]);
        }
    }
}
