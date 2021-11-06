
namespace GK_P2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.wrapper = new System.Windows.Forms.PictureBox();
            this.densityTextBox = new System.Windows.Forms.TextBox();
            this.trianglesCountLabel = new System.Windows.Forms.Label();
            this.lightXTextBox = new System.Windows.Forms.TextBox();
            this.lightYTextBox = new System.Windows.Forms.TextBox();
            this.lightZTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.densityTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.wrapper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // wrapper
            // 
            this.wrapper.Location = new System.Drawing.Point(12, 12);
            this.wrapper.Name = "wrapper";
            this.wrapper.Size = new System.Drawing.Size(500, 500);
            this.wrapper.TabIndex = 0;
            this.wrapper.TabStop = false;
            this.wrapper.Click += new System.EventHandler(this.wrapper_Click);
            this.wrapper.Paint += new System.Windows.Forms.PaintEventHandler(this.wrapper_Paint);
            // 
            // densityTextBox
            // 
            this.densityTextBox.Location = new System.Drawing.Point(701, 13);
            this.densityTextBox.Name = "densityTextBox";
            this.densityTextBox.Size = new System.Drawing.Size(100, 20);
            this.densityTextBox.TabIndex = 2;
            this.densityTextBox.Text = "10";
            // 
            // trianglesCountLabel
            // 
            this.trianglesCountLabel.AutoSize = true;
            this.trianglesCountLabel.Location = new System.Drawing.Point(600, 485);
            this.trianglesCountLabel.Name = "trianglesCountLabel";
            this.trianglesCountLabel.Size = new System.Drawing.Size(35, 13);
            this.trianglesCountLabel.TabIndex = 3;
            this.trianglesCountLabel.Text = "label1";
            // 
            // lightXTextBox
            // 
            this.lightXTextBox.Location = new System.Drawing.Point(603, 39);
            this.lightXTextBox.Name = "lightXTextBox";
            this.lightXTextBox.Size = new System.Drawing.Size(100, 20);
            this.lightXTextBox.TabIndex = 4;
            this.lightXTextBox.Text = "0";
            // 
            // lightYTextBox
            // 
            this.lightYTextBox.Location = new System.Drawing.Point(603, 65);
            this.lightYTextBox.Name = "lightYTextBox";
            this.lightYTextBox.Size = new System.Drawing.Size(100, 20);
            this.lightYTextBox.TabIndex = 5;
            this.lightYTextBox.Text = "0";
            // 
            // lightZTextBox
            // 
            this.lightZTextBox.Location = new System.Drawing.Point(603, 91);
            this.lightZTextBox.Name = "lightZTextBox";
            this.lightZTextBox.Size = new System.Drawing.Size(100, 20);
            this.lightZTextBox.TabIndex = 6;
            this.lightZTextBox.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(617, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // densityTrackBar
            // 
            this.densityTrackBar.Location = new System.Drawing.Point(6, 19);
            this.densityTrackBar.Maximum = 5;
            this.densityTrackBar.Name = "densityTrackBar";
            this.densityTrackBar.Size = new System.Drawing.Size(104, 45);
            this.densityTrackBar.TabIndex = 8;
            this.densityTrackBar.Scroll += new System.EventHandler(this.densityTrackBar_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.densityTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(589, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 68);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sphere density";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ksTrackBar);
            this.groupBox2.Location = new System.Drawing.Point(665, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 68);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ks";
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.Location = new System.Drawing.Point(6, 19);
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Size = new System.Drawing.Size(104, 45);
            this.ksTrackBar.TabIndex = 8;
            this.ksTrackBar.Value = 5;
            this.ksTrackBar.Scroll += new System.EventHandler(this.ksTrackBar_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.kdTrackBar);
            this.groupBox3.Location = new System.Drawing.Point(530, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 68);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kd";
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.Location = new System.Drawing.Point(6, 19);
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(104, 45);
            this.kdTrackBar.TabIndex = 8;
            this.kdTrackBar.Value = 5;
            this.kdTrackBar.Scroll += new System.EventHandler(this.kdTrackBar_Scroll);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.mTrackBar);
            this.groupBox4.Location = new System.Drawing.Point(595, 156);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(114, 68);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "M";
            // 
            // mTrackBar
            // 
            this.mTrackBar.Location = new System.Drawing.Point(6, 19);
            this.mTrackBar.Maximum = 100;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(104, 45);
            this.mTrackBar.TabIndex = 8;
            this.mTrackBar.TickFrequency = 10;
            this.mTrackBar.Value = 50;
            this.mTrackBar.Scroll += new System.EventHandler(this.mTrackBar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 522);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lightZTextBox);
            this.Controls.Add(this.lightYTextBox);
            this.Controls.Add(this.lightXTextBox);
            this.Controls.Add(this.trianglesCountLabel);
            this.Controls.Add(this.densityTextBox);
            this.Controls.Add(this.wrapper);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.wrapper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox wrapper;
        private System.Windows.Forms.TextBox densityTextBox;
        private System.Windows.Forms.Label trianglesCountLabel;
        private System.Windows.Forms.TextBox lightXTextBox;
        private System.Windows.Forms.TextBox lightYTextBox;
        private System.Windows.Forms.TextBox lightZTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar densityTrackBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar ksTrackBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar kdTrackBar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar mTrackBar;
    }
}

