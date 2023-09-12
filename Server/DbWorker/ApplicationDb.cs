using Microsoft.EntityFrameworkCore;
using DbWorker.Classes;

namespace DbWorker
{
    public class ApplicationDb
    {
        async public Task AddCategory(Category category)
        {
            var db = new ApplicationContext();
            await db.Categories.AddAsync(category);
           await db.SaveChangesAsync();
        }
        async public Task DeleteCategory(int Id)
        {
            var db = new ApplicationContext();
            Category? category = db.Categories.Include(c=> c.Children).AsParallel().FirstOrDefault(c => c.Id == Id);

            if (category != null)
            {
                foreach (var child in category.Children.ToList())
                {
                    DeleteChildCategories(child);
                }

                db.Categories.Remove(category);

                await db.SaveChangesAsync();
              
            }

              void DeleteChildCategories(Category category1)
            {
                foreach (Category? child1 in category1?.Children?.ToList())
                {
                    DeleteChildCategories(child1);
                }
                List<Category> list = db.Categories.Where(c => c.ParentId == category1.Id).AsParallel().ToList();
                category1.Children.Clear();
                db.Categories.Remove(category1);
                db.SaveChangesAsync();
            }
        }

        async public Task UpdateCategory(Category UpdateCategory)
        {
            var db = new ApplicationContext();
            var category = db.Categories.FirstOrDefault(c => c.Id == UpdateCategory.Id);
            if(category != null) 
            {
                category.Title =UpdateCategory.Title;
                category.ParentId = UpdateCategory.ParentId;
                await db.SaveChangesAsync();
            }
        }

         public List<Category> GetAllCategories()
        {
            var db = new ApplicationContext();
            
            return db.Categories.ToList();
        }

        async public Task AddProduct(int id,Product product)
        {
            var db = new ApplicationContext();
            var c = db.Categories.FirstOrDefault(p =>p.Id == id);
            var d = product;
            d.Category = c;
           await db.Products.AddAsync(product);
           await db.SaveChangesAsync();
        }
        async public Task DeleteProduct(int Id)
        {
            var db = new ApplicationContext();
            var Product = db.Products.FirstOrDefault(p => p.Id == Id);
            if (Product != null)
            {
                db.Products.Remove(Product);
                await db.SaveChangesAsync();
            }
        }

         public async  Task<List<Product>> GetCategoryProductsAsync(int id)
        {
            var db = new ApplicationContext();

            return db.Products.Where(p=>p.CategoryId == id).AsParallel().ToList();
        }

        public async Task UpdateProduct(Product UpdateProduct)
        {
            var db = new ApplicationContext();
            var product = db.Products.FirstOrDefault(c => c.Id == UpdateProduct.Id);
            if (product != null)
            {
                product.Title = UpdateProduct.Title;
                product.Count = UpdateProduct.Count;
                product.Price = UpdateProduct.Count;
                product.CategoryId = UpdateProduct.CategoryId;
               await db.SaveChangesAsync();
            }
        }
    }
}
