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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 59);
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
    }
}

