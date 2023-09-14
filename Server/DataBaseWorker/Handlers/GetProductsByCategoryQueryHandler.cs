using DataBaseWorker.Handlers;
using DataBaseWorker.Models;
using DataBaseWorker.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWorker.Handlers
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, List<Product>>
    {
        private readonly ApplicationDb _db = new ApplicationDb();


        public async Task<List<Product>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetProductsByCategoryAsync(request.id);
        }
    }
}