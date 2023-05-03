
using MediatR;



using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.Features.Categories.Queries.GetCategoriesList;
using Wego.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListModel>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;


        public GetCategoriesListQueryHandler(IAsyncRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryListModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();
            return allCategories.MapTo<List<CategoryListModel>>();
        }
    }
}
