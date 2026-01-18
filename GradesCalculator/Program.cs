int i = 0;
double sum = 0;
double grade = 0;

do
{
    Console.WriteLine($"Enter the grade of student {i + 1}. Type -1 to exit.");
    grade = double.Parse(Console.ReadLine());
    if (grade != -1)
    {
        sum += grade;
        i++;
    }
} while (grade != -1);

double avg = Math.Round(sum / i, 2);
Console.WriteLine($"The average grade of the class is {avg}");
