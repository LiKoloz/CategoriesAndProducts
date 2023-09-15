using DataBaseWorker.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWorker.Queries
{
    public record GetCategoriesQuery : IRequest<List<Category>>;
}
