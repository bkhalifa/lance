using Wego.Application.Features.Categories.Queries;
using Wego.ApplicationTests.Mock;

namespace Wego.ApplicationTests.Categories.Queries;

public class GetCategoriesListQueryHandlerTests
{
    private readonly Mock<IBaseRepository<Category>> _mockCategoryRepository;

    public GetCategoriesListQueryHandlerTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
    }

    /// <summary>
    /// get all ctegories
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetCategoriesListTest()
    {
        var handler = new GetCategoriesListQueryHandler(_mockCategoryRepository.Object);

        var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(4, result.Count);
    }
}
