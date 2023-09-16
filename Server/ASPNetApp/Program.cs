using ASPNetApp.Models;
using DataBaseWorker.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DataBaseWorker.Queries;
using DataBaseWorker.Models;
using DataBaseWorker.Handlers;
using DataBaseWorker;
using DataBaseWorker.Commands;

namespace ASPNetApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllersWithViews();
            builder.Services.AddCors();
 


            Config.AddAppContext(builder.Services);

            {
                builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
                .AddTransient<IRequestHandler<GetCategoriesQuery, List<Category>>, GetCategoryQueryHandler>()
                .AddTransient<IRequestHandler<AddCategoryCommand, Category>, AddCategoryCommandHandler>()
                .AddTransient<IRequestHandler<DeleteCategoryCommand, object>, DeleteCategoryCommandHandler>()
                .AddTransient<IRequestHandler<ChangeCategoryCommand, Category>, ChangeCategoryCommandHandler>();
            }

            {
                builder.Services.AddTransient<IRequestHandler<GetProductsByCategoryQuery, List<Product>>, GetProductsByCategoryQueryHandler>()
                    .AddTransient<IRequestHandler<AddProductCommand, Product>, AddProductCommandHandler>()
                    .AddTransient<IRequestHandler<DeleteProductCommand, object>, DeleteProductCommandHandler>()
                    .AddTransient<IRequestHandler<ChangeProductCommand, object>, ChangeProductCommandHandler>();

            }


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin()
                             .AllowAnyHeader()
                            .AllowAnyMethod());
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}