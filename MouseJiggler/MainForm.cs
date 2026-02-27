#region header

// MouseJiggler - MainForm.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/24 1:57 AM.
// Updates by: Dimitris Panokostas (midwan)

#endregion

#region using

using ArkaneSystems.MouseJiggler.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace ArkaneSystems.MouseJiggler;

public partial class MainForm : Form
{
  /// <summary>
  ///     Constructor for use by the form designer.
  /// </summary>
  public MainForm ()
      : this (false, false, false, false, 1, false)
  {
  }

  public MainForm (bool jiggleOnStartup, bool minimizeOnStartup, bool zenJiggleEnabled, bool randomTimer, int jigglePeriod, bool showSettings)
  {
    this.InitializeComponent ();

    // Jiggling on startup?
    this.JiggleOnStartup = jiggleOnStartup;

    // Set settings properties
    // We do this by setting the controls, and letting them set the properties.

    this.cbMinimize.Checked = minimizeOnStartup;
    this.cbZen.Checked = zenJiggleEnabled;
    this.cbRandom.Checked = randomTimer;

    // Validate jigglePeriod before setting it
    if (jigglePeriod >= this.nudPeriod.Minimum && jigglePeriod <= this.nudPeriod.Maximum)
      this.nudPeriod.Value = jigglePeriod;
    else
      // Handle invalid jigglePeriod value, e.g., set to default or raise an error
      this.nudPeriod.Value = this.nudPeriod.Minimum; // or any default value within the range
    this.JigglePeriod = (int)this.nudPeriod.Value;

    // Show settings panel on startup if requested
    if (showSettings)
    {
      this.cbSettings.Checked = true;
      this.panelSettings.Visible = true;
    }

    // Component initial setting
    this.tsmiStartJiggling.Visible = !this.cbJiggling.Checked;
    this.tsmiStopJiggling.Visible = this.cbJiggling.Checked;
  }

  public bool JiggleOnStartup { get; }

  private void MainForm_Load (object sender, EventArgs e)
  {
    if (this.JiggleOnStartup)
      this.cbJiggling.Checked = true;
  }

  private void UpdateNotificationAreaText ()
  {
    if (!this.cbJiggling.Checked)
    {
      this.niTray.Text = @"Not jiggling the mouse.";
    }
    else
    {
      var ww = this.ZenJiggleEnabled ? "with" : "without";
      var rnd = this.RandomTimer ? $@" with random variation," : string.Empty;
      this.niTray.Text = $@"Jiggling mouse every {this.JigglePeriod} s,{rnd} {ww} Zen.";
    }
  }

  private void cmdAbout_Click (object sender, EventArgs e) => new AboutBox ().ShowDialog (this);

  private void trayMenu_ClickOpen (object sender, EventArgs e) => this.niTray_DoubleClick (sender, e);

  private void trayMenu_ClickExit (object sender, EventArgs e) => Application.Exit ();

  private void trayMenu_ClickStartJiggling (object sender, EventArgs e)
  {
    this.cbJiggling.Checked = true;
    this.UpdateNotificationAreaText ();
  }

  private void trayMenu_ClickStopJiggling (object sender, EventArgs e)
  {
    this.cbJiggling.Checked = false;
    this.UpdateNotificationAreaText ();
  }

  #region Property synchronization

  private void cbSettings_CheckedChanged (object sender, EventArgs e) => this.panelSettings.Visible = this.cbSettings.Checked;

  private void cbMinimize_CheckedChanged (object sender, EventArgs e) => this.MinimizeOnStartup = this.cbMinimize.Checked;

  private void cbZen_CheckedChanged (object sender, EventArgs e) => this.ZenJiggleEnabled = this.cbZen.Checked;

  private void cbRandom_CheckedChanged (object sender, EventArgs e) => this.RandomTimer = this.cbRandom.Checked;

  private void nudPeriod_ValueChanged (object sender, EventArgs e) => this.JigglePeriod = (int)this.nudPeriod.Value;

  #endregion Property synchronization

  #region Do the Jiggle!

  protected bool Zig = true;

  private void cbJiggling_CheckedChanged (object sender, EventArgs e)
  {
    this.jiggleTimer.Enabled = this.cbJiggling.Checked;
    this.UpdateTrayMenu ();
  }

  private void UpdateTrayMenu ()
  {
    this.trayMenu.Items[1].Visible = !this.cbJiggling.Checked;
    this.trayMenu.Items[2].Visible = this.cbJiggling.Checked;
  }

  private void jiggleTimer_Tick (object sender, EventArgs e)
  {
    if (this.ZenJiggleEnabled)
      Helpers.Jiggle (0);
    else if (this.Zig)
      Helpers.Jiggle (4);
    else //zag
      Helpers.Jiggle (-4);

    this.Zig = !this.Zig;

    if (this.RandomTimer)
    {
      var newInterval = Random.Shared.Next(1, this.JigglePeriod + 1) * 1000;
      this.lbPeriod.Text = $@"{newInterval / 1000} s";
      this.jiggleTimer.Interval = newInterval;
    }
  }

  #endregion Do the Jiggle!

  #region Minimize and restore

  private void cmdTrayify_Click (object sender, EventArgs e) => this.MinimizeToTray ();

  private void niTray_DoubleClick (object sender, EventArgs e) => this.RestoreFromTray ();

  private void MinimizeToTray ()
  {
    this.Visible = false;
    this.ShowInTaskbar = false;
    this.niTray.Visible = true;

    this.UpdateNotificationAreaText ();
  }

  private void RestoreFromTray ()
  {
    this.Visible = true;
    this.ShowInTaskbar = true;
    this.niTray.Visible = false;
  }

  #endregion Minimize and restore

  #region Settings property backing fields

  private int _jigglePeriod;

  private bool _minimizeOnStartup;

  private bool _zenJiggleEnabled;

  private bool _randomTimer;

  #endregion Settings property backing fields

  #region Settings properties

  [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]

  public bool MinimizeOnStartup
  {
    get => this._minimizeOnStartup;
    set
    {
      this._minimizeOnStartup = value;
      Settings.Default.MinimizeOnStartup = value;
      Settings.Default.Save ();
      this.OnPropertyChanged (nameof (this.MinimizeOnStartup));
    }
  }

  [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]

  public bool ZenJiggleEnabled
  {
    get => this._zenJiggleEnabled;
    set
    {
      this._zenJiggleEnabled = value;
      Settings.Default.ZenJiggle = value;
      Settings.Default.Save ();
      this.OnPropertyChanged (nameof (this.ZenJiggleEnabled));
    }
  }

  [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]

  public bool RandomTimer
  {
    get => this._randomTimer;
    set
    {
      this._randomTimer = value;
      Settings.Default.RandomTimer = value;
      Settings.Default.Save ();
      this.OnPropertyChanged (nameof (this.RandomTimer));
    }
  }

  [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]

  public int JigglePeriod
  {
    get => this._jigglePeriod;
    set
    {
      this._jigglePeriod = value;
      Settings.Default.JigglePeriod = value;
      Settings.Default.Save ();

      this.jiggleTimer.Interval = value * 1000;
      this.lbPeriod.Text = $@"{value} s";
      this.OnPropertyChanged (nameof (this.JigglePeriod));
    }
  }

  private void OnPropertyChanged (string propertyName) => PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));

  public event PropertyChangedEventHandler? PropertyChanged;

  #endregion Settings properties

  #region Minimize on start

  private bool _firstShown = true;

  private void MainForm_Shown (object sender, EventArgs e)
  {
    if (this._firstShown && this.MinimizeOnStartup)
      this.MinimizeToTray ();

    this._firstShown = false;
  }

  #endregion
}
