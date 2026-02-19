// Point p1 = new(2, 6);
// p1.DisplayPoint();

// Point p2;
// p2.X = 10;
// p2.Y = 12;
// p2.DisplayPoint();

// public struct Point
// {
//     // public double X { get; set; }
//     // public double Y { get; set; }

//     public double X;
//     public double Y;

//     public Point(double x, double y)
//     {
//         X = x;
//         Y = Y;
//     }

//     public void DisplayPoint() => Console.WriteLine($"Point: ({X}, {Y})");
// }

foreach (Months month in Enum.GetValues(typeof(Months)))
    Console.WriteLine($"Month {(int)(month)}: {typeof(Months)}");

Point p1 = new(0, 0);
Point p2 = new(5, 12);
Console.WriteLine($"Distance between points 1 and 2: {p1.DistanceTo(p2):F3}");

DateTime myBirthday = new DateTime(1914, 06, 28);
Console.WriteLine($"My birthday is {myBirthday:dd/MM/yyyy}");

public struct Point
{
    private double X { get; }
    private double Y { get; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double DistanceTo(Point p2)
    {
        double dx = p2.X - X;
        double dy = p2.Y - Y;

        return Math.Sqrt(dx * dx + dy * dy);
    }
}

enum Months
{
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    Semptember,
    October,
    November,
    December,
}
