using CRUDLayers.Models;
using CRUDLayers.Repositories;
using CRUDLayers.UI;

namespace CRUDLayers.ProductServices
{
    public class ProductService
    {
        // private readonly → the repo is an internal tool for the service.
        // Nobody outside of ProductService is allowed to switch the repository with something else
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository) =>
            _productRepository = productRepository;

        public void Create(Product product)
        {
            if (ValidateProduct(product))
                _productRepository.AddProduct(product);
            ColorChanges.WriteInColor(
                $"\n  ID  | NAME                  | PRICE [$] | QUANTITY\n",
                ConsoleColor.Blue
            );
            Console.WriteLine(
                $"{product.Id, 5} | {product.Name, -21} | {product.Price, -9} | {product.Qty, -8}"
            );
        }

        public void GetAllProducts()
        {
            if (_productRepository.ListProducts().Any())
            {
                ColorChanges.WriteInColor(
                    $"\n  ID  | NAME                  | PRICE [$] | QUANTITY \n",
                    ConsoleColor.DarkBlue
                );
                foreach (Product product in _productRepository.ListProducts())
                    Console.WriteLine(
                        $"{product.Id, 5} | {product.Name, -21} | {product.Price, -9} | {product.Qty, -8}"
                    );
            }
            else
                throw new Exception("🚫 THERE ARE NO PRODUCTS IN THE DATABASE 🚫");
        }

        public Product GetByID(int id)
        {
            if (id <= 0)
                throw new Exception($"🚫 ID {id} IS INVALID 🚫");

            var product = _productRepository.FindProductByID(id);
            if (product is null)
                throw new Exception($"🚫 PRODUCT ID WAS NOT FOUND 🚫");
            return product;
        }

        public void RemoveProduct(int id)
        {
            var product = _productRepository.FindProductByID(id);
            if (product == null)
                throw new Exception("🚫 PRODUCT ID WAS NOT FOUND 🚫");
            _productRepository.DeleteProduct(product);
        }

        private bool ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new Exception("🚫 NAME IS INVALID 🚫");
            if (double.IsNegative(product.Price) || double.IsNaN(product.Price))
                throw new Exception("🚫 PRICE IS INVALID 🚫");
            if (product.Qty < 0)
                throw new Exception("🚫 QUANTITY MUST BE A NON-NEGATIVE NUMBER 🚫");
            return true;
        }
    };
}
