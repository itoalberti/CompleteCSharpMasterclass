using System.Drawing;
using System.Globalization;
using System.Net.WebSockets;
using System.Security.Authentication.ExtendedProtection;
using CRUDLayers.Models;
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
                        ListProducts();
                        break;
                    case "3":
                        FindByID();
                        break;
                    case "4":
                        UpdateProduct();
                        break;
                    case "5":
                        DeleteProduct();
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
                    $"\n=================ERROR=================\n{e}",
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

    public void ListProducts() => _controller.ListProducts();

    private bool FindByID()
    {
        while (true)
        {
            Console.Write($"\nType in the ID of the product: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var productFound = _controller.FindByID(id);
                ColorChanges.WriteInColor(
                    $"\n______________✔️ PRODUCT WAS FOUND ✔️_______________",
                    ConsoleColor.Green
                );
                ColorChanges.WriteInColor(
                    $"\n  ID  | NAME                  | PRICE [$] | QUANTITY\n",
                    ConsoleColor.DarkBlue
                );
                Console.WriteLine(
                    $"{productFound.Id, 5} | {productFound.Name, -21} | {productFound.Price, -9} | {productFound.Qty, -8}"
                );
                return false;
            }
            throw new ArgumentException($"\n⚠️ INVALID ID ⚠️\n");
        }
    }

    public void UpdateProduct()
    {
        Console.Write($"Type in the ID of the product you want to edit: ");
        if (int.TryParse(Console.ReadLine(), out int id) && id > 0)
        {
            Console.Write($"Type in the new name: ");
            string newName = Console.ReadLine();
            Console.Write($"Type in the new price: ");
            double.TryParse(Console.ReadLine(), out double newPrice);
            Console.Write($"Type in the new quantity: ");
            int newQty = int.Parse(Console.ReadLine());
            _controller.UpdateProduct(id, newName, newPrice, newQty);
            ColorChanges.WriteInColor(
                $"\n✔️ PRODUCT UPDATED SUCCESSFULLY! ✔️\n",
                ConsoleColor.Green
            );
        }
        else
            throw new ArgumentException("⚠️ INVALID ID ⚠️");
    }

    private bool DeleteProduct()
    {
        while (true)
        {
            Console.Write($"\nType in the ID of the product you want to remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                string productName = _controller.FindByID(id).Name;
                _controller.RemoveProduct(id);
                ColorChanges.WriteInColor(
                    $"\n✔️ PRODUCT [{id} - {productName.ToUpper()}] REMOVED SUCCESSFULLY! ✔️\n",
                    ConsoleColor.DarkGreen
                );
                return false;
            }
            ColorChanges.WriteInColor($"\n⚠️ INVALID ID ⚠️\n", ConsoleColor.Yellow);
        }
    }
}
