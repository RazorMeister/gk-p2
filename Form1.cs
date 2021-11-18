using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using GK_P2.Bitmap;
using GK_P2.Properties;
using GK_P2.Shape;

namespace GK_P2
{
    public partial class Form1 : Form
    {
        private Sphere sphere = new Sphere(
            new Point3d() { X = Settings.CENTER_X, Y = Settings.CENTER_Y, Z = Settings.CENTER_Z }, 
            Settings.SPHERE_R
        );

        private Point light = new Point();
        private double phi = 0;
        private double r = 0;
        private double deltaR = Settings.ANIMATION_SPEED * 2;

        DateTime lastCheckTime = DateTime.Now;
        long frameCount = 0;

        private System.Timers.Timer timer;

        private Thread loadTextureThread;

        private Triangle movingTriangle;
        private Point lastMovingPoint;

        public Form1()
        {
            InitializeComponent();

            this.debugPanelLabel.Text = $"Sphere | Center ({Settings.CENTER_X}, {Settings.CENTER_Y}, {Settings.CENTER_Z}) | Radius {Settings.SPHERE_R}";

            // Check CUDA support
            try
            {
                CudaHelper.Initialize();
            }
            catch (DllNotFoundException e)
            {
                this.cudaModeCheckbox.Enabled = false;
                this.cudaSupportedLabel.Text = "Not supported on this device";
                Settings.CUDASupported = false;
            }
            catch (Exception e)
            {
                this.cudaModeCheckbox.Enabled = false;
                this.cudaSupportedLabel.Text = "Something went wrong";
                Settings.CUDASupported = false;
            }


            // Triangulate sphere
            this.sphere.Triangulate();

            // Init light animation
            this.InitAnimation();

            // Set wrapper background
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.wrapper.Width, this.wrapper.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(255, 127, 127, 255));
            this.wrapper.Image = bmp;

            // Load texture
            this.LoadTexture();
        }

        private async void LoadTextureHelper(string texturePath)
        {
            var image = texturePath != null ? (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(texturePath) : Resources.defaultTexture;
            var normalMap = NormalMap.Make(image, 2.0);
            
            this.textureNormalMapPreviewWrapper.Image = normalMap;
            this.texturePreviewWrapper.Image = image;
        }

        private void LoadTexture(string texturePath = null)
        {
            this.textureNormalMapPreviewWrapper.Image = null;
            this.texturePreviewWrapper.Image = Resources.loading;
            Settings.TextureLoaded = false;

            if (this.loadTextureThread != null && this.loadTextureThread.IsAlive)
                this.loadTextureThread.Abort();

            this.loadTextureThread = new Thread(() =>
            {
                this.LoadTextureHelper(texturePath);
                Settings.TextureLoaded = true;
                this.sphere.SetUp();
            });
            this.loadTextureThread.Start();
        }

        private void InitAnimation()
        {
            timer = new System.Timers.Timer();
            timer.Interval = Settings.ANIMATION_INTERVAL;
            timer.Elapsed += Animate;
            timer.Enabled = true;
        }

        private AbstractBitmap CreateBitmap()
        {
            if (Settings.CUDAMode)
                return new CudaBitmap(this.wrapper.Width, this.wrapper.Height);

            return new FastBitmap(this.wrapper.Width, this.wrapper.Height);
        }

        private void wrapper_Paint(object sender, PaintEventArgs e)
        {
            Interlocked.Increment(ref frameCount);

            using(AbstractBitmap bm = this.CreateBitmap())
            {
                this.sphere.Draw(e, bm, this.light);
                e.Graphics.DrawImage(bm.GetBitmap(this.light), 0, 0);
            }

            e.Graphics.DrawString(
                $"FPS: {this.GetFps().ToString()}",
                new Font("Consolas", 9, FontStyle.Bold),
                Brushes.Black,
                this.wrapper.Width - 60,
                4
            );
        }

        private double GetFps()
        {
            double secondsElapsed = (DateTime.Now - lastCheckTime).TotalSeconds;
            long count = Interlocked.Exchange(ref frameCount, 0);
            double fps = count / secondsElapsed;
            lastCheckTime = DateTime.Now;
            return Math.Round(fps);
        }

        private void Animate(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (!Settings.LightAnimationOn) return;

            this.phi += Settings.ANIMATION_SPEED * 0.05;
            if (this.r > 400 || this.r < 0) this.deltaR = -this.deltaR;

            this.r += this.deltaR;

            this.light.X = (int)(this.r * Math.Cos(this.phi) + Settings.WRAPPER_WIDTH / 2);
            this.light.Y = (int)(this.r * Math.Sin(this.phi) + Settings.WRAPPER_HEIGHT / 2);

            this.wrapper.Invalidate();
        }
    }
}
