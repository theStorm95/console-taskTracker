using TaskTracker.Factory;

namespace TaskTracker.Services;

public class ConsoleService(ICommandFactory commandFactory)
{
  public void Run(string[] args)
  {
    if (args.Length == 0)
    {
      Console.WriteLine("Must provide a valid command. Type -h or --help for a list of valid commands");
      return;
    }

    var command = args[0];

    if (command == "-h" || command == "--help")
    {
      Console.WriteLine("Available commands:");
      Console.WriteLine("  -h, --help: Display this help message");
      Console.WriteLine("  add: Add a new task");
      Console.WriteLine("  list: List all tasks");
      Console.WriteLine("  complete: Mark a task as complete");
      Console.WriteLine("  delete: Delete a task");
    }

    var commandInstance = commandFactory.GetCommand(command);

    if (commandInstance != null)
    {
      commandInstance.Execute(args);
    }
    else
    {
      Console.WriteLine("Must provide a valid command. Type -h or --help for a list of valid commands");
    }
  }
}
