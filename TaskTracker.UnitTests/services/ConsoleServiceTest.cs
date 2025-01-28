using System.Data.Common;
using TaskTracker.services;

namespace TaskTracker.UnitTests;

public class ConsoleServiceTests
{
  [Fact]
  public void Run_NoArgs_PrintsErrorWithHelpPrompt()
  {
    // Arrange
    Database db = new FakeDb();
    TaskTracker taskService = new TaskTracker(db);
    ConsoleService consoleService = new ConsoleService(taskService);
    var output = new StringWriter();
    Console.SetOut(output);

    // Act
    consoleService.Run([]);

    // Assert
    Assert.Equal("Must provide a valid command. Type -h or --help for a list of valid commands\n", output.ToString());
  }

  [Fact]
  public void Run_WithInvalidCommand_PrintsErrorWithHelpPrompt()
  {
    // Arrange
    Database db = new FakeDb();
    TaskTracker taskService = new TaskTracker(db);
    ConsoleService consoleService = new ConsoleService(taskService);
    var output = new StringWriter();
    Console.SetOut(output);

    // Act
    consoleService.Run(["invalid"]);

    // Assert
    Assert.Equal("Must provide a valid command. Type -h or --help for a list of valid commands\n", output.ToString());
  }

  [Fact]
  public void Run_HelpCommand_PrintsHelpMessage()
  {
    // Arrange
    Database db = new FakeDb();
    TaskTracker taskService = new TaskTracker(db);
    ConsoleService consoleService = new ConsoleService(taskService);
    var output = new StringWriter();
    Console.SetOut(output);

    // Act
    consoleService.Run(["-h"]);

    // Assert
    Assert.Equal("Available commands:\n  -h, --help: Display this help message\n  add: Add a new task\n  list: List all tasks\n  complete: Mark a task as complete\n  delete: Delete a task\n", output.ToString());
  }
}