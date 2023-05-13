
using Wego.Application.Features.Skills.Queries;
using Wego.Application.Models.Common;

namespace Wego.ApplicationTests.Categories.Queries
{
    public class GetSkillListQueryHandlerTests
    {
        private readonly Mock<IBaseRepository<Skill>> _skillRepositoryMock;
        public GetSkillListQueryHandlerTests()
        {
            _skillRepositoryMock = new Mock<IBaseRepository<Skill>>();
        }

        [Fact]
        public async Task GetSkillListQuery_Returns_ListOf_GetSkillModel()
        {
            //Arrange
            var expectedResult= new List<Skill>()
            {
                new Skill() { Id = 1},
                new Skill() { Id = 2},
                new Skill() { Id = 3},
            };
            _skillRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(expectedResult);

            // Act
            var handler = new GetSkillListQueryHandler(_skillRepositoryMock.Object);

            var result = await handler.Handle(new GetSkillListQuery(), CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<GetSkillModel>>(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetSkillListQuery_Returns_Empty()
        {
            //Arrange
            _skillRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(() => new List<Skill>());

            // Act
            var handler = new GetSkillListQueryHandler(_skillRepositoryMock.Object);

            var result = await handler.Handle(new GetSkillListQuery(), CancellationToken.None);

            //Assert
            Assert.Empty(result);
            Assert.IsType<List<GetSkillModel>>(result);
        }

    }
}
