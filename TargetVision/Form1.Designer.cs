namespace TargetVision
{
    partial class FormsController
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Capture = new PictureBox();
            menuStrip1 = new MenuStrip();
            Menu = new ToolStripComboBox();
            UpperLaserThreshold = new Button();
            CoordinateLabel = new Label();
            ShapeCountLabel = new Label();
            ImageResolution = new Label();
            splitter1 = new Splitter();
            panel2 = new Panel();
            LowerLaserThreshold = new Button();
            CalibrationButton = new Button();
            ShootChecker = new ListBox();
            panel4 = new Panel();
            panel5 = new Panel();
            panel1 = new Panel();
            MaxScreenLengthCount = new Label();
            UppLaserThresholdCount = new Label();
            UppScreenThresholdCount = new Label();
            LaserDelayCount = new Label();
            MinScreenLengthCount = new Label();
            LowLaserThresholdCount = new Label();
            LowScreenThresholdCount = new Label();
            LaserDelayLabel = new Label();
            LaserDelay = new HScrollBar();
            LowLaserThreshold = new HScrollBar();
            UpperScreenLength = new Label();
            LowScrenLength = new Label();
            LaserThresholdUppLabel = new Label();
            LaserThresholdLowLabel = new Label();
            UpperScreenThresholdLabel = new Label();
            LowScreenThresholdLabel = new Label();
            UppScreenThreshold = new HScrollBar();
            LowScreenThreshold = new HScrollBar();
            UppLaserThreshold = new HScrollBar();
            MinScreenLength = new HScrollBar();
            MaxScreenLength = new HScrollBar();
            LowerLeft = new Label();
            LowerRight = new Label();
            UpperRight = new Label();
            UpperLeft = new Label();
            splitter2 = new Splitter();
            ((System.ComponentModel.ISupportInitialize)Capture).BeginInit();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Capture
            // 
            Capture.BackColor = Color.FromArgb(30, 40, 50);
            Capture.BorderStyle = BorderStyle.FixedSingle;
            Capture.Dock = DockStyle.Left;
            Capture.Location = new Point(56, 27);
            Capture.Margin = new Padding(3, 2, 3, 2);
            Capture.Name = "Capture";
            Capture.Size = new Size(547, 534);
            Capture.SizeMode = PictureBoxSizeMode.Zoom;
            Capture.TabIndex = 0;
            Capture.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(30, 40, 50);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Menu });
            menuStrip1.Location = new Point(56, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1328, 27);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            Menu.BackColor = Color.FromArgb(224, 224, 224);
            Menu.Name = "Menu";
            Menu.Size = new Size(106, 23);
            Menu.SelectedIndexChanged += ChangeCameraId;
            // 
            // UpperLaserThreshold
            // 
            UpperLaserThreshold.AutoSize = true;
            UpperLaserThreshold.BackColor = Color.FromArgb(224, 224, 224);
            UpperLaserThreshold.Enabled = false;
            UpperLaserThreshold.Location = new Point(26, 78);
            UpperLaserThreshold.Margin = new Padding(3, 2, 3, 2);
            UpperLaserThreshold.Name = "UpperLaserThreshold";
            UpperLaserThreshold.Size = new Size(359, 60);
            UpperLaserThreshold.TabIndex = 4;
            UpperLaserThreshold.Text = "Без пристрелочных и задержки";
            UpperLaserThreshold.UseVisualStyleBackColor = false;
            UpperLaserThreshold.Click += ButtonUpperLaserClick;
            // 
            // CoordinateLabel
            // 
            CoordinateLabel.AutoSize = true;
            CoordinateLabel.Location = new Point(-1, 0);
            CoordinateLabel.Name = "CoordinateLabel";
            CoordinateLabel.Size = new Size(124, 15);
            CoordinateLabel.TabIndex = 16;
            CoordinateLabel.Text = "Экран не обнаружен!";
            // 
            // ShapeCountLabel
            // 
            ShapeCountLabel.AutoSize = true;
            ShapeCountLabel.Location = new Point(0, 27);
            ShapeCountLabel.Name = "ShapeCountLabel";
            ShapeCountLabel.Size = new Size(112, 15);
            ShapeCountLabel.TabIndex = 18;
            ShapeCountLabel.Text = "Кол-во попаданий:";
            // 
            // ImageResolution
            // 
            ImageResolution.AutoSize = true;
            ImageResolution.BackColor = Color.FromArgb(224, 224, 224);
            ImageResolution.ForeColor = SystemColors.ActiveCaptionText;
            ImageResolution.Location = new Point(554, 28);
            ImageResolution.Name = "ImageResolution";
            ImageResolution.Size = new Size(49, 15);
            ImageResolution.TabIndex = 20;
            ImageResolution.Text = "000x000\r\n";
            // 
            // splitter1
            // 
            splitter1.BackColor = Color.FromArgb(30, 40, 50);
            splitter1.Location = new Point(603, 27);
            splitter1.Margin = new Padding(3, 2, 3, 2);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(13, 534);
            splitter1.TabIndex = 21;
            splitter1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(30, 40, 50);
            panel2.Controls.Add(LowerLaserThreshold);
            panel2.Controls.Add(CalibrationButton);
            panel2.Controls.Add(UpperLaserThreshold);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(616, 418);
            panel2.Name = "panel2";
            panel2.Size = new Size(768, 143);
            panel2.TabIndex = 25;
            // 
            // LowerLaserThreshold
            // 
            LowerLaserThreshold.AutoSize = true;
            LowerLaserThreshold.BackColor = Color.FromArgb(224, 224, 224);
            LowerLaserThreshold.Enabled = false;
            LowerLaserThreshold.ForeColor = SystemColors.ActiveCaptionText;
            LowerLaserThreshold.Location = new Point(385, 78);
            LowerLaserThreshold.Margin = new Padding(3, 2, 3, 2);
            LowerLaserThreshold.Name = "LowerLaserThreshold";
            LowerLaserThreshold.Size = new Size(359, 60);
            LowerLaserThreshold.TabIndex = 5;
            LowerLaserThreshold.Text = "3 пристрелочных + задержка";
            LowerLaserThreshold.UseVisualStyleBackColor = false;
            LowerLaserThreshold.Click += LowerLaserThreshold_Click;
            // 
            // CalibrationButton
            // 
            CalibrationButton.AutoSize = true;
            CalibrationButton.BackColor = Color.FromArgb(224, 224, 224);
            CalibrationButton.ForeColor = SystemColors.ControlText;
            CalibrationButton.Location = new Point(26, 14);
            CalibrationButton.Margin = new Padding(3, 2, 3, 2);
            CalibrationButton.Name = "CalibrationButton";
            CalibrationButton.Size = new Size(718, 60);
            CalibrationButton.TabIndex = 4;
            CalibrationButton.Text = "Калибровка";
            CalibrationButton.UseVisualStyleBackColor = false;
            CalibrationButton.Click += CalibrationButtonClick;
            // 
            // ShootChecker
            // 
            ShootChecker.BackColor = Color.FromArgb(179, 199, 214);
            ShootChecker.BorderStyle = BorderStyle.FixedSingle;
            ShootChecker.FormattingEnabled = true;
            ShootChecker.ItemHeight = 15;
            ShootChecker.Location = new Point(0, 0);
            ShootChecker.Name = "ShootChecker";
            ShootChecker.Size = new Size(222, 377);
            ShootChecker.TabIndex = 26;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(30, 40, 50);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(ShootChecker);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(616, 27);
            panel4.Name = "panel4";
            panel4.Size = new Size(768, 391);
            panel4.TabIndex = 28;
            // 
            // panel5
            // 
            panel5.AutoSize = true;
            panel5.BackColor = Color.FromArgb(179, 199, 214);
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(panel1);
            panel5.Controls.Add(LowerLeft);
            panel5.Controls.Add(LowerRight);
            panel5.Controls.Add(UpperRight);
            panel5.Controls.Add(UpperLeft);
            panel5.Controls.Add(CoordinateLabel);
            panel5.Controls.Add(ShapeCountLabel);
            panel5.Location = new Point(224, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(536, 377);
            panel5.TabIndex = 27;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(179, 199, 214);
            panel1.Controls.Add(MaxScreenLengthCount);
            panel1.Controls.Add(UppLaserThresholdCount);
            panel1.Controls.Add(UppScreenThresholdCount);
            panel1.Controls.Add(LaserDelayCount);
            panel1.Controls.Add(MinScreenLengthCount);
            panel1.Controls.Add(LowLaserThresholdCount);
            panel1.Controls.Add(LowScreenThresholdCount);
            panel1.Controls.Add(LaserDelayLabel);
            panel1.Controls.Add(LaserDelay);
            panel1.Controls.Add(LowLaserThreshold);
            panel1.Controls.Add(UpperScreenLength);
            panel1.Controls.Add(LowScrenLength);
            panel1.Controls.Add(LaserThresholdUppLabel);
            panel1.Controls.Add(LaserThresholdLowLabel);
            panel1.Controls.Add(UpperScreenThresholdLabel);
            panel1.Controls.Add(LowScreenThresholdLabel);
            panel1.Controls.Add(UppScreenThreshold);
            panel1.Controls.Add(LowScreenThreshold);
            panel1.Controls.Add(UppLaserThreshold);
            panel1.Controls.Add(MinScreenLength);
            panel1.Controls.Add(MaxScreenLength);
            panel1.Location = new Point(-1, 142);
            panel1.Name = "panel1";
            panel1.Size = new Size(532, 225);
            panel1.TabIndex = 256;
            // 
            // MaxScreenLengthCount
            // 
            MaxScreenLengthCount.AutoSize = true;
            MaxScreenLengthCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            MaxScreenLengthCount.Location = new Point(494, 182);
            MaxScreenLengthCount.Name = "MaxScreenLengthCount";
            MaxScreenLengthCount.Size = new Size(14, 15);
            MaxScreenLengthCount.TabIndex = 274;
            MaxScreenLengthCount.Text = "0";
            // 
            // UppLaserThresholdCount
            // 
            UppLaserThresholdCount.AutoSize = true;
            UppLaserThresholdCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            UppLaserThresholdCount.Location = new Point(494, 135);
            UppLaserThresholdCount.Name = "UppLaserThresholdCount";
            UppLaserThresholdCount.Size = new Size(14, 15);
            UppLaserThresholdCount.TabIndex = 273;
            UppLaserThresholdCount.Text = "0";
            // 
            // UppScreenThresholdCount
            // 
            UppScreenThresholdCount.AutoSize = true;
            UppScreenThresholdCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            UppScreenThresholdCount.Location = new Point(491, 89);
            UppScreenThresholdCount.Name = "UppScreenThresholdCount";
            UppScreenThresholdCount.Size = new Size(14, 15);
            UppScreenThresholdCount.TabIndex = 272;
            UppScreenThresholdCount.Text = "0";
            // 
            // LaserDelayCount
            // 
            LaserDelayCount.AutoSize = true;
            LaserDelayCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LaserDelayCount.Location = new Point(494, 44);
            LaserDelayCount.Name = "LaserDelayCount";
            LaserDelayCount.Size = new Size(14, 15);
            LaserDelayCount.TabIndex = 271;
            LaserDelayCount.Text = "0";
            // 
            // MinScreenLengthCount
            // 
            MinScreenLengthCount.AutoSize = true;
            MinScreenLengthCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            MinScreenLengthCount.Location = new Point(210, 182);
            MinScreenLengthCount.Name = "MinScreenLengthCount";
            MinScreenLengthCount.Size = new Size(14, 15);
            MinScreenLengthCount.TabIndex = 270;
            MinScreenLengthCount.Text = "0";
            // 
            // LowLaserThresholdCount
            // 
            LowLaserThresholdCount.AutoSize = true;
            LowLaserThresholdCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LowLaserThresholdCount.Location = new Point(210, 135);
            LowLaserThresholdCount.Name = "LowLaserThresholdCount";
            LowLaserThresholdCount.Size = new Size(14, 15);
            LowLaserThresholdCount.TabIndex = 269;
            LowLaserThresholdCount.Text = "0";
            // 
            // LowScreenThresholdCount
            // 
            LowScreenThresholdCount.AutoSize = true;
            LowScreenThresholdCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LowScreenThresholdCount.Location = new Point(210, 89);
            LowScreenThresholdCount.Name = "LowScreenThresholdCount";
            LowScreenThresholdCount.Size = new Size(14, 15);
            LowScreenThresholdCount.TabIndex = 268;
            LowScreenThresholdCount.Text = "0";
            // 
            // LaserDelayLabel
            // 
            LaserDelayLabel.AutoSize = true;
            LaserDelayLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LaserDelayLabel.Location = new Point(284, 44);
            LaserDelayLabel.Name = "LaserDelayLabel";
            LaserDelayLabel.Size = new Size(137, 15);
            LaserDelayLabel.TabIndex = 267;
            LaserDelayLabel.Text = "Задержка лазера/сек :";
            // 
            // LaserDelay
            // 
            LaserDelay.LargeChange = 1;
            LaserDelay.Location = new Point(285, 59);
            LaserDelay.Maximum = 10;
            LaserDelay.Minimum = 1;
            LaserDelay.Name = "LaserDelay";
            LaserDelay.Size = new Size(247, 17);
            LaserDelay.TabIndex = 266;
            LaserDelay.Value = 5;
            // 
            // LowLaserThreshold
            // 
            LowLaserThreshold.LargeChange = 1;
            LowLaserThreshold.Location = new Point(0, 150);
            LowLaserThreshold.Maximum = 255;
            LowLaserThreshold.Minimum = 1;
            LowLaserThreshold.Name = "LowLaserThreshold";
            LowLaserThreshold.Size = new Size(248, 17);
            LowLaserThreshold.TabIndex = 0;
            LowLaserThreshold.Value = 235;
            // 
            // UpperScreenLength
            // 
            UpperScreenLength.AutoSize = true;
            UpperScreenLength.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            UpperScreenLength.Location = new Point(285, 182);
            UpperScreenLength.Name = "UpperScreenLength";
            UpperScreenLength.Size = new Size(192, 15);
            UpperScreenLength.TabIndex = 265;
            UpperScreenLength.Text = "Максимальный размер экрана :";
            // 
            // LowScrenLength
            // 
            LowScrenLength.AutoSize = true;
            LowScrenLength.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LowScrenLength.Location = new Point(0, 182);
            LowScrenLength.Name = "LowScrenLength";
            LowScrenLength.Size = new Size(188, 15);
            LowScrenLength.TabIndex = 264;
            LowScrenLength.Text = "Минимальный размер экрана :";
            // 
            // LaserThresholdUppLabel
            // 
            LaserThresholdUppLabel.AutoSize = true;
            LaserThresholdUppLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LaserThresholdUppLabel.Location = new Point(285, 135);
            LaserThresholdUppLabel.Name = "LaserThresholdUppLabel";
            LaserThresholdUppLabel.Size = new Size(193, 15);
            LaserThresholdUppLabel.TabIndex = 263;
            LaserThresholdUppLabel.Text = "Верхний порог яркости лазера :";
            // 
            // LaserThresholdLowLabel
            // 
            LaserThresholdLowLabel.AutoSize = true;
            LaserThresholdLowLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LaserThresholdLowLabel.Location = new Point(0, 135);
            LaserThresholdLowLabel.Name = "LaserThresholdLowLabel";
            LaserThresholdLowLabel.Size = new Size(191, 15);
            LaserThresholdLowLabel.TabIndex = 262;
            LaserThresholdLowLabel.Text = "Нижний порог яркости лазера :";
            // 
            // UpperScreenThresholdLabel
            // 
            UpperScreenThresholdLabel.AutoSize = true;
            UpperScreenThresholdLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            UpperScreenThresholdLabel.Location = new Point(284, 89);
            UpperScreenThresholdLabel.Name = "UpperScreenThresholdLabel";
            UpperScreenThresholdLabel.Size = new Size(193, 15);
            UpperScreenThresholdLabel.TabIndex = 261;
            UpperScreenThresholdLabel.Text = "Верхний порог яркости экрана :";
            // 
            // LowScreenThresholdLabel
            // 
            LowScreenThresholdLabel.AutoSize = true;
            LowScreenThresholdLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LowScreenThresholdLabel.Location = new Point(0, 89);
            LowScreenThresholdLabel.Name = "LowScreenThresholdLabel";
            LowScreenThresholdLabel.Size = new Size(191, 15);
            LowScreenThresholdLabel.TabIndex = 260;
            LowScreenThresholdLabel.Text = "Нижний порог яркости экрана :";
            // 
            // UppScreenThreshold
            // 
            UppScreenThreshold.LargeChange = 1;
            UppScreenThreshold.Location = new Point(285, 104);
            UppScreenThreshold.Maximum = 255;
            UppScreenThreshold.Minimum = 1;
            UppScreenThreshold.Name = "UppScreenThreshold";
            UppScreenThreshold.Size = new Size(247, 17);
            UppScreenThreshold.TabIndex = 0;
            UppScreenThreshold.Value = 255;
            // 
            // LowScreenThreshold
            // 
            LowScreenThreshold.LargeChange = 1;
            LowScreenThreshold.Location = new Point(1, 104);
            LowScreenThreshold.Maximum = 255;
            LowScreenThreshold.Minimum = 1;
            LowScreenThreshold.Name = "LowScreenThreshold";
            LowScreenThreshold.Size = new Size(247, 17);
            LowScreenThreshold.TabIndex = 0;
            LowScreenThreshold.Value = 100;
            // 
            // UppLaserThreshold
            // 
            UppLaserThreshold.LargeChange = 1;
            UppLaserThreshold.Location = new Point(285, 150);
            UppLaserThreshold.Maximum = 255;
            UppLaserThreshold.Minimum = 1;
            UppLaserThreshold.Name = "UppLaserThreshold";
            UppLaserThreshold.Size = new Size(247, 17);
            UppLaserThreshold.TabIndex = 0;
            UppLaserThreshold.Value = 255;
            // 
            // MinScreenLength
            // 
            MinScreenLength.LargeChange = 1;
            MinScreenLength.Location = new Point(0, 197);
            MinScreenLength.Maximum = 20;
            MinScreenLength.Minimum = 1;
            MinScreenLength.Name = "MinScreenLength";
            MinScreenLength.Size = new Size(248, 17);
            MinScreenLength.TabIndex = 0;
            MinScreenLength.Value = 10;
            // 
            // MaxScreenLength
            // 
            MaxScreenLength.LargeChange = 1;
            MaxScreenLength.Location = new Point(285, 197);
            MaxScreenLength.Maximum = 20;
            MaxScreenLength.Minimum = 1;
            MaxScreenLength.Name = "MaxScreenLength";
            MaxScreenLength.Size = new Size(247, 17);
            MaxScreenLength.TabIndex = 0;
            MaxScreenLength.Value = 16;
            // 
            // LowerLeft
            // 
            LowerLeft.AutoSize = true;
            LowerLeft.Location = new Point(283, 78);
            LowerLeft.Name = "LowerLeft";
            LowerLeft.Size = new Size(124, 15);
            LowerLeft.TabIndex = 22;
            LowerLeft.Text = "Нижний-левый угол:";
            // 
            // LowerRight
            // 
            LowerRight.AutoSize = true;
            LowerRight.Location = new Point(283, 53);
            LowerRight.Name = "LowerRight";
            LowerRight.Size = new Size(131, 15);
            LowerRight.TabIndex = 21;
            LowerRight.Text = "Нижний-правый угол:";
            // 
            // UpperRight
            // 
            UpperRight.AutoSize = true;
            UpperRight.Location = new Point(284, 27);
            UpperRight.Name = "UpperRight";
            UpperRight.Size = new Size(132, 15);
            UpperRight.TabIndex = 20;
            UpperRight.Text = "Верхний-правый угол:";
            // 
            // UpperLeft
            // 
            UpperLeft.AutoSize = true;
            UpperLeft.Location = new Point(284, 0);
            UpperLeft.Name = "UpperLeft";
            UpperLeft.Size = new Size(125, 15);
            UpperLeft.TabIndex = 19;
            UpperLeft.Text = "Верхний-левый угол:";
            // 
            // splitter2
            // 
            splitter2.BackColor = Color.FromArgb(30, 40, 50);
            splitter2.Location = new Point(0, 0);
            splitter2.Margin = new Padding(3, 2, 3, 2);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(56, 561);
            splitter2.TabIndex = 29;
            splitter2.TabStop = false;
            // 
            // FormsController
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1384, 561);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(splitter1);
            Controls.Add(ImageResolution);
            Controls.Add(Capture);
            Controls.Add(menuStrip1);
            Controls.Add(splitter2);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(1400, 600);
            Name = "FormsController";
            Text = "ShootingGallery";
            Load += LoadProgram;
            ((System.ComponentModel.ISupportInitialize)Capture).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Capture;
        private MenuStrip menuStrip1;
        private ToolStripComboBox Menu;
        private Button UpperLaserThreshold;
        private Label CoordinateLabel;
        private Label ShapeCountLabel;
        private Label ImageResolution;
        private Splitter splitter1;
        private Panel panel2;
        private ListBox ShootChecker;
        private Button CalibrationButton;
        private Panel panel4;
        private Splitter splitter2;
        private Panel panel5;
        private Label LowerLeft;
        private Label LowerRight;
        private Label UpperRight;
        private Label UpperLeft;
        private Button LowerLaserThreshold;
        private HScrollBar MaxScreenLength;
        private HScrollBar MinScreenLength;
        private Panel panel1;
        private HScrollBar UppScreenThreshold;
        private HScrollBar LowScreenThreshold;
        private HScrollBar UppLaserThreshold;
        private Label UpperScreenLength;
        private Label LowScrenLength;
        private Label LaserThresholdUppLabel;
        private Label LaserThresholdLowLabel;
        private Label UpperScreenThresholdLabel;
        private Label LowScreenThresholdLabel;
        private HScrollBar LowLaserThreshold;
        private Label LaserDelayLabel;
        private HScrollBar LaserDelay;
        private Label MaxScreenLengthCount;
        private Label UppLaserThresholdCount;
        private Label UppScreenThresholdCount;
        private Label LaserDelayCount;
        private Label MinScreenLengthCount;
        private Label LowLaserThresholdCount;
        private Label LowScreenThresholdCount;
    }
}
