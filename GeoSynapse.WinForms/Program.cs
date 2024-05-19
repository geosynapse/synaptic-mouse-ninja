using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Threading;
using System.Windows.Forms;
using GeoSynapse.Poc.Properties;
using GeoSynapse.Utils;
using JetBrains.Annotations;
using PInvoke;

namespace GeoSynapse.Poc
{
  [PublicAPI]
  public static class Program
  {
    [STAThread]
    public static int Main(string[] args)
    {
      // Attach to the parent process's console so we can display help, version information, and command-line errors.
      Kernel32.AttachConsole(dwProcessId: WinFormsTickle.AttachParentProcess);

      var instance = new Mutex(initiallyOwned: false, name: "single instance: GeoSynapse.Poc");

      try
      {
        if (instance.WaitOne(millisecondsTimeout: 0))

        // Parse arguments and do the appropriate thing.
        {
          return Program.GetCommandLineParser().Invoke(args: args);
        }
        else
        {
          Console.WriteLine(value: "Geo Synapse is already running. Aborting.");

          return 1;
        }
      }
      finally
      {
        instance.Close();

        // Detach from the parent console.
        Kernel32.FreeConsole();
      }
    }

    private static int RootHandler(bool tickle, bool minimized, bool zen, int seconds)
    {
      // Prepare Windows Forms to run the application.
      Application.SetHighDpiMode(highDpiMode: HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(defaultValue: false);

      // Run the application.
      var mainForm = new MainForm(geoOnStartup: tickle,
                                   minimizeOnStartup: minimized,
                                   zenTickleEnabled: zen,
                                   ticklePeriod: seconds);

      Application.Run(mainForm: mainForm);

      return 0;
    }

    private static RootCommand GetCommandLineParser()
    {
      // Create root command.
      var rootCommand = new RootCommand
      {
        Description = "Invokes geo synapse events",
        Handler =
                                CommandHandler.Create(action: new Func<bool, bool, bool, int, int>(Program.RootHandler)),
      };

      // -j --tickle
      Option optTickling = new(aliases: new[] { "--geo", "-j", }, description: "Geo enable.");
      optTickling.Argument = new Argument<bool>();
      optTickling.Argument.SetDefaultValue(value: false);
      rootCommand.AddOption(option: optTickling);

      // -m --minimized
      Option optMinimized = new(aliases: new[] { "--minimized", "-m", }, description: "Start minimized.");
      optMinimized.Argument = new Argument<bool>();
      optMinimized.Argument.SetDefaultValue(value: Settings.Default.MinimizeOnStartup);
      rootCommand.AddOption(option: optMinimized);

      // -z --zen
      Option optZen = new(aliases: new[] { "--zen", "-z", }, description: "Start with zen (invisible) geo enabled.");
      optZen.Argument = new Argument<bool>();
      optZen.Argument.SetDefaultValue(value: Settings.Default.ZenTickle);
      rootCommand.AddOption(option: optZen);

      // -s 60 --seconds=60
      Option optPeriod = new(aliases: new[] { "--seconds", "-s", },
                              description: "Set number of seconds for the geo interval.");

      optPeriod.Argument = new Argument<int>();

      optPeriod.AddValidator(validate: p => p.GetValueOrDefault<int>() < 1
                                                 ? "Period cannot be shorter than 1 second."
                                                 : null);

      optPeriod.AddValidator(validate: p => p.GetValueOrDefault<int>() > 60
                                                 ? "Period cannot be longer than 60 seconds."
                                                 : null);

      optPeriod.Argument.SetDefaultValue(value: Settings.Default.TicklePeriod);
      rootCommand.AddOption(option: optPeriod);

      return rootCommand;
    }
  }
}
