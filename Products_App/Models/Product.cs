using System.Data.Common;
using System.Runtime.CompilerServices;

namespace CRUDLayers.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Qty { get; private set; }

        public Product(string name, double price, int qty)
        {
            Name = name;
            Price = price;
            Qty = qty;
        }

        public void SetID(int id)
        {
            Id = id;
        }
    }

    // public void UpdateProduct(string newName, double newPrice, int newQty)
    // {
    //     Name = newName;
    //     Price = newPrice;
    //     Qty = newQty;
    // }
}
