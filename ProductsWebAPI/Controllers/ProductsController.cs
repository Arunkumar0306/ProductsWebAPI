using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsWebAPI.Models;
using ProductsWebAPI.Repository;

namespace ProductsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ProductsController : ControllerBase
        {
            private readonly  IProductRepository _productsRepository;
             public ProductsController(IProductRepository productRepository)
            {
                _productsRepository = productRepository;
            }
            [HttpGet]
            public ActionResult GetProducts()
            {
                try
                {
                    return Ok(_productsRepository.GetProducts());
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            [HttpGet("product_id")]
            public ActionResult GetProductsById(int product_id)
            {
                try
                {
                    var product = _productsRepository.GetProductById(product_id);
                   
                    if (product.productName != null)
                    {
                        return Ok(product);
                    }
                    return NotFound("Product not found");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            [HttpGet("byname/product_name")]
            public ActionResult GetProductsByName(string product_name)
            {
                try
                {
                    return Ok(_productsRepository.GetProductByName(product_name));
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            [HttpPost]
            public ActionResult AddProducts(Product product)
            {
                try
                {
                var result = _productsRepository.AddProduct(product);

                    return CreatedAtAction("GetProductsById", new {productId=result.productId },result);
                }
                catch(Exception) 
                {
                    return BadRequest("Failed to Add Product");
                }
            }
            [HttpPut("product_id")]
            public ActionResult UpdateProducts(int product_id,Product product) 
            {
                try
                {
                    if (_productsRepository.UpdateProduct(product_id, product))
                    {
                        return Ok("Product updated successfully");
                    }
                    return NotFound("Product not found");
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        [HttpDelete("product_id")]
        public ActionResult DeleteProducts(int product_id)
        {
            try
            {
                if (_productsRepository.DeleteProduct(product_id))
                {
                    return Ok("Product deleted successfully");

                }
                else
                {
                    return NotFound("Product not found");
                }
            }

            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
