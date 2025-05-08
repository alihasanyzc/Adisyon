using AdisyonApp.Business;
using AdisyonApp.Business.Concrete;
using AdisyonApp.Entities;
using System;

class Program
{
    static void Main(string[] args)
    {
        var productManager = new ProductManager();
        var tableManager = new TableManager();

        while (true)
        {
            Console.WriteLine("\n=== ANA MENÜ ===");
            Console.WriteLine("1. Masa Seç");
            Console.WriteLine("2. Ürün Yönetimi");
            Console.WriteLine("3. Gün Sonu Raporu");
            Console.WriteLine("4. Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.Write("Masa numarası: ");
                    int masaId = int.Parse(Console.ReadLine());
                    MasaIslemleri(tableManager, productManager, masaId);
                    break;
                case "2":
                    UrunYonetimi(productManager);
                    break;
                case "3":
                    tableManager.GetEndOfDayReport();
                    break;
                case "4":
                    Console.WriteLine("Çıkılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }

    static void MasaIslemleri(TableManager tableManager, ProductManager productManager, int masaId)
    {
        while (true)
        {
            Console.WriteLine($"\n--- Masa {masaId} Menüsü ---");
            Console.WriteLine("1. Sipariş Ekle");
            Console.WriteLine("2. Sipariş Sil");
            Console.WriteLine("3. Sipariş Güncelle");
            Console.WriteLine("4. Siparişleri Listele");
            Console.WriteLine("5. Masanın Toplam Tutarı");
            Console.WriteLine("6. Ana Menüye Dön");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    var urunler = productManager.GetAllProducts();
                    Console.Write("Ürün ID: ");
                    int urunId = int.Parse(Console.ReadLine());
                    var secilen = urunler.Find(p => p.Id == urunId);
                    Console.Write("Adet: ");
                    int adet = int.Parse(Console.ReadLine());
                    var yeniOrder = new Order
                    {
                        Id = urunId * 10 + masaId,
                        Product = secilen,
                        Quantity = adet
                    };
                    tableManager.AddOrder(masaId, yeniOrder);
                    break;
                case "2":
                    Console.Write("Silinecek Sipariş ID: ");
                    int silId = int.Parse(Console.ReadLine());
                    tableManager.RemoveOrder(masaId, silId);
                    break;
                case "3":
                    Console.Write("Sipariş ID: ");
                    int guncelleId = int.Parse(Console.ReadLine());
                    Console.Write("Yeni Adet: ");
                    int yeniAdet = int.Parse(Console.ReadLine());
                    tableManager.UpdateOrder(masaId, guncelleId, yeniAdet);
                    break;
                case "4":
                    var orders = tableManager.GetOrders(masaId);
                    foreach (var o in orders)
                        Console.WriteLine($"ID: {o.Id}, {o.Product.Name} x{o.Quantity} = {o.Product.Price * o.Quantity} TL");
                    break;
                case "5":
                    Console.WriteLine($"Toplam: {tableManager.GetTableTotal(masaId)} TL");
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }

    static void UrunYonetimi(ProductManager productManager)
    {
        while (true)
        {
            Console.WriteLine("\n--- Ürün Yönetimi ---");
            Console.WriteLine("1. Ürün Listele");
            Console.WriteLine("2. Ürün Ekle");
            Console.WriteLine("3. Ürün Güncelle");
            Console.WriteLine("4. Ürün Sil");
            Console.WriteLine("5. Ana Menüye Dön");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    productManager.GetAllProducts();
                    break;
                case "2":
                    Console.Write("Ürün adı: ");
                    string ad = Console.ReadLine();
                    Console.Write("Fiyat: ");
                    decimal fiyat = decimal.Parse(Console.ReadLine());
                    productManager.AddProduct(new Product { Name = ad, Price = fiyat });
                    break;
                case "3":
                    Console.Write("Güncellenecek ürün ID: ");
                    int guncelleId = int.Parse(Console.ReadLine());
                    Console.Write("Yeni ad: ");
                    string yeniAd = Console.ReadLine();
                    Console.Write("Yeni fiyat: ");
                    decimal yeniFiyat = decimal.Parse(Console.ReadLine());
                    productManager.UpdateProduct(guncelleId, yeniAd, yeniFiyat);
                    break;
                case "4":
                    Console.Write("Silinecek ürün ID: ");
                    int silId = int.Parse(Console.ReadLine());
                    productManager.RemoveProduct(silId);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }
}
