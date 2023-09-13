using ASPNetApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNetApp.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;
        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }


        [HttpGet("api/categories")]
        public async Task<IActionResult> GetAllCategories()
        {
           return Json(db.Categories.ToList()); 
        }
        [HttpDelete("api/delete/category/{Id}")]
        public async Task DeleteCategory(int Id)
        {
            if(Id != null)
            {
                Category? category = db.Categories.Include(c => c.Children).AsParallel().FirstOrDefault(c => c.Id == Id);

                if (category != null)
                {
                    foreach (var child in category.Children.ToList())
                    {
                       await DeleteChildCategories(child);
                    }

                    db.Categories.Remove(category);

                    await db.SaveChangesAsync();

                }

                async Task DeleteChildCategories(Category category1)
                {
                    foreach (Category? child1 in category1?.Children?.ToList())
                    {
                        await DeleteChildCategories(child1);
                    }
                    List<Category> list = db.Categories.Where(c => c.ParentId == category1.Id).AsParallel().ToList();
                    category1.Children.Clear();
                    db.Categories.Remove(category1);
                    await db.SaveChangesAsync();
                }
            }
        }

        [HttpPut("api/put/category")]
        public async Task PutCategory(Category category)
        {
            var c = db.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (c != null)
            {
                c.Title = category.Title;
                c.ParentId = category.ParentId;
                await db.SaveChangesAsync();
            }
        }

        [HttpPost("api/post/category")]
        public async Task PostCategory (Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
        }

    }
}
