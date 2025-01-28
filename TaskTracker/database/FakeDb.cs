public interface Database
{
  void AddTask(Task task);
  void RemoveTask(Task task);
  void UpdateTask(Task task);
  // List<TaskTracker.Task> getTasks();
}

public class FakeDb : Database
{
  public void AddTask(Task task)
  {
    Console.WriteLine("Task added");
  }

  public void RemoveTask(Task task)
  {
    Console.WriteLine("Task removed");
  }

  public void UpdateTask(Task task)
  {
    Console.WriteLine("Task updated");
  }
}