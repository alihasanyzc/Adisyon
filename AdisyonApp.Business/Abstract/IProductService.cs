using AdisyonApp.Entities;

public interface IProductService
{
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int productId);
    Product GetProductById(int productId);
    List<Product> GetAllProducts();
    double CalculateTotalPrice(int productId);
}