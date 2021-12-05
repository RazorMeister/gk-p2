using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_P2
{
    public partial class Form1
    {
        #region Event helpers
        private void PauseAnimation(Action func)
        {
            bool lastAnimationOn = Settings.LightAnimationOn;
            Settings.LightAnimationOn = false;

            func();

            Settings.LightAnimationOn = lastAnimationOn;
        }

        private void SetColorDialog(Button colorButton, Action<Color> callbackFunc)
        {
            this.PauseAnimation(() =>
            {
                ColorDialog MyDialog = new ColorDialog();
                MyDialog.AllowFullOpen = false;
                MyDialog.ShowHelp = true;
                MyDialog.Color = colorButton.BackColor;

                if (MyDialog.ShowDialog() == DialogResult.OK)
                {
                    var color = MyDialog.Color;

                    colorButton.BackColor = color;
                    callbackFunc(color);

                    // Algorithm found on the Internet for contrasting foreColor
                    // https://betterprogramming.pub/generate-contrasting-text-for-your-random-background-color-ac302dc87b4
                    var edge = (color.R * 299 + color.G * 587 + color.B * 114) / 1000;
                    colorButton.ForeColor = edge < 128 ? Color.White : Color.Black;
                }
            });
        }
        #endregion

        #region Scroll bars
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

        private void kTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.K = this.kTrackBar.Value * 0.1;
            this.kLabel.Text = Settings.K.ToString();
            this.sphere.SetUp();
            this.wrapper.Invalidate();
        }
        #endregion

        #region Button events
        private void button2_Click(object sender, EventArgs e)
        {
            Settings.LightZ = Int32.Parse(this.lightZTextBox.Text);

            this.wrapper.Invalidate();
        }

        private void reflectorZButton_Click(object sender, EventArgs e)
        {
            Settings.ReflectorZ = Int32.Parse(this.reflectorZTextBox.Text);

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
            this.SetColorDialog(this.lightColorButton, (color) => Settings.LightColor = color);
        }

        private void withLightButton_Click(object sender, EventArgs e)
        {
            if (Settings.WithLight)
            {
                Settings.CUDAMode = false;
                this.cudaModeCheckbox.Checked = false;
                this.cudaModeCheckbox.Enabled = false;
                this.withLightButton.BackColor = Color.WhiteSmoke;
                this.withLightButton.Text = "Light OFF";
                this.lightAnimationButton.Enabled = false;
                Settings.WithLight = false;
            }
            else
            {
                if (Settings.CUDASupported) this.cudaModeCheckbox.Enabled = true;

                this.withLightButton.BackColor = Color.Yellow;
                this.withLightButton.Text = "Light ON";
                this.lightAnimationButton.Enabled = true;
                Settings.WithLight = true;
            }

            this.wrapper.Invalidate();
        }

        private void objectSolidColorButton_Click(object sender, EventArgs e)
        {
            this.SetColorDialog(this.objectSolidColorButton, (color) =>
            {
                Settings.ObjectSolidColor = color;
                this.sphere.SetUp();
            });
        }

        private void loadTextureButton_Click(object sender, EventArgs e)
        {
            this.PauseAnimation(() =>
            {
                string workingDirectory = Environment.CurrentDirectory;

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    CheckFileExists = true,
                    CheckPathExists = true,
                    RestoreDirectory = true,
                    InitialDirectory = Directory.GetParent(workingDirectory).Parent.FullName,
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;..."
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    this.LoadTexture(openFileDialog.FileName);
            });
        }
        #endregion

        #region Mouse events
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
            if (Settings.ReflectorOn)
            {
                Settings.ReflectorPoint = new Point(e.Location.X - Settings.CENTER_X, e.Location.Y - Settings.CENTER_Y);
                if (!Settings.LightAnimationOn)
                    this.wrapper.Invalidate();
            }

            if (this.movingTriangle == null) return;

            int dX = e.Location.X - this.lastMovingPoint.X;
            int dY = e.Location.Y - this.lastMovingPoint.Y;

            this.movingTriangle.SelectedPoint.X += dX;
            this.movingTriangle.SelectedPoint.Y += dY;
            this.movingTriangle.SetUp();

            this.lastMovingPoint = e.Location;

            this.wrapper.Invalidate();
        }

        private void wrapper_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.movingTriangle != null)
                this.movingTriangle.SelectedPoint = null;

            this.movingTriangle = null;
        }
        #endregion

        #region Radio buttons
        private void objectTextureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.objectTextureRadioButton.Checked)
            {
                Settings.ObjectFillType = Settings.ObjectFillTypeEnum.TEXTURE;
                this.sphere.SetUp();
                this.wrapper.Invalidate();
            }
        }

        private void objectSolidColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.objectSolidColorRadioButton.Checked)
            {
                Settings.ObjectFillType = Settings.ObjectFillTypeEnum.SOLID_COLOR;
                this.sphere.SetUp();
                this.wrapper.Invalidate();
            }
        }

        private void fillEachPixelRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.FillCalculation = Settings.FillCalculationEnum.EACH_PIXEL;
            if (Settings.CUDASupported) this.cudaModeCheckbox.Enabled = true;
        }

        private void fillInterpolationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.FillCalculation = Settings.FillCalculationEnum.INTERPOLATION;
            Settings.CUDAMode = false;
            this.cudaModeCheckbox.Checked = false;
            this.cudaModeCheckbox.Enabled = false;
        }

        private void fillOnePixelRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.FillCalculation = Settings.FillCalculationEnum.ONE_PIXEL;
            Settings.CUDAMode = false;
            this.cudaModeCheckbox.Checked = false;
            this.cudaModeCheckbox.Enabled = false;
        }
        #endregion

        #region Checkboxes
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

                Settings.CUDAMode = false;
            }
            else
            {
                this.sphere.SetUp();
                this.withLightButton.Enabled = true;
            }

            this.wrapper.Invalidate();
        }

        private void cudaModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.CUDAMode = this.cudaModeCheckbox.Checked;
            this.wrapper.Invalidate();
        }

        private void reflectorCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.ReflectorOn = this.reflectorCheckbox.Checked;
            this.wrapper.Invalidate();
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.loadTextureThread != null && this.loadTextureThread.IsAlive)
                this.loadTextureThread.Abort();
        }
    }
}
