using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_P2.Shape;

namespace GK_P2
{
    class NormalMap
    {
        public static System.Drawing.Bitmap Make(System.Drawing.Bitmap image, double strength = 2.0)
        {
            System.Drawing.Bitmap normal = new System.Drawing.Bitmap(image.Width, image.Height);
            Settings.NormalMap = new Vector3d[image.Width, image.Height];

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    double topLeft = Intensity(image.GetPixel(Clamp(x - 1, image.Width - 1), Clamp(y - 1, image.Height - 1)));
                    double top = Intensity(image.GetPixel(Clamp(x, image.Width - 1), Clamp(y - 1, image.Height - 1)));
                    double topRight = Intensity(image.GetPixel(Clamp(x + 1, image.Width - 1), Clamp(y - 1, image.Height - 1)));
                    double left = Intensity(image.GetPixel(Clamp(x - 1, image.Width - 1), Clamp(y, image.Height - 1)));
                    double right = Intensity(image.GetPixel(Clamp(x + 1, image.Width - 1), Clamp(y, image.Height - 1)));
                    double bottomLeft = Intensity(image.GetPixel(Clamp(x - 1, image.Width - 1), Clamp(y + 1, image.Height - 1)));
                    double bottom = Intensity(image.GetPixel(Clamp(x, image.Width - 1), Clamp(y + 1, image.Height - 1)));
                    double bottomRight = Intensity(image.GetPixel(Clamp(x + 1, image.Width - 1), Clamp(y + 1, image.Height - 1)));

                    double dX = (topRight + 2.0 * right + bottomRight) - (topLeft + 2.0 * left + bottomLeft);
                    double dY = (bottomLeft + 2.0 * bottom + bottomRight) - (topLeft + 2.0 * top + topRight);
                    double dZ = 1.0 / strength;

                    Vector3d vec = (new Vector3d() { X = dX, Y = dY, Z = dZ }).ToVersor();

                    Settings.NormalMap[x, y] = vec;

                    Color col = Color.FromArgb(255, ToRgb(vec.X), ToRgb(vec.Y), ToRgb(vec.Z));
                    normal.SetPixel(x, y, col);
                }
            }

            return normal;
        }

        private static double Intensity(Color color) => (color.R + color.G + color.B) / (3.0 * 255.0);

        private static int Clamp(int value, int max) => Math.Min(max, Math.Max(0, value));

        private static int ToRgb(double value) => (int)((value + 1.0) * (255.0 / 2.0));
    }
}
