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
using Windows.Win32.System.Power;
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

  #region Execution state

  public static void StayAwake ()
  {
    var returnValue = PInvoke.SetThreadExecutionState (EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_SYSTEM_REQUIRED);

    if (returnValue != 0)
      return;

    var errorCode = Marshal.GetLastWin32Error();

    Debugger.Log (1,
        "StayAwake",
        $"failed to set execution state; retval={returnValue}, errcode=0x{errorCode:x8}\n");
  }

  public static void AllowSleep ()
  {
    var returnValue = PInvoke.SetThreadExecutionState (EXECUTION_STATE.ES_CONTINUOUS);

    if (returnValue != 0)
      return;

    var errorCode = Marshal.GetLastWin32Error();
    Debugger.Log (1,
        "AllowSleep",
        $"failed to set execution state; retval={returnValue}, errcode=0x{errorCode:x8}\n");
  }

  #endregion Execution state

  #region Jiggling

  /// <summary>
  ///     Jiggle the mouse; i.e., fake a mouse movement event.
  /// </summary>
  /// <param name="delta">The mouse will be moved by delta pixels along both X and Y.</param>
  internal static void Jiggle (int deltax, int deltay)
  {
    var inp = new INPUT
    {
      type = INPUT_TYPE.INPUT_MOUSE,
      Anonymous = new INPUT._Anonymous_e__Union
      {
        mi = new MOUSEINPUT
        {
          dx = deltax,
          dy = deltay,
          mouseData = 0,
          dwFlags = MOUSE_EVENT_FLAGS.MOUSEEVENTF_MOVE,
          time = 0,
          dwExtraInfo = 0
        }
      }
    };

    var returnValue = PInvoke.SendInput(new ReadOnlySpan<INPUT>(in inp), Marshal.SizeOf<INPUT>());

    if (returnValue == 1)
      return;
    var errorCode = Marshal.GetLastWin32Error();

    Debugger.Log (1,
        "Jiggle",
        $"failed to insert event to input stream; retval={returnValue}, errcode=0x{errorCode:x8}\n");
  }

  #endregion Jiggling

  #region Movement detection

  private static int? lastx, lasty;

  /// <summary>
  /// Determines whether the mouse cursor has moved since the last check.
  /// </summary>
  /// <remarks>This method updates its internal state each time it is called. Repeated calls will return true
  /// only if the cursor position has changed since the last call. This method is not thread-safe.</remarks>
  /// <returns>true if the mouse cursor position has changed since the previous invocation; otherwise, false.</returns>
  public static bool HasMouseMoved ()
  {
    bool result = false;

    if (PInvoke.GetCursorPos (out var point))
    {
      result = lastx != point.X || lasty != point.Y;

      lastx = point.X;
      lasty = point.Y;
    }

    return result;
  }

  /// <summary>
  /// Updates the stored mouse cursor position to reflect the current location on the screen.
  /// </summary>
  /// <remarks>This method retrieves the current position of the mouse cursor using platform invocation and
  /// updates internal state accordingly. If the cursor position cannot be obtained, the stored values remain
  /// unchanged.</remarks>
  public static void UpdateMousePosition ()
  {
    if (PInvoke.GetCursorPos (out var point))
    {
      lastx = point.X;
      lasty = point.Y;
    }
  }

  #endregion Movement detection
}
