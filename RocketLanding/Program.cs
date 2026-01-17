using System.Security.Principal;

string[] rocket =
{
    "        |",
    "       / \\",
    "      / _ \\",
    "     |.o '.|",
    "     |'._.'|",
    "     |     |",
    "     |  °  |",
    "     |     |",
    "     |  °  |",
    "     |     |",
    "     |  °  |",
    "     |     |",
    "     |     |",
    "     |     |",
    "   ,'|  |  |`.",
    "  /  |  |  |  \\",
    "  |,-'--|--'-.|",
};
string[] flame = { "     /|||||\\", "    |||||||||", "     \\|||||/", "       \\|/", "        |" };
string ground = "_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_";

int windowHeight = rocket.Length + flame.Length;

// Printing processes
Console.Clear();

// 1) GROUND
Console.WriteLine(new string('\n', windowHeight));
Console.Write(ground);
Thread.Sleep(500);

Console.Clear();

// 2) GROUND AND FLAME
string printedString = "";
for (int i = 0; i < flame.Length; i++)
{
    Console.Clear();
    printedString = flame[flame.Length - 1 - i] + "\n" + printedString;
    Console.Write(printedString);
    Console.Write(new string('\n', windowHeight - i));
    Console.Write(ground);
    Thread.Sleep(500);
}

// 3) GROUND, FLAME AND ROCKET
for (int i = 0; i < rocket.Length; i++)
{
    Console.Clear();
    printedString = rocket[rocket.Length - 1 - i] + "\n" + printedString;
    Console.Write(printedString);
    Console.Write(new string('\n', windowHeight - 5 - i));
    Console.Write(ground);
    Thread.Sleep(500);
}

// 4) GROUND AND ROCKET
int lastIndex;
for (int i = 0; i < flame.Length + 1; i++)
{
    Console.Clear();
    lastIndex = printedString.LastIndexOf('\n');
    printedString = '\n' + printedString.Substring(0, lastIndex);
    Console.WriteLine(printedString);
    Console.WriteLine(ground);
    Thread.Sleep(500);
}
Console.Clear();
Console.WriteLine("-------ROCKET HAS LANDED!-------");
Console.WriteLine(printedString);
Console.WriteLine(ground);
