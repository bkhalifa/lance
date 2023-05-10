using MediatR;

using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.Models.Common;
using Wego.Domain.Entities;


namespace Wego.Application.Features.Categories.Queries
{
    public record GetCategoriesListQuery() : IRequest<List<GetCategoriesModel>>;

    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<GetCategoriesModel>>
    {
        private readonly IBaseRepository<Category> _categoryRepository;


        public GetCategoriesListQueryHandler(IBaseRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetCategoriesModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryRepository.GetAllAsync(CacheDuration.OneHour)).OrderBy(x => x.Name).ToList();
            return allCategories.MapTo<List<GetCategoriesModel>>();
        }
    }
}
