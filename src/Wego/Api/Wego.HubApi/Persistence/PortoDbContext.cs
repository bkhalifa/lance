
using Microsoft.EntityFrameworkCore;


namespace Wego.HubApi.Persistence;
public partial class PortoDbContext : DbContext
{
    public PortoDbContext(DbContextOptions<PortoDbContext> options)
         : base(options)
    { }
    public virtual DbSet<Candidate> Candidates { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<Recruiter> Recruiters { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK_Candidates_1");

            entity.Property(e => e.ProfileId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}