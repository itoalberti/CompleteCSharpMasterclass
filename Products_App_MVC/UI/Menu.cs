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
            Console.WriteLine($"6) Place an order for a product");
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
                    // case "6":
                    // PlaceOrder();
                    // break;
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
        string price = Console.ReadLine();
        Console.Write($"\nType in the quantity in stock: ");
        string qty = Console.ReadLine();

        _controller.CreateProduct(name, price, qty);
        ColorChanges.WriteInColor(
            $"\n✔️ PRODUCT CREATED SUCCESSFULLY! ✔️\n",
            ConsoleColor.DarkGreen
        );
    }

    public void ListProducts()
    {
        var allProducts = _controller.ListProducts();
        ColorChanges.WriteInColor(
            $"\n  ID  | NAME                  | PRICE [$] | QUANTITY \n",
            ConsoleColor.DarkBlue
        );
        foreach (var product in allProducts)
            Console.WriteLine(
                $"{product.Id, 5} | {product.Name, -21} | {product.Price, -9} | {product.Qty, -8}"
            );
    }

    private void FindByID()
    {
        Console.Write($"\nType in the ID of the product: ");
        string id = Console.ReadLine();
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
    }

    public void UpdateProduct()
    {
        Console.Write($"Type in the ID of the product you want to edit: ");
        string id = Console.ReadLine();
        var product = _controller.FindByID(id);
        Console.Write($"Type in the new name: ");
        string newName = Console.ReadLine();
        Console.Write($"Type in the new price: ");
        string newPrice = Console.ReadLine();
        Console.Write($"Type in the new quantity: ");
        string newQty = Console.ReadLine();
        _controller.UpdateProduct(id, newName, newPrice, newQty);
        ColorChanges.WriteInColor($"\n✔️ PRODUCT UPDATED SUCCESSFULLY! ✔️\n", ConsoleColor.Green);
    }

    private void DeleteProduct()
    {
        Console.Write($"\nType in the ID of the product you want to remove: ");
        string id = Console.ReadLine();
        string productName = _controller.FindByID(id).Name;
        _controller.RemoveProduct(id);
        ColorChanges.WriteInColor(
            $"\n✔️ PRODUCT [{id} - {productName.ToUpper()}] REMOVED SUCCESSFULLY! ✔️\n",
            ConsoleColor.DarkGreen
        );
    }

    // private void PlaceOrder()
    // {
    //     Console.WriteLine($"Type in the ID of the product of which you want to place your order: ");
    //     string id = Console.ReadLine();
    //     var product = _controller.FindByID(id);
    //     Console.WriteLine($"How many units of {product.Name} will you buy?");
    //     if (!int.TryParse(Console.ReadLine(), out int parsedQty) || parsedQty <= 0)
    //         throw new ArgumentException("🚫 PRODUCT QUANTITY MUST BE A POSITIVE INTEGER 🚫 ");
    // }
}
