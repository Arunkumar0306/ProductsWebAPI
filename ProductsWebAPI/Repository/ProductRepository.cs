using ProductsWebAPI.Models;

namespace ProductsWebAPI.Repository
{
    public class ProductRepository:IProductRepository
    {
        public static List<Product> products = new List<Product>()
        {
            new Product()
            {
                productId = 1,
                productName="Shoes",
                productBrand="Puma",
                productQuantity=1,
                productPrice=2000
            },
            new Product()
            {
                productId = 2,
                productName="Shirt",
                productBrand="Rare Rabbit",
                productQuantity=1,
                productPrice=1800
            },
            new Product()
            {
                productId = 3,
                productName="Bluetooth",
                productBrand="Realme",
                productQuantity=1,
                productPrice=2200
            },

        };
        private static int nextProductId = 4;
        public ProductRepository() { }
        public List<Product> GetProducts() { return products; }
        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault(x => x.productId == id);
            if(product!=null)
                return product;

            return new Product();
            
           
        }
        public List<Product> GetProductByName(string name) 
        {
            return products.Where(x => x.productName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public Product AddProduct(Product product)
        {
            try
            {
                product.productId = nextProductId++;
                products.Add(product);
                return product;
            }
            catch(Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
            
        }
        public bool UpdateProduct(int id,Product product)
        {
            var currentProduct = products.FirstOrDefault(x => x.productId == id);
            if(currentProduct!=null)
            {
                currentProduct.productName = product.productName;
                currentProduct.productBrand = product.productBrand;
                currentProduct.productQuantity = product.productQuantity;
                currentProduct.productPrice = product.productPrice;
                return true;
            }
            return false;
        }
        public bool DeleteProduct(int id)
        {
            var product = products.Find(x => x.productId == id);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }
    }
}
