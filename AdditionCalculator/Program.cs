int n1 = 0;
int n2  = 0;

Console.WriteLine("Type in the first number");
string userInput=Console.ReadLine();
n1 =int.Parse(userInput);

Console.WriteLine("Type in the second number");
userInput=Console.ReadLine();
n2=int.Parse(userInput);

Console.WriteLine($"Sum {n1} + {n2} = {n1+n2}");


