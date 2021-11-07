
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
            this.sphereDensityLabel = new System.Windows.Forms.Label();
            this.kdLabel = new System.Windows.Forms.Label();
            this.ksLabel = new System.Windows.Forms.Label();
            this.mLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lightAnimationButton = new System.Windows.Forms.Button();
            this.debugPanelLabel = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lightColorButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wrapper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // wrapper
            // 
            this.wrapper.Location = new System.Drawing.Point(12, 12);
            this.wrapper.Name = "wrapper";
            this.wrapper.Size = new System.Drawing.Size(500, 500);
            this.wrapper.TabIndex = 0;
            this.wrapper.TabStop = false;
            this.wrapper.Paint += new System.Windows.Forms.PaintEventHandler(this.wrapper_Paint);
            // 
            // lightZTextBox
            // 
            this.lightZTextBox.Location = new System.Drawing.Point(22, 19);
            this.lightZTextBox.Name = "lightZTextBox";
            this.lightZTextBox.Size = new System.Drawing.Size(75, 20);
            this.lightZTextBox.TabIndex = 6;
            this.lightZTextBox.Text = "260";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Set";
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
            this.densityTrackBar.Value = 2;
            this.densityTrackBar.Scroll += new System.EventHandler(this.densityTrackBar_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sphereDensityLabel);
            this.groupBox1.Controls.Add(this.densityTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(530, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 86);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sphere density";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ksLabel);
            this.groupBox2.Controls.Add(this.ksTrackBar);
            this.groupBox2.Location = new System.Drawing.Point(674, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 86);
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
            this.groupBox3.Controls.Add(this.kdLabel);
            this.groupBox3.Controls.Add(this.kdTrackBar);
            this.groupBox3.Location = new System.Drawing.Point(530, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 86);
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
            this.groupBox4.Controls.Add(this.mLabel);
            this.groupBox4.Controls.Add(this.mTrackBar);
            this.groupBox4.Location = new System.Drawing.Point(530, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(114, 86);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "M";
            // 
            // mTrackBar
            // 
            this.mTrackBar.Location = new System.Drawing.Point(6, 19);
            this.mTrackBar.Maximum = 100;
            this.mTrackBar.Minimum = 1;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(104, 45);
            this.mTrackBar.TabIndex = 8;
            this.mTrackBar.TickFrequency = 10;
            this.mTrackBar.Value = 50;
            this.mTrackBar.Scroll += new System.EventHandler(this.mTrackBar_Scroll);
            // 
            // sphereDensityLabel
            // 
            this.sphereDensityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sphereDensityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sphereDensityLabel.Location = new System.Drawing.Point(6, 49);
            this.sphereDensityLabel.Name = "sphereDensityLabel";
            this.sphereDensityLabel.Size = new System.Drawing.Size(102, 34);
            this.sphereDensityLabel.TabIndex = 9;
            this.sphereDensityLabel.Text = "2";
            this.sphereDensityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kdLabel
            // 
            this.kdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.kdLabel.Location = new System.Drawing.Point(6, 49);
            this.kdLabel.Name = "kdLabel";
            this.kdLabel.Size = new System.Drawing.Size(102, 34);
            this.kdLabel.TabIndex = 10;
            this.kdLabel.Text = "0.5";
            this.kdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ksLabel
            // 
            this.ksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ksLabel.Location = new System.Drawing.Point(6, 49);
            this.ksLabel.Name = "ksLabel";
            this.ksLabel.Size = new System.Drawing.Size(102, 34);
            this.ksLabel.TabIndex = 10;
            this.ksLabel.Text = "0.5";
            this.ksLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mLabel
            // 
            this.mLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.mLabel.Location = new System.Drawing.Point(6, 49);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(102, 34);
            this.mLabel.TabIndex = 10;
            this.mLabel.Text = "50";
            this.mLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lightZTextBox);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Location = new System.Drawing.Point(674, 104);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(114, 86);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Light Z";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lightAnimationButton);
            this.groupBox6.Location = new System.Drawing.Point(530, 196);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(114, 52);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Light animation";
            // 
            // lightAnimationButton
            // 
            this.lightAnimationButton.BackColor = System.Drawing.Color.Yellow;
            this.lightAnimationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lightAnimationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lightAnimationButton.Location = new System.Drawing.Point(9, 23);
            this.lightAnimationButton.Name = "lightAnimationButton";
            this.lightAnimationButton.Size = new System.Drawing.Size(96, 23);
            this.lightAnimationButton.TabIndex = 0;
            this.lightAnimationButton.Text = "ON";
            this.lightAnimationButton.UseVisualStyleBackColor = false;
            this.lightAnimationButton.Click += new System.EventHandler(this.lightAnimationButton_Click);
            // 
            // debugPanelLabel
            // 
            this.debugPanelLabel.AutoSize = true;
            this.debugPanelLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.debugPanelLabel.Location = new System.Drawing.Point(12, 524);
            this.debugPanelLabel.Name = "debugPanelLabel";
            this.debugPanelLabel.Size = new System.Drawing.Size(68, 13);
            this.debugPanelLabel.TabIndex = 15;
            this.debugPanelLabel.Text = "Debug panel";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lightColorButton);
            this.groupBox7.Location = new System.Drawing.Point(674, 196);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(114, 52);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Light color";
            // 
            // lightColorButton
            // 
            this.lightColorButton.BackColor = System.Drawing.Color.White;
            this.lightColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lightColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lightColorButton.Location = new System.Drawing.Point(9, 23);
            this.lightColorButton.Name = "lightColorButton";
            this.lightColorButton.Size = new System.Drawing.Size(96, 23);
            this.lightColorButton.TabIndex = 0;
            this.lightColorButton.Text = "Select new";
            this.lightColorButton.UseVisualStyleBackColor = false;
            this.lightColorButton.Click += new System.EventHandler(this.lightColorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 546);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.debugPanelLabel);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox wrapper;
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
        private System.Windows.Forms.Label sphereDensityLabel;
        private System.Windows.Forms.Label ksLabel;
        private System.Windows.Forms.Label kdLabel;
        private System.Windows.Forms.Label mLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button lightAnimationButton;
        private System.Windows.Forms.Label debugPanelLabel;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button lightColorButton;
    }
}

