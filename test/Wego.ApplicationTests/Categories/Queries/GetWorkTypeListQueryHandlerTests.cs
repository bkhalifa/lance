//using Wego.Application.Features.Jobs.Queries;
//using Wego.Application.Models.Common;

//namespace Wego.ApplicationTests.Categories.Queries
//{
//    public class GetWorkTypeListQueryHandlerTests
//    {
//        private readonly Mock<IBaseRepository<WorkType>> _workTypeRepositoryMock;
//        public GetWorkTypeListQueryHandlerTests()
//        {
//            _workTypeRepositoryMock = new Mock<IBaseRepository<WorkType>>();
//        }

//        [Fact]
//        public async Task GetWorkTypeListQuery_Returns_ListOf_GetWorkTypeModel()
//        {
//            //Arrange
//            var expectedResult= new List<WorkType>()
//            {
//                new WorkType() { Id = 1},
//                new WorkType() { Id = 2},
//                new WorkType() { Id = 3},
//            };
//            _workTypeRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(expectedResult);

//            // Act
//            var handler = new GetWorkTypeListQueryHandler(_workTypeRepositoryMock.Object);

//            var result = await handler.Handle(new GetWorkTypeListQuery(), CancellationToken.None);

//            //Assert
//            Assert.NotNull(result);
//            Assert.IsType<List<WorkTypeModel>>(result);
//            Assert.Equal(3, result.Count());
//        }

//        [Fact]
//        public async Task GetWorkTypeListQuery_Returns_Empty()
//        {
//            //Arrange
//            _workTypeRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(() => new List<WorkType>());

//            // Act
//            var handler = new GetWorkTypeListQueryHandler(_workTypeRepositoryMock.Object);

//            var result = await handler.Handle(new GetWorkTypeListQuery(), CancellationToken.None);

//            //Assert
//            Assert.Empty(result);
//            Assert.IsType<List<WorkTypeModel>>(result);
//        }

//    }
//}
