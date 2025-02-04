using TaskTracker.Factory;
using TaskTracker.Services;

namespace TaskTracker.Commands;

public class AddCommand(ITaskTracker taskTracker) : ICommand
{
  public void Execute(string[] args)
  {
    if (args.Length < 2 || args.Length > 3)
    {
      throw new ArgumentException("Invalid number of arguments. Usage: add <task> [<priority>]");
    }

    string task = args[1];

    taskTracker.AddTask(task);
  }
}
