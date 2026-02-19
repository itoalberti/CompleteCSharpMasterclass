public static class Logger
{
    private static string _path = "logs.txt";

    public static void Log(string message) =>
        File.AppendAllText(
            _path,
            $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}: {message}{Environment.NewLine}"
        );
}
