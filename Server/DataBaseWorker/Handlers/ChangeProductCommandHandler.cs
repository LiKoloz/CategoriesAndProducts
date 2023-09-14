using DataBaseWorker.Commands;
using DataBaseWorker.Handlers;
using DataBaseWorker.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWorker.Handlers
{
    public class ChangeProductCommandHandler : IRequestHandler<ChangeProductCommand, object>
    {
        private readonly ApplicationDb _db = new ApplicationDb();

        public async Task<object> Handle(ChangeProductCommand request, CancellationToken cancellationToken)
        {
            await _db.ChangeProductAsync(request.id);
            return new object();
        }
    }
}
