using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using GK_P2.Bitmap;
using GK_P2.Shape;

namespace GK_P2
{
    public partial class Form1 : Form
    {
        private const int CENTER_X = 250;
        private const int CENTER_Y = 250;
        private const int CENTER_Z = 0;
        private const int SPHERE_R = 240;

        private Sphere sphere = new Sphere(new Point3d() { X = CENTER_X, Y = CENTER_Y, Z = CENTER_Z }, SPHERE_R);
        private Point light = new Point();
        private double phi = 0;
        private double r = 0;
        private double deltaR = 5;

        private System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();

            this.debugPanelLabel.Text = $"Sphere | Center ({CENTER_X}, {CENTER_Y}, {CENTER_Z}) | Radius {SPHERE_R}";

            this.InitAnimation();

            this.sphere.Triangulate();
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
            Stopwatch sw = new Stopwatch();
            sw.Start();

            FastBitmap bm = new FastBitmap(this.wrapper.Width, this.wrapper.Height);

            this.sphere.Draw(e, this.light);


            e.Graphics.DrawImage(bm.Bitmap, 0, 0);

            sw.Stop();
            //Debug.WriteLine("Elapsed={0}", sw.Elapsed);
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
                this.lightAnimationButton.Text = "OFF";
                Settings.LightAnimationOn = false;
            }
            else
            {
                this.lightAnimationButton.BackColor = Color.Yellow;
                this.lightAnimationButton.Text = "ON";
                Settings.LightAnimationOn = true;
            }
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = this.lightColorButton.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                var color = MyDialog.Color;

                this.lightColorButton.BackColor = color;
                Settings.LightColor = color;

                // Algorithm found on the Internet for contrasting foreColor
                // https://betterprogramming.pub/generate-contrasting-text-for-your-random-background-color-ac302dc87b4
                var edge = (color.R * 299 + color.G * 587 + color.B * 114) / 1000;
                this.lightColorButton.ForeColor =  edge < 128 ? Color.White : Color.Black;
            }
        }
    }
}
