
using Microsoft.EntityFrameworkCore;

using Wego.Application.Contracts;
using Wego.Domain.Common;

namespace Wego.Persistence.EF;

public partial class PortoDbContext : DbContext
{

    private readonly ILoggedInUserService _loggedInUserService;

    public PortoDbContext(DbContextOptions<PortoDbContext> options, ILoggedInUserService loggedInUserService)
          : base(options)
    {
        _loggedInUserService = loggedInUserService;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = _loggedInUserService.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
