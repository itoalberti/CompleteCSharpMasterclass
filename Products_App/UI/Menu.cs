using System.Globalization;
using System.Security.Authentication.ExtendedProtection;
using CRUDLayers.ProductServices;
using CRUDLayers.Repositories;
using CRUDLayers.UI;

public class Menu
{
    private readonly ProductController _controller;

    public Menu(ProductController controller)
    {
        _controller = controller;
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine($"");
            ColorChanges.WriteInColor(
                "\n===== 🍎🥦🥩 BERNIE'S BEST GROCERIES 🧀🍗🥕 =====\n",
                ConsoleColor.Green
            );
            Console.WriteLine($"1) Add a new product");
            Console.WriteLine($"2) List all products");
            Console.WriteLine($"3) Find a product by its ID");
            Console.WriteLine($"4) Update a product");
            Console.WriteLine($"5) Delete a product");
            Console.WriteLine($"0) Exit program");
            Console.Write($"Type in the option you want: ");
            string option = Console.ReadLine().Trim();

            try
            {
                switch (option)
                {
                    case "1":
                        CreateProduct();
                        break;
                    case "2":
                        GetAll();
                        break;
                    case "3":
                        // GetByID();
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "0":
                        ColorChanges.WriteInColor($"\n🛑 SYSTEM CLOSED 🛑\n\n", ConsoleColor.Red);

                        return;
                    default:
                        ColorChanges.WriteInColor(
                            $"\n⚠️ THIS OPTION IS NOT AVAILABLE. CHOOSE ONE FROM THE LIST ⚠️\n",
                            ConsoleColor.Yellow
                        );
                        break;
                }
            }
            catch (Exception e)
            {
                ColorChanges.WriteInColor(
                    $"\n============ERROR============\n{e}",
                    ConsoleColor.Red
                );
            }
        }
    }

    public void CreateProduct()
    {
        Console.Write($"\nType in the name of the product: ");
        string name = Console.ReadLine().Trim();
        Console.Write($"\nType in the price in $: ");
        double price = double.Parse(Console.ReadLine());
        Console.Write($"\nType in the quantity in stock: ");
        int qty = int.Parse(Console.ReadLine());
        ColorChanges.WriteInColor(
            $"\n✔️ PRODUCT CREATED SUCCESSFULLY! ✔️\n",
            ConsoleColor.DarkGreen
        );
        _controller.CreateProduct(name, price, qty);
    }

    public void GetAll() => _controller.ListProducts();
}
