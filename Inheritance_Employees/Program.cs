// Employee bernie = new Employee("Bernie", 36, "Sales Representative", 1100);
Manager jeremiah = new Manager("Jeremiah", 58, "Executive Manager", 851, 14);
jeremiah.DisplayManagerInfo();
Console.WriteLine(jeremiah.ToString());

public class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine($"==========Person constructor called==========");
    }

    public void DisplayPersonInfo() => Console.WriteLine($"Name: {Name} | Age: {Age}");
}

public class Employee : Person
{
    public string JobTitle { get; private set; }
    public int Id { get; private set; }

    public Employee(string name, int age, string jobtitle, int id)
        : base(name, age)
    {
        JobTitle = jobtitle;
        Id = id;
        Console.WriteLine($"==========Employee constructor called==========");
    }

    public void DisplayEmployeeInfo() => Console.WriteLine($"Job title: {JobTitle} | ID: {Id}");
}

public class Manager : Employee
{
    public int TeamSize { get; private set; }

    public Manager(string name, int age, string jobtitle, int id, int teamsize)
        : base(name, age, jobtitle, id)
    {
        TeamSize = teamsize;
    }

    public void DisplayManagerInfo() =>
        Console.WriteLine($"Job title: {JobTitle} | ID: {Id} | Team size: {TeamSize}");
}
