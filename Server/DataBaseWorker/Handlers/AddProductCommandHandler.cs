using Azure.Core;
using DataBaseWorker.Commands;
using DataBaseWorker.Models;
using MediatR;

namespace DataBaseWorker.Handlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly ApplicationDb _db = new ApplicationDb();

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _db.AddProductAsync(request.id, request.product);
            return request.product;
        }
    }
}
