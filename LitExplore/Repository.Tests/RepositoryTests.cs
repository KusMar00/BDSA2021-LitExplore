using System.IO;

namespace LitExplore.Repository.Tests
{
    public class RepositoryTests : IDisposable
    {
        private readonly Database database;

        private LitExploreContext Context { get => database.Context; }

        public RepositoryTests()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<LitExploreContext>();
            builder.UseSqlite(connection);
            database = new(builder.Options);
        }

        public void Dispose() => Context.Dispose();

        [Fact]
        public void SeedTest()
        {
            File.WriteAllText("appsettings.json", "{}");
            var db = new Database();
            db.Seed();
        }
    }
}