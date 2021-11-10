using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GK_P2.Bitmap
{
    public abstract class AbstractBitmap : IDisposable
    {
        protected System.Drawing.Bitmap Bitmap { get; set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int N { get; private set; }
        public int Stripe { get; private set; }

        protected AbstractBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            N = width * height;
            Stripe = width * 4;
        }

        public abstract void SetPixel(int x, int y, Color color);

        public virtual System.Drawing.Bitmap GetBitmap(Point light) => this.Bitmap;

        public virtual void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap?.Dispose();
        }
    }
}
