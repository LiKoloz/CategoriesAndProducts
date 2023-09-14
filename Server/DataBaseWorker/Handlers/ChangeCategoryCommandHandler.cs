using DataBaseWorker.Commands;
using DataBaseWorker.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWorker.Handlers
{
    public class ChangeCategoryCommandHandler : IRequestHandler<ChangeCategoryCommand, Category>
    {
        private readonly ApplicationDb _db = new ApplicationDb();

        public async Task<Category> Handle(ChangeCategoryCommand request, CancellationToken cancellationToken)
        {
            await _db.ChangeCategoryAsync(request.category);
            return request.category;
        }
    }
    
}
