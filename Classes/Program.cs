// using System.Globalization;
using System;
using System.Globalization;
using System.Runtime.ConstrainedExecution;

namespace Classes;

class Program
{
    static void Main(string[] args)
    {
        // used for transforming strings into Title Case
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        Product.PrintMessage();

        Customer jebediah = new Customer("Jebediah", "34 Liberty Street", "55463241");
        Customer newCustomer = new Customer("Thomas");
        Console.WriteLine("Type in the customer's name:");
        newCustomer.Name = Console.ReadLine();
        Console.WriteLine("Type in the customer's address:");
        newCustomer.Address = Console.ReadLine();

        Person p = new Person();
        Person.User u = new Person.User(p, 3350);
        u.DisplayUserData();

        Customer customer1 = new Customer("Godinez"); // instantiated only with name because
        customer1.Address = "887 Lexington Avenue";
        customer1.SetDetails("Larry", "990 Manhattan St", "66512547");
        Console.WriteLine(
            $"Customer name: {customer1.Name}\nCustomer address: {customer1.Address}\nCustomer contact number: {customer1.ContactNumber}"
        );

        Product myProduct = new Product();
        myProduct.Name = "Soap";
        myProduct.Price = 3.55f;
        myProduct.HasStock = true;
        myProduct.Qty = 8;
        Console.WriteLine(Product.NumberOfProducts);
    }
}
