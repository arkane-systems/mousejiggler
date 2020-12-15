#region header

// MouseJiggle - Program.cs
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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace ArkaneSystems.MouseJiggle
{
	internal static class Program
	{
		private const int AttachParentProcess = -1;
		private const int SecondsMinimum = 1;
		private const int SecondsMaximum = 60;

		public static bool StartJiggling;
		public static bool ZenJiggling;
		public static bool StartMinimized;
		public static int StartWithSeconds;

		private static readonly string[] JiggleCommands = { "-j", "--jiggle" };
		private static readonly string[] MinimizeCommands = { "-m", "--minimized" };
		private static readonly string[] ZenCommands = { "-z", "--zen" };
		private static readonly string[] HelpCommands = { "-h", "--help" };
		private static readonly string[] SecondsCommands = { "-s:", "--seconds:" };

		// Required for attaching console output to the Windows Form Application
		[DllImport("kernel32.dll")]

		private static extern bool AttachConsole(int dwProcessId);

		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			var instance = new Mutex(false, "single instance: ArkaneSystems.MouseJiggle");

			if (instance.WaitOne(0, false))
			{
				// Check for command-line switches. No need to loop through, just check for the specific allowed ones
				if (JiggleCommands.Any(c => args.Contains(c, StringComparer.OrdinalIgnoreCase)))
				{
					StartJiggling = true;
				}
				if (ZenCommands.Any(c => args.Contains(c, StringComparer.OrdinalIgnoreCase)))
				{
					ZenJiggling = true;
				}
				if (HelpCommands.Any(c => args.Contains(c, StringComparer.OrdinalIgnoreCase)))
				{
					WriteHelpInfo();
					return;
				}
				if (MinimizeCommands.Any(c => args.Contains(c, StringComparer.OrdinalIgnoreCase)))
				{
					StartMinimized = true;
				}

				var secondsArg = args.FirstOrDefault(a => SecondsCommands.Any(c => a.StartsWith(c, StringComparison.OrdinalIgnoreCase)));
				if (secondsArg != null)
				{
					var secondsValue =
						secondsArg.Substring(secondsArg.IndexOf(":", StringComparison.InvariantCultureIgnoreCase) + 1);
					if (!string.IsNullOrEmpty(secondsValue) && int.TryParse(secondsValue, out int _))
					{
						var seconds = int.Parse(secondsValue);
						if (seconds < SecondsMinimum)
						{
							seconds = SecondsMinimum;
						}
						if (seconds > SecondsMaximum)
						{
							seconds = SecondsMaximum;
						}
						StartWithSeconds = seconds;
					}
				}

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}

			instance.Close();
		}

		private static void WriteHelpInfo()
		{
			AttachConsole(AttachParentProcess);
			Console.WriteLine($@"
Mouse Jiggler {Assembly.GetEntryAssembly().GetName().Version}
usage:

-z or --zen         Start with zen (invisible) jiggling enabled
-j or --jiggle      Start with jiggling enabled
-m or --minimized   Start minimized
-s:X or --seconds:X Start with X seconds set for the jiggle interval
-h or --help        Show help information");
		}
	}
}
