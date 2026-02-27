using System;
using System.CommandLine;
using System.CommandLine.Help;
using System.CommandLine.Invocation;

namespace ArkaneSystems.MouseJiggler;

/// <summary>
/// Provides a command-line help action that displays a blank line before the standard help output.
/// </summary>
/// <remarks>This is used to clear up the spacing issue created when attaching to the parent console.</remarks>
internal class SpacedHelpAction : SynchronousCommandLineAction
{
  private readonly HelpAction _defaultHelp;

  public SpacedHelpAction (HelpAction defaultHelp) => this._defaultHelp = defaultHelp;

  public override int Invoke (ParseResult parseResult)
  {
    Console.WriteLine ("\n");

    int result = this._defaultHelp.Invoke (parseResult);

    return result;
  }
}
