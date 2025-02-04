using Moq;
using TaskTracker.Services;
using TaskTracker.Database;
using TaskTracker.Models;

namespace TaskTracker.UnitTests.Services;

public class TaskTrackerTest
{
  [Fact]
  public void AddTask_Should_Call_Database_AddTask()
  {
    // Arrange
    var mockDatabase = new Mock<IDatabase>();
    var taskTracker = new TaskTrackerService(mockDatabase.Object);
    string taskDescription = "Test Task";

    // Act
    taskTracker.AddTask(taskDescription);

    // Assert
    mockDatabase.Verify(db => db.AddTask(It.IsAny<ToDoTask>()), Times.Once);
  }
}