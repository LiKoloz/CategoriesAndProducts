
using Microsoft.AspNetCore.Mvc;
using ASPNetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetApp.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }   
        [HttpGet("api/get/products/{id}")]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            var result =  _db.Products.Where(p => p.CategoryId == id).AsParallel().ToList();
            return Json(result);
        }


        [HttpDelete("api/delete/product/{id}")]
        public async void DeleteProduct(int Id)
        {
            var Product = await _db.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (Product != null)
            {
                _db.Products.Remove(Product);
                await _db.SaveChangesAsync();
            }
        }

        [HttpPut("api/put/product")]
        public async Task PutProduct(Product UpdateProduct)
        {
            var product = await _db.Products.FirstOrDefaultAsync(c => c.Id == UpdateProduct.Id);
            if (product != null)
            {
                product.Title = UpdateProduct.Title;
                product.Count = UpdateProduct.Count;
                product.Price = UpdateProduct.Count;
                product.CategoryId = UpdateProduct.CategoryId;
                await _db.SaveChangesAsync();
            }
        }

        [HttpPost("api/post/product/{id}")]
        public async void PostProduct(int id,Product product)
        {
            var c = _db.Categories.FirstOrDefault(p => p.Id == id);
            var d = product;
            d.Category = c;
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }
    }
}
