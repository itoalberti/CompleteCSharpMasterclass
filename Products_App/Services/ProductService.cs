using System.ComponentModel.DataAnnotations;
using CRUDLayers.Models;
using CRUDLayers.Repositories;

namespace CRUDLayers.ProductServices
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Product product)
        {
            if (ValidateProduct(product))
                _productRepository.AddProduct(product);
            // Console.WriteLine($"ID: {product.Id}");
            // Console.WriteLine($"Name: {product.Name}");
            // Console.WriteLine($"Price: {product.Price}");
            // Console.WriteLine($"Qty: {product.Qty}");
        }

        // public bool ValidateProductName(Product product)
        // {
        //     (string.IsNullOrWhiteSpace(product.Name) || product.Name.Any(char.IsDigit)) ? false : true;
        // }
        public bool ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new Exception("🚫 Name is invalid 🚫");
            if (double.IsNegative(product.Price) || double.IsNaN(product.Price))
                throw new Exception("🚫 Price is invalid 🚫");
            if (int.IsNegative(product.Qty))
                throw new Exception("🚫 Quantity has to be greater than or equal to 0");
            return true;
        }
    };
}
