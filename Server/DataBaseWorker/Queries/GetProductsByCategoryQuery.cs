using DataBaseWorker.Models;
using DataBaseWorker.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWorker.Queries
{
    public record GetProductsByCategoryQuery(int id) : IRequest<List<Product>>;
}
