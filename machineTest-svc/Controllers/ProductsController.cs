using machineTest_svc.Data;
using machineTest_svc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace machineTest_svc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly string _productFilePath = "Data/products.json";

        [HttpGet]
        [Authorize]
        public IActionResult GetProducts()
        {
            var products = JsonFileHandler.ReadJsonFile<Product>(_productFilePath);
            return Ok(products);
        }

    }
}
