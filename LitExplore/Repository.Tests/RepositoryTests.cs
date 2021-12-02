namespace LitExplore.Repository.Tests;

public abstract class RepositoryTests : IDisposable
{
    private readonly Database database;

    protected LitExploreContext Context { get => database.Context; }

    public RepositoryTests()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var builder = new DbContextOptionsBuilder<LitExploreContext>();
        builder.UseSqlite(connection);
        database = new(builder.Options);
        Context.Database.EnsureCreated();
        SeedDatabase();
    }

    public void Dispose()
    {
        Context.Dispose();
        GC.SuppressFinalize(this);
    }

    protected abstract void SeedDatabase();
}
