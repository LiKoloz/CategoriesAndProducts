
using Microsoft.AspNetCore.Mvc;
using ASPNetApp.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using DataBaseWorker.Queries;
using DataBaseWorker.Commands;
using DataBaseWorker.Models;

namespace ASPNetApp.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("api/get/products/{id}")]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            var result = await _mediator.Send(new GetProductsByCategoryQuery(id));
            return Json(result);
        }


        [HttpDelete("api/delete/product/{id}")]
        public async void DeleteProduct(int Id)
        {
            await _mediator.Send(new DeleteProductCommand(Id));
        }

        [HttpPut("api/put/product")]
        public async Task PutProduct(Product product)
        {
            await _mediator.Send(new ChangeProductCommand(product.Id));
        }

        [HttpPost("api/post/product/{id}")]
        public async void PostProduct(int id,Product product)
        {
            await _mediator.Send(new AddProductCommand(id, product));
        }
    }
}