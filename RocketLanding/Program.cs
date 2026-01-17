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
string[] flame =
{
    "     /|||||\\",
    "    |||||||||",
    "     \\|||||/",
    "      \\|||/",
    "       \\|/",
    "        |",
};
string ground = "_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_";
int windowHeight = rocket.Length + flame.Length;
string printedString = "";
Console.Clear();

// PRINTING FUNCTIONS
void DrawGround()
{
    Console.Write(ground);
    Thread.Sleep(500);
}

void DrawScene(string[] element, int lineBreaks)
{
    for (int i = 0; i < element.Length; i++)
    {
        Console.Clear();
        printedString = element[element.Length - 1 - i] + "\n" + printedString;
        Console.Write(printedString);
        Console.Write(new string('\n', windowHeight - lineBreaks - i));
        DrawGround();
    }
}

// 1) GROUND
Console.WriteLine(new string('\n', windowHeight));
DrawGround();

// 2) GROUND AND FLAME
DrawScene(flame, 0);

// 3) GROUND, FLAME AND ROCKET
DrawScene(rocket, flame.Length);

// 4) GROUND AND ROCKET
int lastIndex;
for (int i = 0; i < flame.Length + 1; i++)
{
    Console.Clear();
    lastIndex = printedString.LastIndexOf('\n');
    printedString = '\n' + printedString.Substring(0, lastIndex);
    Console.WriteLine(printedString);
    DrawGround();
}
Console.Clear();
Console.WriteLine("-------ROCKET HAS LANDED!-------");
Console.WriteLine(printedString);
DrawGround();
