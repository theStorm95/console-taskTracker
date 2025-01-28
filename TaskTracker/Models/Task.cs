namespace TaskTracker
{
  public class Task
  {
    public required string id;
    public required string description;
    public string status = "in-progress";
    public string created_at = DateTime.Now.ToString();
    public string updated_at = DateTime.Now.ToString();
  }
}