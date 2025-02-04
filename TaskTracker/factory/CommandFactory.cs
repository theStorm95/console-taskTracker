using TaskTracker.Commands;
using TaskTracker.Services;

namespace TaskTracker.Factory;

public interface ICommand
{
  void Execute(string[] args);
}

public interface ICommandFactory
{
  ICommand? GetCommand(string command);
}

public class CommandFactory : ICommandFactory
{
  private readonly Dictionary<string, ICommand> _commands;

  public CommandFactory(ITaskTracker taskTracker)
  {
    _commands = new Dictionary<string, ICommand>
    {
      ["add"] = new AddCommand(taskTracker),
    };
  }

  public ICommand? GetCommand(string command)
  {
    return _commands.TryGetValue(command, out var cmd) ? cmd : null;
  }
}