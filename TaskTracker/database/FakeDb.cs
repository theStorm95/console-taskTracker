using TaskTracker.Models;

namespace TaskTracker.Database;

public interface IDatabase
{
  void AddTask(ToDoTask task);
  // void RemoveTask(string taskId);
  // void UpdateTask(ToDoTask task);
  // List<TaskTracker.Task> getTasks();
}

public class FakeDb : IDatabase
{
  public void AddTask(ToDoTask task)
  {
    Console.WriteLine("Task added");
  }

  // public void RemoveTask(string taskId)
  // {
  //   Console.WriteLine("Task removed");
  // }

  // public void UpdateTask(Task task)
  // {
  //   Console.WriteLine("Task updated");
  // }
}