using System;
using System.Diagnostics;
using System.Drawing;
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
        private double deltaR = 5;

        DateTime _lastCheckTime = DateTime.Now;
        long _frameCount = 0;

        private System.Timers.Timer timer;

        private Thread loadTextureThread;

        private Triangle movingTriangle;
        private Point lastMovingPoint;

        public Form1()
        {
            InitializeComponent();

            this.debugPanelLabel.Text = $"Sphere | Center ({Settings.CENTER_X}, {Settings.CENTER_Y}, {Settings.CENTER_Z}) | Radius {Settings.SPHERE_R}";

            this.InitAnimation();

            this.sphere.Triangulate();

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.wrapper.Width, this.wrapper.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(255, 127, 127, 255));
            this.wrapper.Image = bmp;

            this.LoadTexture();

            var timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += showFps;
            timer.Enabled = true;
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
            });
            this.loadTextureThread.Start();
        }

        private void InitAnimation()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 50;
            timer.Elapsed += animate;
            timer.Enabled = true;
        }

        private void wrapper_Paint(object sender, PaintEventArgs e)
        {
            Interlocked.Increment(ref _frameCount);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            using(FastBitmap bm = new FastBitmap(this.wrapper.Width, this.wrapper.Height))
            {
                this.sphere.Draw(e, bm, this.light);


                e.Graphics.DrawImage(bm.Bitmap, 0, 0);
            }

            
            sw.Stop();
            //Debug.WriteLine("Elapsed={0}", sw.Elapsed);
        }

        // called every once in a while
        double GetFps()
        {
            double secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
            long count = Interlocked.Exchange(ref _frameCount, 0);
            double fps = count / secondsElapsed;
            _lastCheckTime = DateTime.Now;
            return fps;
        }

        private void showFps(Object source, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine($"Fps - {this.GetFps().ToString()}");
        }

        private void animate(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (!Settings.LightAnimationOn) return;

            this.phi += 0.1;
            if (this.r > 400 || this.r < 0) this.deltaR = -this.deltaR;

            this.r += this.deltaR;

            this.light.X = (int)(this.r * Math.Cos(this.phi) + 250);
            this.light.Y = (int)(this.r * Math.Sin(this.phi) + 250);

            this.wrapper.Invalidate();
        }

        private void PauseAnimation(Action func)
        {
            bool lastAnimationOn = Settings.LightAnimationOn;
            Settings.LightAnimationOn = false;

            func();

            Settings.LightAnimationOn = lastAnimationOn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.LightZ = Int32.Parse(this.lightZTextBox.Text);

            this.wrapper.Invalidate();
        }

        private void densityTrackBar_Scroll(object sender, EventArgs e)
        {
            this.sphereDensityLabel.Text = this.densityTrackBar.Value.ToString();
            Settings.SetSphereDensityFromTrackBar(this.densityTrackBar.Value);

            this.sphere.Triangulate();

            this.wrapper.Invalidate();
        }

        private void kdTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.Kd = this.kdTrackBar.Value * 0.1;
            this.kdLabel.Text = Settings.Kd.ToString();
            this.wrapper.Invalidate();
        }

        private void ksTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.Ks = this.ksTrackBar.Value * 0.1;
            this.ksLabel.Text = Settings.Ks.ToString();
            this.wrapper.Invalidate();
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.M = this.mTrackBar.Value;
            this.mLabel.Text = Settings.M.ToString();
            this.wrapper.Invalidate();
        }

        private void lightAnimationButton_Click(object sender, EventArgs e)
        {
            if (Settings.LightAnimationOn)
            {
                this.lightAnimationButton.BackColor = Color.WhiteSmoke;
                this.lightAnimationButton.Text = "Animation OFF";
                this.withLightButton.Enabled = true;
                Settings.LightAnimationOn = false;
            }
            else
            {
                this.lightAnimationButton.BackColor = Color.Yellow;
                this.lightAnimationButton.Text = "Animation ON";
                this.withLightButton.Enabled = false;
                Settings.LightAnimationOn = true;
            }

            this.wrapper.Invalidate();
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            this.PauseAnimation(() =>
            {
                ColorDialog MyDialog = new ColorDialog();
                MyDialog.AllowFullOpen = false;
                MyDialog.ShowHelp = true;
                MyDialog.Color = this.lightColorButton.BackColor;

                if (MyDialog.ShowDialog() == DialogResult.OK)
                {
                    var color = MyDialog.Color;

                    this.lightColorButton.BackColor = color;
                    Settings.LightColor = color;

                    // Algorithm found on the Internet for contrasting foreColor
                    // https://betterprogramming.pub/generate-contrasting-text-for-your-random-background-color-ac302dc87b4
                    var edge = (color.R * 299 + color.G * 587 + color.B * 114) / 1000;
                    this.lightColorButton.ForeColor = edge < 128 ? Color.White : Color.Black;
                    this.wrapper.Invalidate();
                }
            });
        }

        private void withLightButton_Click(object sender, EventArgs e)
        {
            if (Settings.WithLight)
            {
                this.withLightButton.BackColor = Color.WhiteSmoke;
                this.withLightButton.Text = "Light OFF";
                this.lightAnimationButton.Enabled = false;
                Settings.WithLight = false;
            }
            else
            {
                this.withLightButton.BackColor = Color.Yellow;
                this.withLightButton.Text = "Light ON";
                this.lightAnimationButton.Enabled = true;
                Settings.WithLight = true;
            }

            this.wrapper.Invalidate();
        }

        private void objectTextureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.objectTextureRadioButton.Checked)
            {
                Settings.ObjectFillType = Settings.ObjectFillTypeEnum.TEXTURE;
                this.wrapper.Invalidate();
            }
        }

        private void objectSolidColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.objectSolidColorRadioButton.Checked)
            {
                Settings.ObjectFillType = Settings.ObjectFillTypeEnum.SOLID_COLOR;
                this.wrapper.Invalidate();
            }
        }

        private void objectSolidColorButton_Click(object sender, EventArgs e)
        {
            this.PauseAnimation(() =>
            {
                ColorDialog MyDialog = new ColorDialog();
                MyDialog.AllowFullOpen = false;
                MyDialog.ShowHelp = true;
                MyDialog.Color = this.objectSolidColorButton.BackColor;

                if (MyDialog.ShowDialog() == DialogResult.OK)
                {
                    var color = MyDialog.Color;

                    this.objectSolidColorButton.BackColor = color;
                    Settings.ObjectSolidColor = color;

                    // Algorithm found on the Internet for contrasting foreColor
                    // https://betterprogramming.pub/generate-contrasting-text-for-your-random-background-color-ac302dc87b4
                    var edge = (color.R * 299 + color.G * 587 + color.B * 114) / 1000;
                    this.objectSolidColorButton.ForeColor = edge < 128 ? Color.White : Color.Black;
                    this.wrapper.Invalidate();
                }
            });

        }

        private void kTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.K = this.kTrackBar.Value * 0.1;
            this.kLabel.Text = Settings.K.ToString();
            this.wrapper.Invalidate();
        }

        private void loadTextureButton_Click(object sender, EventArgs e)
        {
            this.PauseAnimation(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    CheckFileExists = true,
                    CheckPathExists = true,
                    RestoreDirectory = true,
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    this.LoadTexture(openFileDialog.FileName);
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.loadTextureThread != null && this.loadTextureThread.IsAlive)
                this.loadTextureThread.Abort();
        }

        private void editModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.EditMode = this.editModeCheckbox.Checked;

            if (Settings.EditMode)
            {
                Settings.LightAnimationOn = false;
                this.lightAnimationButton.BackColor = Color.WhiteSmoke;
                this.lightAnimationButton.Text = "Animation OFF";
                this.withLightButton.Enabled = false;

                Settings.WithLight = false;
                this.withLightButton.BackColor = Color.WhiteSmoke;
                this.withLightButton.Text = "Light OFF";
                this.lightAnimationButton.Enabled = false;
            }
            else
            {
                this.withLightButton.Enabled = true;
            }

            this.wrapper.Invalidate();
        }

        private void wrapper_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Settings.EditMode) return;

            var triangles = this.sphere.GeTriangles();
            this.lastMovingPoint = e.Location;

            foreach (var triangle in triangles)
            {
                var nearestPoint = triangle.GetNearestPoint(e.Location);

                if (nearestPoint != null)
                {
                    triangle.SelectedPoint = nearestPoint;
                    this.movingTriangle = triangle;
                    break;
                }
            }
        }

        private void wrapper_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.movingTriangle == null) return;

            int dX = e.Location.X - this.lastMovingPoint.X;
            int dY = e.Location.Y - this.lastMovingPoint.Y;

            this.movingTriangle.SelectedPoint.X += dX;
            this.movingTriangle.SelectedPoint.Y += dY;
            this.movingTriangle.SetMidPoint();

            this.lastMovingPoint = e.Location;

            this.wrapper.Invalidate();
        }

        private void wrapper_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.movingTriangle != null)
                this.movingTriangle.SelectedPoint = null;

            this.movingTriangle = null;
        }
    }
}
