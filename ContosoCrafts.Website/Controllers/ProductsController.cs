using ContosoCrafts.Website.Models;
using ContosoCrafts.Website.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoCrafts.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        JsonFileProductService ProductService { get; }
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;  
        }


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery]string productId,[FromQuery]int Rating)
        {
            ProductService.AddRating(productId, Rating);
            return Ok();
        }
    }
}
