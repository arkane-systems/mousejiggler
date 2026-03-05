namespace ArkaneSystems.MouseJiggler
{
  partial class MainForm
  {
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose (bool disposing)
    {
      if (disposing && (this.components != null))
        this.components.Dispose ();
      base.Dispose (disposing);
    }

    private void InitializeComponent ()
    {
      this.components = new System.ComponentModel.Container ();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (MainForm));

      this.jiggleTimer = new System.Windows.Forms.Timer (this.components);
      this.niTray      = new System.Windows.Forms.NotifyIcon (this.components);
      this.trayMenu    = new System.Windows.Forms.ContextMenuStrip (this.components);
      this.tsmiOpen          = new System.Windows.Forms.ToolStripMenuItem ();
      this.tsmiStartJiggling = new System.Windows.Forms.ToolStripMenuItem ();
      this.tsmiStopJiggling  = new System.Windows.Forms.ToolStripMenuItem ();
      this.tsmiExit          = new System.Windows.Forms.ToolStripMenuItem ();

      this.flpLayout = new System.Windows.Forms.FlowLayoutPanel ();

      // Header
      this.panelHeader   = new System.Windows.Forms.Panel ();
      this.lblLogo       = new System.Windows.Forms.Label ();
      this.lblAppName    = new System.Windows.Forms.Label ();
      this.lblSubtitle   = new System.Windows.Forms.Label ();
      this.pnlIndicator  = new System.Windows.Forms.Panel ();
      this.lblStatusText = new System.Windows.Forms.Label ();

      // Jiggle toggle row
      this.panelBase      = new System.Windows.Forms.Panel ();
      this.lblJiggleTitle = new System.Windows.Forms.Label ();
      this.cbJiggling     = new ArkaneSystems.MouseJiggler.Controls.ToggleSwitch ();

      // Action buttons
      this.panelActions = new System.Windows.Forms.Panel ();
      this.btnSettings  = new System.Windows.Forms.Button ();
      this.cmdAbout     = new System.Windows.Forms.Button ();
      this.cmdTrayify   = new System.Windows.Forms.Button ();

      // Settings panel
      this.panelSettings    = new System.Windows.Forms.Panel ();
      this.pnlSeparator     = new System.Windows.Forms.Panel ();
      this.lblModeTitle     = new System.Windows.Forms.Label ();
      this.cmbJiggleMode    = new System.Windows.Forms.ComboBox ();
      this.lblRandomTitle   = new System.Windows.Forms.Label ();
      this.cbRandom         = new ArkaneSystems.MouseJiggler.Controls.ToggleSwitch ();
      this.lblPeriodLabel   = new System.Windows.Forms.Label ();
      this.nudPeriod        = new System.Windows.Forms.NumericUpDown ();
      this.lbPeriod         = new System.Windows.Forms.Label ();
      this.lblDistanceLabel = new System.Windows.Forms.Label ();
      this.nudDistance      = new System.Windows.Forms.NumericUpDown ();
      this.lblMinimizeTitle = new System.Windows.Forms.Label ();
      this.cbMinimize       = new ArkaneSystems.MouseJiggler.Controls.ToggleSwitch ();

      this.flpLayout.SuspendLayout ();
      this.panelHeader.SuspendLayout ();
      this.panelBase.SuspendLayout ();
      this.panelActions.SuspendLayout ();
      this.panelSettings.SuspendLayout ();
      ((System.ComponentModel.ISupportInitialize) this.nudPeriod).BeginInit ();
      ((System.ComponentModel.ISupportInitialize) this.nudDistance).BeginInit ();
      this.trayMenu.SuspendLayout ();
      this.SuspendLayout ();

      // ── jiggleTimer ─────────────────────────────────────────────────────────
      this.jiggleTimer.Interval = 1000;
      this.jiggleTimer.Tick    += this.jiggleTimer_Tick;

      // ── trayMenu ────────────────────────────────────────────────────────────
      this.trayMenu.BackColor = System.Drawing.Color.FromArgb (15, 21, 32);
      this.trayMenu.ForeColor = System.Drawing.Color.FromArgb (203, 213, 225);
      this.trayMenu.Items.AddRange (new System.Windows.Forms.ToolStripItem[] {
        this.tsmiOpen, this.tsmiStartJiggling, this.tsmiStopJiggling, this.tsmiExit });
      this.trayMenu.Name = "trayMenu";
      this.trayMenu.Size = new System.Drawing.Size (143, 92);

      this.tsmiOpen.Name   = "tsmiOpen";
      this.tsmiOpen.Text   = "Open";
      this.tsmiOpen.Click += this.niTray_DoubleClick;

      this.tsmiStartJiggling.Name   = "tsmiStartJiggling";
      this.tsmiStartJiggling.Text   = "Start Jiggling";
      this.tsmiStartJiggling.Click += this.trayMenu_ClickStartJiggling;

      this.tsmiStopJiggling.Name   = "tsmiStopJiggling";
      this.tsmiStopJiggling.Text   = "Stop Jiggling";
      this.tsmiStopJiggling.Click += this.trayMenu_ClickStopJiggling;

      this.tsmiExit.Name   = "tsmiExit";
      this.tsmiExit.Text   = "Exit";
      this.tsmiExit.Click += this.trayMenu_ClickExit;

      // ── niTray ──────────────────────────────────────────────────────────────
      this.niTray.ContextMenuStrip = this.trayMenu;
      this.niTray.Icon             = (System.Drawing.Icon) resources.GetObject ("niTray.Icon");
      this.niTray.Text             = "Mouse Jiggler";
      this.niTray.DoubleClick     += this.niTray_DoubleClick;

      // ── flpLayout ───────────────────────────────────────────────────────────
      this.flpLayout.AutoSize      = true;
      this.flpLayout.AutoSizeMode  = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flpLayout.BackColor     = System.Drawing.Color.FromArgb (8, 12, 20);
      this.flpLayout.Controls.Add (this.panelHeader);
      this.flpLayout.Controls.Add (this.panelBase);
      this.flpLayout.Controls.Add (this.panelActions);
      this.flpLayout.Controls.Add (this.panelSettings);
      this.flpLayout.Dock          = System.Windows.Forms.DockStyle.Fill;
      this.flpLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flpLayout.Location      = new System.Drawing.Point (0, 0);
      this.flpLayout.Margin        = new System.Windows.Forms.Padding (0);
      this.flpLayout.Name          = "flpLayout";
      this.flpLayout.Padding       = new System.Windows.Forms.Padding (0);
      this.flpLayout.Size          = new System.Drawing.Size (420, 216);
      this.flpLayout.TabIndex      = 0;
      this.flpLayout.WrapContents  = false;

      // ── panelHeader (420 × 76) ───────────────────────────────────────────────
      this.panelHeader.BackColor = System.Drawing.Color.FromArgb (15, 21, 32);
      this.panelHeader.Controls.Add (this.lblLogo);
      this.panelHeader.Controls.Add (this.lblAppName);
      this.panelHeader.Controls.Add (this.lblSubtitle);
      this.panelHeader.Controls.Add (this.pnlIndicator);
      this.panelHeader.Controls.Add (this.lblStatusText);
      this.panelHeader.Margin    = new System.Windows.Forms.Padding (0);
      this.panelHeader.Name      = "panelHeader";
      this.panelHeader.Size      = new System.Drawing.Size (420, 76);
      this.panelHeader.TabIndex  = 0;
      this.panelHeader.Paint    += this.panelHeader_Paint;

      this.lblLogo.AutoSize  = false;
      this.lblLogo.BackColor = System.Drawing.Color.Transparent;
      this.lblLogo.Font      = new System.Drawing.Font ("Segoe UI Emoji", 20F);
      this.lblLogo.ForeColor = System.Drawing.Color.FromArgb (0, 212, 255);
      this.lblLogo.Location  = new System.Drawing.Point (14, 16);
      this.lblLogo.Name      = "lblLogo";
      this.lblLogo.Size      = new System.Drawing.Size (44, 44);
      this.lblLogo.Text      = "🖱";
      this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

      this.lblAppName.AutoSize  = false;
      this.lblAppName.BackColor = System.Drawing.Color.Transparent;
      this.lblAppName.Font      = new System.Drawing.Font ("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
      this.lblAppName.ForeColor = System.Drawing.Color.FromArgb (226, 232, 240);
      this.lblAppName.Location  = new System.Drawing.Point (64, 12);
      this.lblAppName.Name      = "lblAppName";
      this.lblAppName.Size      = new System.Drawing.Size (240, 28);
      this.lblAppName.Text      = "MOUSE JIGGLER";

      this.lblSubtitle.AutoSize  = false;
      this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
      this.lblSubtitle.Font      = new System.Drawing.Font ("Segoe UI", 9F);
      this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb (71, 85, 105);
      this.lblSubtitle.Location  = new System.Drawing.Point (66, 42);
      this.lblSubtitle.Name      = "lblSubtitle";
      this.lblSubtitle.Size      = new System.Drawing.Size (200, 18);
      this.lblSubtitle.Text      = "prevent screen sleep";

      // status indicator dot (20 × 20, custom-painted)
      this.pnlIndicator.BackColor = System.Drawing.Color.Transparent;
      this.pnlIndicator.Location  = new System.Drawing.Point (378, 24);
      this.pnlIndicator.Name      = "pnlIndicator";
      this.pnlIndicator.Size      = new System.Drawing.Size (20, 20);
      this.pnlIndicator.TabStop   = false;
      this.pnlIndicator.Paint    += this.pnlIndicator_Paint;

      this.lblStatusText.AutoSize  = false;
      this.lblStatusText.BackColor = System.Drawing.Color.Transparent;
      this.lblStatusText.Font      = new System.Drawing.Font ("Segoe UI", 7.5F);
      this.lblStatusText.ForeColor = System.Drawing.Color.FromArgb (100, 116, 139);
      this.lblStatusText.Location  = new System.Drawing.Point (348, 48);
      this.lblStatusText.Name      = "lblStatusText";
      this.lblStatusText.Size      = new System.Drawing.Size (60, 16);
      this.lblStatusText.Text      = "IDLE";
      this.lblStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

      // ── panelBase — jiggle toggle row (420 × 88) ────────────────────────────
      this.panelBase.BackColor = System.Drawing.Color.FromArgb (8, 12, 20);
      this.panelBase.Controls.Add (this.lblJiggleTitle);
      this.panelBase.Controls.Add (this.cbJiggling);
      this.panelBase.Margin    = new System.Windows.Forms.Padding (0);
      this.panelBase.Name      = "panelBase";
      this.panelBase.Size      = new System.Drawing.Size (420, 88);
      this.panelBase.TabIndex  = 1;

      this.lblJiggleTitle.AutoSize  = false;
      this.lblJiggleTitle.BackColor = System.Drawing.Color.Transparent;
      this.lblJiggleTitle.Font      = new System.Drawing.Font ("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
      this.lblJiggleTitle.ForeColor = System.Drawing.Color.FromArgb (100, 116, 139);
      this.lblJiggleTitle.Location  = new System.Drawing.Point (24, 32);
      this.lblJiggleTitle.Name      = "lblJiggleTitle";
      this.lblJiggleTitle.Size      = new System.Drawing.Size (200, 24);
      this.lblJiggleTitle.Text      = "JIGGLING";

      this.cbJiggling.Location       = new System.Drawing.Point (340, 30);
      this.cbJiggling.Name           = "cbJiggling";
      this.cbJiggling.Size           = new System.Drawing.Size (56, 28);
      this.cbJiggling.TabIndex       = 0;
      this.cbJiggling.CheckedChanged += this.cbJiggling_CheckedChanged;

      // ── panelActions (420 × 52) ──────────────────────────────────────────────
      this.panelActions.BackColor = System.Drawing.Color.FromArgb (15, 21, 32);
      this.panelActions.Controls.Add (this.btnSettings);
      this.panelActions.Controls.Add (this.cmdAbout);
      this.panelActions.Controls.Add (this.cmdTrayify);
      this.panelActions.Margin    = new System.Windows.Forms.Padding (0);
      this.panelActions.Name      = "panelActions";
      this.panelActions.Size      = new System.Drawing.Size (420, 52);
      this.panelActions.TabIndex  = 2;

      this.btnSettings.BackColor                         = System.Drawing.Color.FromArgb (22, 32, 48);
      this.btnSettings.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb (30, 48, 70);
      this.btnSettings.FlatAppearance.BorderSize         = 1;
      this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb (30, 44, 64);
      this.btnSettings.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
      this.btnSettings.Font                              = new System.Drawing.Font ("Segoe UI", 8.5F);
      this.btnSettings.ForeColor                         = System.Drawing.Color.FromArgb (148, 163, 184);
      this.btnSettings.Location                          = new System.Drawing.Point (10, 8);
      this.btnSettings.Name                              = "btnSettings";
      this.btnSettings.Size                              = new System.Drawing.Size (126, 36);
      this.btnSettings.TabIndex                          = 1;
      this.btnSettings.Text                              = "⚙  SETTINGS";
      this.btnSettings.UseVisualStyleBackColor           = false;
      this.btnSettings.Click                            += this.btnSettings_Click;

      this.cmdAbout.BackColor                         = System.Drawing.Color.FromArgb (22, 32, 48);
      this.cmdAbout.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb (30, 48, 70);
      this.cmdAbout.FlatAppearance.BorderSize         = 1;
      this.cmdAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb (30, 44, 64);
      this.cmdAbout.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
      this.cmdAbout.Font                              = new System.Drawing.Font ("Segoe UI", 8.5F);
      this.cmdAbout.ForeColor                         = System.Drawing.Color.FromArgb (148, 163, 184);
      this.cmdAbout.Location                          = new System.Drawing.Point (148, 8);
      this.cmdAbout.Name                              = "cmdAbout";
      this.cmdAbout.Size                              = new System.Drawing.Size (126, 36);
      this.cmdAbout.TabIndex                          = 2;
      this.cmdAbout.Text                              = "◌  ABOUT";
      this.cmdAbout.UseVisualStyleBackColor           = false;
      this.cmdAbout.Click                            += this.cmdAbout_Click;

      this.cmdTrayify.BackColor                         = System.Drawing.Color.FromArgb (22, 32, 48);
      this.cmdTrayify.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb (30, 48, 70);
      this.cmdTrayify.FlatAppearance.BorderSize         = 1;
      this.cmdTrayify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb (30, 44, 64);
      this.cmdTrayify.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
      this.cmdTrayify.Font                              = new System.Drawing.Font ("Segoe UI", 8.5F);
      this.cmdTrayify.ForeColor                         = System.Drawing.Color.FromArgb (148, 163, 184);
      this.cmdTrayify.Location                          = new System.Drawing.Point (286, 8);
      this.cmdTrayify.Name                              = "cmdTrayify";
      this.cmdTrayify.Size                              = new System.Drawing.Size (124, 36);
      this.cmdTrayify.TabIndex                          = 3;
      this.cmdTrayify.Text                              = "⬇  TRAY";
      this.cmdTrayify.UseVisualStyleBackColor           = false;
      this.cmdTrayify.Click                            += this.cmdTrayify_Click;

      // ── panelSettings (420 × 240) ────────────────────────────────────────────
      this.panelSettings.BackColor = System.Drawing.Color.FromArgb (15, 21, 32);
      this.panelSettings.Controls.Add (this.pnlSeparator);
      this.panelSettings.Controls.Add (this.lblModeTitle);
      this.panelSettings.Controls.Add (this.cmbJiggleMode);
      this.panelSettings.Controls.Add (this.lblRandomTitle);
      this.panelSettings.Controls.Add (this.cbRandom);
      this.panelSettings.Controls.Add (this.lblPeriodLabel);
      this.panelSettings.Controls.Add (this.nudPeriod);
      this.panelSettings.Controls.Add (this.lbPeriod);
      this.panelSettings.Controls.Add (this.lblDistanceLabel);
      this.panelSettings.Controls.Add (this.nudDistance);
      this.panelSettings.Controls.Add (this.lblMinimizeTitle);
      this.panelSettings.Controls.Add (this.cbMinimize);
      this.panelSettings.Margin    = new System.Windows.Forms.Padding (0);
      this.panelSettings.Name      = "panelSettings";
      this.panelSettings.Size      = new System.Drawing.Size (420, 240);
      this.panelSettings.TabIndex  = 3;
      this.panelSettings.Visible   = false;

      // 1 px separator
      this.pnlSeparator.BackColor = System.Drawing.Color.FromArgb (30, 48, 70);
      this.pnlSeparator.Location  = new System.Drawing.Point (0, 0);
      this.pnlSeparator.Name      = "pnlSeparator";
      this.pnlSeparator.Size      = new System.Drawing.Size (420, 1);
      this.pnlSeparator.TabStop   = false;

      // row 1 — jiggle mode (y = 16)
      this.lblModeTitle.AutoSize  = false;
      this.lblModeTitle.BackColor = System.Drawing.Color.Transparent;
      this.lblModeTitle.Font      = new System.Drawing.Font ("Segoe UI", 10F);
      this.lblModeTitle.ForeColor = System.Drawing.Color.FromArgb (156, 163, 175);
      this.lblModeTitle.Location  = new System.Drawing.Point (24, 20);
      this.lblModeTitle.Name      = "lblModeTitle";
      this.lblModeTitle.Size      = new System.Drawing.Size (160, 22);
      this.lblModeTitle.Text      = "JIGGLE MODE";

      this.cmbJiggleMode.BackColor         = System.Drawing.Color.FromArgb (22, 32, 48);
      this.cmbJiggleMode.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbJiggleMode.FlatStyle         = System.Windows.Forms.FlatStyle.Flat;
      this.cmbJiggleMode.ForeColor         = System.Drawing.Color.FromArgb (203, 213, 225);
      this.cmbJiggleMode.FormattingEnabled = true;
      this.cmbJiggleMode.Location          = new System.Drawing.Point (250, 17);
      this.cmbJiggleMode.Name              = "cmbJiggleMode";
      this.cmbJiggleMode.Size              = new System.Drawing.Size (146, 26);
      this.cmbJiggleMode.TabIndex          = 0;
      this.cmbJiggleMode.SelectedIndexChanged += this.cmbJiggleMode_SelectedIndexChanged;

      // row 2 — random timer (y = 60)
      this.lblRandomTitle.AutoSize  = false;
      this.lblRandomTitle.BackColor = System.Drawing.Color.Transparent;
      this.lblRandomTitle.Font      = new System.Drawing.Font ("Segoe UI", 10F);
      this.lblRandomTitle.ForeColor = System.Drawing.Color.FromArgb (156, 163, 175);
      this.lblRandomTitle.Location  = new System.Drawing.Point (24, 64);
      this.lblRandomTitle.Name      = "lblRandomTitle";
      this.lblRandomTitle.Size      = new System.Drawing.Size (200, 22);
      this.lblRandomTitle.Text      = "RANDOM TIMER";

      this.cbRandom.Location       = new System.Drawing.Point (340, 62);
      this.cbRandom.Name           = "cbRandom";
      this.cbRandom.Size           = new System.Drawing.Size (56, 28);
      this.cbRandom.TabIndex       = 1;
      this.cbRandom.CheckedChanged += this.cbRandom_CheckedChanged;

      // row 3 — interval (y = 104)
      this.lblPeriodLabel.AutoSize  = false;
      this.lblPeriodLabel.BackColor = System.Drawing.Color.Transparent;
      this.lblPeriodLabel.Font      = new System.Drawing.Font ("Segoe UI", 10F);
      this.lblPeriodLabel.ForeColor = System.Drawing.Color.FromArgb (156, 163, 175);
      this.lblPeriodLabel.Location  = new System.Drawing.Point (24, 112);
      this.lblPeriodLabel.Name      = "lblPeriodLabel";
      this.lblPeriodLabel.Size      = new System.Drawing.Size (160, 22);
      this.lblPeriodLabel.Text      = "INTERVAL (s)";

      this.nudPeriod.BackColor   = System.Drawing.Color.FromArgb (22, 32, 48);
      this.nudPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.nudPeriod.ForeColor   = System.Drawing.Color.FromArgb (203, 213, 225);
      this.nudPeriod.Location    = new System.Drawing.Point (250, 109);
      this.nudPeriod.Maximum     = new decimal (new int[] { 10800, 0, 0, 0 });
      this.nudPeriod.Minimum     = new decimal (new int[] { 1, 0, 0, 0 });
      this.nudPeriod.Name        = "nudPeriod";
      this.nudPeriod.Size        = new System.Drawing.Size (100, 27);
      this.nudPeriod.TabIndex    = 4;
      this.nudPeriod.TextAlign   = System.Windows.Forms.HorizontalAlignment.Right;
      this.nudPeriod.Value       = new decimal (new int[] { 1, 0, 0, 0 });
      this.nudPeriod.ValueChanged += this.nudPeriod_ValueChanged;

      // lbPeriod — shows current effective interval (updated by random mode)
      this.lbPeriod.AutoSize  = false;
      this.lbPeriod.BackColor = System.Drawing.Color.Transparent;
      this.lbPeriod.Font      = new System.Drawing.Font ("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
      this.lbPeriod.ForeColor = System.Drawing.Color.FromArgb (0, 212, 255);
      this.lbPeriod.Location  = new System.Drawing.Point (356, 113);
      this.lbPeriod.Name      = "lbPeriod";
      this.lbPeriod.Size      = new System.Drawing.Size (48, 18);
      this.lbPeriod.Text      = "1 s";
      this.lbPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

      // row 4 — distance (y = 148)
      this.lblDistanceLabel.AutoSize  = false;
      this.lblDistanceLabel.BackColor = System.Drawing.Color.Transparent;
      this.lblDistanceLabel.Font      = new System.Drawing.Font ("Segoe UI", 10F);
      this.lblDistanceLabel.ForeColor = System.Drawing.Color.FromArgb (156, 163, 175);
      this.lblDistanceLabel.Location  = new System.Drawing.Point (24, 156);
      this.lblDistanceLabel.Name      = "lblDistanceLabel";
      this.lblDistanceLabel.Size      = new System.Drawing.Size (200, 22);
      this.lblDistanceLabel.Text      = "MOVE DISTANCE";

      this.nudDistance.BackColor   = System.Drawing.Color.FromArgb (22, 32, 48);
      this.nudDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.nudDistance.ForeColor   = System.Drawing.Color.FromArgb (203, 213, 225);
      this.nudDistance.Location    = new System.Drawing.Point (250, 153);
      this.nudDistance.Maximum     = new decimal (new int[] { 120, 0, 0, 0 });
      this.nudDistance.Minimum     = new decimal (new int[] { 1, 0, 0, 0 });
      this.nudDistance.Name        = "nudDistance";
      this.nudDistance.Size        = new System.Drawing.Size (100, 27);
      this.nudDistance.TabIndex    = 6;
      this.nudDistance.TextAlign   = System.Windows.Forms.HorizontalAlignment.Right;
      this.nudDistance.Value       = new decimal (new int[] { 1, 0, 0, 0 });
      this.nudDistance.ValueChanged += this.nudDistance_ValueChanged;

      // row 5 — minimize on start (y = 196)
      this.lblMinimizeTitle.AutoSize  = false;
      this.lblMinimizeTitle.BackColor = System.Drawing.Color.Transparent;
      this.lblMinimizeTitle.Font      = new System.Drawing.Font ("Segoe UI", 10F);
      this.lblMinimizeTitle.ForeColor = System.Drawing.Color.FromArgb (156, 163, 175);
      this.lblMinimizeTitle.Location  = new System.Drawing.Point (24, 200);
      this.lblMinimizeTitle.Name      = "lblMinimizeTitle";
      this.lblMinimizeTitle.Size      = new System.Drawing.Size (240, 22);
      this.lblMinimizeTitle.Text      = "MINIMIZE ON START";

      this.cbMinimize.Location       = new System.Drawing.Point (340, 198);
      this.cbMinimize.Name           = "cbMinimize";
      this.cbMinimize.Size           = new System.Drawing.Size (56, 28);
      this.cbMinimize.TabIndex       = 7;
      this.cbMinimize.CheckedChanged += this.cbMinimize_CheckedChanged;

      // ── MainForm ─────────────────────────────────────────────────────────────
      this.AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
      this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize            = true;
      this.AutoSizeMode        = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor           = System.Drawing.Color.FromArgb (8, 12, 20);
      this.ClientSize          = new System.Drawing.Size (420, 216);
      this.Controls.Add (this.flpLayout);
      this.Font                = new System.Drawing.Font ("Segoe UI", 9.75F);
      this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon                = (System.Drawing.Icon) resources.GetObject ("$this.Icon");
      this.Margin              = new System.Windows.Forms.Padding (0);
      this.MaximizeBox         = false;
      this.MinimizeBox         = false;
      this.Name                = "MainForm";
      this.Text                = "Mouse Jiggler";
      this.Load               += this.MainForm_Load;
      this.Shown              += this.MainForm_Shown;

      this.flpLayout.ResumeLayout (false);
      this.flpLayout.PerformLayout ();
      this.panelHeader.ResumeLayout (false);
      this.panelBase.ResumeLayout (false);
      this.panelActions.ResumeLayout (false);
      this.panelSettings.ResumeLayout (false);
      this.panelSettings.PerformLayout ();
      ((System.ComponentModel.ISupportInitialize) this.nudPeriod).EndInit ();
      ((System.ComponentModel.ISupportInitialize) this.nudDistance).EndInit ();
      this.trayMenu.ResumeLayout (false);
      this.ResumeLayout (false);
      this.PerformLayout ();
    }

    // ── Field declarations ─────────────────────────────────────────────────────
    private System.Windows.Forms.Timer                        jiggleTimer;
    private System.Windows.Forms.FlowLayoutPanel             flpLayout;

    private System.Windows.Forms.Panel                       panelHeader;
    private System.Windows.Forms.Label                       lblLogo;
    private System.Windows.Forms.Label                       lblAppName;
    private System.Windows.Forms.Label                       lblSubtitle;
    private System.Windows.Forms.Panel                       pnlIndicator;
    private System.Windows.Forms.Label                       lblStatusText;

    private System.Windows.Forms.Panel                       panelBase;
    private System.Windows.Forms.Label                       lblJiggleTitle;
    private ArkaneSystems.MouseJiggler.Controls.ToggleSwitch cbJiggling;

    private System.Windows.Forms.Panel                       panelActions;
    private System.Windows.Forms.Button                      btnSettings;
    private System.Windows.Forms.Button                      cmdAbout;
    private System.Windows.Forms.Button                      cmdTrayify;

    private System.Windows.Forms.Panel                       panelSettings;
    private System.Windows.Forms.Panel                       pnlSeparator;
    private System.Windows.Forms.Label                       lblModeTitle;
    private System.Windows.Forms.ComboBox                    cmbJiggleMode;
    private System.Windows.Forms.Label                       lblRandomTitle;
    private ArkaneSystems.MouseJiggler.Controls.ToggleSwitch cbRandom;
    private System.Windows.Forms.Label                       lblPeriodLabel;
    private System.Windows.Forms.NumericUpDown               nudPeriod;
    private System.Windows.Forms.Label                       lbPeriod;
    private System.Windows.Forms.Label                       lblDistanceLabel;
    private System.Windows.Forms.NumericUpDown               nudDistance;
    private System.Windows.Forms.Label                       lblMinimizeTitle;
    private ArkaneSystems.MouseJiggler.Controls.ToggleSwitch cbMinimize;

    private System.Windows.Forms.NotifyIcon                  niTray;
    private System.Windows.Forms.ContextMenuStrip            trayMenu;
    private System.Windows.Forms.ToolStripMenuItem           tsmiOpen;
    private System.Windows.Forms.ToolStripMenuItem           tsmiStartJiggling;
    private System.Windows.Forms.ToolStripMenuItem           tsmiStopJiggling;
    private System.Windows.Forms.ToolStripMenuItem           tsmiExit;
  }
}
