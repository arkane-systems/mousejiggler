#region header

// MouseJiggle - MainForm.cs
// 
// Alistair J. R. Young
// Arkane Systems
// 
// Copyright Arkane Systems 2012-2019.  All rights reserved.
// 
// Created: 2019-05-11 3:10 PM

#endregion

#region using

using System ;
using System.Windows.Forms ;

using Microsoft.Win32 ;

#endregion

namespace ArkaneSystems.MouseJiggle
{
    public partial class MainForm : Form
    {
        public MainForm () { this.InitializeComponent () ; }

        protected bool zig = true ;

        private void jiggleTimer_Tick (object sender, EventArgs e)
        {
            // jiggle
            if (this.cbZenJiggle.Checked)
            {
                Jiggler.Jiggle (0, 0) ;
            }
            else
            {
                if (this.zig)
                    Jiggler.Jiggle (4, 4) ;
                else // zag
                    Jiggler.Jiggle (-4, -4) ;
            }

            this.zig = !this.zig ;
        }

        private void cbEnabled_CheckedChanged (object sender, EventArgs e) { this.jiggleTimer.Enabled = this.cbEnabled.Checked ; }

        private void cmdAbout_Click (object sender, EventArgs e)
        {
            using (var a = new AboutBox ())
                a.ShowDialog () ;
        }

        private void MainForm_Load (object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey (@"Software\Arkane Systems\MouseJiggle",
                                                                     RegistryKeyPermissionCheck.ReadWriteSubTree) ;
                var zen = (int) key.GetValue ("ZenJiggleEnabled", 0) ;

                if (zen == 0)
                    this.cbZenJiggle.Checked = false ;
                else
                    this.cbZenJiggle.Checked = true ;
            }
            catch (Exception)
            {
                // Ignore any problems - non-critical operation.
            }

            if (Program.ZenJiggling)
                this.cbZenJiggle.Checked = true ;

            if (Program.StartJiggling)
                this.cbEnabled.Checked = true ;

            if (Program.StartMinimized)
                this.cmdToTray_Click (this, null) ;

            trkTime.Value = Program.TickValue;
            lblTime.Text = Program.TickValue + "s";
            jiggleTimer.Interval = Program.TickValue * 1000;
        }

        private void cbZenJiggle_CheckedChanged (object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey (@"Software\Arkane Systems\MouseJiggle",
                                                                     RegistryKeyPermissionCheck.ReadWriteSubTree) ;
                if (this.cbZenJiggle.Checked)
                    key.SetValue ("ZenJiggleEnabled", 1) ;
                else
                    key.SetValue ("ZenJiggleEnabled", 0) ;
            }
            catch (Exception)
            {
                // Ignore any problems - non-critical operation.
            }
        }

        private void cmdToTray_Click (object sender, EventArgs e)
        {
            // minimize to tray
            this.Visible = false ;

            // remove from taskbar
            this.ShowInTaskbar = false ;

            // show tray icon
            this.nifMin.Visible = true ;
        }

        private void nifMin_DoubleClick (object sender, EventArgs e)
        {
            // restore the window
            this.Visible = true ;

            // replace in taskbar
            this.ShowInTaskbar = true ;

            // hide tray icon
            this.nifMin.Visible = false ;
        }

        private void trkTime_Scroll(object sender, EventArgs e)
        {
            int value = trkTime.Value;
            lblTime.Text = value + "s";
            jiggleTimer.Interval = value * 1000;
        }
    }
}
