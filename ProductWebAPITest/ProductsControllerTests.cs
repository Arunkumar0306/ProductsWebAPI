using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework.Internal;
using ProductsWebAPI.Controllers;
using ProductsWebAPI.Models;
using ProductsWebAPI.Repository;

namespace ProductWebAPITest
{
    public class ProductsControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }
        //Positive Test Cases
        //Test Case for get product by id. Test Case should pass if the matching 
        //product is found and returned as a response with 200 status code
        [Test]
        public void GetProductByIdReturnsSuccess()
        {
            int ProductId = 1;
            var product = new Product { productId = 1, productName = "Ear phones", productBrand = "Sony", productPrice = 0, productQuantity = 1 };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetProductById(ProductId)).Returns(product);
            var productController = new ProductsController(mockRepo.Object);
            var actual = productController.GetProductsById(ProductId);
            var okResult = actual as ObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(product));
            Assert.That(StatusCodes.Status200OK, Is.EqualTo(okResult.StatusCode));
        }
        //Test Case for adding new product. Test Case should pass if product is 
       // added successfully and returned as a response with 201 status code.
        
        [Test]
        public void CreateShouldReturnSuccess()
        {
            var product = new Product { productId = 1, productName = "Ear phones", productBrand = "Sony", productPrice = 0, productQuantity = 1 };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.AddProduct(product)).Returns(product);
            var productController = new ProductsController(mockRepo.Object);
            var actual = productController.AddProducts(product);
            var createdResult = actual as ObjectResult;
            Assert.That(createdResult.Value, Is.EqualTo(product));
            Assert.That(StatusCodes.Status201Created,Is.EqualTo( createdResult.StatusCode));
        }
        //Test Case for updating a product. Test Case should pass if product is 
        //updated successfully and returned as a response with 200 status code.
        [Test]
        public void UpdateProductShouldReturnSuccess() 
        {
            int ProductId = 1;
            var product = new Product { productId = 1, productName = "Ear phones", productBrand = "Sony", productPrice = 0, productQuantity = 1 };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.UpdateProduct(ProductId,product)).Returns(true);
            var productController = new ProductsController(mockRepo.Object);
            var actual = productController.UpdateProducts(ProductId,product);
            var okResult = actual as ObjectResult;
            Assert.That(okResult.Value,Is.EqualTo("Product updated successfully"));
            Assert.That(StatusCodes.Status200OK, Is.EqualTo(okResult.StatusCode));
        }
        //Test Case for deleting a product. Test Case should pass if product is 
        //deleted successfully and returned as a response with 200 status code.
        [Test]
        public void DeleteProductShouldReturnSuccess()
        {
            int ProductId = 1;
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.DeleteProduct(ProductId)).Returns(true);
            var productController = new ProductsController(mockRepo.Object);
            var actual = productController.DeleteProducts(ProductId);
            var okResult = actual as ObjectResult;
            Assert.That(okResult.Value, Is.EqualTo("Product deleted successfully"));
            Assert.That(StatusCodes.Status200OK, Is.EqualTo(okResult.StatusCode));
        }

        //Negative Test Cases
        //Test Case for get product by id.Test Case should pass if product with
        //specified id not found and 404 Not Found status code is returned.
        [Test]
        public void GetProductByIdReturnsNotFound()
        {
            int ProductId = 2;
            var product = new Product();
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetProductById(ProductId)).Returns(product);
            var productController = new ProductsController(mockRepo.Object);
            var actual = productController.GetProductsById(ProductId);
            var notFoundResult = actual as ObjectResult;
            Assert.That(notFoundResult.Value, Is.EqualTo("Product not found"));
            Assert.That(StatusCodes.Status404NotFound, Is.EqualTo(notFoundResult.StatusCode));
        }
        //Test Case for adding new product.Test Case should pass if product is 
        //failed to add and specific status code is returned.
        [Test]
        public void CreateShouldReturnFailed()
        {
            var product = new Product { productId = 1, productName = "Ear phones", productBrand = "Sony", productPrice = 0, productQuantity = 1 };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.AddProduct(product)).Throws<ArgumentNullException>();
            var productController = new ProductsController(mockRepo.Object);
            var actual = productController.AddProducts(product);
            var badRequestResult = actual as ObjectResult;
            Assert.That("Failed to Add Product",Is.EqualTo(badRequestResult.Value));
            Assert.That(StatusCodes.Status400BadRequest, Is.EqualTo(badRequestResult.StatusCode));
        }
        // Test Case for updating new product.Test Case should pass if product
        //with specified id not found and 404 Not Found status code is returned.
        [Test]
        public void UpdateProductShouldReturnNotFound()
        {
            int ProductId = 2;
            var product = new Product { productId = 2, productName = "Ear phones", productBrand = "Sony", productPrice = 0, productQuantity = 1 };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.UpdateProduct(ProductId, product)).Returns(false);
            var productController = new ProductsController(mockRepo.Object);
            var actual = productController.UpdateProducts(ProductId, product);
            var notFoundResult = actual as ObjectResult;
            Assert.That(notFoundResult.Value, Is.EqualTo("Product not found"));
            Assert.That(StatusCodes.Status404NotFound, Is.EqualTo(notFoundResult.StatusCode));
        }
        //Test Case for deleting new product.Test Case should pass if product
        //with specified id not found and 404 Not Found status code is returned.
        [Test]
        public void DeleteProductShouldReturnNotFound()
        {
            int ProductId = 2;
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.DeleteProduct(ProductId)).Returns(false);
            var productController = new ProductsController(mockRepo.Object);
            var actual = productController.DeleteProducts(ProductId);
            var notFoundResult = actual as ObjectResult;
            Assert.That(notFoundResult.Value, Is.EqualTo("Product not found"));
            Assert.That(StatusCodes.Status404NotFound, Is.EqualTo(notFoundResult.StatusCode));
        }
    }
}