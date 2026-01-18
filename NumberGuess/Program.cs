Random r = new Random();
int randomNumber = r.Next(0, 11);
Console.WriteLine("Guess a number from 0 to 10");
int guess = int.Parse(Console.ReadLine());

while (guess != randomNumber)
{
    Console.WriteLine("You guessed wrong! Guess again");
    guess = int.Parse(Console.ReadLine());
}
Console.WriteLine("Now you got it right!");
