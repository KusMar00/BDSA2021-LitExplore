namespace LitExplore.Repository.Tests;

public abstract class RepositoryTests : IDisposable
{
    protected LitExploreContext Context { get; private set; }

    public RepositoryTests()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var builder = new DbContextOptionsBuilder<LitExploreContext>();
        builder.UseSqlite(connection);
        Context = new(builder.Options);
        Context.Database.EnsureCreated();
        SeedDatabase();
    }

    public void Dispose()
    {
        Context.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Use this to seed the database for tests.
    /// </summary>
    protected abstract void SeedDatabase();
}
