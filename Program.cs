#region header

// MouseJiggle - Program.cs
// 
// Alistair J. R. Young
// Arkane Systems
// 
// Copyright Arkane Systems 2012-2013.
// 
// Created: 2013-08-24 12:41 PM

#endregion

using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ArkaneSystems.MouseJiggle
{
    internal static class Program
    {
        public static bool StartJiggling = false;
        public static bool ZenJiggling = false;
        public static bool StartMinimized = false;
        public static bool NoException = false;


        // Required for attaching console output to the Windows Form Application
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main (string[] args)
        {
            Mutex instance = new Mutex(false, "single instance: ArkaneSystems.MouseJiggle");

            if (instance.WaitOne(0, false))
            {
                // Check for command-line switches.
                foreach (string arg in args)
                {
                    if ((System.String.Compare (arg.ToUpperInvariant (), "--JIGGLE", System.StringComparison.Ordinal) ==
                         0) ||
                        (System.String.Compare (arg.ToUpperInvariant (), "-J", System.StringComparison.Ordinal) == 0))
                        StartJiggling = true;

                    if ((System.String.Compare (arg.ToUpperInvariant (), "--ZEN", System.StringComparison.Ordinal) == 0) ||
                        (System.String.Compare (arg.ToUpperInvariant (), "-Z", System.StringComparison.Ordinal) == 0))
                        ZenJiggling = true;

                    if (
                        (System.String.Compare (arg.ToUpperInvariant (), "--MINIMIZED", System.StringComparison.Ordinal) ==
                         0) ||
                        (System.String.Compare (arg.ToUpperInvariant (), "-M", System.StringComparison.Ordinal) == 0))
                        StartMinimized = true;
                    if (
                        (System.String.Compare (arg.ToUpperInvariant (), "--HELP", System.StringComparison.Ordinal) ==
                         0) ||
                        (System.String.Compare (arg.ToUpperInvariant (), "-H", System.StringComparison.Ordinal) == 0))
                    {
                        WriteHelpInfo();
                        return;
                    }
                    if (
                        (System.String.Compare(arg.ToUpperInvariant(), "--NOEXCEPTION", System.StringComparison.Ordinal) ==
                         0) ||
                        (System.String.Compare(arg.ToUpperInvariant(), "-N", System.StringComparison.Ordinal) == 0))
                        NoException = true;
                }

                Application.EnableVisualStyles ();
                Application.SetCompatibleTextRenderingDefault (false);
                Application.Run (new MainForm ());
            }

            instance.Close ();
        }

        private static void WriteHelpInfo()
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("MouseJiggle Usage Help:");
            Console.WriteLine("-Z or --ZEN:\t\tStart the Mouse Jiggler with zen jiggling enabled");
            Console.WriteLine("-J or --JIGGLE:\t\tStart the Mouse Jiggler with jiggling enabled");
            Console.WriteLine("-M or --MINIMIZED:\tStart the Mouse Jiggler minimised");
            Console.WriteLine("-H or --HELP:\t\tShow this Help info");
        }
    }
}
