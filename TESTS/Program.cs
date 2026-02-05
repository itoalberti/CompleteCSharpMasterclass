using System;
using System.Collections.Generic;

Dictionary<string, Student> allStudents = new();

Student student1 = new(101, "Jonah", 9);
Student student2 = new(102, "Maria", 5);
Student student3 = new(103, "Earl", 0);
Student student4 = new(104, "Keith", 4);

allStudents.Add(student1.Name, student1);
allStudents.Add(student2.Name, student2);
allStudents.Add(student3.Name, student3);
allStudents.Add(student4.Name, student4);

PrintStudents(allStudents);

static void PrintStudents(Dictionary<string, Student> students)
{
    foreach (var student in students.Values)
        Console.WriteLine($"Name: {student.Name}, Id: {student.Id}, Grade: {student.Grade}");
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Grade { get; set; }

    public Student(int id, string name, int grade)
    {
        Id = id;
        Name = name;
        Grade = grade;
    }
}
