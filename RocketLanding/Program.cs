string[] rocket =
{
    "ROCKET 0",
    "ROCKET 1",
    "ROCKET 2",
    "ROCKET 3",
    "ROCKET 4",
    "ROCKET 5",
    "ROCKET 6",
    "ROCKET 7",
    "ROCKET 8",
    "ROCKET 9",
};

// {
//     "        |",
//     "       / \\",
//     "      / _ \\",
//     "     |.o '.|",
//     "     |'._.'|",
//     "     |     |",
//     "   ,'|  |  |`.",
//     "  /  |  |  |  \\",
//     "  |,-'--|--'-.|",
// };

// string[] flame = { "	   /|||||\\", "    |||||||||", "     \\|||||/", "       \\|/", "        |" };
string[] flame = { "FLAME 0", "FLAME 1", "FLAME 2", "FLAME 3" };
string ground = "_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_\\|/_";

int windowHeight = rocket.Length + flame.Length;

// Printing processes
Console.Clear();

// 1) GROUND
Console.WriteLine(new string('\n', windowHeight));
Console.Write(ground);
Thread.Sleep(1000);

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
    Thread.Sleep(1000);
}

// 3) GROUND, FLAME AND ROCKET
for (int i = 0; i < rocket.Length; i++)
{
    Console.Clear();
    printedString = rocket[rocket.Length - 1 - i] + "\n" + printedString;
    Console.Write(printedString);
    Console.Write(new string('\n', windowHeight - 4 - i));
    Console.Write(ground);
    Thread.Sleep(1000);
}
Console.WriteLine(printedString.TrimEnd('\n'));

// 4) GROUND AND ROCKET
// for (int i = 0; i < flame.Length; i++)
// {
//     // Console.Clear();
//     printedString = printedString.TrimEnd('\n');
//     printedString = '\n' + printedString;
//     Console.WriteLine(printedString);
//     // Console.WriteLine(new string('\n', windowHeight - i - 1));
//     // Console.WriteLine(ground);
// }
