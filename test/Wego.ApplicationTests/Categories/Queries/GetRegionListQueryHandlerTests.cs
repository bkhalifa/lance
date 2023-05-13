using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wego.Application.Features.Locations.Queries;
using Wego.Application.Models.Common;

namespace Wego.ApplicationTests.Categories.Queries
{
    public class GetRegionListQueryHandlerTests
    {
        private readonly Mock<IBaseRepository<Region>> _RegionRepositoryMock;
        public GetRegionListQueryHandlerTests()
        {
            _RegionRepositoryMock = new Mock<IBaseRepository<Region>>();
        }

        [Fact]
        public async Task GetRegionListQuery_Returns_ListOf_GetRegionModel()
        {
            //Arrange
            var expectedResult= new List<Region>()
            {
                new Region() { Id = 1},
                new Region() { Id = 2},
                new Region() { Id = 3},
            };
            _RegionRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(expectedResult);

            // Act
            var handler = new GetRegionListQueryHandler(_RegionRepositoryMock.Object);

            var result = await handler.Handle(new GetRegionListQuery(), CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<GetRegionModel>>(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetRegionListQuery_Returns_Empty()
        {
            //Arrange
            _RegionRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(() => new List<Region>());

            // Act
            var handler = new GetRegionListQueryHandler(_RegionRepositoryMock.Object);

            var result = await handler.Handle(new GetRegionListQuery(), CancellationToken.None);

            //Assert
            Assert.Empty(result);
            Assert.IsType<List<GetRegionModel>>(result);
        }

    }
}
