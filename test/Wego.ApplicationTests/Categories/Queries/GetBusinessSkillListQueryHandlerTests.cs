using Moq;
using System;
using System.Collections.Generic;
using Wego.Application.Features.Skills.Queries;
using Wego.Application.Models.Common;

namespace Wego.ApplicationTests.Categories.Queries
{
    public class GetBusinessSkillListQueryHandlerTests
    {
        private readonly Mock<IBaseRepository<BusinessSkill>> _businessSkillRepositoryMock;
        public GetBusinessSkillListQueryHandlerTests()
        {
            _businessSkillRepositoryMock = new Mock<IBaseRepository<BusinessSkill>>();
        }

        [Fact]
        public async Task GetBusinessSkillListQuery_Returns_ListOf_GetBusinessSkillModel()
        {
            //Arrange
            var expectedResult= new List<BusinessSkill>()
            {
                new BusinessSkill() { Id = 1},
                new BusinessSkill() { Id = 2},
                new BusinessSkill() { Id = 3},
            };
            _businessSkillRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(expectedResult);

            // Act
            var handler = new GetBusinessSkillListQueryHandler(_businessSkillRepositoryMock.Object);

            var result = await handler.Handle(new GetBusinessSkillListQuery(), CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<GetBusinessSkillModel>>(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetBusinessSkillListQuery_Returns_Empty()
        {
            //Arrange
            _businessSkillRepositoryMock.Setup(x => x.GetAllAsync(CacheDuration.OneMonth, default)).ReturnsAsync(() => new List<BusinessSkill>());

            // Act
            var handler = new GetBusinessSkillListQueryHandler(_businessSkillRepositoryMock.Object);

            var result = await handler.Handle(new GetBusinessSkillListQuery(), CancellationToken.None);

            //Assert
            Assert.Empty(result);
            Assert.IsType<List<GetBusinessSkillModel>>(result);
        }

    }
}
