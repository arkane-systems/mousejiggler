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

namespace ArkaneSystems.MouseJiggle
{
    internal static class Program
    {
        public static bool StartJiggling = false;
        public static bool ZenJiggling = false;
        public static bool StartMinimized = false;
        public static bool NoException = false;

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
    }
}
