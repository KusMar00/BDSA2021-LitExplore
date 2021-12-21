using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;


using System.Diagnostics.CodeAnalysis;

namespace LitExplore.Repository;
[ExcludeFromCodeCoverage]
public partial class Database
{
    internal const string ConnectionStringName = "LitExplore";

    /// <summary>
    /// Creates and seeds the database if it does not already exist.
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

    /// <summary>
    /// Gets the dafault options which should be used when not testing.
    /// </summary>
    public static DbContextOptionsBuilder<LitExploreContext> GetOptionsBuilder()
    {
        var optionsBuilder = new DbContextOptionsBuilder<LitExploreContext>()
            .UseSqlServer(GetConnectionString());
        return optionsBuilder;
    }

    /// <summary>
    /// Gets the connection string named 'LitExplore' in LitExplore.Repository
    /// </summary>
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
