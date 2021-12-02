using Microsoft.EntityFrameworkCore;

namespace LitExplore.Repository;
public class LitExploreContext : DbContext, ILitExploreContext
{
    public DbSet<Paper> Papers => Set<Paper>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Relation> Relations => Set<Relation>();
    public LitExploreContext(DbContextOptions<LitExploreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Relation>()
        .HasNoKey();
    }
}
