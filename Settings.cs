
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GK_P2.Shape;

namespace GK_P2
{
    class Settings
    {
        public const double ANIMATION_SPEED = 1.5;
        public const int ANIMATION_INTERVAL = 20;
        public const int CENTER_X = 250;
        public const int CENTER_Y = 250;
        public const int CENTER_Z = 0;
        public const int SPHERE_R = 240;
        public const int WRAPPER_WIDTH = 500;
        public const int WRAPPER_HEIGHT = 500;

        public enum ObjectFillTypeEnum
        {
            SOLID_COLOR,
            TEXTURE
        }

        public enum FillCalculationEnum
        {
            EACH_PIXEL,
            INTERPOLATION,
            ONE_PIXEL
        }

        public static bool EditMode { get; set; } = false;
        public static bool CUDAMode { get; set; } = false;
        public static bool CUDASupported { get; set; } = true;

        /* Sphere settings */
        public static int SphereDensity { get; set; } = 45;
        public static ObjectFillTypeEnum ObjectFillType { get; set; } = ObjectFillTypeEnum.TEXTURE;
        public static Color ObjectSolidColor { get; set; } = Color.Aquamarine;
        public static Vector3d[,] NormalMap { get; set; }
        public static double K { get; set; } = 0.5;
        public static bool TextureLoaded { get; set; } = false;
        public static FillCalculationEnum FillCalculation { get; set; } = FillCalculationEnum.EACH_PIXEL;

        /* Light settings */
        public static int LightZ { get; set; } = 260;
        public static bool LightAnimationOn { get; set; } = true;
        public static bool WithLight { get; set; } = true;
        public static Color LightColor { get; set; } = Color.White;

        /* Light params */
        public static double Kd { get; set; } = 0.5;
        public static double Ks { get; set; } = 0.5;
        public static int M { get; set; } = 50;

        public static void SetSphereDensityFromTrackBar(int trackBarValue)
        {
            Settings.SphereDensity = 15 + 15 * trackBarValue;
        }
    }
}
