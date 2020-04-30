namespace ArkaneSystems.MouseJiggle
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.jiggleTimer = new System.Windows.Forms.Timer(this.components);
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cbZenJiggle = new System.Windows.Forms.CheckBox();
            this.cmdToTray = new System.Windows.Forms.Button();
            this.nifMin = new System.Windows.Forms.NotifyIcon(this.components);
            this.trkTime = new System.Windows.Forms.TrackBar();
            this.lblTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trkTime)).BeginInit();
            this.SuspendLayout();
            // 
            // jiggleTimer
            // 
            this.jiggleTimer.Interval = 1000;
            this.jiggleTimer.Tick += new System.EventHandler(this.jiggleTimer_Tick);
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(13, 13);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(92, 17);
            this.cbEnabled.TabIndex = 0;
            this.cbEnabled.Text = "Enable jiggle?";
            this.cbEnabled.UseVisualStyleBackColor = true;
            this.cbEnabled.CheckedChanged += new System.EventHandler(this.cbEnabled_CheckedChanged);
            // 
            // cmdAbout
            // 
            this.cmdAbout.Location = new System.Drawing.Point(111, 7);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(33, 23);
            this.cmdAbout.TabIndex = 1;
            this.cmdAbout.Text = "?";
            this.cmdAbout.UseVisualStyleBackColor = true;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // cbZenJiggle
            // 
            this.cbZenJiggle.AutoSize = true;
            this.cbZenJiggle.Location = new System.Drawing.Point(25, 36);
            this.cbZenJiggle.Name = "cbZenJiggle";
            this.cbZenJiggle.Size = new System.Drawing.Size(78, 17);
            this.cbZenJiggle.TabIndex = 2;
            this.cbZenJiggle.Text = "Zen jiggle?";
            this.cbZenJiggle.UseVisualStyleBackColor = true;
            this.cbZenJiggle.CheckedChanged += new System.EventHandler(this.cbZenJiggle_CheckedChanged);
            // 
            // cmdToTray
            // 
            this.cmdToTray.Image = ((System.Drawing.Image)(resources.GetObject("cmdToTray.Image")));
            this.cmdToTray.Location = new System.Drawing.Point(111, 32);
            this.cmdToTray.Name = "cmdToTray";
            this.cmdToTray.Size = new System.Drawing.Size(33, 23);
            this.cmdToTray.TabIndex = 3;
            this.cmdToTray.UseVisualStyleBackColor = true;
            this.cmdToTray.Click += new System.EventHandler(this.cmdToTray_Click);
            // 
            // nifMin
            // 
            this.nifMin.Icon = ((System.Drawing.Icon)(resources.GetObject("nifMin.Icon")));
            this.nifMin.Text = "Mouse Jiggler";
            this.nifMin.DoubleClick += new System.EventHandler(this.nifMin_DoubleClick);
            // 
            // trkTime
            // 
            this.trkTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkTime.LargeChange = 10;
            this.trkTime.Location = new System.Drawing.Point(12, 61);
            this.trkTime.Maximum = 60;
            this.trkTime.Minimum = 1;
            this.trkTime.Name = "trkTime";
            this.trkTime.Size = new System.Drawing.Size(132, 45);
            this.trkTime.TabIndex = 4;
            this.trkTime.TickFrequency = 5;
            this.trkTime.Value = 1;
            this.trkTime.Scroll += new System.EventHandler(this.trkTime_Scroll);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.Location = new System.Drawing.Point(12, 92);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(132, 13);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "1s";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 116);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.trkTime);
            this.Controls.Add(this.cmdToTray);
            this.Controls.Add(this.cbZenJiggle);
            this.Controls.Add(this.cmdAbout);
            this.Controls.Add(this.cbEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MouseJiggle";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer jiggleTimer;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.Button cmdAbout;
        private System.Windows.Forms.CheckBox cbZenJiggle;
        private System.Windows.Forms.Button cmdToTray;
        private System.Windows.Forms.NotifyIcon nifMin;
        private System.Windows.Forms.TrackBar trkTime;
        private System.Windows.Forms.Label lblTime;
    }
}

