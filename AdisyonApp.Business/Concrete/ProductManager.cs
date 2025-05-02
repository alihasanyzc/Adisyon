using AdisyonApp.Business.Abstract;
using AdisyonApp.Entities;

namespace AdisyonApp.Business.Concrete
{
   
          
        public class ProductManager : IProductService
{
    private readonly List<Product> _products;

    public ProductManager()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Çay", Price = 10 },
            new Product { Id = 2, Name = "Kahve", Price = 20 },
            new Product { Id = 3, Name = "Soda", Price = 12 }
        };
    }

       public List<Product> GetAllProducts()
     {
    return _products;
    }

   public void AddProduct(Product product)
{
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
            _products.Remove(product);
    }
}

    }
