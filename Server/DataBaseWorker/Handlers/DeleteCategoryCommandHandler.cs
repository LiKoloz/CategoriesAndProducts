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
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, object>
    {
        private readonly ApplicationDb _db = new ApplicationDb();

        public async Task<object> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _db.DeleteCategoryAsync(request.id);
            return new object();
        }
    }
}
