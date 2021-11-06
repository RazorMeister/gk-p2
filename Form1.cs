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
        private Sphere sphere = new Sphere(new Point3d() { X = 250, Y = 250, Z = 0 }, 240);
        private Point light = new Point();
        private double phi = 0;
        private double r = 200;

        private System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();

            timer = new System.Timers.Timer();
            timer.Interval = 50;
            timer.Elapsed += animate;
            timer.Enabled = true;

            this.sphere.Triangulate();
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
            this.phi += 0.1;
            this.r = 300 + Math.Sin(this.phi) * 300;

            this.light.X = (int)(this.r * Math.Cos(this.phi) + 250);
            this.light.Y = (int)(this.r * Math.Sin(this.phi) + 250);
            this.wrapper.Invalidate();

            //Debug.WriteLine($"{this.light.X}, {this.light.Y}");
        }

        private void wrapper_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.LightZ = Int32.Parse(this.lightZTextBox.Text);

            this.wrapper.Invalidate();
        }

        private void densityTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.SetSphereDensityFromTrackBar(this.densityTrackBar.Value);
            this.sphere.Triangulate();

            this.trianglesCountLabel.Text = this.sphere.GetTrianglesCount().ToString();

            this.wrapper.Invalidate();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void kdTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.Kd = this.kdTrackBar.Value * 0.1;
            this.wrapper.Invalidate();
        }

        private void ksTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.Ks = this.ksTrackBar.Value * 0.1;
            this.wrapper.Invalidate();
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.M = this.mTrackBar.Value;
            this.wrapper.Invalidate();
        }
    }
}
