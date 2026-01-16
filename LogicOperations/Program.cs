Console.WriteLine("Enter your age:");
int age = int.Parse(Console.ReadLine());
bool isAdult = true;

switch (age)
{
    case >= 18:
        Console.WriteLine("You're old enough for whatever!");
        break;
    case < 18:
        Console.WriteLine("You're too young!");
        break;
    default:
        break;
}

string[] questions =
{
    "What is the capital of Armenia?",
    "In what year did the USSR collapse?",
    "Is Jesus Christ risen?",
};

string[] answers = { "Yerevan", "1991", "Yes" };

Console.WriteLine("Answer to the following questions:");
int score = 0;
for (int i = 0; i < questions.GetLength(0); i++)
{
    Console.WriteLine(questions[i]);
    var answer = Console.ReadLine();
    if (answer.Trim().ToLower() == answers[i].ToLower())
    {
        Console.WriteLine("--- Correct! ---");
        score++;
    }
    else
        Console.WriteLine("--- Wrong! ---");
}
Console.WriteLine($"You got {score} questions right.");

Console.WriteLine("---------------------------------");
Console.WriteLine("Type in a number (inputString):");
string inputString = Console.ReadLine();

// by default, all integers declared are =0
int n1;

// TryParse: tries to parse inputString to an int and store its value in n1. Yields True or False
var x = int.TryParse(inputString, out n1);
Console.WriteLine($"x = {x}");
bool isNumber = int.TryParse(inputString, out n1);
Console.WriteLine($"n1 = {n1}");
Console.WriteLine($"isNumber = {isNumber}");

bool test;
var y = bool.TryParse(inputString, out test);
Console.WriteLine($"y = {y}");
Console.WriteLine($"test = {test}");

float f = 1.23f;
Console.WriteLine($"f = {f}");
var z = float.TryParse(inputString, out f);
Console.WriteLine($"f = {f}");
Console.WriteLine($"z = {z}");

Console.WriteLine("Starting timer at time t=0.00s");
Thread.Sleep(2500);
Console.WriteLine("Finishing timer at time t=2.50s");
