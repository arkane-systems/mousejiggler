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
    protected override void Dispose (bool disposing)
    {
      if (disposing && (this.components != null))
      {
        this.components.Dispose ();
      }
      base.Dispose (disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ()
    {
      this.components = new System.ComponentModel.Container ();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.jiggleTimer = new System.Windows.Forms.Timer (this.components);
      this.flpLayout = new System.Windows.Forms.FlowLayoutPanel ();
      this.panelBase = new System.Windows.Forms.Panel ();
      this.cmdAbout = new System.Windows.Forms.Button ();
      this.cmdTrayify = new System.Windows.Forms.Button ();
      this.cbSettings = new System.Windows.Forms.CheckBox ();
      this.cbJiggling = new System.Windows.Forms.CheckBox ();
      this.panelSettings = new System.Windows.Forms.Panel ();
      this.lbPeriod = new System.Windows.Forms.Label ();
      this.nudPeriod = new System.Windows.Forms.NumericUpDown ();
      this.lblPeriodLabel = new System.Windows.Forms.Label ();
      this.cbMinimize = new System.Windows.Forms.CheckBox ();
      this.cbRandom = new System.Windows.Forms.CheckBox ();
      this.cbZen = new System.Windows.Forms.CheckBox ();
      this.trayMenu = new System.Windows.Forms.ContextMenuStrip (this.components);
      this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem ();
      this.tsmiStartJiggling = new System.Windows.Forms.ToolStripMenuItem ();
      this.tsmiStopJiggling = new System.Windows.Forms.ToolStripMenuItem ();
      this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem ();
      this.niTray = new System.Windows.Forms.NotifyIcon (this.components);
      this.flpLayout.SuspendLayout ();
      this.panelBase.SuspendLayout ();
      this.panelSettings.SuspendLayout ();
      ((System.ComponentModel.ISupportInitialize)this.nudPeriod).BeginInit ();
      this.trayMenu.SuspendLayout ();
      this.SuspendLayout ();
      // 
      // jiggleTimer
      // 
      this.jiggleTimer.Interval = 1000;
      this.jiggleTimer.Tick += this.jiggleTimer_Tick;
      // 
      // flpLayout
      // 
      this.flpLayout.AutoSize = true;
      this.flpLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flpLayout.Controls.Add (this.panelBase);
      this.flpLayout.Controls.Add (this.panelSettings);
      this.flpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flpLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flpLayout.Location = new System.Drawing.Point (0, 0);
      this.flpLayout.Name = "flpLayout";
      this.flpLayout.Padding = new System.Windows.Forms.Padding (5);
      this.flpLayout.Size = new System.Drawing.Size (304, 143);
      this.flpLayout.TabIndex = 0;
      // 
      // panelBase
      // 
      this.panelBase.Controls.Add (this.cmdAbout);
      this.panelBase.Controls.Add (this.cmdTrayify);
      this.panelBase.Controls.Add (this.cbSettings);
      this.panelBase.Controls.Add (this.cbJiggling);
      this.panelBase.Location = new System.Drawing.Point (8, 8);
      this.panelBase.Name = "panelBase";
      this.panelBase.Size = new System.Drawing.Size (289, 28);
      this.panelBase.TabIndex = 0;
      // 
      // cmdAbout
      // 
      this.cmdAbout.Location = new System.Drawing.Point (198, 2);
      this.cmdAbout.Name = "cmdAbout";
      this.cmdAbout.Size = new System.Drawing.Size (40, 23);
      this.cmdAbout.TabIndex = 2;
      this.cmdAbout.Text = "?";
      this.cmdAbout.UseVisualStyleBackColor = true;
      this.cmdAbout.Click += this.cmdAbout_Click;
      // 
      // cmdTrayify
      // 
      this.cmdTrayify.Location = new System.Drawing.Point (244, 2);
      this.cmdTrayify.Name = "cmdTrayify";
      this.cmdTrayify.Size = new System.Drawing.Size (40, 23);
      this.cmdTrayify.TabIndex = 3;
      this.cmdTrayify.Text = "🔽";
      this.cmdTrayify.UseVisualStyleBackColor = true;
      this.cmdTrayify.Click += this.cmdTrayify_Click;
      // 
      // cbSettings
      // 
      this.cbSettings.Location = new System.Drawing.Point (88, 5);
      this.cbSettings.Name = "cbSettings";
      this.cbSettings.Size = new System.Drawing.Size (77, 19);
      this.cbSettings.TabIndex = 1;
      this.cbSettings.Text = "Settings...";
      this.cbSettings.UseVisualStyleBackColor = true;
      this.cbSettings.CheckedChanged += this.cbSettings_CheckedChanged;
      // 
      // cbJiggling
      // 
      this.cbJiggling.AutoSize = true;
      this.cbJiggling.Location = new System.Drawing.Point (3, 5);
      this.cbJiggling.Name = "cbJiggling";
      this.cbJiggling.Size = new System.Drawing.Size (72, 19);
      this.cbJiggling.TabIndex = 0;
      this.cbJiggling.Text = "Jiggling?";
      this.cbJiggling.UseVisualStyleBackColor = true;
      this.cbJiggling.CheckedChanged += this.cbJiggling_CheckedChanged;
      // 
      // panelSettings
      // 
      this.panelSettings.Controls.Add (this.lbPeriod);
      this.panelSettings.Controls.Add (this.nudPeriod);
      this.panelSettings.Controls.Add (this.lblPeriodLabel);
      this.panelSettings.Controls.Add (this.cbMinimize);
      this.panelSettings.Controls.Add (this.cbRandom);
      this.panelSettings.Controls.Add (this.cbZen);
      this.panelSettings.Location = new System.Drawing.Point (8, 42);
      this.panelSettings.Name = "panelSettings";
      this.panelSettings.Size = new System.Drawing.Size (289, 92);
      this.panelSettings.TabIndex = 1;
      this.panelSettings.Visible = false;
      // 
      // lbPeriod
      // 
      this.lbPeriod.AutoSize = true;
      this.lbPeriod.Location = new System.Drawing.Point (262, 12);
      this.lbPeriod.Name = "lbPeriod";
      this.lbPeriod.Size = new System.Drawing.Size (21, 15);
      this.lbPeriod.TabIndex = 3;
      this.lbPeriod.Text = "1 s";
      // 
      // nudPeriod
      // 
      this.nudPeriod.Location = new System.Drawing.Point (131, 63);
      this.nudPeriod.Maximum = new decimal (new int[] { 10800, 0, 0, 0 });
      this.nudPeriod.Minimum = new decimal (new int[] { 1, 0, 0, 0 });
      this.nudPeriod.Name = "nudPeriod";
      this.nudPeriod.Size = new System.Drawing.Size (147, 23);
      this.nudPeriod.TabIndex = 6;
      this.nudPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.nudPeriod.Value = new decimal (new int[] { 1, 0, 0, 0 });
      this.nudPeriod.ValueChanged += this.nudPeriod_ValueChanged;
      // 
      // lblPeriodLabel
      // 
      this.lblPeriodLabel.AutoSize = true;
      this.lblPeriodLabel.Location = new System.Drawing.Point (10, 65);
      this.lblPeriodLabel.Name = "lblPeriodLabel";
      this.lblPeriodLabel.Size = new System.Drawing.Size (98, 15);
      this.lblPeriodLabel.TabIndex = 5;
      this.lblPeriodLabel.Text = "Jiggle interval (s):";
      // 
      // cbMinimize
      // 
      this.cbMinimize.AutoSize = true;
      this.cbMinimize.Location = new System.Drawing.Point (10, 37);
      this.cbMinimize.Name = "cbMinimize";
      this.cbMinimize.Size = new System.Drawing.Size (123, 19);
      this.cbMinimize.TabIndex = 4;
      this.cbMinimize.Text = "Minimize on start?";
      this.cbMinimize.UseVisualStyleBackColor = true;
      this.cbMinimize.CheckedChanged += this.cbMinimize_CheckedChanged;
      // 
      // cbRandom
      // 
      this.cbRandom.AutoSize = true;
      this.cbRandom.Location = new System.Drawing.Point (131, 11);
      this.cbRandom.Name = "cbRandom";
      this.cbRandom.Size = new System.Drawing.Size (118, 19);
      this.cbRandom.TabIndex = 1;
      this.cbRandom.Text = "Random interval?";
      this.cbRandom.UseVisualStyleBackColor = true;
      this.cbRandom.CheckedChanged += this.cbRandom_CheckedChanged;
      // 
      // cbZen
      // 
      this.cbZen.AutoSize = true;
      this.cbZen.Location = new System.Drawing.Point (10, 11);
      this.cbZen.Name = "cbZen";
      this.cbZen.Size = new System.Drawing.Size (83, 19);
      this.cbZen.TabIndex = 0;
      this.cbZen.Text = "Zen jiggle?";
      this.cbZen.UseVisualStyleBackColor = true;
      this.cbZen.CheckedChanged += this.cbZen_CheckedChanged;
      // 
      // trayMenu
      // 
      this.trayMenu.Items.AddRange (new System.Windows.Forms.ToolStripItem[] { this.tsmiOpen, this.tsmiStartJiggling, this.tsmiStopJiggling, this.tsmiExit });
      this.trayMenu.Name = "trayMenu";
      this.trayMenu.Size = new System.Drawing.Size (181, 114);
      // 
      // tsmiOpen
      // 
      this.tsmiOpen.Name = "tsmiOpen";
      this.tsmiOpen.Size = new System.Drawing.Size (180, 22);
      this.tsmiOpen.Text = "Open";
      this.tsmiOpen.Click += this.niTray_DoubleClick;
      // 
      // tsmiStartJiggling
      // 
      this.tsmiStartJiggling.Name = "tsmiStartJiggling";
      this.tsmiStartJiggling.Size = new System.Drawing.Size (180, 22);
      this.tsmiStartJiggling.Text = "Start Jiggling";
      this.tsmiStartJiggling.Click += this.trayMenu_ClickStartJiggling;
      // 
      // tsmiStopJiggling
      // 
      this.tsmiStopJiggling.Name = "tsmiStopJiggling";
      this.tsmiStopJiggling.Size = new System.Drawing.Size (180, 22);
      this.tsmiStopJiggling.Text = "Stop Jiggling";
      this.tsmiStopJiggling.Click += this.trayMenu_ClickStopJiggling;
      // 
      // tsmiExit
      // 
      this.tsmiExit.Name = "tsmiExit";
      this.tsmiExit.Size = new System.Drawing.Size (180, 22);
      this.tsmiExit.Text = "Exit";
      this.tsmiExit.Click += this.trayMenu_ClickExit;
      // 
      // niTray
      // 
      this.niTray.ContextMenuStrip = this.trayMenu;
      this.niTray.Icon = (System.Drawing.Icon)resources.GetObject ("niTray.Icon");
      this.niTray.Text = "Mouse Jiggler";
      this.niTray.DoubleClick += this.niTray_DoubleClick;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size (304, 143);
      this.Controls.Add (this.flpLayout);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.Text = "Mouse Jiggler";
      this.Load += this.MainForm_Load;
      this.Shown += this.MainForm_Shown;
      this.flpLayout.ResumeLayout (false);
      this.panelBase.ResumeLayout (false);
      this.panelBase.PerformLayout ();
      this.panelSettings.ResumeLayout (false);
      this.panelSettings.PerformLayout ();
      ((System.ComponentModel.ISupportInitialize)this.nudPeriod).EndInit ();
      this.trayMenu.ResumeLayout (false);
      this.ResumeLayout (false);
      this.PerformLayout ();
    }

    #endregion

    private System.Windows.Forms.Timer jiggleTimer;
    private System.Windows.Forms.FlowLayoutPanel flpLayout;
    private System.Windows.Forms.Panel panelSettings;
    private System.Windows.Forms.NumericUpDown nudPeriod;
    private System.Windows.Forms.Label lblPeriodLabel;
    private System.Windows.Forms.CheckBox cbMinimize;
    private System.Windows.Forms.CheckBox cbZen;
    private System.Windows.Forms.Panel panelBase;
    private System.Windows.Forms.CheckBox cbSettings;
    private System.Windows.Forms.CheckBox cbJiggling;
    private System.Windows.Forms.Label lbPeriod;
    private System.Windows.Forms.Button cmdAbout;
    private System.Windows.Forms.NotifyIcon niTray;
    private System.Windows.Forms.Button cmdTrayify;
    private System.Windows.Forms.ContextMenuStrip trayMenu;
    private System.Windows.Forms.CheckBox cbRandom;
    private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
    private System.Windows.Forms.ToolStripMenuItem tsmiStartJiggling;
    private System.Windows.Forms.ToolStripMenuItem tsmiStopJiggling;
    private System.Windows.Forms.ToolStripMenuItem tsmiExit;
  }
}
