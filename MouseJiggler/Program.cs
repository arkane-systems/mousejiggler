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
        Console.WriteLine (@"Mouse Jiggler is already running. Aborting.");

        return 1;
      }
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
      Description = "Start with jiggling enabled.",
      DefaultValueFactory = _ => false
    };

    // -m --minimized
    var optMinimized = new Option<bool>("--minimized", "-m")
    {
      Description = "Start minimized.",
      DefaultValueFactory = _ => Settings.Default.MinimizeOnStartup
    };

    // -o --mode
    var optMode = new Option<JiggleMode>("--mode", "-o")
    {
      Description = "Start with the specified jiggle mode enabled.",
      DefaultValueFactory = _ => Enum.TryParse<JiggleMode>(Settings.Default.JiggleMode, true, out JiggleMode m) ? m : JiggleMode.Normal
    };

    // -r --random
    var optRandom = new Option<bool>("--random", "-r")
    {
      Description = "Start with random variation enabled.",
      DefaultValueFactory = _ => Settings.Default.RandomTimer
    };

    // -s 60 --seconds 60
    var optPeriod = new Option<int>("--seconds", "-s")
    {
      Description = "Set X number of seconds for the jiggle interval.",
      DefaultValueFactory = _ => Settings.Default.JigglePeriod
    };

    optPeriod.Validators.Add (result =>
    {
      var value = result.GetValue(optPeriod);
      if (value < 1)
        result.AddError ("Period cannot be shorter than 1 second.");
      else if (value > 10800)
        result.AddError ("Period cannot be longer than 10800 seconds.");
    });

    // -d 1 --distance 1
    var optDistance = new Option<int>("--distance", "-d")
    {
      Description = "Set the multiplier for the jiggle distance.",
      DefaultValueFactory = _ => Settings.Default.JiggleDistance
    };

    optDistance.Validators.Add (result =>
    {
      var value = result.GetValue(optDistance);
      if (value < 1)
        result.AddError ("Distance multiplier cannot be less than 1.");
      else if (value > 120)
        result.AddError ("Distance multiplier cannot be greater than 120.");
    });

    // -g --settings
    var optSettings = new Option<bool>("--settings", "-g")
    {
      Description = "Start with settings panel displayed.",
      DefaultValueFactory = _ => false
    };

    // Create root command.
    var rootCommand = new RootCommand("Virtually jiggles the mouse, making the computer seem not idle.")
        {
            optJiggling,
            optMinimized,
            optMode,
            optRandom,
            optPeriod,
            optDistance,
            optSettings
        };

    // Replace default help action with our spaced help action.
    var ha = (from o in rootCommand.Options
              where o is HelpOption
              select o).First();
    ha.Action = new SpacedHelpAction ((HelpAction)ha.Action!);

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
}