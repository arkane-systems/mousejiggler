#region header

// MouseJiggler - Program.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/22 4:12 PM.
// Updates by: Dimitris Panokostas (midwan)

#endregion

#region using

using ArkaneSystems.MouseJiggler.Properties;
using JetBrains.Annotations;
using System;
using System.CommandLine;
using System.CommandLine.Help;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Windows.Win32;

#endregion

namespace ArkaneSystems.MouseJiggler;

[PublicAPI]
public static class Program
{
  static bool AttachedToConsole { get; set; } = false;

  /// <summary>
  ///     The main entry point for the application.
  /// </summary>
  [STAThread]
  public static int Main (string[] args)
  {
    // Attach to the parent process's console so we can display help, version information, and command-line errors.
    Program.AttachedToConsole = PInvoke.AttachConsole (Helpers.AttachParentProcess);

    try
    {
      // Parse arguments and do the appropriate thing. Single-instance enforcement happens inside
      // RootHandler, not here, since --stop-jiggling is meant to signal an already-running instance
      // rather than compete with it for the mutex.
      return GetCommandLineParser ().Parse (args).Invoke ();
    }
    catch (Exception ex)
    {
      // Report unhandled exceptions instead of letting the process crash silently, since a GUI launch
      // has no console for the default unhandled-exception dialog to be useful on.
      if (AttachedToConsole)
        Console.Error.WriteLine (string.Format (GetResourceString ("Program_UnexpectedError_Console"), ex.Message));
      else
        MessageBox.Show (string.Format (GetResourceString ("Program_UnexpectedError_Dialog"), ex.Message),
            @"Mouse Jiggler",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

      return 1;
    }
    finally
    {
      // Detach from the parent console.
      if (AttachedToConsole)
      {
        _ = PInvoke.FreeConsole ();
        Program.AttachedToConsole = false;
      }
    }
  }

  private static int RootHandler (bool jiggle, bool minimized, JiggleMode mode, bool random, bool settings, int seconds, int distance, bool respectLockedState)
  {
    // Ensure that we are the only instance of the Mouse Jiggler currently running.
    var instance = new Mutex(false, "single instance: ArkaneSystems.MouseJiggler");

    try
    {
      if (!instance.WaitOne (0))
      {
        Console.WriteLine (GetResourceString ("Program_AlreadyRunning"));

        return 1;
      }

      // Prepare Windows Forms to run the application.
      _ = Application.SetHighDpiMode (HighDpiMode.SystemAware);
      Application.EnableVisualStyles ();
      Application.SetCompatibleTextRenderingDefault (false);
      Application.SetColorMode (SystemColorMode.System);

      // Detach from console before running the application, as we won't be needing it anymore.
      if (AttachedToConsole)
      {
        _ = PInvoke.FreeConsole ();
        Program.AttachedToConsole = false;
      }

      // Run the application.
      var mainForm = new MainForm(jiggle,
              minimized,
              mode,
              random,
              seconds,
              distance,
              settings,
              respectLockedState);

      Application.Run (mainForm);

      return 0;
    }
    finally
    {
      instance.Close ();
    }
  }

  /// <summary>
  ///     Signals an already-running Mouse Jiggler instance to stop jiggling, then exits without starting
  ///     a GUI of its own. Intended to be invoked by Task Scheduler (or similar) as a clean alternative to
  ///     a timed auto-stop feature built into the app itself.
  /// </summary>
  private static int StopRunningInstance ()
  {
    if (!EventWaitHandle.TryOpenExisting (Helpers.StopJigglingEventName, out var stopEvent))
    {
      Console.WriteLine (GetResourceString ("Program_NoInstanceToStop"));

      return 1;
    }

    using (stopEvent)
      _ = stopEvent.Set ();

    return 0;
  }

  private static RootCommand GetCommandLineParser ()
  {
    // -j --jiggle
    var optJiggling = new Option<bool>("--jiggle", "-j")
    {
      Description = GetResourceString ("Program_OptJiggle_Description"),
      DefaultValueFactory = _ => false
    };

    // -m --minimized
    var optMinimized = new Option<bool>("--minimized", "-m")
    {
      Description = GetResourceString ("Program_OptMinimized_Description"),
      DefaultValueFactory = _ => Settings.Default.MinimizeOnStartup
    };

    // -o --mode
    var optMode = new Option<JiggleMode>("--mode", "-o")
    {
      Description = GetResourceString ("Program_OptMode_Description"),
      DefaultValueFactory = _ => Enum.TryParse<JiggleMode>(Settings.Default.JiggleMode, true, out JiggleMode m) ? m : JiggleMode.Normal
    };

    // -r --random
    var optRandom = new Option<bool>("--random", "-r")
    {
      Description = GetResourceString ("Program_OptRandom_Description"),
      DefaultValueFactory = _ => Settings.Default.RandomTimer
    };

    // -s 60 --seconds 60
    var optPeriod = new Option<int>("--seconds", "-s")
    {
      Description = GetResourceString ("Program_OptSeconds_Description"),
      DefaultValueFactory = _ => Settings.Default.JigglePeriod
    };

    optPeriod.Validators.Add (result =>
    {
      var value = result.GetValue(optPeriod);
      if (value < 1)
        result.AddError (GetResourceString ("Program_Error_PeriodTooShort"));
      else if (value > 10800)
        result.AddError (GetResourceString ("Program_Error_PeriodTooLong"));
    });

    // -d 1 --distance 1
    var optDistance = new Option<int>("--distance", "-d")
    {
      Description = GetResourceString ("Program_OptDistance_Description"),
      DefaultValueFactory = _ => Settings.Default.JiggleDistance
    };

    optDistance.Validators.Add (result =>
    {
      var value = result.GetValue(optDistance);
      if (value < 1)
        result.AddError (GetResourceString ("Program_Error_DistanceTooShort"));
      else if (value > 120)
        result.AddError (GetResourceString ("Program_Error_DistanceTooLong"));
    });

    // -g --settings
    var optSettings = new Option<bool>("--settings", "-g")
    {
      Description = GetResourceString ("Program_OptSettings_Description"),
      DefaultValueFactory = _ => false
    };

    // -l --respect-locked-state
    var optRespectLockedState = new Option<bool>("--respect-locked-state", "-l")
    {
      Description = GetResourceString ("Program_OptRespectLockedState_Description"),
      DefaultValueFactory = _ => Settings.Default.RespectLockedState
    };

    // --stop-jiggling
    var optStopJiggling = new Option<bool>("--stop-jiggling")
    {
      Description = GetResourceString ("Program_OptStopJiggling_Description"),
      DefaultValueFactory = _ => false
    };

    // Create root command.
    var rootCommand = new RootCommand(GetResourceString ("Program_RootCommand_Description"))
        {
            optJiggling,
            optMinimized,
            optMode,
            optRandom,
            optPeriod,
            optDistance,
            optSettings,
            optRespectLockedState,
            optStopJiggling
        };

    // Replace default help action with our spaced help action, if present.
    var ha = rootCommand.Options.OfType<HelpOption>().FirstOrDefault();
    if (ha?.Action is HelpAction helpAction)
    {
      ha.Description = GetResourceString ("Program_HelpOption_Description");
      ha.Action = new SpacedHelpAction(helpAction);
    }

    rootCommand.SetAction (parseResult =>
    {
      // --stop-jiggling signals an already-running instance and exits; it never starts a GUI of its
      // own, so none of the other options apply when it's given.
      if (parseResult.GetValue (optStopJiggling))
        return StopRunningInstance ();

      var jiggle = parseResult.GetValue(optJiggling);
      var minimized = parseResult.GetValue(optMinimized);
      var mode = parseResult.GetValue(optMode);
      var random = parseResult.GetValue(optRandom);
      var seconds = parseResult.GetValue(optPeriod);
      var distance = parseResult.GetValue(optDistance);
      var settings = parseResult.GetValue(optSettings);
      var respectLockedState = parseResult.GetValue(optRespectLockedState);

      return RootHandler (jiggle, minimized, mode, random, settings, seconds, distance, respectLockedState);
    });

    // Build the command line parser.
    return rootCommand;
  }

  private static string GetResourceString (string key) => Resources.ResourceManager.GetString (key, Resources.Culture) ?? key;
}