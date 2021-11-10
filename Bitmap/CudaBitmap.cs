using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GK_P2.Bitmap
{
    public struct ColorStruct
    {
        public int R;
        public int G;
        public int B;

        public ColorStruct(int r, int g, int b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }

    public struct PointStruct
    {
        public float X;
        public float Y;
        public float Z;

        public PointStruct(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    public struct PixelStruct
    {
        public ColorStruct Color;
        public float Z;
        public PointStruct N;

        public PixelStruct(ColorStruct color, float z, PointStruct n)
        {
            this.Color = color;
            this.Z = z;
            this.N = n;
        }
    }

    public struct TriangleStruct
    {
        public PointStruct Point1;
        public PointStruct Point2;
        public PointStruct Point3;

        public TriangleStruct(PointStruct point1, PointStruct point2, PointStruct point3)
        {
            this.Point1 = point1;
            this.Point2 = point2;
            this.Point3 = point3;
        }
    }

    public class CudaBitmap : AbstractBitmap
    {
        protected GCHandle BitsHandle { get; private set; }

        public override void SetPixel(int x, int y, Color color)
        {
            throw new NotImplementedException();
        }

        public PixelStruct[] Pixels { get; private set; }

        public CudaBitmap(int width, int height) : base(width, height)
        {
            Pixels = new PixelStruct[this.N];
        }

        public void SetPixel(int x, int y, PixelStruct pixelStruct)
        {
            int index = x + (y * Width);
            Pixels[index] = pixelStruct;
        }

        public override System.Drawing.Bitmap GetBitmap(Point light)
        {
            CudaHelper.GetInstance().Calculate(
                this.Pixels, 
                new PointStruct((float)light.X, (float)light.Y, (float)Settings.LightZ),
                new ColorStruct(Settings.LightColor.R, Settings.LightColor.G, Settings.LightColor.B), 
                this.N, 
                out var result
            );

            Int32[] Bits = result;
            this.BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            this.Bitmap = new System.Drawing.Bitmap(this.Width, this.Height, this.Stripe, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());

            return this.Bitmap;
        }

        public override void Dispose()
        {
            this.BitsHandle.Free();
            base.Dispose();
        }
    }
}
