#region header

// MouseJiggler - Program.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/22 4:12 PM.
// Updates by: Dimitris Panokostas (midwan)

#endregion

#region using

using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Threading;
using System.Windows.Forms;
using ArkaneSystems.MouseJiggler.Properties;
using JetBrains.Annotations;
using Windows.Win32;

#endregion

namespace ArkaneSystems.MouseJiggler;

[PublicAPI]
public static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    public static int Main(string[] args)
    {
        // Attach to the parent process's console so we can display help, version information, and command-line errors.
        PInvoke.AttachConsole(Helpers.AttachParentProcess);

        // Ensure that we are the only instance of the Mouse Jiggler currently running.
        var instance = new Mutex(false, "single instance: ArkaneSystems.MouseJiggler");

        try
        {
            if (instance.WaitOne(0))

                // Parse arguments and do the appropriate thing.
            {
                return GetCommandLineParser().Invoke(args);
            }
            else
            {
                Console.WriteLine(@"Mouse Jiggler is already running. Aborting.");

                return 1;
            }
        }
        finally
        {
            instance.Close();

            // Detach from the parent console.
            PInvoke.FreeConsole();
        }
    }

    private static int RootHandler(bool jiggle, bool minimized, bool zen, int seconds)
    {
        // Prepare Windows Forms to run the application.
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Run the application.
        var mainForm = new MainForm(jiggle,
            minimized,
            zen,
            seconds);

        Application.Run(mainForm);

        return 0;
    }

    private static RootCommand GetCommandLineParser()
    {
        // Create root command.
        var rootCommand = new RootCommand
        {
            Description = "Virtually jiggles the mouse, making the computer seem not idle.",
            Handler =
                CommandHandler.Create(new Func<bool, bool, bool, int, int>(RootHandler))
        };

        // -j --jiggle
        Option optJiggling = new(["--jiggle", "-j"], "Start with jiggling enabled.")
        {
            Argument = new Argument<bool>(() => false)
        };
        rootCommand.AddOption(optJiggling);

        // -m --minimized
        Option optMinimized = new(["--minimized", "-m"], "Start minimized.")
        {
            Argument = new Argument<bool>(() => Settings.Default.MinimizeOnStartup)
        };
        rootCommand.AddOption(optMinimized);

        // -z --zen
        Option optZen = new(["--zen", "-z"], "Start with zen (invisible) jiggling enabled.")
        {
            Argument = new Argument<bool>(() => Settings.Default.ZenJiggle)
        };
        rootCommand.AddOption(optZen);

        // -s:60 --seconds:60
        var optPeriod = new Option<int>(["--seconds", "-s"], "Set X number of seconds for the jiggle interval.")
        {
            Argument = new Argument<int>(() => Settings.Default.JigglePeriod)
        };
        optPeriod.AddValidator(p => p.GetValueOrDefault<int>() < 1 ? "Period cannot be shorter than 1 second." : null);
        optPeriod.AddValidator(p =>
            p.GetValueOrDefault<int>() > 10800 ? "Period cannot be longer than 10800 seconds." : null);
        rootCommand.AddOption(optPeriod);

        // Build the command line parser.
        return rootCommand;
    }
}