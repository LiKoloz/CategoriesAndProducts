using Azure.Core;
using DataBaseWorker.Commands;
using DataBaseWorker.Models;
using MediatR;

namespace DataBaseWorker.Handlers
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Category>
    {
        private readonly ApplicationDb _db = new ApplicationDb();

        public async Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
           await _db.AddCategoryAsync(request.category);
            return request.category;
        }
    }
}
