using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

using Moq;

using Wego.Application.Contracts.Persistence;
using Wego.Application.Features.Categories.Queries.GetCategoriesList;
using Wego.Applocation.Tests.Mocks;
using Wego.Domain.Entities;

namespace Wego.Applocation.Tests.Categories.Queries;

public class GetCategoriesListQueryHandlerTests
{

    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

    public GetCategoriesListQueryHandlerTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
    }

    [Fact]
    public async Task GetCategoriesListTest()
    {
        var handler = new GetCategoriesListQueryHandler(_mockCategoryRepository.Object);

        var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

        Assert.Equal(4, result.Count);
    }
}
