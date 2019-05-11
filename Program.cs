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
using System.Runtime.InteropServices ;
using System.Threading ;
using System.Windows.Forms ;

#endregion

namespace ArkaneSystems.MouseJiggle
{
    internal static class Program
    {
        private const int  ATTACH_PARENT_PROCESS = -1 ;
        public static bool StartJiggling ;
        public static bool ZenJiggling ;
        public static bool StartMinimized ;
        public static bool NoException ;


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
                foreach (string arg in args)
                {
                    if ((string.Compare (arg.ToUpperInvariant (), "--JIGGLE", StringComparison.Ordinal) ==
                         0) ||
                        (string.Compare (arg.ToUpperInvariant (), "-J", StringComparison.Ordinal) == 0))
                        Program.StartJiggling = true ;

                    if ((string.Compare (arg.ToUpperInvariant (), "--ZEN", StringComparison.Ordinal) == 0) ||
                        (string.Compare (arg.ToUpperInvariant (), "-Z",    StringComparison.Ordinal) == 0))
                        Program.ZenJiggling = true ;

                    if (
                        (string.Compare (arg.ToUpperInvariant (), "--MINIMIZED", StringComparison.Ordinal) ==
                         0) ||
                        (string.Compare (arg.ToUpperInvariant (), "-M", StringComparison.Ordinal) == 0))
                        Program.StartMinimized = true ;
                    if (
                        (string.Compare (arg.ToUpperInvariant (), "--HELP", StringComparison.Ordinal) ==
                         0) ||
                        (string.Compare (arg.ToUpperInvariant (), "-H", StringComparison.Ordinal) == 0))
                    {
                        Program.WriteHelpInfo () ;
                        return ;
                    }

                    if (
                        (string.Compare (arg.ToUpperInvariant (), "--NOEXCEPTION", StringComparison.Ordinal) ==
                         0) ||
                        (string.Compare (arg.ToUpperInvariant (), "-N", StringComparison.Ordinal) == 0))
                        Program.NoException = true ;
                }

                Application.EnableVisualStyles () ;
                Application.SetCompatibleTextRenderingDefault (false) ;
                Application.Run (new MainForm ()) ;
            }

            instance.Close () ;
        }

        private static void WriteHelpInfo ()
        {
            Program.AttachConsole (Program.ATTACH_PARENT_PROCESS) ;
            Console.WriteLine () ;
            Console.WriteLine () ;
            Console.WriteLine ("MouseJiggle Usage Help:") ;
            Console.WriteLine ("-Z or --ZEN:\t\tStart the Mouse Jiggler with zen jiggling enabled") ;
            Console.WriteLine ("-J or --JIGGLE:\t\tStart the Mouse Jiggler with jiggling enabled") ;
            Console.WriteLine ("-M or --MINIMIZED:\tStart the Mouse Jiggler minimised") ;
            Console.WriteLine ("-H or --HELP:\t\tShow this Help info") ;
        }
    }
}
