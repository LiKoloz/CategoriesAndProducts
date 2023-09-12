using ASPNetApp.Models;
using Microsoft.AspNetCore.Mvc;
using DbWorker;
using DbWorker.Classes;

namespace ASPNetApp.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ApplicationDb _db;
        public CategoryController(ApplicationDb db)
        {
            _db = db;
        }


        [HttpGet("api/categories")]
        public async Task<IActionResult> GetAllCategories()
        {
           return Json(_db.GetAllCategories()); 
        }
        [HttpDelete("api/delete/category/{Id}")]
        public async Task DeleteCategory(int Id)
        {
            await _db.DeleteCategory(Id); 
        }

        [HttpPut("api/put/category")]
        public async Task PutCategory(Category category)
        {
           await _db.UpdateCategory(category);
        }

        [HttpPost("api/post/category")]
        public async Task PostCategory (Category category)
        {
           await _db.AddCategory(category);
        }

    }
}
