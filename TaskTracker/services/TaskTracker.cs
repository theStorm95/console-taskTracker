using TaskTracker.Database;
using TaskTracker.Models;

namespace TaskTracker.Services
{
  public interface ITaskTracker
  {
    void AddTask(string taskDescription);
  }

  public class TaskTrackerService(IDatabase db) : ITaskTracker
  {
    private int _taskId = 1;

    public void AddTask(string taskDescription)
    {
      var task = new ToDoTask
      {
        id = _taskId++,
        description = taskDescription
      };

      db.AddTask(task);
      Console.WriteLine($"Task added successfully (ID: {task.id})");
    }
  }
}