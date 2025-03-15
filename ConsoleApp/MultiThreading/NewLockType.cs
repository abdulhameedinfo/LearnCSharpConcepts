public class NewLockType
{
    public NewLockType()
    {
        var logger = new Logger("Log.txt");
        Parallel.For(1, 5, x =>
        {
            logger.Log($"Log entry from thread {x}");
        });
    }
}

public class Logger
{
    private readonly Lock _lock = new();
    private readonly string _lockFilePath;

    public Logger(string lockFilePath)
    {
        _lockFilePath = lockFilePath;
    }
    public void Log(string message)
    {
        lock (_lock)
        {
            System.Console.WriteLine($"{DateTime.Now}: {message}");
            System.Threading.Thread.Sleep(3000);
        }
        // using (_lock.EnterScope())
        // {
        // File.AppendAllText(_lockFilePath, $"{DateTime.Now}: {message} {Environment.NewLine}");
        // }
    }
}