using ASPNetApp.Models;
using Microsoft.AspNetCore.Mvc;
using DbWorker;
using DbWorker.Classes;

namespace ASPNetApp.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
       
        [HttpGet("api/categories")]
        public IActionResult GetAllCategories()
        {
            return Json(ApplicationDb.GetAllCategories()); 
        }
        [HttpDelete("api/delete/category/{Id}")]
        public async void DeleteCategory(int Id)
        {
            await ApplicationDb.DeleteCategory(Id); 
        }

        [HttpPut("api/put/category")]
        public async void PutCategory(Category category)
        {
           await ApplicationDb.UpdateCategory(category);
        }

        [HttpPost("api/post/category")]
        public async void PostCategory (Category category)
        {
           await ApplicationDb.AddCategory(category);
        }

    }
}
