using CRUDLayers.Models;
using CRUDLayers.Repositories;
using CRUDLayers.UI;

public class ProductController
{
    // private readonly → the repository is an internal tool for the controller.
    // Nobody outside of ProductController is allowed to swap the repository with something else
    private readonly ProductRepository _repository;

    public ProductController(ProductRepository repository) => _repository = repository;

    public void CreateProduct(string name, string price, string qty)
    {
        name = name.Trim();
        if (ValidateProduct(name, price, qty, out double parsedPrice, out int parsedQty))
        {
            _repository.CreateProduct(new Product(name, parsedPrice, parsedQty));
            Logger.Log($"Product created in the database: \"{name}\"");
        }
    }

    public IReadOnlyList<Product> ListProducts()
    {
        var products = _repository.GetAllProducts();
        if (!products.Any())
            throw new InvalidOperationException("🚫 THERE ARE NO PRODUCTS IN THE DATABASE 🚫");
        Logger.Log($"All products were listed");
        return products;
    }

    public Product FindByID(string id)
    {
        if (!int.TryParse(id, out int parsedID) || parsedID <= 0)
            throw new KeyNotFoundException($"🚫 PRODUCT ID MUST BE A POSITIVE INTEGER 🚫");
        var product =
            _repository.GetProductById(parsedID)
            ?? throw new KeyNotFoundException($"🚫 PRODUCT ID \'{parsedID}\' DOES NOT EXIST 🚫");
        Logger.Log($"Product \"{parsedID}\" {product.Name}\" was looked up by its ID");
        return product;
    }

    public void UpdateProduct(string id, string newName, string newPrice, string newQty)
    {
        newName = newName.Trim();
        var product = FindByID(id);
        if (ValidateProduct(newName, newPrice, newQty, out double parsedPrice, out int parsedQty))
        { }
        _repository.UpdateProduct(product.Id, newName, parsedPrice, parsedQty);
        Logger.Log($"Product \"{product.Id} - {product.Name}\" was updated");
    }

    public void RemoveProduct(string id)
    {
        var product = FindByID(id);
        Logger.Log($"Product \"{product.Id} - {product.Name}\" was deleted from the database");
        _repository.Delete(product);
    }

    // public void PlaceOrder(string id)
    // {
    //     var product = FindByID(id);
    // }

    private static bool ValidateProduct(
        string name,
        string price,
        string qty,
        out double parsedPrice,
        out int parsedQty
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("🚫 PRODUCT NAME CANNOT BE EMPTY 🚫");
        if (!double.TryParse(price, out parsedPrice) || parsedPrice <= 0)
            throw new ArgumentException("🚫 PRICE MUST BE A NUMBER GREATER THAN ZERO 🚫");
        if (!int.TryParse(qty, out parsedQty) || parsedQty < 0)
            throw new ArgumentException("🚫 QUANTITY MUST BE A NON NEGATIVE INTEGER 🚫");
        return true;
    }
}
