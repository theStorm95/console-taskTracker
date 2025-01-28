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

    switch (command)
    {
      case "-h":
      case "--help":
        Console.WriteLine("Available commands:");
        Console.WriteLine("  -h, --help: Display this help message");
        Console.WriteLine("  add: Add a new task");
        Console.WriteLine("  list: List all tasks");
        Console.WriteLine("  complete: Mark a task as complete");
        Console.WriteLine("  delete: Delete a task");
        break;
      default:
        Console.WriteLine("Must provide a valid command. Type -h or --help for a list of valid commands");
        break;
    }
  }
}
