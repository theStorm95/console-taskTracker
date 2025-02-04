using TaskTracker.Services;
using Moq;
using TaskTracker.Factory;

namespace TaskTracker.UnitTests.services;

public class ConsoleServiceTests
{
  [Fact]
  public void Run_NoArgs_PrintsErrorWithHelpPrompt()
  {
    // Arrange
    var mockFactory = new Mock<CommandFactory>(MockBehavior.Strict, new Mock<ITaskTracker>().Object);
    var consoleService = new ConsoleService(mockFactory.Object);
    var output = new StringWriter();
    Console.SetOut(output);

    // Act
    consoleService.Run([]);

    // Assert
    Assert.Equal("Must provide a valid command. Type -h or --help for a list of valid commands\n", output.ToString());
  }

  [Fact]
  public void Run_HelpCommand_PrintsHelpMessage()
  {
    // Arrange
    var mockFactory = new Mock<CommandFactory>(MockBehavior.Strict, new Mock<ITaskTracker>().Object);
    var consoleService = new ConsoleService(mockFactory.Object);
    var output = new StringWriter();
    Console.SetOut(output);

    // Act
    consoleService.Run(["-h"]);

    // Assert
    Assert.Contains("Available", output.ToString());
  }

  [Fact]
  public void Run_WithInvalidCommand_PrintsErrorWithHelpPrompt()
  {
    // Arrange
    var mockFactory = new Mock<CommandFactory>(MockBehavior.Strict, new Mock<ITaskTracker>().Object);
    var consoleService = new ConsoleService(mockFactory.Object);
    var output = new StringWriter();
    Console.SetOut(output);

    // Act
    consoleService.Run(["invalid"]);

    // Assert
    Assert.Equal("Must provide a valid command. Type -h or --help for a list of valid commands\n", output.ToString());
  }

  [Fact]
  public void Run_WithValidCommand_ExecutesCommand()
  {
    // Arrange
    var mockCommand = new Mock<ICommand>();
    var mockFactory = new Mock<ICommandFactory>();
    mockFactory.Setup(f => f.GetCommand("add")).Returns(mockCommand.Object);

    var consoleService = new ConsoleService(mockFactory.Object);

    // Act
    consoleService.Run(["add", "Test Command"]);

    // Assert
    mockCommand.Verify(cmd => cmd.Execute(It.IsAny<string[]>()), Times.Once);
  }
}