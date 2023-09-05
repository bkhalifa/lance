﻿using Wego.Application.Features.Categories.Queries;

namespace Wego.Application.IRepo;

public interface ICategoryRepository 
{
    Task<IEnumerable<GetCategoriesModel>> GetAllAsync(CancellationToken cancellationToken = default);
}
