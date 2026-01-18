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

int[,] array2D =
{
    { 11, 12, 13 },
    { 21, 22, 23 },
    { 31, 32, 33 },
    { 41, 42, 43 },
};

// 3D array with 4 blocks, 2 lines per block and 3 elements per line
int[,,] array3D =
{
    {
        { 1, 2, 3 },
        { 4, 5, 6 },
    },
    {
        { 7, 8, 9 },
        { 10, 11, 12 },
    },
    {
        { 13, 14, 15 },
        { 16, 17, 18 },
    },
    {
        { 19, 20, 21 },
        { 22, 23, 24 },
    },
};
