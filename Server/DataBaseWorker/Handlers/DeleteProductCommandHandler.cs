using DataBaseWorker.Commands;
using DataBaseWorker.Handlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWorker.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, object>
    {
        private readonly ApplicationDb _db = new ApplicationDb();

        public async Task<object> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _db.DeleteProductAsync(request.id);
            return new object();
        }
    }
}
