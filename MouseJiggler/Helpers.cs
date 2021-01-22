#region header

// MouseJiggler - Helpers.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/20 7:40 PM.

#endregion

#region using

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using PInvoke;

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

        #endregion Console management

        #region Jiggling

        /// <summary>
        ///     Jiggle the mouse; i.e., fake a mouse movement event.
        /// </summary>
        /// <param name="delta">The mouse will be moved by delta pixels along both X and Y.</param>
        internal static void Jiggle (int delta)
        {
            var inp = new User32.INPUT
                      {
                          type = User32.InputType.INPUT_MOUSE,
                          Inputs = new User32.INPUT.InputUnion
                                   {
                                       mi = new User32.MOUSEINPUT
                                            {
                                                dx                 = delta,
                                                dy                 = delta,
                                                mouseData          = 0,
                                                dwFlags            = User32.MOUSEEVENTF.MOUSEEVENTF_MOVE,
                                                time               = 0,
                                                dwExtraInfo_IntPtr = IntPtr.Zero,
                                            },
                                   },
                      };

            uint returnValue = User32.SendInput (nInputs: 1, pInputs: new[] {inp,}, cbSize: Marshal.SizeOf<User32.INPUT> ());

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
