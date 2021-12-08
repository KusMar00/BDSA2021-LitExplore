using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace LitExplore.Repository;
public partial class Database
{
    internal const string ConnectionStringName = "LitExplore";

    public LitExploreContext Context { get; set; }

    public IPaperRepository PaperRepository { get; private set; }
    public IProjectRepository ProjectRepository { get; private set; }
    public IUserRepository UserRepository { get; private set; }

    /// <summary>
    /// Creates a Database with a custom options.
    /// </summary>
    /// <param name="options">Options to use to initialize the LitExploreContext</param>
    /// <param name="migrate">Automatically apply migrations</param>
    public Database(DbContextOptions<LitExploreContext> options, bool migrate = false)
    {
        Context = new LitExploreContext(options);
        if (migrate) Context.Database.Migrate();

        PaperRepository = new PaperRepository(Context);
        ProjectRepository = new ProjectRepository(Context);
        UserRepository = new UserRepository(Context);
    }

    /// <summary>
    /// Create a Database with default options using the connection string named 'LitExplore' in LitExplore.Repository.
    /// </summary>
    public Database()
    {
        var configuration = LoadConfiguration();
        var connectionString = configuration.GetConnectionString(ConnectionStringName);
        var optionsBuilder = new DbContextOptionsBuilder<LitExploreContext>()
            .UseSqlServer(connectionString);
        var context = new LitExploreContext(optionsBuilder.Options);
        
        if (context.Database.GetService<IRelationalDatabaseCreator>().Exists())
        { // If the database exists, just apply migrations.
            context.Database.Migrate();
        }
        else
        { // Otherwise, create and seed the database.
            Seed(context);
        }

        PaperRepository = new PaperRepository(context);
        ProjectRepository = new ProjectRepository(context);
        UserRepository = new UserRepository(context);

        Context = context;
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
