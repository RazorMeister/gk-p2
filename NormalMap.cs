using System;
using System.Diagnostics;
using System.Drawing;
using GK_P2.Shape;

namespace GK_P2
{
    class NormalMap
    {
        public static System.Drawing.Bitmap Make(System.Drawing.Bitmap image, double strength = 2.0)
        {
            System.Drawing.Bitmap normal = new System.Drawing.Bitmap(image.Width, image.Height);
            Settings.NormalMap = new Vector3d[image.Width, image.Height];

            for (int x = 0; x < Math.Min(image.Width, Settings.WRAPPER_WIDTH); x++)
            {
                for (int y = 0; y < Math.Min(image.Height, Settings.WRAPPER_HEIGHT); y++)
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

            System.Drawing.Bitmap newNormal = new System.Drawing.Bitmap(image.Width, image.Height);
            var newNormalMap = new Vector3d[image.Width, image.Height];

            for (int x = 0; x < Math.Min(image.Width, Settings.WRAPPER_WIDTH); x++)
            {
                for (int y = 0; y < Math.Min(image.Height, Settings.WRAPPER_HEIGHT); y++)
                {
                    int cx = 250;
                    int cy = 250;

                    int bulgeRadius = 240;
                    double bulgeStrength = 0.8;

                    int dx = x - cx;
                    int dy = y - cy;
                    double distanceSquared = dx * dx + dy * dy; ;
                    int sx = x;
                    int sy = y;

                    if (distanceSquared < bulgeRadius * bulgeRadius)
                    {
                        double distance = Math.Sqrt(distanceSquared);

                        double r = distance / bulgeRadius;
                        double a = Math.Atan2(dy, dx);
                        double rn = Math.Pow(r, bulgeStrength) * distance;
                        double newX = rn * Math.Cos(a) + cx;
                        double newY = rn * Math.Sin(a) + cy;
                        sx += (int)(newX - x);
                        sy += (int)(newY - y);
                        
                        
                    }

                    if (sx >= 0 && sx < image.Width && sy >= 0 && sy < image.Height)
                    {
                        newNormal.SetPixel(
                            x, y,
                            normal.GetPixel(
                                sx,
                                sy
                            )
                        );

                        newNormalMap[x, y] = Settings.NormalMap[sx, sy];
                    }
                }
            }

            Settings.NormalMap = newNormalMap;

            return newNormal;
        }

        private static double Intensity(Color color) => (color.R + color.G + color.B) / (3.0 * 255.0);

        private static int Clamp(int value, int max) => Math.Min(max, Math.Max(0, value));

        private static int ToRgb(double value) => (int)((value + 1.0) * (255.0 / 2.0));
    }
}
