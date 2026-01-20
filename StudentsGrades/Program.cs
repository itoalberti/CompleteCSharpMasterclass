using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;

namespace StudentsGrades;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of students whose grades  you want to input:");
        int numberOfStudents = int.Parse(Console.ReadLine());
        var classGrades = new Dictionary<string, List<double>>()
        {
            { "Arts", new List<double>() },
            { "Biology", new List<double>() },
            { "Chemistry", new List<double>() },
            { "English", new List<double>() },
            { "Mathematics", new List<double>() },
        };
        var avgGrades = new Dictionary<string, double>();

        foreach (var subject in classGrades.Keys)
        {
            Console.WriteLine($"----- STUDENTS' GRADES IN {subject.ToUpper()} ----- ");
            double sum = 0;
            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine($"Grade of student {i + 1}:");
                double grade = double.Parse(Console.ReadLine());
                classGrades[subject].Add(grade);
                sum += grade;
            }
            avgGrades[key: subject] = sum / numberOfStudents;
        }
        Console.WriteLine("GRADES SUMMARY");
        foreach (var item in classGrades)
        {
            Console.WriteLine($"{item.Key}: {string.Join(" | ", item.Value)}");
            Console.WriteLine($"Average grade of class in {item.Key}: {avgGrades[item.Key]:F2}");
        }
    }
}
