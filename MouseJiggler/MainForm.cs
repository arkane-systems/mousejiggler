#region header

// MouseJiggler - MainForm.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/24 1:57 AM.
// Updates by: Dimitris Panokostas (midwan)

#endregion

#region using

using ArkaneSystems.MouseJiggler.Properties;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Windows.Win32.UI.Input.KeyboardAndMouse;

#endregion

namespace ArkaneSystems.MouseJiggler;

public partial class MainForm : Form
{
  private const int MaxNotifyIconTextLength = 63;
  private const int ToggleJigglingHotKeyId = 1;
  private const int HotKeyMessage = 0x0312;
  private const HOT_KEY_MODIFIERS ToggleJigglingHotKeyModifiers = HOT_KEY_MODIFIERS.MOD_CONTROL | HOT_KEY_MODIFIERS.MOD_SHIFT | HOT_KEY_MODIFIERS.MOD_NOREPEAT;
  private const VIRTUAL_KEY ToggleJigglingHotKeyKey = VIRTUAL_KEY.VK_J;
  private const string ToggleJigglingHotKeyText = "Ctrl+Shift+J";

  private bool _hotKeyRegistered;

  /// <summary>
  ///     Constructor for use by the form designer.
  /// </summary>
  public MainForm ()
      : this (false, false, JiggleMode.Normal, false, 1, 1, false, false)
  { }

  public MainForm (bool jiggleOnStartup, bool minimizeOnStartup, JiggleMode jiggleMode, bool randomTimer, int jigglePeriod, int jiggleDistance, bool showSettings, bool respectLockedState)
  {
    this.InitializeComponent ();
    this.cmbJiggleMode.Format += (_, e) =>
    {
      if (e.ListItem is JiggleMode mode)
        e.Value = GetJiggleModeDisplayName (mode);
    };

    // Initialize JiggleMode combo box with enum values
    this.cmbJiggleMode.Items.Clear ();
    foreach (JiggleMode mode in Enum.GetValues<JiggleMode> ())
    {
      _ = this.cmbJiggleMode.Items.Add (mode);
    }

    // Jiggling on startup?
    this.JiggleOnStartup = jiggleOnStartup;

    // Set settings properties
    // We do this by setting the controls, and letting them set the properties.

    this.cbMinimize.Checked = minimizeOnStartup;
    this.cmbJiggleMode.SelectedItem = jiggleMode;
    this.cbRandom.Checked = randomTimer;
    this.cbRespectLockedState.Checked = respectLockedState;

    // Validate jigglePeriod before setting it
    if (jigglePeriod >= this.nudPeriod.Minimum && jigglePeriod <= this.nudPeriod.Maximum)
      this.nudPeriod.Value = jigglePeriod;
    else
      // Handle invalid jigglePeriod value, e.g., set to default or raise an error
      this.nudPeriod.Value = this.nudPeriod.Minimum; // or any default value within the range
    this.JigglePeriod = (int)this.nudPeriod.Value;

    // Validate jiggleDistance before setting it
    if (jiggleDistance >= this.nudDistance.Minimum && jiggleDistance <= this.nudDistance.Maximum)
      this.nudDistance.Value = jiggleDistance;
    else
      // Handle invalid jiggleDistance value, e.g., set to default or raise an error
      this.nudDistance.Value = this.nudDistance.Minimum; // or any default value within the range
    this.JiggleDistance = (int)this.nudDistance.Value;

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
    SystemEvents.SessionSwitch += this.SystemEvents_SessionSwitch;

    if (this.JiggleOnStartup)
      this.cbJiggling.Checked = true;
  }

  protected override void OnFormClosing (FormClosingEventArgs e)
  {
    SystemEvents.SessionSwitch -= this.SystemEvents_SessionSwitch;
    base.OnFormClosing (e);
  }

  private void UpdateNotificationAreaText ()
  {
    if (!this.cbJiggling.Checked)
    {
      this.niTray.Text = GetResourceString ("MainForm_TrayNotJiggling");
    }
    else
    {
      var randomSegment = this.RandomTimer ? GetResourceString ("MainForm_TrayRandomSegment") : string.Empty;
      var mode = GetJiggleModeDisplayName (this.JiggleMode);
      var text = string.Format (GetResourceString ("MainForm_TrayStatusFormat"), this.JigglePeriod, randomSegment, mode, this.JiggleDistance);
      var ellipsis = GetResourceString ("MainForm_TrayEllipsis");
      this.niTray.Text = text.Length > MaxNotifyIconTextLength ? text[..(MaxNotifyIconTextLength - ellipsis.Length)] + ellipsis : text;
    }
  }

  private static string GetJiggleModeDisplayName (JiggleMode mode) => mode switch
  {
    JiggleMode.Normal => GetResourceString ("JiggleMode_Normal_DisplayName"),
    JiggleMode.Zen => GetResourceString ("JiggleMode_Zen_DisplayName"),
    JiggleMode.Circle => GetResourceString ("JiggleMode_Circle_DisplayName"),
    JiggleMode.Linear => GetResourceString ("JiggleMode_Linear_DisplayName"),
    _ => mode.ToString ()
  };

  private static string GetResourceString (string key) => Resources.ResourceManager.GetString (key, Resources.Culture) ?? key;

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

  protected override void OnHandleCreated (EventArgs e)
  {
    base.OnHandleCreated (e);
    this.RegisterToggleJigglingHotKey ();
  }

  protected override void OnHandleDestroyed (EventArgs e)
  {
    this.UnregisterToggleJigglingHotKey ();
    base.OnHandleDestroyed (e);
  }

  protected override void WndProc (ref Message m)
  {
    if (m.Msg == HotKeyMessage && m.WParam == (IntPtr)ToggleJigglingHotKeyId)
      this.cbJiggling.Checked = !this.cbJiggling.Checked;

    base.WndProc (ref m);
  }

  private void RegisterToggleJigglingHotKey ()
  {
    if (this._hotKeyRegistered)
      return;

    this._hotKeyRegistered = Helpers.RegisterHotKey (this.Handle,
        ToggleJigglingHotKeyId,
        ToggleJigglingHotKeyModifiers,
        ToggleJigglingHotKeyKey);

    if (!this._hotKeyRegistered)
    {
      _ = MessageBox.Show (this,
          string.Format (GetResourceString ("MainForm_HotKeyRegistrationFailed"), ToggleJigglingHotKeyText),
          @"Mouse Jiggler",
          MessageBoxButtons.OK,
          MessageBoxIcon.Warning);
    }
  }

  private void UnregisterToggleJigglingHotKey ()
  {
    if (!this._hotKeyRegistered)
      return;

    Helpers.UnregisterHotKey (this.Handle, ToggleJigglingHotKeyId);
    this._hotKeyRegistered = false;
  }

  #region Property synchronization

  private void cbSettings_CheckedChanged (object sender, EventArgs e) => this.panelSettings.Visible = this.cbSettings.Checked;

  private void cbMinimize_CheckedChanged (object sender, EventArgs e) => this.MinimizeOnStartup = this.cbMinimize.Checked;

  private void cmbJiggleMode_SelectedIndexChanged (object sender, EventArgs e)
  {
    if (this.cmbJiggleMode.SelectedItem is JiggleMode mode)
    {
      this.JiggleMode = mode;
      this.Pattern = mode switch
      {
        JiggleMode.Normal => JigglePatterns.Normal,
        JiggleMode.Zen => JigglePatterns.Zen,
        JiggleMode.Circle => JigglePatterns.Circle,
        JiggleMode.Linear => JigglePatterns.Linear,
        _ => throw new ArgumentOutOfRangeException (null, mode, GetResourceString ("Error_NoPatternForMode"))
      };
    }
  }

  private void cbRandom_CheckedChanged (object sender, EventArgs e) => this.RandomTimer = this.cbRandom.Checked;

  private void cbRespectLockedState_CheckedChanged (object sender, EventArgs e) => this.RespectLockedState = this.cbRespectLockedState.Checked;

  private void nudPeriod_ValueChanged (object sender, EventArgs e) => this.JigglePeriod = (int)this.nudPeriod.Value;

  private void nudDistance_ValueChanged (object sender, EventArgs e) => this.JiggleDistance = (int)this.nudDistance.Value;

  #endregion Property synchronization

  #region Do the Jiggle!

  protected (int deltax, int deltay)[] Pattern = null!;
  protected int Step = 0;

  private bool _workstationLocked;

  /// <summary>
  ///     Whether the mouse should currently be jiggled, taking into account both the user's "Jiggling?"
  ///     setting and whether jiggling is being suppressed because the workstation is locked.
  /// </summary>
  private bool JigglingActive => this.cbJiggling.Checked && !(this.RespectLockedState && this._workstationLocked);

  private void cbJiggling_CheckedChanged (object sender, EventArgs e)
  {
    this.UpdateJigglingState ();
    this.UpdateTrayMenu ();
    this.UpdateNotificationAreaText ();
  }

  /// <summary>
  ///     Applies <see cref="JigglingActive" /> to the timer and execution state, without touching
  ///     <c>cbJiggling.Checked</c> itself, so the checkbox (and the tray icon/menu it drives) always
  ///     reflects the user's actual setting rather than a transient lock-induced pause.
  /// </summary>
  private void UpdateJigglingState ()
  {
    if (this.JigglingActive)
      Helpers.StayAwake ();
    else
      Helpers.AllowSleep ();

    this.Step = 0;
    this.jiggleTimer.Enabled = this.JigglingActive;
  }

  private void UpdateTrayMenu ()
  {
    this.trayMenu.Items[1].Visible = !this.cbJiggling.Checked;
    this.trayMenu.Items[2].Visible = this.cbJiggling.Checked;
  }

  private void jiggleTimer_Tick (object sender, EventArgs e)
  {
    // Don't jiggle if the user has moved the mouse since the last jiggle, to avoid interfering with user input.
    if (Helpers.HasMouseMoved ())
    {
      return;
    }

    if (this.Step >= this.Pattern.Length)
      this.Step = 0;

    var (deltax, deltay) = this.Pattern[this.Step];
    this.Step++;

    if (this.Step >= this.Pattern.Length)
      this.Step = 0;

    Helpers.Jiggle (deltax, deltay);

    Helpers.UpdateMousePosition ();

    if (this.RandomTimer)
    {
      var newInterval = Random.Shared.Next(1, this.JigglePeriod + 1) * 1000;
      this.lbPeriod.Text = string.Format (GetResourceString ("MainForm_PeriodValueFormat"), newInterval / 1000);
      this.jiggleTimer.Interval = newInterval;
    }
    else
      this.jiggleTimer.Interval = this.JigglePeriod * 1000;
  }

  #endregion Do the Jiggle!

  private void SystemEvents_SessionSwitch (object sender, SessionSwitchEventArgs e)
  {
    if (e.Reason != SessionSwitchReason.SessionLock && e.Reason != SessionSwitchReason.SessionUnlock)
      return;

    if (this.IsDisposed)
      return;

    // SetThreadExecutionState (called from UpdateJigglingState via Helpers.StayAwake/AllowSleep) is
    // per-thread, so it must be set and cleared from the same (UI) thread. SystemEvents raises this
    // event on its own thread, so marshal to the UI thread before touching it.
    if (this.InvokeRequired)
    {
      this.BeginInvoke (new Action<object, SessionSwitchEventArgs> (this.SystemEvents_SessionSwitch), sender, e);
      return;
    }

    this._workstationLocked = e.Reason == SessionSwitchReason.SessionLock;

    if (this.RespectLockedState)
      this.UpdateJigglingState ();
  }

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

  private bool _randomTimer;

  private JiggleMode _jiggleMode;

  private int _jiggleDistance;

  private bool _respectLockedState;

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

  public JiggleMode JiggleMode
  {
    get => this._jiggleMode;
    set
    {
      // Validate that the value is a defined enum value
      if (!Enum.IsDefined (value))
        throw new ArgumentOutOfRangeException (nameof (value), value, GetResourceString ("Error_InvalidJiggleModeValue"));

      this._jiggleMode = value;
      Settings.Default.JiggleMode = value.ToString ();
      Settings.Default.Save ();
      this.OnPropertyChanged (nameof (this.JiggleMode));
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
      this.lbPeriod.Text = string.Format (GetResourceString ("MainForm_PeriodValueFormat"), value);

      this.OnPropertyChanged (nameof (this.JigglePeriod));
    }
  }

  [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]

  public int JiggleDistance
  {
    get => this._jiggleDistance;
    set
    {
      this._jiggleDistance = value;
      Settings.Default.JiggleDistance = value;
      Settings.Default.Save ();

      JigglePatterns.UpdatePatterns (value);

      this.Pattern = this.JiggleMode switch
      {
        JiggleMode.Normal => JigglePatterns.Normal,
        JiggleMode.Zen => JigglePatterns.Zen,
        JiggleMode.Circle => JigglePatterns.Circle,
        JiggleMode.Linear => JigglePatterns.Linear,
        _ => throw new ArgumentOutOfRangeException (null, this.JiggleMode, GetResourceString ("Error_NoPatternForMode"))
      };

      this.OnPropertyChanged (nameof (this.JiggleDistance));
    }
  }

  [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]

  public bool RespectLockedState
  {
    get => this._respectLockedState;
    set
    {
      this._respectLockedState = value;
      Settings.Default.RespectLockedState = value;
      Settings.Default.Save ();
      this.OnPropertyChanged (nameof (this.RespectLockedState));

      this.UpdateJigglingState ();
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
