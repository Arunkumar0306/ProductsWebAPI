
using NUnit.Framework.Internal;
using ProductsWebAPI.Models;
using ProductsWebAPI.Repository;

namespace ProductWebAPITest
{
     public class ProductsRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }
        //Test Case for adding new product.Test Case should pass if product is 
        //added successfully.
        [Test]
        public void Test_01_AddProductsReturnProduct()
        {
            var repository = new ProductRepository();
           
            var product = new Product
            {
                productId = 1,
                productName = "Shoes",
                productBrand = "Puma",
                productQuantity = 1,
                productPrice = 2000
            };
            var actual = repository.AddProduct(product);

            
            Assert.That(product, Is.EqualTo(actual));
        }
        //Test Case for get product by id.Test Case should pass if the matching
        //product is found.
        [Test]
        public void Test_02_GetProductsByIdReturnProduct()
        {

            var repository = new ProductRepository();
            var ProductId = 1;
            var product = new Product
            {
                productId = 1,
                productName = "Shoes",
                productBrand = "Puma",
                productQuantity = 1,
                productPrice = 2000
            };
            var actual = repository.GetProductById(ProductId);
            Assert.That(product.productName, Is.EqualTo(actual.productName));
        }
       
        //Test Case for updating a product.Test Case should pass if product is 
        //updated successfully.
        [Test]
        public void Test_03_UpdateProductsReturnTrue()
        {
            var repository = new ProductRepository();
            int ProductId = 1;
            var product = new Product
            {
                productId = 1,
                productName = "EarPhones",
                productBrand = "Sony",
                productQuantity = 1,
                productPrice = 2000
            };
            var actual = repository.UpdateProduct(ProductId,product);


            Assert.That(true, Is.EqualTo(actual));
        }
        //Test Case for deleting a product.Test Case should pass if product is 
        //deleted successfully

        [Test]
        public void Test_04_DeleteProductsReturnTrue()
        {
            var repository = new ProductRepository();
            var ProductId = 1;
            var actual=repository.DeleteProduct(ProductId);
            Assert.That(true, Is.EqualTo(actual));

        }

    }
}
