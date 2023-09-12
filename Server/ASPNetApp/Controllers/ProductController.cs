using DbWorker.Classes;
using DbWorker;
using Microsoft.AspNetCore.Mvc;


namespace ASPNetApp.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApplicationDb _db;
        public ProductController(ApplicationDb db)
        {
            _db = db;
        }   
        [HttpGet("api/get/products/{id}")]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            return Json(_db.GetCategoryProductsAsync(id));
        }


        [HttpDelete("api/delete/product/{id}")]
        public async void DeleteProduct(int Id)
        {
            await _db.DeleteProduct(Id);
        }

        [HttpPut("api/put/product")]
        public async void PutProduct(Product product)
        {
            await _db.UpdateProduct(product);
        }

        [HttpPost("api/post/product/{id}")]
        public async void PostProduct(int id,Product product)
        {
            await _db.AddProduct(id,product);
        }
    }
}
