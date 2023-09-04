using Wego.Application.Features.Jobs.Queries;
using Wego.Application.Models.Common;

namespace Wego.ApplicationTests.Categories.Queries
{
    public class GetContractTypeListQueryHandlerTests
    {
        private readonly Mock<IBaseRepository<ContractType>> _contractTypeRepositoryMock;
        public GetContractTypeListQueryHandlerTests()
        {
            _contractTypeRepositoryMock = new Mock<IBaseRepository<ContractType>>();
        }

        [Fact]
        public async Task GetContractTypeListQuery_Returns_ListOf_GetContractTypeModel()
        {
            //Arrange
            var expectedResult= new List<ContractType>()
            {
                new ContractType() { Id = 1},
                new ContractType() { Id = 2},
                new ContractType() { Id = 3},
            };
            _contractTypeRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(expectedResult);

            // Act
            var handler = new GetContractTypeListQueryHandler(_contractTypeRepositoryMock.Object);

            var result = await handler.Handle(new GetContractTypeListQuery(), CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<ContractTypeModel>>(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetContractTypeListQuery_Returns_Empty()
        {
            //Arrange
            _contractTypeRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(() => new List<ContractType>());

            // Act
            var handler = new GetContractTypeListQueryHandler(_contractTypeRepositoryMock.Object);

            var result = await handler.Handle(new GetContractTypeListQuery(), CancellationToken.None);

            //Assert
            Assert.Empty(result);
            Assert.IsType<List<ContractTypeModel>>(result);
        }

    }
}
