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

    // Ensure that we are the only instance of the Mouse Jiggler currently running.
    var instance = new Mutex(false, "single instance: ArkaneSystems.MouseJiggler");

    try
    {
      if (instance.WaitOne (0))

      // Parse arguments and do the appropriate thing.
      {
        return GetCommandLineParser ().Parse (args).Invoke ();
      }
      else
      {
        Console.WriteLine (GetResourceString ("Program_AlreadyRunning"));

        return 1;
      }
    }
    catch (Exception ex)
    {
      // Report unhandled exceptions instead of letting the process crash silently, since a GUI launch
      // has no console for the default unhandled-exception dialog to be useful on.
      if (AttachedToConsole)
        Console.Error.WriteLine ($@"Mouse Jiggler encountered an unexpected error: {ex.Message}");
      else
        MessageBox.Show ($"Mouse Jiggler encountered an unexpected error:\n\n{ex.Message}",
            @"Mouse Jiggler",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

      return 1;
    }
    finally
    {
      instance.Close ();

      // Detach from the parent console.
      if (AttachedToConsole)
      {
        _ = PInvoke.FreeConsole ();
        Program.AttachedToConsole = false;
      }
    }
  }

  private static int RootHandler (bool jiggle, bool minimized, JiggleMode mode, bool random, bool settings, int seconds, int distance)
  {
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
            settings);

    Application.Run (mainForm);

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

    // Create root command.
    var rootCommand = new RootCommand(GetResourceString ("Program_RootCommand_Description"))
        {
            optJiggling,
            optMinimized,
            optMode,
            optRandom,
            optPeriod,
            optDistance,
            optSettings
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
      var jiggle = parseResult.GetValue(optJiggling);
      var minimized = parseResult.GetValue(optMinimized);
      var mode = parseResult.GetValue(optMode);
      var random = parseResult.GetValue(optRandom);
      var seconds = parseResult.GetValue(optPeriod);
      var distance = parseResult.GetValue(optDistance);
      var settings = parseResult.GetValue(optSettings);

      return RootHandler (jiggle, minimized, mode, random, settings, seconds, distance);
    });

    // Build the command line parser.
    return rootCommand;
  }

  private static string GetResourceString (string key) => Resources.ResourceManager.GetString (key, Resources.Culture) ?? key;
}