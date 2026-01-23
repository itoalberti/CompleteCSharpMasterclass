namespace Classes;

internal class Product
{
    public static int NumberOfProducts = 0;

    // ____________ MEMBER VARIABLES ____________
    private string _name = "";
    private float _price = 0f;
    private bool _hasStock = false;
    private int _qty = 0;

    public Product()
    {
        NumberOfProducts++;
    }

    public static void PrintMessage()
    {
        Console.WriteLine($"This message comes from the Product class");
    }

    // ____________ PROPERTIES ____________
    public string Name
    {
        get => _name;
        set => _name = value;
    }
    public float Price
    {
        // get => _price;
        get
        {
            if (!_hasStock)
            {
                return 0f;
            }
            else
            {
                return _price;
            }
        }
        set => _price = value;
    }
    public bool HasStock
    {
        get => _hasStock;
        set => _hasStock = value;
    }
    public int Qty
    {
        get
        {
            if (!_hasStock)
            {
                return 0;
            }
            else
            {
                return _qty;
            }
        }
        set => _qty = value;
    }
}
