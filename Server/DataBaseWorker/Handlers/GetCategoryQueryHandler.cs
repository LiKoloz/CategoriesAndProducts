using DataBaseWorker.Models;
using DataBaseWorker.Queries;
using MediatR;


namespace DataBaseWorker.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly ApplicationDb _db = new ApplicationDb();
    

        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetAllCategoriesAsync();
        }
    }
}
