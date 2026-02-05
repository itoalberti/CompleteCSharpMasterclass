using CRUDLayers.Models;

namespace CRUDLayers.Repositories
{
    public class ProductRepository
    {
        private List<Product> _allProducts = new();
        private int _nextID = 0;

        // CREATE
        public Product AddProduct(Product newProduct)
        {
            _nextID++;
            newProduct.SetID(_nextID);
            _allProducts.Add(newProduct);
            return newProduct;
        }

        // LIST
        // public List<Product> ListProducts() => _allProducts;

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
    }
}

// public class ProductRepository
// {
//     private readonly List<Product> _allProducts = new();
//     private int _nextID = 1;

//     public Product AddProduct(Product newProduct)
//     {
//         _nextID++;
//         _allProducts.Add(newProduct);
//         return newProduct;
//     }
// }
