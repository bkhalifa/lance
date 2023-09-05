//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Wego.Application.Features.Locations.Queries;
//using Wego.Application.Models.Common;

//namespace Wego.ApplicationTests.Categories.Queries
//{
//    public class GetCountryListQueryHandlerTests
//    {
//        private readonly Mock<IBaseRepository<Country>> _countryRepositoryMock;
//        public GetCountryListQueryHandlerTests()
//        {
//            _countryRepositoryMock = new Mock<IBaseRepository<Country>>();
//        }

//        [Fact]
//        public async Task GetRegionListQuery_Returns_ListOf_GetCountryModel()
//        {
//            //Arrange
//            var expectedResult= new List<Country>()
//            {
//                new Country() { Id = 1},
//                new Country() { Id = 2},
//                new Country() { Id = 3},
//            };
//            _countryRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(expectedResult);

//            // Act
//            var handler = new GetCountryListQueryHandler(_countryRepositoryMock.Object);

//            var result = await handler.Handle(new GetCountryListQuery(), CancellationToken.None);

//            //Assert
//            Assert.NotNull(result);
//            Assert.IsType<List<GetCountryModel>>(result);
//            Assert.Equal(3, result.Count());
//        }

//        [Fact]
//        public async Task GetRegionListQuery_Returns_Empty()
//        {
//            //Arrange
//            _countryRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(() => new List<Country>());

//            // Act
//            var handler = new GetCountryListQueryHandler(_countryRepositoryMock.Object);

//            var result = await handler.Handle(new GetCountryListQuery(), CancellationToken.None);

//            //Assert
//            Assert.Empty(result);
//            Assert.IsType<List<GetCountryModel>>(result);
//        }

//    }
//}
