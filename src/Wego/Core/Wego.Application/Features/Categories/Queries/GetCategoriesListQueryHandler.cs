using MediatR;

using Wego.Application.IRepo;

namespace Wego.Application.Features.Categories.Queries
{
    public record GetCategoriesListQuery() : IRequest<List<GetCategoriesModel>>;

    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<GetCategoriesModel>>
    {
        private readonly ICategoryRepository _categoryRepository;


        public GetCategoriesListQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetCategoriesModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
         => (await _categoryRepository.GetAllAsync()).ToList();

    }
}
