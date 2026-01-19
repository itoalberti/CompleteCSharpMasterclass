using System.Security.Cryptography.X509Certificates;

namespace DraftOldStyle;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of students whose grades  you want to input:");
        int numberOfStudents = int.Parse(Console.ReadLine());
        // string[] subjects = ["Arts", "Biology", "Chemistry", "English", "Mathematics"];
        var classGrades = new Dictionary<string, List<double>>()
        {
            { "Arts", new List<double>() },
            { "Biology", new List<double>() },
            { "Chemistry", new List<double>() },
            { "English", new List<double>() },
            { "Mathematics", new List<double>() },
        };

        foreach (var subject in classGrades.Keys)
        {
            Console.WriteLine($"----- STUDENTS' GRADES IN {subject.ToUpper()} ----- ");
            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine($"Grade of student {i + 1}:");
                double grade = double.Parse(Console.ReadLine());
                classGrades[subject].Add(grade);
            }
        }
    }
}
