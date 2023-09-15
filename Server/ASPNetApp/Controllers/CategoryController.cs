using ASPNetApp.Models;
using DataBaseWorker.Commands;
using DataBaseWorker.Models;
using DataBaseWorker.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNetApp.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("api/categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return Json(result); 
        }

        [HttpPost("api/post/category")]
        public async Task PostCategory(Category category)
        {
            var categoryToReturn = await _mediator.Send(new AddCategoryCommand(category));
        }
        
        [HttpDelete("api/delete/category/{Id:int}")]
        public async Task DeleteCategory(int Id)
        {
             await _mediator.Send(new DeleteCategoryCommand(Id));
        }

        [HttpPut("api/put/category")]
        public async Task PutCategory(Category category)
        {
            await _mediator.Send(new ChangeCategoryCommand(category));
        }

    }
}
