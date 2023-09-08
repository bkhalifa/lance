using MediatR;

using Wego.Application.IRepo;

namespace Wego.Application.Features.Categories.Queries
{
    public record GetCategoriesListQuery() : IRequest<List<CategoryModel>>;

    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryModel>>
    {
        private readonly ICategoryRepository _categoryRepository;


        public GetCategoriesListQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
         => (await _categoryRepository.GetAllAsync()).ToList();

    }
}
