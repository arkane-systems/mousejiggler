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
    _ = PInvoke.AttachConsole (Helpers.AttachParentProcess);
    Program.AttachedToConsole = true;

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

  private static int RootHandler (bool jiggle, bool minimized, bool zen, bool random, bool settings, int seconds)
  {
    // Prepare Windows Forms to run the application.
    _ = Application.SetHighDpiMode (HighDpiMode.SystemAware);
    Application.EnableVisualStyles ();
    Application.SetCompatibleTextRenderingDefault (false);

    // Detach from console before running the application, as we won't be needing it anymore.
    _ = PInvoke.FreeConsole ();
    Program.AttachedToConsole = false;

    // Run the application.
    var mainForm = new MainForm(jiggle,
            minimized,
            zen,
            random,
            seconds,
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

    // -z --zen
    var optZen = new Option<bool>("--zen", "-z")
    {
      Description = "Start with zen (invisible) jiggling enabled.",
      DefaultValueFactory = _ => Settings.Default.ZenJiggle
    };

    // -r --random
    var optRandom = new Option<bool>("--random", "-r")
    {
      Description = "Start with random timer enabled.",
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
            optZen,
            optRandom,
            optPeriod,
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
      var zen = parseResult.GetValue(optZen);
      var random = parseResult.GetValue(optRandom);
      var settings = parseResult.GetValue(optSettings);
      var seconds = parseResult.GetValue(optPeriod);

      return RootHandler (jiggle, minimized, zen, random, settings, seconds);
    });

    // Build the command line parser.
    return rootCommand;
  }
}