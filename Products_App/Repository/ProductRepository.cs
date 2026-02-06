using CRUDLayers.Models;

namespace CRUDLayers.Repositories
{
    public class ProductRepository
    {
        // private → if the list of products is public, Menu() is able to execute _allProducts.Clear() without passing through the repository
        // data access must be controlled by the repository only
        private readonly List<Product> _allProducts = new();
        private int _nextID = 0;

        // public AddProduct → ProductService needs access to save data in it
        public Product AddProduct(Product newProduct)
        {
            _nextID++;
            newProduct.SetID(_nextID);
            _allProducts.Add(newProduct);
            return newProduct;
        }

        public List<Product> ListProducts() => _allProducts;

        public Product? FindProductByID(int id) => _allProducts.FirstOrDefault(p => p.Id == id);
    }
}

// LIST BY ID
// public Product GetProductByID(int id) => _allProducts.FirstOrDefault(p => p.Id == id);

// UPDATE
// public void UpdateProduct(Product product)
// {
//     var updatedProduct = GetProductByID(product.Id);
//     if (updatedProduct == null)
//         return;

//     updatedProduct.Name = product.Name;
//     updatedProduct.Price = product.Price;
//     updatedProduct.Qty = product.Qty;
// }

// public class ProductRepository
// {
//     public readonly List<Product> _allProducts = new();
//     public int _nextID = 1;

//     public Product AddProduct(Product newProduct)
//     {
//         _nextID++;
//         _allProducts.Add(newProduct);
//         return newProduct;
//     }
// }
