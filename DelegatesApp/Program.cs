string message = Console.ReadLine();
Logger logger = new();

LogHandler logToConsoleHandler = logger.LogToConsole;
LogHandler logToFileHandler = logger.LogToFile;

logToConsoleHandler($"Hello, {message}! Printing to console.");
logToFileHandler($"Hello, {message}! Now in txt file!");

public delegate void LogHandler(string msg);

public class Logger
{
    public void LogToConsole(string msg) => Console.WriteLine($"Console Log: {msg}");

    public void LogToFile(string msg) =>
        System.IO.File.AppendAllText("log.txt", $"File Log: {msg}\n");
}
