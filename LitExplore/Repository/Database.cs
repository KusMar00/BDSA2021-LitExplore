using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LitExplore.Repository;
public class Database //: IPaperRepository, IProjectRepository, IUserRepository
{
    internal const string ConnectionStringName = "LitExplore";

    public LitExploreContext Context { get; set; }

    public Database(DbContextOptions<LitExploreContext> options)
    {
        Context = new LitExploreContext(options);
        //Context.Database.Migrate();
    }

    public Database()
    {
        var configuration = LoadConfiguration();
        var connectionString = configuration.GetConnectionString(ConnectionStringName);
        var optionsBuilder = new DbContextOptionsBuilder<LitExploreContext>()
            .UseSqlServer(connectionString);
        Context = new LitExploreContext(optionsBuilder.Options);
        //Context.Database.Migrate();
    }

    public static IConfiguration LoadConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Database>();

        return configuration.Build();
    }

    /// <summary>
    /// The seed data comes from Google Scholar (https://scholar.google.com/).
    /// The seed data does not include users at these are part of the vertical slice.
    /// </summary>
    public void Seed()
    {
        /*
        Context.Database.EnsureDeleted();
        // Clean migrations.
        var migrator = Context.GetService<IMigrator>();
        migrator.Migrate("0");
        Context.Database.Migrate();
        */

        var Author_P_Esquivel = new Author { GivenName = "Patricia", Surname = "Esquivel" };
        var Author_VM_Jimenez = new Author { GivenName = "Victor M.", Surname = "Jimenez" };
        var Paper_Functional_Properties_Of_Coffee = new Paper
        {
            Authors = new HashSet<Author> { Author_P_Esquivel, Author_VM_Jimenez },
            Name = @"Functional properties of coffee and coffee by-products",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0963996911003449?casa_token=tdCQmafGfxcAAAAA:tKxOe9YNAwPLm6A_w-oKnGKZPLZu1Dug4RaZ68RKeDCfeEdjs_HFiJh0q5j-hwIEB6PBpXT0914",
            Abstract = @"Coffee, one of the most popular beverages, is consumed by millions of people every day. Traditionally, coffee beneficial effects have been attributed solely to its most intriguing and investigated ingredient, caffeine, but it is now known that other compounds also contribute to …",
        };

        var Author_A_Zurro = new Author { GivenName = "Antonio", Surname = "ZUORRO" };
        var Author_R_Lavecchia = new Author { GivenName = "Roberto", Surname = "Lavecchia" };
        var Paper_Spent_Coffee_Grounds = new Paper
        {
            Authors = new HashSet<Author>() { Author_A_Zurro, Author_R_Lavecchia },
            Name = @"Spent coffee grounds as a valuable source of phenolic compounds and bioenergy",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0959652611005117?casa_token=N76EXWDZvMoAAAAA:9ryevfBm9sXLugCElAxj47CxgJS2XQ08c-LW04yZyYo2h9DRKtKSsH0xUhqL3APxHAD0Slz2taI",
            Abstract = @"Spent coffee grounds collected from coffee bars (SCG-1) or recovered from coffee capsules (SCG-2) were investigated as a potential source of phenolic compounds and energy. Preliminary characterization of these materials provided a total phenolic content of 17.75 mg …",
        };
        var Relation_Spent_Coffee_To_Functional_Properties = new Relation
        {
            From = Paper_Spent_Coffee_Grounds,
            To = Paper_Functional_Properties_Of_Coffee
        };

        var Author_JB_Essner = new Author { GivenName = "Jerimy B.", Surname = "Essner" };
        var Author_JA_Kist = new Author { GivenName = "Jennifer A", Surname = "Kist" };
        var Author_L_Polo_Parada = new Author { GivenName = "Luis", Surname = "Polo-Parada" };
        var Paper_Artifacts_And_Errors = new Paper
        {
            Authors = new HashSet<Author>() { Author_JB_Essner, Author_JA_Kist, Author_L_Polo_Parada },
            Name = @"Artifacts and errors associated with the ubiquitous presence of fluorescent impurities in carbon nanodots",
            URL = @"https://www.academia.edu/download/55961585/2018_Artifact_and_Errors_associated_wit_Ubiquitous_presence_of_Fluorescent_impurities_in_Carbon_Nanodot.pdf",
            Abstract = @"Fluorescent carbon dots have attracted tremendous attention owing to their superlative optical properties which suggest opportunities for replacing conventional fluorescent materials in various application fields. Not surprisingly, the rapid pace of publication has …",
        };
        var Relation_Artifacts_And_Errors_To_Functional_Properties = new Relation
        {
            From = Paper_Artifacts_And_Errors,
            To = Paper_Functional_Properties_Of_Coffee
        };
    }
}
