using TaskTracker.Services;
using TaskTracker.Database;
using TaskTracker.Factory;

namespace TaskTracker;

class Program
{
    static void Main(string[] args)
    {
        IDatabase db = new FakeDb();
        var taskService = new TaskTrackerService(db);

        var commandFactory = new CommandFactory(taskService);
        var consoleService = new ConsoleService(commandFactory);

        consoleService.Run(args);
    }
}
