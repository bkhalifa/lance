//using FluentValidation.TestHelper;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;
//using Wego.Application.Features.Locations.Queries;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

//namespace Wego.ApplicationTests.Categories.Queries
//{
//    public class GetLocationsByQueryListQueryHandlerTests
//    {
//        private readonly Mock<IDataManager> _dataManagerMock;
//        private readonly GetLocationsByQueryListQueryValidator _validator;
//        public GetLocationsByQueryListQueryHandlerTests()
//        {
//            _dataManagerMock = new Mock<IDataManager>();
//            _validator = new GetLocationsByQueryListQueryValidator();
//        }

//        [Theory]
//        [InlineData("par")]
//        public async Task GetLocationsByQueryList_Returns_ListOf_GetLocationsByQueryModel(string query)
//        {
//            //Arrange
//            var expectedResult = new List<GetLocationsByQueryModel> {
//                new GetLocationsByQueryModel() { Code = "paris" },
//                new GetLocationsByQueryModel() { Code = "parly" },
//                new GetLocationsByQueryModel() { Code = "mpar" }
//            };


//            _dataManagerMock.Setup(x => x.GetListAsync<GetLocationsByQueryModel>(It.IsAny<string>(), It.IsAny<List<SqlParameter>>(), default)).ReturnsAsync(expectedResult);

//            // Act
//            var handler = new GetLocationsByQueryListQueryHandler(_dataManagerMock.Object);

//            var result = await handler.Handle(new GetLocationsByQueryListQuery(query), CancellationToken.None);

//            //Assert
//            Assert.NotNull(result);
//            Assert.IsType<List<GetLocationsByQueryModel>>(result);
//            Assert.Equal(3, result.Count());
//        }

//        [Theory]
//        [InlineData("paris")]
//        public async Task GetLocationsByCodeList_Returns_Empty(string code)
//        {
//            //Arrange
//            _dataManagerMock.Setup(x => x.GetListAsync<GetLocationsByQueryModel>(It.IsAny<string>(), It.IsAny<List<SqlParameter>>(), default))
//                .ReturnsAsync(() => new List<GetLocationsByQueryModel>());

//            // Act
//            var handler = new GetLocationsByQueryListQueryHandler(_dataManagerMock.Object);

//            var result = await handler.Handle(new GetLocationsByQueryListQuery(code), CancellationToken.None);

//            //Assert
//            Assert.Empty(result);
//            Assert.IsType<List<GetLocationsByQueryModel>>(result);
//        }

//        [Theory]
//        [InlineData("")]
//        [InlineData(null)]
//        public void GetLocationsByCodeList_Validate_Query_Required(string str)
//        {
//            var query = new GetLocationsByQueryListQuery(str);
//            var result = _validator.TestValidate(query);
//            result.ShouldHaveValidationErrorFor(x => x.Query);
//        }
//        [Theory]
//        [InlineData("a")]
//        public void GetLocationsByCodeList_Validate_Query_MinLength(string str)
//        {
//            var query = new GetLocationsByQueryListQuery(str);
//            var result = _validator.TestValidate(query);
//            result.ShouldHaveValidationErrorFor(x => x.Query);
//        }
//    }

//}
