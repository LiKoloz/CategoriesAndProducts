using DbWorker.Classes;
using DbWorker;
using Microsoft.AspNetCore.Mvc;


namespace ASPNetApp.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet("api/get/products/{id}")]
        public ActionResult GetProductsByCategory(int id)
        {
            var a = ApplicationDb.GetCategoryProducts(id);
            foreach(var item in a)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
            return Json(ApplicationDb.GetCategoryProducts(id));
        }


        [HttpDelete("api/delete/product/{id}")]
        public async void DeleteProduct(int Id)
        {
            await ApplicationDb.DeleteProduct(Id);
        }

        [HttpPut("api/put/product")]
        public async void PutProduct(Product product)
        {
            await ApplicationDb.UpdateProduct(product);
        }

        [HttpPost("api/post/product/{id}")]
        public async void PostProduct(int id,Product product)
        {
            await ApplicationDb.AddProduct(id,product);
        }
    }
}
