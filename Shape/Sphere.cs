using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GK_P2.Bitmap;
using System.Threading.Tasks;

namespace GK_P2.Shape
{
    class Sphere : ISphere
    {
        private List<Triangle> triangleList;

        public Point3d Center { get; private set; }
        public int Radius { get; private set; }

        public Sphere(Point3d center, int radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public int GetTrianglesCount() => this.triangleList.Count;

        public List<Triangle> GeTriangles() => this.triangleList;

        public void Draw(PaintEventArgs e, AbstractBitmap bm, Point light)
        {
            if (Settings.EditMode == true)
            {
                this.triangleList.ForEach(triangle => triangle.Draw(e, bm, light));
                return;
            }

            /*int range = this.triangleList.Count / 100;

            Parallel.For(0, (int)Math.Ceiling((double)this.triangleList.Count / range), num =>
            {
                for (int i = 0; i < range; i++)
                {
                    int index = num * range + i;
                    if (index >= this.triangleList.Count) break;
                    this.triangleList[index].Generate(bm, light);
                }

            });*/
            Parallel.For(0, this.triangleList.Count - 1, num => this.triangleList[num].Generate(bm, light));
        }

        public void Triangulate()
        {
            this.triangleList = new List<Triangle>();
            var trlist = this.CreateTriangles(Settings.SphereDensity);

            for (int i = 0; i < trlist.Count; i++)
            {
                Triangle tr = new Triangle();
                Point3d p1 = new Point3d(), p2 = new Point3d(), p3 = new Point3d();


                p1.X = trlist[i].Point1.X * this.Radius + this.Center.X;
                p1.Y = trlist[i].Point1.Y * this.Radius + this.Center.Y;
                p1.Z = trlist[i].Point1.Z * this.Radius + this.Center.Z;
                                                          
                p2.X = trlist[i].Point2.X * this.Radius + this.Center.X;
                p2.Y = trlist[i].Point2.Y * this.Radius + this.Center.Y;
                p2.Z = trlist[i].Point2.Z * this.Radius + this.Center.Z;
                                                          
                p3.X = trlist[i].Point3.X * this.Radius + this.Center.X;
                p3.Y = trlist[i].Point3.Y * this.Radius + this.Center.Y;
                p3.Z = trlist[i].Point3.Z * this.Radius + this.Center.Z;

                if (p1.Z < 0) continue;

                tr.Point1 = p1;
                tr.Point2 = p2;
                tr.Point3 = p3;
                tr.Normal = trlist[i].Normal.ToVersor();
                tr.SetUp();

                this.triangleList.Add(tr);
            }
        }

        private List<Triangle> CreateTriangles(int density)
        {
            int count = density * 2;
            double steps = Math.PI / density;

            Point3d[,] pointList = new Point3d[density + 1, count + 1];

            for (int tita = 0; tita <= density; tita++)
            {
                double vtita = tita * steps;

                for (int nphi = -density; nphi <= density; nphi++)
                {
                    double vphi = nphi * steps;
                    pointList[tita, nphi + density] = new Point3d();
                    pointList[tita, nphi + density].X = Math.Sin(vtita) * Math.Cos(vphi);
                    pointList[tita, nphi + density].Y = Math.Sin(vtita) * Math.Sin(vphi);
                    pointList[tita, nphi + density].Z = Math.Cos(vtita);
                }
            }

            List<Triangle> toReturn = new List<Triangle>();

            for (int n_tita = 1; n_tita <= pointList.GetLength(0) - 1; n_tita++)
            {
                for (int n_phi = 0; n_phi <= pointList.GetLength(1) - 1; n_phi++)
                {
                    Triangle t1 = new Triangle();
                    Triangle t2 = new Triangle();

                    t1.Point1 = pointList[n_tita, n_phi];
                    t1.Point2 = pointList[n_tita, (n_phi + 1) % pointList.GetLength(1)];
                    t1.Point3 = pointList[n_tita - 1, n_phi];
                    t1.Normal = new Vector3d() { X = t1.Point1.X, Y = t1.Point1.Y, Z = t1.Point1.Z };

                    t2.Point1 = pointList[n_tita, (n_phi + 1) % pointList.GetLength(1)];
                    t2.Point2 = pointList[n_tita - 1, (n_phi + 1) % pointList.GetLength(1)];
                    t2.Point3 = pointList[n_tita - 1, n_phi];
                    t2.Normal = new Vector3d() { X = t2.Point1.X, Y = t2.Point1.Y, Z = t2.Point1.Z };

                    toReturn.Add(t1);
                    toReturn.Add(t2);
                }
            }

            return toReturn;
        }

    }
}
