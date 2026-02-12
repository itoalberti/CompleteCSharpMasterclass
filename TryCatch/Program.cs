using System.Diagnostics;

try
{
    Console.WriteLine($"Type in the first number:");
    int a = int.Parse(Console.ReadLine());
    Console.WriteLine($"Type in the second number:");
    int b = int.Parse(Console.ReadLine());
    Console.WriteLine($"Result N1/N2 = {a / b}");
}
// catch (DivideByZeroException ex)
// {
//     Console.WriteLine($"IT'S IMPOSSIBLE TO DIVIDE BY ZERO!\n{ex}");
// }
catch (FormatException ex)
{
    Console.WriteLine($"YOU MUST TYPE NUMBERS TO PERFORM A CALCULATION\n{ex.Message}");
}
finally
{
    Console.WriteLine($"This line always executes, regardless of the errors");
}
