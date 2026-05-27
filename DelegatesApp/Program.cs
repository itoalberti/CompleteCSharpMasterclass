// Console.WriteLine($"Type in the message you want to log:");
// string message = Console.ReadLine();
// Logger logger = new();

// LogHandler logToConsoleHandler = logger.LogToConsole;
// LogHandler logToFileHandler = logger.LogToFile;

// logToConsoleHandler($"Hello, {message}! Printing to console.");
// logToFileHandler($"{DateTime.Now} : {message}");

// Area circleArea = new Circle().CircleArea;
// Console.WriteLine($"Area of this circle is {circleArea([5])}");

// // This delegate defines that every LogHandler must receive a string as parameter and return void
// public delegate void LogHandler(string msg);

// public class Logger
// {
//     public void LogToConsole(string msg) => Console.WriteLine($"Console Log: {msg}");

//     public void LogToFile(string msg) =>
//         System.IO.File.AppendAllText("log.txt", $"File Log: {msg}\n");
// }

// public delegate float Area(int[] dimensions);

// public class Circle
// {
//     public float Perimeneter(int radius) => (float)(Math.PI * 2 * radius);

//     public float CircleArea(int radius) => (float)(Math.PI * radius * radius);
// }

// public class Rectangle
// {
//     public int RectangleArea(int width, int height) => width * height;
// }

// public class Triangle
// {
//     public int TriangleArea(int width, int height) => width * height / 2;
// }

// List<Produto> produtos = new List<Produto>
// {
//     new Produto { Nome = "Teclado", Preco = 150 },
//     new Produto { Nome = "Mouse", Preco = 80 },
//     new Produto { Nome = "Monitor", Preco = 1200 },
//     new Produto { Nome = "Cabo HDMI", Preco = 30 },
// };

// // 3. O uso prático: Passamos a "regra" como se fosse um parâmetro
// Console.WriteLine("Produtos Baratos (menos de 100):");
// FiltrarEExibir(produtos, p => p.Preco < 100);

// Console.WriteLine("\nProdutos Caros (mais de 1000):");
// FiltrarEExibir(produtos, p => p.Preco > 1000);

// // 2. O Método Genérico: Ele não sabe QUAL é o filtro, apenas sabe COMO aplicar um filtro
// static void FiltrarEExibir(List<Produto> lista, FiltroProduto filtro)
// {
//     foreach (var prod in lista)
//     {
//         // O delegate decide se o produto entra ou não no resultado
//         if (filtro(prod))
//             Console.WriteLine($"- {prod.Nome}: R$ {prod.Preco}");
//     }
// }

// // 1. Definição do Delegate: "Eu aceito qualquer função que receba um Produto e retorne um bool"
// public delegate bool FiltroProduto(Produto p);

// public class Produto
// {
//     public string Nome { get; set; }
//     public decimal Preco { get; set; }
// }

List<Product> products = new
{
    new Product
    {
        Name = "Dish detergent",
        Price = 3.50,
        Qty = 120,
    },
    new Product
    {
        Name = "Paper straws",
        Price = 1.85,
        Qty = 1500,
    },
    new Product
    {
        Name = "Slow cooker",
        Price = 125.60,
        Qty = 0,
    },
    new Product
    {
        Name = "Blender",
        Price = 87.88,
        Qty = 3,
    },
};

Console.WriteLine($"Products below $100:");

static void FilterProducts(List<Product> products, FilterProduct filter)
{
    foreach (Product product in products)
    {
        if (filter(product))
            Console.WriteLine($"- {prod.Name}: R$ {prod.Price}");
    }
}

public class Product
{
    public string Name;
    public float Price;
    public int Qty;
}
