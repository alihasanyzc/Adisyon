using AdisyonApp.Business.Concrete;
using AdisyonApp.Entities;

namespace AdisyonApp.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var productManager = new ProductManager();

            // --- TÜM ÜRÜNLERİ LİSTELE ---
            Console.WriteLine("--- Başlangıç Ürün Listesi ---");
            ListProducts(productManager);

            // --- YENİ ÜRÜN EKLE ---
            var yeniUrun = new Product { Id = 4, Name = "Su", Price = 8 };
            productManager.AddProduct(yeniUrun);

            Console.WriteLine("\n--- Ürün Ekleme Sonrası Liste ---");
            ListProducts(productManager);

            // --- ÜRÜN GÜNCELLE ---
            productManager.UpdateProduct(2, "Türk Kahvesi", 25);

            Console.WriteLine("\n--- Güncelleme Sonrası Liste ---");
            ListProducts(productManager);

            // --- ÜRÜN SİL ---
            productManager.RemoveProduct(1); // ID'si 1 olan ürünü sil

            Console.WriteLine("\n--- Silme Sonrası Liste ---");
            ListProducts(productManager);

            Console.WriteLine("\nTest tamamlandı. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }

        static void ListProducts(ProductManager manager)
        {
            var products = manager.GetAllProducts();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Id}. {p.Name} - {p.Price} TL");
            }
        }
    }
}
