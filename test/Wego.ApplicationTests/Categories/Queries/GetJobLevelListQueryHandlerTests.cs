using Wego.Application.Features.Jobs.Queries;
using Wego.Application.Models.Common;

namespace Wego.ApplicationTests.Categories.Queries
{
    public class GetJobLevelListQueryHandlerTests
    {
        private readonly Mock<IBaseRepository<JobLevel>> _jobLevelRepositoryMock;
        public GetJobLevelListQueryHandlerTests()
        {
            _jobLevelRepositoryMock = new Mock<IBaseRepository<JobLevel>>();
        }

        [Fact]
        public async Task GetJobLevelListQuery_Returns_ListOf_GetJobLevelModel()
        {
            //Arrange
            var expectedResult= new List<JobLevel>()
            {
                new JobLevel() { Id = 1},
                new JobLevel() { Id = 2},
                new JobLevel() { Id = 3},
            };
            _jobLevelRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(expectedResult);

            // Act
            var handler = new GetJobLevelListQueryHandler(_jobLevelRepositoryMock.Object);

            var result = await handler.Handle(new GetJobLevelListQuery(), CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<GetJobLevelModel>>(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetJobLevelListQuery_Returns_Empty()
        {
            //Arrange
            _jobLevelRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(() => new List<JobLevel>());

            // Act
            var handler = new GetJobLevelListQueryHandler(_jobLevelRepositoryMock.Object);

            var result = await handler.Handle(new GetJobLevelListQuery(), CancellationToken.None);

            //Assert
            Assert.Empty(result);
            Assert.IsType<List<GetJobLevelModel>>(result);
        }

    }
}
