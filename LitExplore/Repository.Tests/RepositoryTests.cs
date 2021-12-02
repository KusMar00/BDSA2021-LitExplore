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
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        // Enable this test and run it to seed the database without running the whole program. 
        [Fact(Skip = "We don't want to modify the live database when testing.")]
        public void SeedTest()
        {
            File.WriteAllText("appsettings.json", "{}");
            var db = new Database();
            db.Seed();
        }
    }
}