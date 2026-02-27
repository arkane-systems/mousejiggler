#region header

// MouseJiggler - MainForm.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/24 1:57 AM.
// Updates by: Dimitris Panokostas (midwan)

#endregion

#region using

using System;
using System.ComponentModel;
using System.Windows.Forms;
using ArkaneSystems.MouseJiggler.Properties;

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
    InitializeComponent ();

    // Jiggling on startup?
    JiggleOnStartup = jiggleOnStartup;

    // Set settings properties
    // We do this by setting the controls, and letting them set the properties.

    cbMinimize.Checked = minimizeOnStartup;
    cbZen.Checked = zenJiggleEnabled;
    cbRandom.Checked = randomTimer;

    // Validate jigglePeriod before setting it
    if (jigglePeriod >= tbPeriod.Minimum && jigglePeriod <= tbPeriod.Maximum)
      tbPeriod.Value = jigglePeriod;
    else
      // Handle invalid jigglePeriod value, e.g., set to default or raise an error
      tbPeriod.Value = tbPeriod.Minimum; // or any default value within the range
    JigglePeriod = tbPeriod.Value;

    // Show settings panel on startup if requested
    if (showSettings)
    {
      cbSettings.Checked = true;
      panelSettings.Visible = true;
    }

    // Component initial setting
    trayMenu.Items[1].Visible = !cbJiggling.Checked;
    trayMenu.Items[2].Visible = cbJiggling.Checked;
  }

  public bool JiggleOnStartup { get; }

  private void MainForm_Load (object sender, EventArgs e)
  {
    if (JiggleOnStartup)
      cbJiggling.Checked = true;
  }

  private void UpdateNotificationAreaText ()
  {
    if (!cbJiggling.Checked)
    {
      niTray.Text = @"Not jiggling the mouse.";
    }
    else
    {
      var ww = ZenJiggleEnabled ? "with" : "without";
      var rnd = RandomTimer ? $@" with random variation," : string.Empty;
      niTray.Text = $@"Jiggling mouse every {this.JigglePeriod} s,{rnd} {ww} Zen.";
    }
  }

  private void cmdAbout_Click (object sender, EventArgs e)
  {
    new AboutBox ().ShowDialog (this);
  }

  private void trayMenu_ClickOpen (object sender, EventArgs e)
  {
    niTray_DoubleClick (sender, e);
  }

  private void trayMenu_ClickExit (object sender, EventArgs e)
  {
    Application.Exit ();
  }

  private void trayMenu_ClickStartJuggling (object sender, EventArgs e)
  {
    cbJiggling.Checked = true;
    UpdateNotificationAreaText ();
  }

  private void trayMenu_ClickStopJuggling (object sender, EventArgs e)
  {
    cbJiggling.Checked = false;
    UpdateNotificationAreaText ();
  }

  #region Property synchronization

  private void cbSettings_CheckedChanged (object sender, EventArgs e)
  {
    panelSettings.Visible = cbSettings.Checked;
  }

  private void cbMinimize_CheckedChanged (object sender, EventArgs e)
  {
    MinimizeOnStartup = cbMinimize.Checked;
  }

  private void cbZen_CheckedChanged (object sender, EventArgs e)
  {
    ZenJiggleEnabled = cbZen.Checked;
  }

  private void cbRandom_CheckedChanged (object sender, EventArgs e)
  {
    RandomTimer = cbRandom.Checked;
  }

  private void tbPeriod_ValueChanged (object sender, EventArgs e)
  {
    JigglePeriod = tbPeriod.Value;
  }

  #endregion Property synchronization

  #region Do the Jiggle!

  protected bool Zig = true;

  private void cbJiggling_CheckedChanged (object sender, EventArgs e)
  {
    jiggleTimer.Enabled = cbJiggling.Checked;
    UpdateTrayMenu ();
  }

  private void UpdateTrayMenu ()
  {
    trayMenu.Items[1].Visible = !cbJiggling.Checked;
    trayMenu.Items[2].Visible = cbJiggling.Checked;
  }

  private void jiggleTimer_Tick (object sender, EventArgs e)
  {
    if (ZenJiggleEnabled)
      Helpers.Jiggle (0);
    else if (Zig)
      Helpers.Jiggle (4);
    else //zag
      Helpers.Jiggle (-4);

    Zig = !Zig;

    if (RandomTimer)
    {
      var newInterval = Random.Shared.Next(1, JigglePeriod + 1) * 1000;
      lbRandom.Text = $@"{newInterval / 1000} s";
      jiggleTimer.Interval = newInterval;
    }
  }

  #endregion Do the Jiggle!

  #region Minimize and restore

  private void cmdTrayify_Click (object sender, EventArgs e)
  {
    MinimizeToTray ();
  }

  private void niTray_DoubleClick (object sender, EventArgs e)
  {
    RestoreFromTray ();
  }

  private void MinimizeToTray ()
  {
    Visible = false;
    ShowInTaskbar = false;
    niTray.Visible = true;

    UpdateNotificationAreaText ();
  }

  private void RestoreFromTray ()
  {
    Visible = true;
    ShowInTaskbar = true;
    niTray.Visible = false;
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
    get => _minimizeOnStartup;
    set
    {
      _minimizeOnStartup = value;
      Settings.Default.MinimizeOnStartup = value;
      Settings.Default.Save ();
      OnPropertyChanged (nameof (MinimizeOnStartup));
    }
  }

  [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]

  public bool ZenJiggleEnabled
  {
    get => _zenJiggleEnabled;
    set
    {
      _zenJiggleEnabled = value;
      Settings.Default.ZenJiggle = value;
      Settings.Default.Save ();
      OnPropertyChanged (nameof (ZenJiggleEnabled));
    }
  }

  [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]

  public bool RandomTimer
  {
    get => _randomTimer;
    set
    {
      _randomTimer = value;
      Settings.Default.RandomTimer = value;
      Settings.Default.Save ();
      OnPropertyChanged (nameof (RandomTimer));
    }
  }

  [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]

  public int JigglePeriod
  {
    get => _jigglePeriod;
    set
    {
      _jigglePeriod = value;
      Settings.Default.JigglePeriod = value;
      Settings.Default.Save ();

      jiggleTimer.Interval = value * 1000;
      lbPeriod.Text = $@"{value} s";
      OnPropertyChanged (nameof (JigglePeriod));
    }
  }

  private void OnPropertyChanged (string propertyName)
  {
    PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  #endregion Settings properties

  #region Minimize on start

  private bool _firstShown = true;

  private void MainForm_Shown (object sender, EventArgs e)
  {
    if (_firstShown && MinimizeOnStartup)
      MinimizeToTray ();

    _firstShown = false;
  }

  #endregion
}
