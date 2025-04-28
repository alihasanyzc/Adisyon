using AdisyonApp.Business.Concrete;
using AdisyonApp.Entities;

namespace AdisyonApp.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adisyon Uygulaması Başlatıldı!");

            ProductManager ProductManager = new ProductManager();

            // Ürün oluşturma
            Product product1 = new Product { Id = 1, Name = "Hamburger", Price = 150 };
            Product product2 = new Product { Id = 2, Name = "Pizza", Price = 120 };
            Product product3 = new Product { Id = 3, Name = "Kola", Price = 30 };

            ProductManager.CreateProduct(product1);
            ProductManager.CreateProduct(product2); 
            ProductManager.CreateProduct(product3);

            // Tüm ürünleri listeleme
            Console.WriteLine("\nTüm Ürünler:");
            var allProducts = ProductManager.GetAllProducts();
            foreach (var product in allProducts)
            {
                Console.WriteLine($"Id: {product.Id}, Ad: {product.Name}, Fiyat: {product.Price}TL");
            }

            // Ürün güncelleme
            product1.Price = 170;
            ProductManager.UpdateProduct(product1);

            // ID'ye göre ürün getirme
            Console.WriteLine("\nID:1 olan ürün:");
            var selectedProduct = ProductManager.GetProductById(1);
            Console.WriteLine($"Id: {selectedProduct.Id}, Ad: {selectedProduct.Name}, Fiyat: {selectedProduct.Price}TL");

            // Ürün silme
            ProductManager.DeleteProduct(3);
            Console.WriteLine("\nKola ürünü silindi.");
        }
    }
}
