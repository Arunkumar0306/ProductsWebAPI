using ProductsWebAPI.Models;

namespace ProductsWebAPI.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public Product GetProductById(int id);
        public List<Product> GetProductByName(string name);
        public Product AddProduct(Product product);
        public bool UpdateProduct(int id,Product product);
        public bool DeleteProduct(int id);
    }
}
