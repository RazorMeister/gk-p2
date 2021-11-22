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
        public double Field { get; private set; }
        public Dictionary<Point, Point3d> Pixels { get; private set; }
        public Dictionary<Point, Vector3d> NormalVectors { get; private set; }

        public Point3d SelectedPoint { get; set; } = null;

        public Vector3d Normal { get; set; }

        public void SetUp()
        {
            double middleX = (this.Point1.X + this.Point2.X + this.Point3.X) / 3.0;
            double middleY = (this.Point1.Y + this.Point2.Y + this.Point3.Y) / 3.0;
            double middleZ = (this.Point1.Z + this.Point2.Z + this.Point3.Z) / 3.0;

            this.MidPoint = new Point3d() { X = middleX, Y = middleY, Z = middleZ };

            this.Field = this.GetTriangleField(this.Point1.ToPoint(), this.Point2.ToPoint(), this.Point3.ToPoint());

            var points = new List<Point>();
            points.Add(this.Point1.ToPoint());
            points.Add(this.Point2.ToPoint());
            points.Add(this.Point3.ToPoint());

            this.Pixels = new Dictionary<Point, Point3d>();

            Filler.Filler.FillPolygon(
                points,
                (x, y) => this.Pixels[new Point(x, y)] = new Point3d() { X = x, Y = y, Z = this.GetZ(x, y)}
            );

            this.NormalVectors = new Dictionary<Point, Vector3d>();

            foreach (Point pixel in this.Pixels.Keys)
                this.NormalVectors[pixel] = this.GetNormalVersor((int)pixel.X, (int)pixel.Y);
        }

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

        public void Draw(PaintEventArgs e, AbstractBitmap bm, Point light)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, Point1.ToPoint(), Point2.ToPoint());
            e.Graphics.DrawLine(pen, Point1.ToPoint(), Point3.ToPoint());
            e.Graphics.DrawLine(pen, Point2.ToPoint(), Point3.ToPoint());

            e.Graphics.FillEllipse(Brushes.Black, new Rectangle((int)(this.Point1.X - 3), (int)(this.Point1.Y - 3), 6, 6));
            e.Graphics.FillEllipse(Brushes.Black, new Rectangle((int)(this.Point2.X - 3), (int)(this.Point2.Y - 3), 6, 6));
            e.Graphics.FillEllipse(Brushes.Black, new Rectangle((int)(this.Point3.X - 3), (int)(this.Point3.Y - 3), 6, 6));

        }

        public void Generate(AbstractBitmap bm, Point light)
        {
            Action<int, int> callback = null;

            switch (Settings.FillCalculation)
            {
                case Settings.FillCalculationEnum.EACH_PIXEL:
                    if (bm.GetType() == typeof(CudaBitmap))
                        callback = (x, y) => ((CudaBitmap)bm).SetPixel(x, y, this.GetPixelStructForPixel(light, x, y, this.GetSavedZ(x, y)));
                    else
                        callback = (x, y) => bm.SetPixel(x, y, this.GetFillColorForPixel(light, x, y, this.GetSavedZ(x, y)));

                    break;
                case Settings.FillCalculationEnum.INTERPOLATION:
                    Color p1Color = this.GetFillColorForPixel(light, this.Point1.X, this.Point1.Y, this.Point1.Z);
                    Color p2Color = this.GetFillColorForPixel(light, this.Point2.X, this.Point2.Y, this.Point2.Z);
                    Color p3Color = this.GetFillColorForPixel(light, this.Point3.X, this.Point3.Y, this.Point3.Z);
                    callback = (x, y) => bm.SetPixel(x, y, this.InterpolateColorForPixel(x, y, p1Color, p2Color, p3Color));
                    break;
                case Settings.FillCalculationEnum.ONE_PIXEL:
                    Color wholeColor =
                        this.GetFillColorForPixel(light, this.MidPoint.X, this.MidPoint.Y, this.MidPoint.Z);
                    callback = (x, y) => bm.SetPixel(x, y, wholeColor);
                    break;
            }


            // If some params change during generating we do not want to throw exception
            try
            {
                foreach (Point pixel in this.Pixels.Keys)
                    callback(pixel.X, pixel.Y);
            }
            catch (Exception ex)
            {
                
            }
        }

        private int[] GetObjectColor(double x, double y, double z)
        {
            Color solidColor1 = Settings.ObjectSolidColor;
            return new int[] { solidColor1.R, solidColor1.G, solidColor1.B };
        }

        private double GetZ(int x, int y)
        {
            double xDistance = Math.Pow(x - Settings.CENTER_X, 2);
            double yDistance = Math.Pow(y - Settings.CENTER_Y, 2);

            return Math.Max(0.0, Math.Sqrt(Settings.SPHERE_R * Settings.SPHERE_R - xDistance - yDistance));
        }

        private Vector3d GetNormalVersor(int x, int y)
        {
            int x1 = x - Settings.CENTER_X;
            int y1 = y - Settings.CENTER_Y;

            Vector3d n = (new Vector3d() { X = x1, Y = y1, Z = Math.Sqrt(Settings.SPHERE_R * Settings.SPHERE_R + x1 * x1 + y1 * y1) }).ToVersor();

            if (
                Settings.ObjectFillType == Settings.ObjectFillTypeEnum.SOLID_COLOR
                || !Settings.TextureLoaded
                || (x >= Settings.NormalMap.GetLength(0) || y >= Settings.NormalMap.GetLength(1))
            )
                return n;

            Vector3d B = n.CrossProduct(new Vector3d() { X = 0, Y = 0, Z = 1 });
            Vector3d T = B.CrossProduct(n);
            Vector3d tN = Settings.NormalMap[x, y];

            Vector3d fromMatrix = new Vector3d()
            {
                X = tN.X * T.X + tN.Y * B.X + tN.Z + n.X,
                Y = tN.X * T.Y + tN.Y * B.Y + tN.Z + n.Y,
                Z = tN.X * T.Z + tN.Y * B.Z + tN.Z + n.Z,
            }.ToVersor();

            return (Settings.K * n + (1 - Settings.K) * fromMatrix).ToVersor();
        }

        private Vector3d GetSavedNormalVersor(int x, int y)
        {
            Point p = new Point(x, y);

            if (this.NormalVectors.ContainsKey(p))
                return this.NormalVectors[p];

            return this.GetNormalVersor(x, y);
        }

        public double GetSavedZ(int x, int y)
        {
            Point p = new Point(x, y);

            if (this.Pixels.ContainsKey(p))
                return this.Pixels[p].Z;

            return this.MidPoint.Z;
        }

        private PixelStruct GetPixelStructForPixel(Point light, double x, double y, double z)
        {
            int[] objectColor = this.GetObjectColor(x, y, z);
            Vector3d N = this.GetSavedNormalVersor((int)x, (int)y);

            return new PixelStruct(
                new ColorStruct(objectColor[0], objectColor[1], objectColor[2]),
                (float)z,
                new PointStruct((float)N.X, (float)N.Y, (float)N.Z)
            );
        }

        private double GetTriangleField(Point p1, Point p2, Point p3)
        {
            // 1/2 * Determinant(x1 - x2, y1 - y2 | x1 - x3, y1 - y3)

            double firstX = p1.X - p2.X;
            double firstY = p1.Y - p2.Y;

            double secondX = p1.X - p3.X;
            double secondY = p1.Y - p3.Y;

            return Math.Abs((firstX * secondY - firstY * secondX) / 2.0);
        }

        private Color InterpolateColorForPixel(int x, int y, Color p1Color, Color p2Color, Color p3Color)
        {
            Point currPoint = new Point(x, y);
            
            if (this.Field == 0)
                return p1Color;

            double p1Alfa = this.GetTriangleField(currPoint, this.Point2.ToPoint(), this.Point3.ToPoint()) / this.Field;
            double p2Alfa = this.GetTriangleField(currPoint, this.Point1.ToPoint(), this.Point3.ToPoint()) / this.Field;
            double p3Alfa = this.GetTriangleField(currPoint, this.Point1.ToPoint(), this.Point2.ToPoint()) / this.Field;

            return Color.FromArgb(
                255,
                Math.Min(255, (int)(p1Color.R * p1Alfa + p2Color.R * p2Alfa + p3Color.R * p3Alfa)),
                Math.Min(255, (int)(p1Color.G * p1Alfa + p2Color.G * p2Alfa + p3Color.G * p3Alfa)),
                Math.Min(255, (int)(p1Color.B * p1Alfa + p2Color.B * p2Alfa + p3Color.B * p3Alfa))
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

            Vector3d N = this.GetSavedNormalVersor((int)x, (int)y);

            double nCosL = N.ScalarProduct(L);

            Vector3d R = (N * (2 * nCosL) - L).ToVersor();

            double first = Settings.Kd * Math.Max(nCosL, 0.0);

            // Because vCosR = v scalar product r, and v.x = v.y = 0 and v.z = 1
            double vCosR = Math.Max(R.Z, 0.0);

            double second = vCosR > 0 ? Settings.Ks * Math.Pow(vCosR, Settings.M) : 0.0;

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
