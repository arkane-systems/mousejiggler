﻿#region header

// MouseJiggler - MainForm.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/24 1:57 AM.

#endregion

#region using

using System;
using System.Windows.Forms;

using ArkaneSystems.MouseJiggler.Properties;

#endregion

namespace ArkaneSystems.MouseJiggler
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Constructor for use by the form designer.
        /// </summary>
        public MainForm ()
            : this (jiggleOnStartup: false, minimizeOnStartup: false, zenJiggleEnabled: false, alwaysShowTrayIcon: false, jigglePeriod: 1)
        { }

        public MainForm (bool jiggleOnStartup, bool minimizeOnStartup, bool zenJiggleEnabled, bool alwaysShowTrayIcon, int jigglePeriod)
        {
            this.InitializeComponent ();

            // Jiggling on startup?
            this.JiggleOnStartup = jiggleOnStartup;

            // Set settings properties
            // We do this by setting the controls, and letting them set the properties.

            this.cbMinimize.Checked = minimizeOnStartup;
            this.cbZen.Checked      = zenJiggleEnabled;
            this.tbPeriod.Value     = jigglePeriod;
            this.cbShowIcon.Checked = alwaysShowTrayIcon;
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
                this.niTray.Text = "Not jiggling the mouse.";
            }
            else
            {
                string? ww = this.ZenJiggleEnabled ? "with" : "without";
                this.niTray.Text = $"Jiggling mouse every {this.JigglePeriod} s, {ww} Zen.";
            }
        }

        private void cmdAbout_Click (object sender, EventArgs e)
        {
            new AboutBox ().ShowDialog (owner: this);
        }

        #region Property synchronization

        private void cbSettings_CheckedChanged (object sender, EventArgs e)
        {
            this.panelSettings.Visible = this.cbSettings.Checked;
        }

        private void cbMinimize_CheckedChanged (object sender, EventArgs e)
        {
            this.MinimizeOnStartup = this.cbMinimize.Checked;
        }

        private void cbZen_CheckedChanged (object sender, EventArgs e)
        {
            this.ZenJiggleEnabled = this.cbZen.Checked;

            this.UpdateNotificationAreaText ();
        }

        private void cbShowIcon_CheckedChanged (object sender, EventArgs e)
        {
            this.AlwaysShowTrayIcon = this.cbShowIcon.Checked;
            if (this.Visible)
                this.niTray.Visible = this.AlwaysShowTrayIcon;
        }

        private void tbPeriod_ValueChanged (object sender, EventArgs e)
        {
            this.JigglePeriod = this.tbPeriod.Value;

            this.UpdateNotificationAreaText ();
        }

        #endregion Property synchronization

        #region Do the Jiggle!

        protected bool Zig = true;

        private void cbJiggling_CheckedChanged (object sender, EventArgs e)
        {
            this.jiggleTimer.Enabled = this.cbJiggling.Checked;

            this.UpdateNotificationAreaText ();
        }

        private void jiggleTimer_Tick (object sender, EventArgs e)
        {
            if (this.ZenJiggleEnabled)
                Helpers.Jiggle (delta: 0);
            else if (this.Zig)
                Helpers.Jiggle (delta: 4);
            else //zag
                Helpers.Jiggle (delta: -4);

            this.Zig = !this.Zig;
        }

        #endregion Do the Jiggle!

        #region Minimize and restore

        private void cmdTrayify_Click (object sender, EventArgs e)
        {
            this.MinimizeToTray ();
        }

        private void niTray_DoubleClick (object sender, EventArgs e)
        {
            this.RestoreFromTray ();
        }

        private void showToolStripMenuItem_Click (object sender, EventArgs e)
        {
            if (this.Visible)
                this.MinimizeToTray ();
            else
                this.RestoreFromTray ();
        }

        private void exitToolStripMenuItem_Click (object sender, EventArgs e)
        {
            this.Close ();
        }

        private void MinimizeToTray ()
        {
            this.Visible        = false;
            this.ShowInTaskbar  = false;
            this.niTray.Visible = true;

            this.showToolStripMenuItem.Text = "Show";
        }

        private void RestoreFromTray ()
        {
            this.Visible        = true;
            this.ShowInTaskbar  = true;
            this.niTray.Visible = this.AlwaysShowTrayIcon;

            this.showToolStripMenuItem.Text = "Hide";
            this.UpdateNotificationAreaText ();
        }

        #endregion Minimize and restore

        #region Settings property backing fields

        private int jigglePeriod;

        private bool minimizeOnStartup;

        private bool zenJiggleEnabled;

        private bool alwaysShowTrayIcon;

        #endregion Settings property backing fields

        #region Settings properties

        public bool MinimizeOnStartup
        {
            get => this.minimizeOnStartup;
            set
            {
                this.minimizeOnStartup             = value;
                Settings.Default.MinimizeOnStartup = value;
                Settings.Default.Save ();
            }
        }

        public bool ZenJiggleEnabled
        {
            get => this.zenJiggleEnabled;
            set
            {
                this.zenJiggleEnabled      = value;
                Settings.Default.ZenJiggle = value;
                Settings.Default.Save ();
            }
        }

        public bool AlwaysShowTrayIcon
        {
            get => this.alwaysShowTrayIcon;
            set
            {
                this.alwaysShowTrayIcon             = value;
                Settings.Default.AlwaysShowTrayIcon = value;
                Settings.Default.Save ();
            }
        }

        public int JigglePeriod
        {
            get => this.jigglePeriod;
            set
            {
                this.jigglePeriod             = value;
                Settings.Default.JigglePeriod = value;
                Settings.Default.Save ();

                this.jiggleTimer.Interval = value * 1000;
                this.lbPeriod.Text        = $"{value} s";
            }
        }

        #endregion Settings properties

        #region Minimize on start

        private bool firstShown = true;

        private void MainForm_Shown (object sender, EventArgs e)
        {
            if (this.firstShown && this.MinimizeOnStartup)
                this.MinimizeToTray ();
            else
                this.RestoreFromTray (); // Triggers displaying tray icon, updating notification area text

            this.firstShown = false;
        }

        #endregion
    }
}
