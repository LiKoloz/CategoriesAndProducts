using DataBaseWorker.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWorker.Commands
{
    public record ChangeCategoryCommand(Category category) : IRequest<Category>;
}
