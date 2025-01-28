using System.Data.Common;

namespace TaskTracker
{
  public class TaskTracker
  {
    private readonly Database _db;

    public TaskTracker(Database db)
    {
      _db = db;
    }

    public string AddTask(Task task)
    {
      return "Task added " + task.description;
    }
  }
}