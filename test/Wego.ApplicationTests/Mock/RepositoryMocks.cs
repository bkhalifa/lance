using Moq;

using Wego.Application.Contracts.Persistence;
using Wego.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.ApplicationTests.Mock
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
        {

            var categories = new List<Category>
            {
                new Category
                {
                   Id = 1,
                    Name = "Concerts"
                },
                new Category
                {
                    Id = 2,
                    Name = "Musicals"
                },
                new Category
                {
                    Id = 3,
                    Name = "Conferences"
                },
                 new Category
                {
                    Id = 3,
                    Name = "Plays"
                }
            };

            var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
            mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockCategoryRepository;
        }
    }
}
