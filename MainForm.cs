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

using System;
using System.Windows.Forms;

using Microsoft.Win32;

#endregion

namespace ArkaneSystems.MouseJiggle
{
	public partial class MainForm : Form
	{
		public MainForm() { InitializeComponent(); }

		protected bool Zig = true;

		private const string SecondsKeyword = "{{SECONDS}}";
		private const string WithWithoutKeyword = "{{WITHWITHOUT}}";
		private readonly string _notificationTrayText = $"Jiggling mouse every {SecondsKeyword}s {WithWithoutKeyword} zen";

		private void jiggleTimer_Tick(object sender, EventArgs e)
		{
			// jiggle
			if (cbZenJiggle.Checked)
			{
				Jiggler.Jiggle(0, 0);
			}
			else
			{
				if (Zig)
				{
					Jiggler.Jiggle(4, 4);
				}
				else // zag
				{
					Jiggler.Jiggle(-4, -4);
				}
			}

			Zig = !Zig;
		}

		private void cbEnabled_CheckedChanged(object sender, EventArgs e) { jiggleTimer.Enabled = cbEnabled.Checked; }

		private void cmdAbout_Click(object sender, EventArgs e)
		{
			using (var a = new AboutBox())
			{
				a.ShowDialog();
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Arkane Systems\MouseJiggle",
																	 RegistryKeyPermissionCheck.ReadWriteSubTree);
				var zen = (int)key.GetValue("ZenJiggleEnabled", 0);

				cbZenJiggle.Checked = zen != 0;
			}
			catch (Exception)
			{
				// Ignore any problems - non-critical operation.
			}

			if (Program.ZenJiggling)
			{
				cbZenJiggle.Checked = true;
			}

			if (Program.StartJiggling)
			{
				cbEnabled.Checked = true;
			}

			if (Program.StartWithSeconds != default(int))
			{
				SetSeconds();
			}

			if (Program.StartMinimized)
			{
				cmdToTray_Click(this, null);
			}
		}

		private void SetSeconds()
		{
			trkTime.Value = Program.StartWithSeconds;
			jiggleTimer.Interval = Program.StartWithSeconds * 1000;
			lblTime.Text = $@"{Program.StartWithSeconds}s";

			UpdateNotificationTrayText();
		}

		private void UpdateNotificationTrayText()
		{
			if (!cbEnabled.Checked)
			{
				nifMin.Text = @"Not jiggling the mouse.";
			}
			else
			{
				nifMin.Text = _notificationTrayText
					.Replace(SecondsKeyword, (jiggleTimer.Interval / 1000).ToString())
					.Replace(WithWithoutKeyword, cbZenJiggle.Checked ? "with" : "without");
			}
		}

		private void cbZenJiggle_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Arkane Systems\MouseJiggle",
																	 RegistryKeyPermissionCheck.ReadWriteSubTree);
				key.SetValue("ZenJiggleEnabled", cbZenJiggle.Checked ? 1 : 0);
			}
			catch (Exception)
			{
				// Ignore any problems - non-critical operation.
			}
		}

		private void cmdToTray_Click(object sender, EventArgs e)
		{
			// minimize to tray
			Visible = false;

			// remove from taskbar
			ShowInTaskbar = false;

			// show tray icon
			nifMin.Visible = true;

			UpdateNotificationTrayText();
		}

		private void nifMin_DoubleClick(object sender, EventArgs e)
		{
			// restore the window
			Visible = true;

			// replace in taskbar
			ShowInTaskbar = true;

			// hide tray icon
			nifMin.Visible = false;
		}

		private void trkTime_Scroll(object sender, EventArgs e)
		{
			int value = trkTime.Value;
			lblTime.Text = $@"{value}s";
			jiggleTimer.Interval = value * 1000;

			UpdateNotificationTrayText();
		}
	}
}
