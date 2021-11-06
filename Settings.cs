using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_P2
{
    class Settings
    {
        public static int SphereDensity { get; set; } = 10;
        public static int LightZ { get; set; } = 260;
        public static bool LightAnimationOn { get; set; } = true;

        public static double Kd { get; set; } = 0.5;
        public static double Ks { get; set; } = 0.5;
        public static int M { get; set; } = 50;

        public static void SetSphereDensityFromTrackBar(int trackBarValue)
        {
            Settings.SphereDensity = 15 + 15 * trackBarValue;
        }
    }
}
