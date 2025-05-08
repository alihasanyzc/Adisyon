using AdisyonApp.Business.Abstract;
using AdisyonApp.Entities;

namespace AdisyonApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly List<Product> _products;
        private int _nextId;

        public ProductManager()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Çay", Price = 10 },
                new Product { Id = 2, Name = "Kahve", Price = 20 },
                new Product { Id = 3, Name = "Soda", Price = 12 }
            };
            _nextId = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
        }

        public List<Product> GetAllProducts()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("Ürün listesi boş.");
            }
            else
            {
                Console.WriteLine("--- Ürün Listesi ---");
                foreach (var product in _products.OrderBy(p => p.Id))
                {
                    Console.WriteLine($"{product.Id}. {product.Name} - {product.Price} TL");
                }
            }

            return _products;
        }

        public void AddProduct(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
        }

        public void UpdateProduct(int id, string newName, decimal newPrice)
        {
            var product = _products.Find(p => p.Id == id);
            if (product != null)
            {
                product.Name = newName;
                product.Price = newPrice;
            }
        }

        public void RemoveProduct(int id)
        {
            var product = _products.Find(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                // ID'leri yeniden düzenle
                ReorderIds();
            }
        }

        private void ReorderIds()
        {
            // ID'leri 1'den başlayarak sıralı hale getir
            for (int i = 0; i < _products.Count; i++)
            {
                _products[i].Id = i + 1;
            }
            _nextId = _products.Count + 1;
        }
    }
}
