using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing.Constraints;

namespace ProductsWebAPI.Models
{
    public class Product
    {
      
        public int productId { get; set; }
        public string productName { get; set; }
        public string productBrand { get; set; }
        public int productQuantity { get; set; }
        public double productPrice { get; set; }

    }
}
