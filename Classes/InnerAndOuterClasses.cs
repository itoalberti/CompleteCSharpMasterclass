using System;
using System.IO.Pipes;

public class Person
{
    private string name = "Some Name";
    private int age = 21;

    public class User
    {
        private Person person;
        private int userID;

        public User(Person person, int id)
        {
            this.person = person;
            this.userID = id;
        }

        public void DisplayUserData()
        {
            Console.WriteLine($"User name: {person.name}\nUser ID: {userID}");
        }
    }
}

// class Program
// {
//     static void Main()
//     {
//         Person joseph = new Person();
//         Person.Customer customer = new Person.Customer(joseph);
//         customer.DisplayPersonsData();
//     }
// }
