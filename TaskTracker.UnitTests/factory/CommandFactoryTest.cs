using Moq;
using TaskTracker.Factory;
using TaskTracker.Commands;
using TaskTracker.Services;

namespace TaskTracker.UnitTests.Factory;

public class CommandFactoryTests
{
  [Fact]
  public void GetCommand_WithAddCommand_ReturnsAddCommand()
  {
    // Arrange
    var mockTaskTracker = new Mock<ITaskTracker>();
    var commandFactory = new CommandFactory(mockTaskTracker.Object);

    // Act
    ICommand? command = commandFactory.GetCommand("add");

    // Assert
    Assert.IsType<AddCommand>(command);
  }

  [Fact]
  public void GetCommand_WithInvalidCommand_ReturnsNull()
  {
    // Arrange
    var mockTaskTracker = new Mock<ITaskTracker>();
    var commandFactory = new CommandFactory(mockTaskTracker.Object);

    // Act
    ICommand? command = commandFactory.GetCommand("invalid");

    // Assert
    Assert.Null(command);
  }
}