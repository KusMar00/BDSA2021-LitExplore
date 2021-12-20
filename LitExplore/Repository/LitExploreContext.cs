using Microsoft.EntityFrameworkCore;

namespace LitExplore.Repository;
public class LitExploreContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Paper> Papers => Set<Paper>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<User> Users => Set<User>();

    public LitExploreContext(DbContextOptions<LitExploreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Collaborators)
            .WithMany(u => u.HasAccessTo);
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Owner)
            .WithMany(u => u.IsOwnerOf);
        modelBuilder.Entity<Project>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Paper>() // 'Relation' in the application model.
            .HasMany(p => p.Citings)
            .WithMany(p => p.CitedBy);

        modelBuilder.Entity<User>() // Squish SQLite bugs.
            .Property(p => p.Id)
            .HasConversion(u => u, u => u);
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Id)
            .IsUnique();
    }
}
