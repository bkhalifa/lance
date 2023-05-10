using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Wego.Application.Features.Locations.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Wego.ApplicationTests.Categories.Queries
{
    public class GetLocationsByCodeListQueryHandlerTests
    {
        private readonly Mock<IBaseRepository<LocationsSearch>> _locationRepositoryMock;
        private readonly GetLocationsByCodeListQueryValidator _validator;
        public GetLocationsByCodeListQueryHandlerTests()
        {
            _locationRepositoryMock = new Mock<IBaseRepository<LocationsSearch>>();
            _validator = new GetLocationsByCodeListQueryValidator();
        }

        [Theory]
        [InlineData("paris")]
        public async Task GetLocationsByCodeList_Returns_ListOf_GetLocationsByCodeModel(string code)
        {
            //Arrange
            var expectedResult = new List<LocationsSearch> {
                new LocationsSearch() { Code = code },
                new LocationsSearch() { Code = code },
                new LocationsSearch() { Code = code }
            };

            _locationRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LocationsSearch, bool>>>(),null,0,default))
            .ReturnsAsync(expectedResult);

            // Act
            var handler = new GetLocationsByCodeListQueryHandler(_locationRepositoryMock.Object);

            var result = await handler.Handle(new GetLocationsByCodeListQuery(code), CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<GetLocationsByCodeModel>>(result);
            Assert.Single(result);
        }

        [Theory]
        [InlineData("paris")]
        public async Task GetLocationsByCodeList_Returns_Empty(string code)
        {
            //Arrange
            _locationRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LocationsSearch, bool>>>(), null, 0, default))
            .ReturnsAsync(()=> new List<LocationsSearch>());

            // Act
            var handler = new GetLocationsByCodeListQueryHandler(_locationRepositoryMock.Object);

            var result = await handler.Handle(new GetLocationsByCodeListQuery(code), CancellationToken.None);

            //Assert
            Assert.Empty(result);
            Assert.IsType<List<GetLocationsByCodeModel>>(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void GetLocationsByCodeList_Validate_Code_Required(string code)
        {
            var query = new GetLocationsByCodeListQuery(code);
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Code);
        }
    }

}
