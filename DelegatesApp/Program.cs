using System.Net.WebSockets;

static void SuccessMessage(string msg) =>
    Console.WriteLine($"PROCESS EXECUTED SUCCESSFULLY: {msg}");

static void ErrorMessage(string msg) => Console.WriteLine($"PROCESS FAILED: {msg}");

static int Sum(int a) => a + 1000;

static int Subtraction(int a) => a - 50;

static void InvokeSafely(LogHandler logHandler, string msg) { }
MyInt myInt = Sum;
Console.WriteLine(myInt(1));

myInt = Subtraction;
Console.WriteLine(myInt(999));

MyDelegate myDelegate = SuccessMessage;
myDelegate("Database Backup");

myDelegate = ErrorMessage;
myDelegate("Kubernetes update");

DiscountCalculator price = ApplyBlackFridayDiscount;
Console.WriteLine($"The price with Black Friday discount is {price(200)}");

price = ApplyVIPDiscount;
Console.WriteLine($"The price with VIP discount is {price(200)}");

price = ApplyRegularDiscount;
Console.WriteLine($"The price with regular discount is {price(200)}");

double ApplyBlackFridayDiscount(double price) => 0.7 * price;
double ApplyVIPDiscount(double price) => 0.72 * price;
double ApplyRegularDiscount(double price) => 0.75 * price;

Logger logger = new Logger();
LogHandler logHandler = logger.LogToConsole;

logHandler("Logging to console");
logHandler += logger.LogToFile; // → multiple methods assigned to this delegate (logToConsole and logToFile)
logHandler("Log this information");
logHandler("New message in both console and file");

public delegate void MyDelegate(string msg);
public delegate int MyInt(int n);
public delegate double DiscountCalculator(double price);
public delegate void LogHandler(string msg);

public class Logger
{
    public void LogToConsole(string msg)
    {
        Console.WriteLine($"Console Log: {msg}");
    }

    public void LogToFile(string msg)
    {
        Console.WriteLine($"File Log: {msg}");
    }
}
