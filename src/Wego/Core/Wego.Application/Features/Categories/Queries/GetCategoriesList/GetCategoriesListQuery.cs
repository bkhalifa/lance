using MediatR;
namespace Wego.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQuery : IRequest<List<CategoryListModel>>
{
}
