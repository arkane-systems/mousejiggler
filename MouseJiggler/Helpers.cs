#region header

// MouseJiggler - Helpers.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/20 7:40 PM.
// Updates by: Dimitris Panokostas (midwan)

#endregion

#region using

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.UI.Input.KeyboardAndMouse;

#endregion

namespace ArkaneSystems.MouseJiggler;

internal static class Helpers
{
    #region Console management

    /// <summary>
    ///     Constant value signifying a request to attach to the console of the parent process.
    /// </summary>
    internal const uint AttachParentProcess = uint.MaxValue;

    #endregion Console management

    #region Jiggling

    /// <summary>
    ///     Jiggle the mouse; i.e., fake a mouse movement event.
    /// </summary>
    /// <param name="delta">The mouse will be moved by delta pixels along both X and Y.</param>
    internal static void Jiggle(int delta)
    {
        var inp = new INPUT
        {
          type = INPUT_TYPE.INPUT_MOUSE,
          Anonymous = new INPUT._Anonymous_e__Union
          {
            mi = new MOUSEINPUT
            {
              dx = delta,
              dy = delta,
              mouseData = 0,
              dwFlags = MOUSE_EVENT_FLAGS.MOUSEEVENTF_MOVE,
              time = 0,
              dwExtraInfo = 0
            }
          }
        };
    
        var returnValue = PInvoke.SendInput(new ReadOnlySpan<INPUT>(in inp), Marshal.SizeOf<INPUT>());

        if (returnValue == 1) return;
        var errorCode = Marshal.GetLastWin32Error();

        Debugger.Log(1,
            "Jiggle",
            $"failed to insert event to input stream; retval={returnValue}, errcode=0x{errorCode:x8}\n");
    }

    #endregion Jiggling
}