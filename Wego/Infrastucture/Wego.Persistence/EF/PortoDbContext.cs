
using Microsoft.EntityFrameworkCore;

using Wego.Domain.Entities;

namespace Wego.Persistence.EF;

public partial class PortoDbContext : DbContext
{

    public virtual DbSet<BusinessSkill> BusinessSkills { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<ContractType> ContractTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DocVisibility> DocVisibilities { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<ExperienceYear> ExperienceYears { get; set; }

    public virtual DbSet<FrancoCountry> FrancoCountries { get; set; }

    public virtual DbSet<JobLevel> JobLevels { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LocationsSearch> LocationsSearches { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<OffersSearch> OffersSearches { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<TrainShip> TrainShips { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UserVisibility> UserVisibilities { get; set; }

    public virtual DbSet<WorkType> WorkTypes { get; set; }

    public virtual DbSet<ZipCode> ZipCodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=porto;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.City)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cities_ZipCodes");

            entity.HasOne(d => d.Region).WithMany(p => p.Cities).HasConstraintName("FK_Cities_Regions");
        });

        modelBuilder.Entity<ContractType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ContractType");

            entity.Property(e => e.Code).IsFixedLength();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Code).IsFixedLength();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Code).IsFixedLength();
        });

        modelBuilder.Entity<DocVisibility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DocVisib__3214EC07263E13BE");

            entity.HasOne(d => d.Doc).WithOne(p => p.DocVisibility).HasConstraintName("FK__DocVisibi__DocId__07E124C1");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC07E28C52AA");

            entity.HasOne(d => d.UserProfile).WithOne(p => p.Document)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userprofile_documents");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3214EC0712A2554F");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.Experiences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Experienc__UserP__08D548FA");
        });

        modelBuilder.Entity<ExperienceYear>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ExperienceLevels");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<FrancoCountry>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_About");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.Languages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Languages__UserP__09C96D33");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasOne(d => d.Catgeory).WithMany(p => p.Offers).HasConstraintName("FK_Offers_Categories");

            entity.HasOne(d => d.CatgeoryNavigation).WithMany(p => p.Offers).HasConstraintName("FK_Offers_ContractType");

            entity.HasOne(d => d.Customer).WithMany(p => p.Offers).HasConstraintName("FK_Offers_Customers");

            entity.HasOne(d => d.ExperienceYear).WithMany(p => p.Offers).HasConstraintName("FK_Offers_ExperienceLevels");

            entity.HasOne(d => d.WorkType).WithMany(p => p.Offers).HasConstraintName("FK_Offers_WorkType");

            entity.HasOne(d => d.ZipCode).WithMany(p => p.Offers).HasConstraintName("FK_Offers_ZipCodes");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasOne(d => d.Country).WithMany(p => p.Regions).HasConstraintName("FK_Regions_Countries");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_config.Skills");

            entity.HasMany(d => d.Offers).WithMany(p => p.Skills)
                .UsingEntity<Dictionary<string, object>>(
                    "OfferSkill",
                    r => r.HasOne<Offer>().WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OfferSkills_Offers"),
                    l => l.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OfferSkills_Skills"),
                    j =>
                    {
                        j.HasKey("SkillId", "OfferId").HasName("PK_OfferCategories");
                        j.ToTable("OfferSkills");
                    });
        });

        modelBuilder.Entity<TrainShip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TrainShi__3214EC07EC1EEEC2");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.TrainShips)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TrainShip__UserP__0ABD916C");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserProf__3214EC073DC57FDB");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsVisible).HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdateDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<UserVisibility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserVisi__3213E83FC86C941F");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserVisibilities).HasConstraintName("FK__UserVisib__userP__0BB1B5A5");
        });

        modelBuilder.Entity<WorkType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_config.WorkType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
