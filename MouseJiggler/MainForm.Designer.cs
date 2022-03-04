
namespace ArkaneSystems.MouseJiggler
{
    partial class MainForm
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.jiggleTimer = new System.Windows.Forms.Timer(this.components);
            this.flpLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBase = new System.Windows.Forms.Panel();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cmdTrayify = new System.Windows.Forms.Button();
            this.cbSettings = new System.Windows.Forms.CheckBox();
            this.cbJiggling = new System.Windows.Forms.CheckBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.lbPeriod = new System.Windows.Forms.Label();
            this.tbPeriod = new System.Windows.Forms.TrackBar();
            this.cbMinimize = new System.Windows.Forms.CheckBox();
            this.cbShowIcon = new System.Windows.Forms.CheckBox();
            this.cbZen = new System.Windows.Forms.CheckBox();
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.flpLayout.SuspendLayout();
            this.panelBase.SuspendLayout();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPeriod)).BeginInit();
            this.trayContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // jiggleTimer
            // 
            this.jiggleTimer.Interval = 1000;
            this.jiggleTimer.Tick += new System.EventHandler(this.jiggleTimer_Tick);
            // 
            // flpLayout
            // 
            this.flpLayout.AutoSize = true;
            this.flpLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpLayout.Controls.Add(this.panelBase);
            this.flpLayout.Controls.Add(this.panelSettings);
            this.flpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLayout.Location = new System.Drawing.Point(0, 0);
            this.flpLayout.Name = "flpLayout";
            this.flpLayout.Padding = new System.Windows.Forms.Padding(5);
            this.flpLayout.Size = new System.Drawing.Size(304, 160);
            this.flpLayout.TabIndex = 2;
            // 
            // panelBase
            // 
            this.panelBase.Controls.Add(this.cmdAbout);
            this.panelBase.Controls.Add(this.cmdTrayify);
            this.panelBase.Controls.Add(this.cbSettings);
            this.panelBase.Controls.Add(this.cbJiggling);
            this.panelBase.Location = new System.Drawing.Point(8, 8);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(289, 28);
            this.panelBase.TabIndex = 3;
            // 
            // cmdAbout
            // 
            this.cmdAbout.Location = new System.Drawing.Point(198, 2);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(40, 23);
            this.cmdAbout.TabIndex = 2;
            this.cmdAbout.Text = "?";
            this.cmdAbout.UseVisualStyleBackColor = true;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // cmdTrayify
            // 
            this.cmdTrayify.Location = new System.Drawing.Point(244, 2);
            this.cmdTrayify.Name = "cmdTrayify";
            this.cmdTrayify.Size = new System.Drawing.Size(40, 23);
            this.cmdTrayify.TabIndex = 3;
            this.cmdTrayify.Text = "🔽";
            this.cmdTrayify.UseVisualStyleBackColor = true;
            this.cmdTrayify.Click += new System.EventHandler(this.cmdTrayify_Click);
            // 
            // cbSettings
            // 
            this.cbSettings.Location = new System.Drawing.Point(88, 5);
            this.cbSettings.Name = "cbSettings";
            this.cbSettings.Size = new System.Drawing.Size(77, 19);
            this.cbSettings.TabIndex = 1;
            this.cbSettings.Text = "Settings...";
            this.cbSettings.UseVisualStyleBackColor = true;
            this.cbSettings.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
            // 
            // cbJiggling
            // 
            this.cbJiggling.AutoSize = true;
            this.cbJiggling.Location = new System.Drawing.Point(10, 5);
            this.cbJiggling.Name = "cbJiggling";
            this.cbJiggling.Size = new System.Drawing.Size(72, 19);
            this.cbJiggling.TabIndex = 0;
            this.cbJiggling.Text = "Jiggling?";
            this.cbJiggling.UseVisualStyleBackColor = true;
            this.cbJiggling.CheckedChanged += new System.EventHandler(this.cbJiggling_CheckedChanged);
            // 
            // panelSettings
            // 
            this.panelSettings.AutoSize = true;
            this.panelSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSettings.Controls.Add(this.lbPeriod);
            this.panelSettings.Controls.Add(this.tbPeriod);
            this.panelSettings.Controls.Add(this.cbMinimize);
            this.panelSettings.Controls.Add(this.cbShowIcon);
            this.panelSettings.Controls.Add(this.cbZen);
            this.panelSettings.Location = new System.Drawing.Point(8, 42);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(289, 110);
            this.panelSettings.TabIndex = 2;
            this.panelSettings.Visible = false;
            // 
            // lbPeriod
            // 
            this.lbPeriod.AutoSize = true;
            this.lbPeriod.Location = new System.Drawing.Point(244, 41);
            this.lbPeriod.Name = "lbPeriod";
            this.lbPeriod.Size = new System.Drawing.Size(21, 15);
            this.lbPeriod.TabIndex = 3;
            this.lbPeriod.Text = "1 s";
            // 
            // tbPeriod
            // 
            this.tbPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPeriod.Location = new System.Drawing.Point(4, 62);
            this.tbPeriod.Maximum = 60;
            this.tbPeriod.Minimum = 1;
            this.tbPeriod.Name = "tbPeriod";
            this.tbPeriod.Size = new System.Drawing.Size(281, 45);
            this.tbPeriod.TabIndex = 6;
            this.tbPeriod.TickFrequency = 2;
            this.tbPeriod.Value = 1;
            this.tbPeriod.ValueChanged += new System.EventHandler(this.tbPeriod_ValueChanged);
            // 
            // cbMinimize
            // 
            this.cbMinimize.AutoSize = true;
            this.cbMinimize.Location = new System.Drawing.Point(10, 37);
            this.cbMinimize.Name = "cbMinimize";
            this.cbMinimize.Size = new System.Drawing.Size(123, 19);
            this.cbMinimize.TabIndex = 5;
            this.cbMinimize.Text = "Minimize on start?";
            this.cbMinimize.UseVisualStyleBackColor = true;
            this.cbMinimize.CheckedChanged += new System.EventHandler(this.cbMinimize_CheckedChanged);
            // 
            // cbShowIcon
            // 
            this.cbShowIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowIcon.AutoSize = true;
            this.cbShowIcon.Location = new System.Drawing.Point(141, 11);
            this.cbShowIcon.Name = "cbShowIcon";
            this.cbShowIcon.Size = new System.Drawing.Size(143, 19);
            this.cbShowIcon.TabIndex = 4;
            this.cbShowIcon.Text = "Always show tray icon";
            this.cbShowIcon.UseVisualStyleBackColor = true;
            this.cbShowIcon.CheckedChanged += new System.EventHandler(this.cbShowIcon_CheckedChanged);
            // 
            // cbZen
            // 
            this.cbZen.AutoSize = true;
            this.cbZen.Location = new System.Drawing.Point(10, 11);
            this.cbZen.Name = "cbZen";
            this.cbZen.Size = new System.Drawing.Size(83, 19);
            this.cbZen.TabIndex = 4;
            this.cbZen.Text = "Zen jiggle?";
            this.cbZen.UseVisualStyleBackColor = true;
            this.cbZen.CheckedChanged += new System.EventHandler(this.cbZen_CheckedChanged);
            // 
            // niTray
            // 
            this.niTray.ContextMenuStrip = this.trayContextMenuStrip;
            this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
            this.niTray.Text = "Mouse Jiggler";
            this.niTray.DoubleClick += new System.EventHandler(this.niTray_DoubleClick);
            // 
            // trayContextMenuStrip
            // 
            this.trayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.trayContextMenuSeparator,
            this.exitToolStripMenuItem});
            this.trayContextMenuStrip.Name = "trayContextMenuStrip";
            this.trayContextMenuStrip.Size = new System.Drawing.Size(181, 76);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showToolStripMenuItem.Text = "&Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // trayContextMenuSeparator
            // 
            this.trayContextMenuSeparator.Name = "trayContextMenuSeparator";
            this.trayContextMenuSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(304, 160);
            this.Controls.Add(this.flpLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Mouse Jiggler";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.flpLayout.ResumeLayout(false);
            this.flpLayout.PerformLayout();
            this.panelBase.ResumeLayout(false);
            this.panelBase.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPeriod)).EndInit();
            this.trayContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer jiggleTimer;
        private System.Windows.Forms.FlowLayoutPanel flpLayout;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.TrackBar tbPeriod;
        private System.Windows.Forms.CheckBox cbMinimize;
        private System.Windows.Forms.CheckBox cbZen;
        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.CheckBox cbSettings;
        private System.Windows.Forms.CheckBox cbJiggling;
        private System.Windows.Forms.Label lbPeriod;
        private System.Windows.Forms.Button cmdAbout;
        private System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.Button cmdTrayify;
        private System.Windows.Forms.ContextMenuStrip trayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbShowIcon;
        private System.Windows.Forms.ToolStripSeparator trayContextMenuSeparator;
    }
}

