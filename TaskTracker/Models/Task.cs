namespace TaskTracker.Models;

public class ToDoTask
{
  public required int id;
  public required string description;
  public string status = "in-progress";
  public string created_at = DateTime.Now.ToString();
  public string updated_at = DateTime.Now.ToString();

}