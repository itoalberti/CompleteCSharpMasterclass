// using CRUDLayers.Models;

using CRUDLayers.Models;
using CRUDLayers.ProductServices;
using CRUDLayers.Repositories;

public class ProductController
{
    public ProductService _svc;

    public ProductController(ProductService svc) => _svc = svc;

    public void CreateProduct(string name, double price, int qty) =>
        _svc.Create(new Product(name, price, qty));
}

// public class ProductController
// {
// 	private readonly ProductService _service = new();
// 	// Methods are all "void" unless the interface needs to show their information
// 	public void Create
// 	{

// 	}
// 	public List<Product> GetProducts()=>_service.GetAllProducts();
// 	public void RemoveProduct(int id) => _service.RemoveProduct(id);

// }
