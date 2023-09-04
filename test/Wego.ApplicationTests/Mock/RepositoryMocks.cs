
//using Wego.Application.Models.Common;

//namespace Wego.ApplicationTests.Mock
//{
//    public class RepositoryMocks
//    {
//        public static Mock<IBaseRepository<Category>> GetCategoryRepository()
//        {

//            var categories = new List<Category>
//            {
//                new Category
//                {
//                   Id = 1,
//                    Name = "Concerts"
//                },
//                new Category
//                {
//                    Id = 2,
//                    Name = "Musicals"
//                },
//                new Category
//                {
//                    Id = 3,
//                    Name = "Conferences"
//                },
//                 new Category
//                {
//                    Id = 3,
//                    Name = "Plays"
//                }
//            };

//            var mockCategoryRepository = new Mock<IBaseRepository<Category>>();
//            mockCategoryRepository.Setup(repo => repo.GetAllAsync(CacheDuration.OneHour, default)).ReturnsAsync(categories);

//            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
//                (Category category) =>
//                {
//                    categories.Add(category);
//                    return category;
//                });

//            return mockCategoryRepository;
//        }

//    }
//}
