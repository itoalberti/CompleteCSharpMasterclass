static int Factorial(int n)
{
    if (n == 0 || n == 1)
    {
        return 1;
    }
    else
    {
        return n * Factorial(n - 1);
    }
}

Console.WriteLine(Factorial(5));
Console.WriteLine(Factorial(6));
Console.WriteLine(Factorial(15));
