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

using System ;
using System.Reflection ;
using System.Runtime.InteropServices ;
using System.Threading ;
using System.Windows.Forms ;

#endregion

namespace ArkaneSystems.MouseJiggle
{
    internal static class Program
    {
        private const int  AttachParentProcess = -1 ;

        public static bool StartJiggling ;
        public static bool ZenJiggling ;
        public static bool StartMinimized ;
        public static int TickValue = 1;


        // Required for attaching console output to the Windows Form Application
        [DllImport ("kernel32.dll")]
        private static extern bool AttachConsole (int dwProcessId) ;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main (string[] args)
        {
            var instance = new Mutex (false, "single instance: ArkaneSystems.MouseJiggle") ;

            if (instance.WaitOne (0, false))
            {
                // Check for command-line switches.
                foreach (string rawarg in args)
                {
                    var arg = rawarg.ToUpperInvariant () ;

                    if ((string.Compare (arg, "--JIGGLE", StringComparison.Ordinal) ==
                         0) ||
                        (string.Compare (arg, "-J", StringComparison.Ordinal) == 0))
                        Program.StartJiggling = true ;

                    if ((string.Compare (arg, "--ZEN", StringComparison.Ordinal) == 0) ||
                        (string.Compare (arg, "-Z",    StringComparison.Ordinal) == 0))
                        Program.ZenJiggling = true ;

                    if (
                        (string.Compare (arg, "--MINIMIZED", StringComparison.Ordinal) ==
                         0) ||
                        (string.Compare (arg, "-M", StringComparison.Ordinal) == 0))
                        Program.StartMinimized = true ;

                    if ((string.Compare(arg.Substring(0, 5), "-TICK", StringComparison.Ordinal) == 0) ||
                        (string.Compare(arg.Substring(0, 2), "-T", StringComparison.Ordinal) == 0))
                    {
                        string tickStr = arg.Substring(arg.IndexOf(":", StringComparison.InvariantCulture) + 1);
                        if (int.TryParse(tickStr, out int tickVal))
                        {
                            if (tickVal > 0 && tickVal <= 60)
                                Program.TickValue = tickVal;
                        }
                    }

                    if (
                        (string.Compare (arg, "--HELP", StringComparison.Ordinal) ==
                         0) ||
                        (string.Compare (arg, "-H", StringComparison.Ordinal) == 0))
                    {
                        Program.WriteHelpInfo () ;
                        return ;
                    }
                }

                Application.EnableVisualStyles () ;
                Application.SetCompatibleTextRenderingDefault (false) ;
                Application.Run (new MainForm ()) ;
            }

            instance.Close () ;
        }

        private static void WriteHelpInfo ()
        {
            Program.AttachConsole (Program.AttachParentProcess) ;
            Console.WriteLine ($@"
Mouse Jiggler {Assembly.GetEntryAssembly().GetName().Version}
usage:

-z or --zen:        Start with zen (invisible) jiggling enabled
-j or --jiggle:     Start with jiggling enabled
-m or --minimized:  Start minimized
-h or --help:       Show help information
-t:x or --tick:x:   Set time between jiggles to x seconds") ;
        }
    }
}
