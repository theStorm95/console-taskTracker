using TaskTracker.Commands;
using TaskTracker.Services;
using Moq;

namespace TaskTracker.UnitTests.Commands;

public class AddCommandTest
{
  [Fact]
  public void Execute_WhenCalled_WithLessThanTwoArgs_ShouldThrow()
  {
    var mockTaskTracker = new Mock<ITaskTracker>();
    var command = new AddCommand(mockTaskTracker.Object);
    Assert.Throws<ArgumentException>(() => command.Execute(["add"]));
  }

  [Fact]
  public void Execute_WhenCalled_WithMoreThanThreeArgs_ShouldThrow()
  {
    var mockTaskTracker = new Mock<ITaskTracker>();
    var command = new AddCommand(mockTaskTracker.Object);
    Assert.Throws<ArgumentException>(() => command.Execute(["add", "task", "priority", "extra"]));
  }

  [Fact]
  public void Execute_WhenCalled_ShouldAddTask()
  {
    var mockTaskTracker = new Mock<ITaskTracker>();
    var command = new AddCommand(mockTaskTracker.Object);
    command.Execute(["add", "task"]);
    mockTaskTracker.Verify(x => x.AddTask("task"), Times.Once);
  }
}