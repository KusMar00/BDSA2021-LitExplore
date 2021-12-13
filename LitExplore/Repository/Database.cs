
namespace LitExplore.Repository;
public partial class Database
{
    internal const string ConnectionStringName = "LitExplore";

    /// <summary>
    /// Create a Database with default options using the connection string named 'LitExplore' in LitExplore.Repository.
    /// </summary>
    public static void SetupDatabase(LitExploreContext context)
    {
        if (context.Database.GetService<IRelationalDatabaseCreator>().Exists())
        { // If the database exists, just apply migrations.
            context.Database.Migrate();
        }
        else
        { // Otherwise, create and seed the database.
            Seed(context);
        }
    }

    public static DbContextOptionsBuilder<LitExploreContext> GetOptionsBuilder()
    {
        var optionsBuilder = new DbContextOptionsBuilder<LitExploreContext>()
            .UseSqlServer(GetConnectionString());
        return optionsBuilder;
    }

    public static string GetConnectionString()
    {
        var configuration = LoadConfiguration();
        var connectionString = configuration.GetConnectionString(ConnectionStringName);
        return connectionString;
    }

    public static IConfiguration LoadConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Database>();

        return configuration.Build();
    }
}
