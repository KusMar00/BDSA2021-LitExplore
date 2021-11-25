using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LitExplore.Repository;
public class LitExploreContext : DbContext
{
    public LitExploreContext(DbContextOptions<LitExploreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}

public class LitExploreContextFactory : IDesignTimeDbContextFactory<LitExploreContext>
{
    public LitExploreContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets<Database>()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString(Database.ConnectionStringName);

        var optionsBuilder = new DbContextOptionsBuilder<LitExploreContext>()
            .UseSqlServer(connectionString);

        return new LitExploreContext(optionsBuilder.Options);
    }
}
