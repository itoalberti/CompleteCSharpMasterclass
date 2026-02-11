using System.ComponentModel;
using System.Net.Quic;
using System.Security.Cryptography.X509Certificates;
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
                _productRepository.Add(product);
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
            if (_productRepository.GetAll().Any())
            {
                ColorChanges.WriteInColor(
                    $"\n  ID  | NAME                  | PRICE [$] | QUANTITY \n",
                    ConsoleColor.DarkBlue
                );
                foreach (Product product in _productRepository.GetAll())
                    Console.WriteLine(
                        $"{product.Id, 5} | {product.Name, -21} | {product.Price, -9} | {product.Qty, -8}"
                    );
            }
            else
                throw new ArgumentNullException("🚫 THERE ARE NO PRODUCTS IN THE DATABASE 🚫");
        }

        public Product GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException($"🚫 ID MUST BE GREATER THAN ZERO 🚫");

            var product = _productRepository.GetById(id);
            if (product is null)
                throw new KeyNotFoundException($"🚫 PRODUCT ID {id} WAS NOT FOUND 🚫");
            return product;
        }

        public void UpdateProduct(int id, string name, double price, int qty)
        {
            if (id <= 0)
                throw new ArgumentException("🚫 ID MUST BE GREATER THAN ZERO 🚫");
            var product =
                _productRepository.GetById(id)
                ?? throw new KeyNotFoundException($"🚫 THERE IS NO PRODUCT WITH ID {id} 🚫");
            ValidateProduct(new Product(name, price, qty));
            _productRepository.Update(id, name, price, qty);
        }

        public void RemoveProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                throw new KeyNotFoundException($"🚫 PRODUCT ID {id} WAS NOT FOUND 🚫");
            _productRepository.Delete(product);
        }

        private bool ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException(
                    "🚫 PRODUCT NAME CANNOT BE EMPTY 🚫",
                    nameof(product.Name)
                );
            if (double.IsNaN(product.Price) || product.Price <= 0)
                throw new ArgumentException("🚫 PRICE MUST BE GREATER THAN ZERO 🚫");
            if (product.Qty < 0)
                throw new ArgumentException(
                    "🚫 QUANTITY CANNOT BE NEGATIVE 🚫",
                    nameof(product.Qty)
                );
            return true;
        }
    };
}
