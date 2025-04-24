namespace AdisyonApp.Entities
{
    public class Product{

        public int ProductId {get; set;}
        public string? ProductName {get; set;}
        public int ProductPrice {get; set;}
        

        public Product(int productId, string productName, int productPrice){
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
        }




    }
}