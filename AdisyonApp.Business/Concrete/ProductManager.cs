using AdisyonApp.Business.Abstract;
using AdisyonApp.Entities;

namespace AdisyonApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly List<Product> _products;
        
        public ProductManager()
        {
            _products = new List<Product>();
        }

        public void CreateProduct(Product product)
        {
            _products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _products.Find(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public void DeleteProduct(int productId)
        {
            var existingProduct = _products.Find(p => p.Id == productId);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
            }
            else
            {
                throw new Exception("Güncellenemedi..");
            }
        }

        public Product GetProductById(int productId)
        {
            var existingProduct = _products.Find(p => p.Id == productId);
            if (existingProduct != null)
            {
                return existingProduct;
            }
            throw new Exception("Product not found");
        }

        public List<Product> GetAllProducts()
        {
            if (_products.Count == 0)
            {
                throw new Exception("Product not found");
            }
            return _products;
        }

        public double CalculateTotalPrice(int productId)
        {
            var product = GetProductById(productId);
            return (double)product.Price;
        }
    }
}