﻿using Dapper;
using Wego.Application.Contracts.Infrastructure;
using Wego.Application.Features.Categories.Queries;
using Wego.Application.IRepo;
using Wego.Application.Models.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _context;
        private readonly ICacheManager _cacheManager;
        public CategoryRepository(DapperContext context, ICacheManager cacheManager)
        {
            _context = context;
            _cacheManager = cacheManager;
        }
        public async Task<IEnumerable<CategoryModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _cacheManager.GetAsync(nameof(CategoryModel), async () =>
            {
                var sql = "SELECT * FROM config.Categories";
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<CategoryModel>(sql);
                    return result.OrderBy(x => x.Audience ?? 100);
                }
            }, CacheDuration.OneDay, cancellationToken);
        }
    }
}
