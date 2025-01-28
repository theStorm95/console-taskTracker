using TaskTracker.services;

namespace TaskTracker;

class Program
{
    static void Main(string[] args)
    {
        Database db = new FakeDb();
        TaskTracker taskService = new TaskTracker(db);

        ConsoleService consoleService = new ConsoleService(taskService);
        consoleService.Run(args);
    }
}
