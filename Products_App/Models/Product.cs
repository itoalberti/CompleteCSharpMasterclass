namespace CRUDLayers.Models
{
    public class Product
    {
        // get → publicly visible
        // private set →  modifiable only by the Product class itself
        // It also forces the changes in these parameters to pass through their validations/business rules (controller, service etc)
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

        // internal → only ProductRepository needs access to this method. Controller, Service and Menu should not be able to modify the ID
        internal void SetID(int id) => Id = id;
    }

    // public void UpdateProduct(string newName, double newPrice, int newQty)
    // {
    //     Name = newName;
    //     Price = newPrice;
    //     Qty = newQty;
    // }
}
