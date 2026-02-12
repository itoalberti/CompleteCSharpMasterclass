Dog myDog = new();
myDog.Bark();
myDog.MakeSound();
myDog.Eat();

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
