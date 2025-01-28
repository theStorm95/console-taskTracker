using System;

namespace TaskTracker.services;

public class ConsoleService(TaskTracker taskService)
{
  public void Run(string[] args)
  {
    if (args.Length == 0)
    {
      Console.WriteLine("Must provide a valid command. Type -h or --help for a list of valid commands");
      return;
    }

    string command = args[0];

  }
}
