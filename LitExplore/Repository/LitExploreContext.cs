using Microsoft.EntityFrameworkCore;

namespace LitExplore.Repository;
public class LitExploreContext : DbContext
{
    public LitExploreContext(DbContextOptions<LitExploreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
