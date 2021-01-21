#region header

// MouseJiggler - Helpers.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/20 7:40 PM.

#endregion

#region using

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

#endregion

namespace ArkaneSystems.MouseJiggler
{
    internal static class Helpers
    {
        #region Console management

        /// <summary>
        ///     Constant value signifying a request to attach to the console of the parent process.
        /// </summary>
        internal const int AttachParentProcess = -1;

        /// <summary>
        ///     Attach to the console of a specified process.
        /// </summary>
        /// <param name="dwProcessId">The process to attach to.</param>
        /// <returns>True if successful; false otherwise.</returns>
        [DllImport (dllName: "kernel32.dll")]
        internal static extern bool AttachConsole (int dwProcessId);

        #endregion Console management

        #region Jiggling

        /// <summary>
        ///     INPUT structure (used with SendInput to define system input events).
        /// </summary>
        [StructLayout (layoutKind: LayoutKind.Sequential)]

        // ReSharper disable once InconsistentNaming
        private struct INPUT
        {
            internal uint       type;
            internal InputUnion U;

            internal static int Size => Marshal.SizeOf (t: typeof (INPUT));
        }

        /// <summary>
        ///     Union within the INPUT structure, notionally containing MOUSE, KEYBD and HARDWARE alternate structures;
        ///     only MOUSE has been implemented here.
        /// </summary>
        [StructLayout (layoutKind: LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset (offset: 0)]
            internal MOUSEINPUT mi;

            //[FieldOffset(0)]
            //internal KEYBDINPUT ki;
            //[FieldOffset(0)]
            //internal HARDWAREINPUT hi;
        }

        /// <summary>
        ///     MOUSEINPUT structure (used with SendInput to define mouse input events).
        /// </summary>
        [StructLayout (layoutKind: LayoutKind.Sequential)]

        // ReSharper disable once InconsistentNaming
        private struct MOUSEINPUT
        {
            internal int         dx;
            internal int         dy;
            internal int         mouseData;
            internal MOUSEEVENTF dwFlags;
            internal uint        time;
            internal UIntPtr     dwExtraInfo;
        }

        /// <summary>
        ///     An enumeration of mouse event types used by SendInput and the MOUSEINPUT structure.
        /// </summary>
        [Flags]

        // ReSharper disable InconsistentNaming
        private enum MOUSEEVENTF : uint
        {
            ABSOLUTE        = 0x8000,
            HWHEEL          = 0x01000,
            MOVE            = 0x0001,
            MOVE_NOCOALESCE = 0x2000,
            LEFTDOWN        = 0x0002,
            LEFTUP          = 0x0004,
            RIGHTDOWN       = 0x0008,
            RIGHTUP         = 0x0010,
            MIDDLEDOWN      = 0x0020,
            MIDDLEUP        = 0x0040,
            VIRTUALDESK     = 0x4000,
            WHEEL           = 0x0800,
            XDOWN           = 0x0080,
            XUP             = 0x0100,
        }

        // ReSharper restore InconsistentNaming

        // ReSharper disable once InconsistentNaming
        private const int INPUT_MOUSE = 0;

        /// <summary>
        ///     Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        /// <param name="nInputs">The number of structures in the pInputs array.</param>
        /// <param name="pInputs">
        ///     An array of INPUT structures. Each structure represents an event to be inserted into the keyboard
        ///     or mouse input stream.
        /// </param>
        /// <param name="cbSize">
        ///     The size, in bytes, of an INPUT structure. If cbSize is not the size of an INPUT structure, the
        ///     function fails.
        /// </param>
        /// <returns>
        ///     The function returns the number of events that it successfully inserted into the keyboard or mouse input
        ///     stream. If the function returns zero, the input was already blocked by another thread. To get extended error
        ///     information, call GetLastError.
        /// </returns>
        [DllImport (dllName: "user32.dll", SetLastError = true)]
        private static extern uint SendInput (uint nInputs,
                                              [MarshalAs (unmanagedType: UnmanagedType.LPArray)] [In]
                                              INPUT[] pInputs,
                                              int cbSize);

        /// <summary>
        ///     Jiggle the mouse; i.e., fake a mouse movement event.
        /// </summary>
        /// <param name="delta">The mouse will be moved by delta pixels along both X and Y.</param>
        internal static void Jiggle (int delta)
        {
            var inp = new INPUT
                      {
                          type = Helpers.INPUT_MOUSE,
                          U    = new InputUnion (),
                      };

            inp.U.mi = new MOUSEINPUT
                       {
                           dx          = delta,
                           dy          = delta,
                           mouseData   = 0,
                           dwFlags     = MOUSEEVENTF.MOVE,
                           time        = 0,
                           dwExtraInfo = UIntPtr.Zero,
                       };

            uint returnValue = Helpers.SendInput (nInputs: 1, pInputs: new[] {inp,}, cbSize: INPUT.Size);

            if (returnValue != 1)
            {
                int errorCode = Marshal.GetLastWin32Error ();

                Debugger.Log (level: 1,
                              category: "Jiggle",
                              message:
                              $"failed to insert event to input stream; retval={returnValue}, errcode=0x{errorCode:x8}\n");
            }
        }

        #endregion Jiggling
    }
}
