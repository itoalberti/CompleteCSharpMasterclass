using CRUDLayers.Models;
using CRUDLayers.ProductServices;
using CRUDLayers.Repositories;

public class Menu
{
    private readonly ProductController _controller;

    public Menu(ProductController controller) => _controller = controller;

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine($"\n===== 🍎🥦🥩 BERNIE'S BEST GROCERIES 🧀🍗🥕 =====");
            Console.WriteLine($"Type in the option you want:");
            Console.WriteLine($"1) Add a new product");
            Console.WriteLine($"2) List all products");
            Console.WriteLine($"3) Find a product by its ID");
            Console.WriteLine($"4) Update a product");
            Console.WriteLine($"5) Delete a product");
            Console.WriteLine($"0) Exit program");
            string option = Console.ReadLine().Trim();

            // ProductRepository repository = new ProductRepository();
            // ProductService service = new ProductService(repository);
            // ProductController controller = new ProductController(service);

            try
            {
                switch (option)
                {
                    case "1":
                        CreateProduct();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "0":
                        Console.WriteLine($"🛑 SYSTEM CLOSED 🛑");
                        return;
                    default:
                        Console.WriteLine($"DEFAULT");
                        return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }
    }

    public void CreateProduct()
    {
        Console.WriteLine($"\nType in the name of the product:");
        string name = Console.ReadLine().Trim();
        Console.WriteLine($"\nType in the price in $:");
        double price = double.Parse(Console.ReadLine());
        Console.WriteLine($"\nType in the quantity in stock:");
        int qty = int.Parse(Console.ReadLine());
        _controller.CreateProduct(name, price, qty);
        Console.WriteLine($"\n✅ PRODUCT CREATED SUCCESSFULLY! ✅");
    }
}
