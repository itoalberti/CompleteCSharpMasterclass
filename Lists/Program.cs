using System.Drawing;

namespace Lists;

class Program
{
    static void Main(string[] args)
    {
        List<string> colors = ["green", "yellow", "red", "yellow", "brown", "black", "yellow"];
        colors.Add("purple");

        foreach (string color in colors)
            Console.WriteLine($"{color}");

        Console.WriteLine($"TO REMOVE ALL YELLOWS FROM LIST");
        // To delete all repeated items in the list
        while (colors.Remove("yellow") == true)
            colors.Remove("yellow");

        Console.WriteLine($"AFTER REMOVING ALL YELLOWS");
        foreach (string color in colors)
            Console.WriteLine($"{color}");

        List<Student> students = new List<Student>
        {
            new Student { Name = "Amber", Grade = 4 },
            new Student { Name = "Charlene", Grade = 10 },
            new Student { Name = "Donovan", Grade = 7 },
            new Student { Name = "Earl", Grade = 5 },
            new Student { Name = "Bernie", Grade = 0 },
        };

        Predicate<Student> isApproved = s => s.Grade >= 5;

        // Sorting students alphabetically
        students.Sort((a, b) => a.Name.CompareTo(b.Name));

        Console.WriteLine($"STUDENTS SORTED BY NAME");
        foreach (Student s in students)
            Console.WriteLine($"{s.Name.PadRight(10)} - Grade: {s.Grade}");

        // Sorting students by grade (crescent)
        Console.WriteLine($"STUDENTS SORTED BY GRADE ");
        students.Sort((a, b) => a.Grade.CompareTo(b.Grade));
        // less efficient way:
        // students = students.OrderBy(s => s.Grade).ToList();
        foreach (var student in students)
            Console.WriteLine($"{student.Name.PadRight(10)} - Grade: {student.Grade}");

        // Filtering students by grade
        // List<Student> approvedStudents = students.FindAll(s => s.Grade >= 5);
        List<Student> approvedStudents = students.FindAll(isApproved);

        // Alternative way, same complexity but slightly less efficient
        // List<Student> approvedStudents = students.Where(s => s.Grade >= 5).ToList();
        Console.WriteLine($"APPROVED STUDENTS");
        foreach (Student student in approvedStudents)
            Console.WriteLine($"{student.Name.PadRight(10)} - Grade: {student.Grade}");
    }

    private class Student
    {
        public required string Name { get; set; }
        public int Grade { get; set; }
    }
}
