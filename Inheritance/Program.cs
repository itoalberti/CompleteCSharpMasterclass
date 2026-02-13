Dog myDog = new();
myDog.Bark();
myDog.MakeSound();
myDog.Eat();

Student martin = new Student("Martin", 14, 9950, "Fifth grade");
martin.DisplayPersonInfo();

class Animal
{
    public void Eat() => Console.WriteLine($"Eating...");

    // to be able to override the base class method, it must be virtual
    public virtual void MakeSound() => Console.WriteLine($"Generic animal makes a generic sound.");
}

class Dog : Animal
{
    public void Bark() => Console.WriteLine($"Barking...");

    public override void MakeSound() => Console.WriteLine($"Generic sound now is a dog bark.");
}

public class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine($"Person constructor called");
    }

    public void DisplayPersonInfo()
    {
        Console.WriteLine($"========= PERSON DATA =========");
        Console.Write($"Name: {Name} | Age: {Age}");
    }
}

public class Student : Person
{
    public int StudentId { get; private set; }
    public string Grade { get; private set; }

    public Student(string name, int age, int studentId, string grade)
        : base(name, age)
    {
        StudentId = studentId;
        Grade = grade;
        Console.WriteLine($"Student constructor called");
    }
}
