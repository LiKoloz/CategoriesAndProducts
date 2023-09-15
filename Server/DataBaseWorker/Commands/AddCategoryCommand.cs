using DataBaseWorker.Models;
using MediatR;
using System.ComponentModel;


namespace DataBaseWorker.Commands
{
    public record AddCategoryCommand(Category category) : IRequest<Category>;
}
