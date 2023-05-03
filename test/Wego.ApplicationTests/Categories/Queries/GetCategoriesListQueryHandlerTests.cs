using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

using Moq;

using Wego.Application.Contracts.Persistence;
using Wego.Application.Features.Categories.Queries.GetCategoriesList;
using Wego.ApplicationTests.Mock;
using Wego.Domain.Entities;

namespace Wego.ApplicationTests.Categories.Queries;

public class GetCategoriesListQueryHandlerTests
{
    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;
    // comm 1
    // comm 2
    // com 3
    public GetCategoriesListQueryHandlerTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
    }

    [Fact]
    public async Task GetCategoriesListTest()
    {
        var handler = new GetCategoriesListQueryHandler(_mockCategoryRepository.Object);

        var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(4, result.Count);
    }
}
