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
    public class FastBitmap : AbstractBitmap
    {
        public Int32[] Bits { get; private set; }
        protected GCHandle BitsHandle { get; private set; }

        public FastBitmap(int width, int height) : base(width, height)
        {
            Bits = new Int32[this.N];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new System.Drawing.Bitmap(width, height, this.Stripe, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public override void SetPixel(int x, int y, Color color)
        {
            int index = x + (y * Width);
            Bits[index] = color.ToArgb();
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public override void Dispose()
        {
            BitsHandle.Free();
            base.Dispose();
        }
    }
}
