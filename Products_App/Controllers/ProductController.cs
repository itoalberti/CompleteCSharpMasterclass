using CRUDLayers.Models;
using CRUDLayers.ProductServices;

public class ProductController
{
    // private readonly → the service is an internal tool for the controller.
    // Nobody outside of ProductController is allowed to switch the service with something else
    private readonly ProductService _svc;

    public ProductController(ProductService svc) => _svc = svc;

    public void CreateProduct(string name, double price, int qty) =>
        _svc.Create(new Product(name, price, qty));

    public void ListProducts() => _svc.GetAllProducts();

    public Product FindByID(int id) => _svc.GetByID(id);

    // public Product UpdateProduct()

    public void RemoveProduct(int id) => _svc.RemoveProduct(id);
}
