using AdisyonApp.Entities;

public interface IProductService
{
    List<Product> GetAllProducts();
    void AddProduct(Product product);
    void UpdateProduct(int id, string newName, decimal newPrice);
    void RemoveProduct(int id);
}
