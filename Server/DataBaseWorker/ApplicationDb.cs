using DataBaseWorker.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseWorker
{
    public class ApplicationDb
    {
        ApplicationContext db = new ApplicationContext();

     
        public async Task<List<Category>> GetAllCategoriesAsync() => await Task.FromResult(db.Categories.ToList());

        public async Task AddCategoryAsync(Category category)
        {

            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
        }
 
        public async Task DeleteCategoryAsync(int Id)
        {
            if (Id != null)
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

                await Task.CompletedTask;

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
        public async Task ChangeCategoryAsync(Category category)
        {
            var c = db.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (c != null)
            {
                c.Title = category.Title;
                c.ParentId = category.ParentId;
                await db.SaveChangesAsync();
            }
            await Task.CompletedTask;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int id)
        {
            var result = db.Products.Where(p => p.CategoryId == id).AsParallel().ToList();
           return result;
        }

        public async Task DeleteProductAsync(int id)
        {
            var result = db.Products.Where(p => p.CategoryId == id).AsParallel().ToList();
            var Product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (Product != null)
            {
                db.Products.Remove(Product);
                await db.SaveChangesAsync();
            }
           await Task.CompletedTask;
        }

        public async Task ChangeProductAsync(int id)
        {
            var Product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (Product != null)
            {
                db.Products.Remove(Product);
                await db.SaveChangesAsync();
            }
            await Task.CompletedTask;
        }

        public async Task AddProductAsync(int id, Product product)
        {
            var c = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
            var d = product;
            d.Category = c;
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
