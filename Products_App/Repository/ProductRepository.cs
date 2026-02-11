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
        public Product Add(Product newProduct)
        {
            _nextID++;
            newProduct.SetID(_nextID);
            _allProducts.Add(newProduct);
            return newProduct;
        }

        public IReadOnlyList<Product> GetAll() => _allProducts.AsReadOnly();

        public Product? GetById(int id) => _allProducts.FirstOrDefault(p => p.Id == id);

        public void Update(int id, string name, double price, int qty)
        {
            var updatedProduct = GetById(id);
            if (updatedProduct == null)
                throw new ArgumentNullException("🚫 PRODUCT ID WAS NOT FOUND 🚫");
            updatedProduct.UpdateProduct(name, price, qty);
        }

        public void Delete(Product product) => _allProducts.Remove(product);
    }
}
