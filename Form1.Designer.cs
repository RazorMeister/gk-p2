
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
            this.sphereDensityLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ksLabel = new System.Windows.Forms.Label();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.kdLabel = new System.Windows.Forms.Label();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.withLightButton = new System.Windows.Forms.Button();
            this.lightAnimationButton = new System.Windows.Forms.Button();
            this.debugPanelLabel = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lightColorButton = new System.Windows.Forms.Button();
            this.texturePreviewWrapper = new System.Windows.Forms.PictureBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.loadTextureButton = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.kLabel = new System.Windows.Forms.Label();
            this.kTrackBar = new System.Windows.Forms.TrackBar();
            this.textureNormalMapPreviewWrapper = new System.Windows.Forms.PictureBox();
            this.objectSolidColorButton = new System.Windows.Forms.Button();
            this.objectTextureRadioButton = new System.Windows.Forms.RadioButton();
            this.objectSolidColorRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.editModeCheckbox = new System.Windows.Forms.CheckBox();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cudaModeCheckbox = new System.Windows.Forms.CheckBox();
            this.cudaSupportedLabel = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.texturePreviewWrapper)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textureNormalMapPreviewWrapper)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
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
            this.wrapper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.wrapper_MouseDown);
            this.wrapper.MouseMove += new System.Windows.Forms.MouseEventHandler(this.wrapper_MouseMove);
            this.wrapper.MouseUp += new System.Windows.Forms.MouseEventHandler(this.wrapper_MouseUp);
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
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.densityTrackBar.Maximum = 8;
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
            this.groupBox1.Location = new System.Drawing.Point(530, 384);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 86);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sphere density";
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
            this.groupBox4.Location = new System.Drawing.Point(808, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(114, 86);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "M";
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lightZTextBox);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Location = new System.Drawing.Point(808, 104);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(114, 86);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Light Z";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.withLightButton);
            this.groupBox6.Controls.Add(this.lightAnimationButton);
            this.groupBox6.Location = new System.Drawing.Point(530, 104);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(114, 86);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Light animation";
            // 
            // withLightButton
            // 
            this.withLightButton.BackColor = System.Drawing.Color.Yellow;
            this.withLightButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.withLightButton.Enabled = false;
            this.withLightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.withLightButton.Location = new System.Drawing.Point(6, 57);
            this.withLightButton.Name = "withLightButton";
            this.withLightButton.Size = new System.Drawing.Size(102, 23);
            this.withLightButton.TabIndex = 1;
            this.withLightButton.Text = "Light ON";
            this.withLightButton.UseVisualStyleBackColor = false;
            this.withLightButton.Click += new System.EventHandler(this.withLightButton_Click);
            // 
            // lightAnimationButton
            // 
            this.lightAnimationButton.BackColor = System.Drawing.Color.Yellow;
            this.lightAnimationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lightAnimationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lightAnimationButton.Location = new System.Drawing.Point(6, 28);
            this.lightAnimationButton.Name = "lightAnimationButton";
            this.lightAnimationButton.Size = new System.Drawing.Size(102, 23);
            this.lightAnimationButton.TabIndex = 0;
            this.lightAnimationButton.Text = "Animation ON";
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
            this.groupBox7.Location = new System.Drawing.Point(674, 104);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(114, 86);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Light color";
            // 
            // lightColorButton
            // 
            this.lightColorButton.BackColor = System.Drawing.Color.White;
            this.lightColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lightColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lightColorButton.Location = new System.Drawing.Point(9, 49);
            this.lightColorButton.Name = "lightColorButton";
            this.lightColorButton.Size = new System.Drawing.Size(96, 23);
            this.lightColorButton.TabIndex = 0;
            this.lightColorButton.Text = "Select new";
            this.lightColorButton.UseVisualStyleBackColor = false;
            this.lightColorButton.Click += new System.EventHandler(this.lightColorButton_Click);
            // 
            // texturePreviewWrapper
            // 
            this.texturePreviewWrapper.Location = new System.Drawing.Point(153, 59);
            this.texturePreviewWrapper.Name = "texturePreviewWrapper";
            this.texturePreviewWrapper.Size = new System.Drawing.Size(83, 48);
            this.texturePreviewWrapper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.texturePreviewWrapper.TabIndex = 17;
            this.texturePreviewWrapper.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.loadTextureButton);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.textureNormalMapPreviewWrapper);
            this.groupBox8.Controls.Add(this.objectSolidColorButton);
            this.groupBox8.Controls.Add(this.texturePreviewWrapper);
            this.groupBox8.Controls.Add(this.objectTextureRadioButton);
            this.groupBox8.Controls.Add(this.objectSolidColorRadioButton);
            this.groupBox8.Location = new System.Drawing.Point(530, 196);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(392, 182);
            this.groupBox8.TabIndex = 18;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Object color";
            // 
            // loadTextureButton
            // 
            this.loadTextureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadTextureButton.Location = new System.Drawing.Point(261, 19);
            this.loadTextureButton.Name = "loadTextureButton";
            this.loadTextureButton.Size = new System.Drawing.Size(114, 23);
            this.loadTextureButton.TabIndex = 10;
            this.loadTextureButton.Text = "Load texture";
            this.loadTextureButton.UseVisualStyleBackColor = true;
            this.loadTextureButton.Click += new System.EventHandler(this.loadTextureButton_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.kLabel);
            this.groupBox9.Controls.Add(this.kTrackBar);
            this.groupBox9.Location = new System.Drawing.Point(261, 59);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(114, 86);
            this.groupBox9.TabIndex = 20;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "K";
            // 
            // kLabel
            // 
            this.kLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.kLabel.Location = new System.Drawing.Point(6, 49);
            this.kLabel.Name = "kLabel";
            this.kLabel.Size = new System.Drawing.Size(102, 34);
            this.kLabel.TabIndex = 9;
            this.kLabel.Text = "0.5";
            this.kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kTrackBar
            // 
            this.kTrackBar.Location = new System.Drawing.Point(6, 19);
            this.kTrackBar.Name = "kTrackBar";
            this.kTrackBar.Size = new System.Drawing.Size(104, 45);
            this.kTrackBar.TabIndex = 8;
            this.kTrackBar.Value = 5;
            this.kTrackBar.Scroll += new System.EventHandler(this.kTrackBar_Scroll);
            // 
            // textureNormalMapPreviewWrapper
            // 
            this.textureNormalMapPreviewWrapper.Location = new System.Drawing.Point(153, 113);
            this.textureNormalMapPreviewWrapper.Name = "textureNormalMapPreviewWrapper";
            this.textureNormalMapPreviewWrapper.Size = new System.Drawing.Size(83, 48);
            this.textureNormalMapPreviewWrapper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.textureNormalMapPreviewWrapper.TabIndex = 19;
            this.textureNormalMapPreviewWrapper.TabStop = false;
            // 
            // objectSolidColorButton
            // 
            this.objectSolidColorButton.BackColor = System.Drawing.Color.Aquamarine;
            this.objectSolidColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.objectSolidColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.objectSolidColorButton.Location = new System.Drawing.Point(12, 59);
            this.objectSolidColorButton.Name = "objectSolidColorButton";
            this.objectSolidColorButton.Size = new System.Drawing.Size(96, 23);
            this.objectSolidColorButton.TabIndex = 2;
            this.objectSolidColorButton.Text = "Select new color";
            this.objectSolidColorButton.UseVisualStyleBackColor = false;
            this.objectSolidColorButton.Click += new System.EventHandler(this.objectSolidColorButton_Click);
            // 
            // objectTextureRadioButton
            // 
            this.objectTextureRadioButton.AutoSize = true;
            this.objectTextureRadioButton.Checked = true;
            this.objectTextureRadioButton.Location = new System.Drawing.Point(153, 19);
            this.objectTextureRadioButton.Name = "objectTextureRadioButton";
            this.objectTextureRadioButton.Size = new System.Drawing.Size(61, 17);
            this.objectTextureRadioButton.TabIndex = 1;
            this.objectTextureRadioButton.TabStop = true;
            this.objectTextureRadioButton.Text = "Texture";
            this.objectTextureRadioButton.UseVisualStyleBackColor = true;
            this.objectTextureRadioButton.CheckedChanged += new System.EventHandler(this.objectTextureRadioButton_CheckedChanged);
            // 
            // objectSolidColorRadioButton
            // 
            this.objectSolidColorRadioButton.AutoSize = true;
            this.objectSolidColorRadioButton.Location = new System.Drawing.Point(9, 19);
            this.objectSolidColorRadioButton.Name = "objectSolidColorRadioButton";
            this.objectSolidColorRadioButton.Size = new System.Drawing.Size(74, 17);
            this.objectSolidColorRadioButton.TabIndex = 0;
            this.objectSolidColorRadioButton.Text = "Solid color";
            this.objectSolidColorRadioButton.UseVisualStyleBackColor = true;
            this.objectSolidColorRadioButton.CheckedChanged += new System.EventHandler(this.objectSolidColorRadioButton_CheckedChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.editModeCheckbox);
            this.groupBox10.Location = new System.Drawing.Point(674, 384);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(114, 86);
            this.groupBox10.TabIndex = 19;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Edit mode";
            // 
            // editModeCheckbox
            // 
            this.editModeCheckbox.AutoSize = true;
            this.editModeCheckbox.Location = new System.Drawing.Point(17, 29);
            this.editModeCheckbox.Name = "editModeCheckbox";
            this.editModeCheckbox.Size = new System.Drawing.Size(88, 17);
            this.editModeCheckbox.TabIndex = 0;
            this.editModeCheckbox.Text = "Edit mode on";
            this.editModeCheckbox.UseVisualStyleBackColor = true;
            this.editModeCheckbox.CheckedChanged += new System.EventHandler(this.editModeCheckbox_CheckedChanged);
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(536, 497);
            this.fpsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(35, 13);
            this.fpsLabel.TabIndex = 20;
            this.fpsLabel.Text = "label1";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.cudaSupportedLabel);
            this.groupBox11.Controls.Add(this.cudaModeCheckbox);
            this.groupBox11.Location = new System.Drawing.Point(808, 384);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(114, 86);
            this.groupBox11.TabIndex = 21;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "CUDA mode";
            // 
            // cudaModeCheckbox
            // 
            this.cudaModeCheckbox.AutoSize = true;
            this.cudaModeCheckbox.Location = new System.Drawing.Point(10, 29);
            this.cudaModeCheckbox.Name = "cudaModeCheckbox";
            this.cudaModeCheckbox.Size = new System.Drawing.Size(100, 17);
            this.cudaModeCheckbox.TabIndex = 0;
            this.cudaModeCheckbox.Text = "CUDA mode on";
            this.cudaModeCheckbox.UseVisualStyleBackColor = true;
            this.cudaModeCheckbox.CheckedChanged += new System.EventHandler(this.cudaModeCheckbox_CheckedChanged);
            // 
            // cudaSupportedLabel
            // 
            this.cudaSupportedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cudaSupportedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.cudaSupportedLabel.Location = new System.Drawing.Point(6, 49);
            this.cudaSupportedLabel.Margin = new System.Windows.Forms.Padding(0);
            this.cudaSupportedLabel.Name = "cudaSupportedLabel";
            this.cudaSupportedLabel.Size = new System.Drawing.Size(102, 34);
            this.cudaSupportedLabel.TabIndex = 1;
            this.cudaSupportedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 546);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.fpsLabel);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox8);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
            ((System.ComponentModel.ISupportInitialize)(this.texturePreviewWrapper)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textureNormalMapPreviewWrapper)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button lightAnimationButton;
        private System.Windows.Forms.Label debugPanelLabel;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button lightColorButton;
        private System.Windows.Forms.PictureBox texturePreviewWrapper;
        private System.Windows.Forms.Button withLightButton;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton objectTextureRadioButton;
        private System.Windows.Forms.RadioButton objectSolidColorRadioButton;
        private System.Windows.Forms.Button objectSolidColorButton;
        private System.Windows.Forms.PictureBox textureNormalMapPreviewWrapper;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label kLabel;
        private System.Windows.Forms.TrackBar kTrackBar;
        private System.Windows.Forms.Button loadTextureButton;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox editModeCheckbox;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.CheckBox cudaModeCheckbox;
        private System.Windows.Forms.Label cudaSupportedLabel;
    }
}

