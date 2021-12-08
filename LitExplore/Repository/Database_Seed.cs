using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LitExplore.Repository;
public partial class Database
{
    /// <summary>
    /// The seed data comes from Google Scholar (https://scholar.google.com/).
    /// The seed data does not include users at these are part of the vertical slice.
    /// </summary>
    public void Seed(LitExploreContext context)
    {
        context.Database.EnsureDeleted();
        // Clean migrations.
        var migrator = context.GetService<IMigrator>();
        migrator.Migrate("0");
        context.Database.Migrate();

        // Template for adding papers
        /*

        var Author_GivenName_Surname = new Author { GivenName = "", Surname = "" };
        var PaperName = new Paper
        {
            Authors = new HashSet<Author>() { Author_GivenName_Surname },
            Name = @"",
            URL = @"",
            Abstract = @"",
            Citings = new List<Paper> {  }
        };
        context.Papers.Add(PaperName);
        
        */
        // Template for adding papers

        var Author_P_Esquivel = new Author { GivenName = "Patricia", Surname = "Esquivel" };
        var Author_VM_Jimenez = new Author { GivenName = "Victor M.", Surname = "Jimenez" };
        var Paper_Functional_Properties_Of_Coffee = new Paper
        {
            Authors = new HashSet<Author> { Author_P_Esquivel, Author_VM_Jimenez },
            Name = @"Functional properties of coffee and coffee by-products",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0963996911003449?casa_token=tdCQmafGfxcAAAAA:tKxOe9YNAwPLm6A_w-oKnGKZPLZu1Dug4RaZ68RKeDCfeEdjs_HFiJh0q5j-hwIEB6PBpXT0914",
            Abstract = @"Coffee, one of the most popular beverages, is consumed by millions of people every day. Traditionally, coffee beneficial effects have been attributed solely to its most intriguing and investigated ingredient, caffeine, but it is now known that other compounds also contribute to …",
        };
        context.Papers.Add(Paper_Functional_Properties_Of_Coffee);

        var Author_A_Zurro = new Author { GivenName = "Antonio", Surname = "ZUORRO" };
        var Author_R_Lavecchia = new Author { GivenName = "Roberto", Surname = "Lavecchia" };
        var Paper_Spent_Coffee_Grounds = new Paper
        {
            Authors = new HashSet<Author>() { Author_A_Zurro, Author_R_Lavecchia },
            Name = @"Spent coffee grounds as a valuable source of phenolic compounds and bioenergy",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0959652611005117?casa_token=N76EXWDZvMoAAAAA:9ryevfBm9sXLugCElAxj47CxgJS2XQ08c-LW04yZyYo2h9DRKtKSsH0xUhqL3APxHAD0Slz2taI",
            Abstract = @"Spent coffee grounds collected from coffee bars (SCG-1) or recovered from coffee capsules (SCG-2) were investigated as a potential source of phenolic compounds and energy. Preliminary characterization of these materials provided a total phenolic content of 17.75 mg …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Paper_Spent_Coffee_Grounds);

        var Author_Y_Narita = new Author { GivenName = "Y", Surname = "Narita" };
        var Author_K_Inouye = new Author { GivenName = "K", Surname = "Inouye" };
        var Review_On_Utilization_And_Composition_of_Coffee_Silverskin = new Paper
        {
            Authors = new HashSet<Author>() { Author_Y_Narita, Author_K_Inouye },
            Name = @"Review on utilization and composition of coffee silverskin",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0963996914000295?casa_token=2IWcGZxe2gQAAAAA:xZPHNHZgDB0snvQbAL1AlWQXTVXBjjG5R6Eh0SLgQz5ufhyVAQry_dOc9IpEMqMsXGkSEwx4",
            Abstract = @"Coffee is one of the most frequently consumed drinks in the world. Coffee silverskin (CS) is the only by-product produced during the coffee beans roasting process, and large amounts of CS are produced by roasters in coffee-consuming countries. However, methods for the …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Review_On_Utilization_And_Composition_of_Coffee_Silverskin);

        var Author_JB_Essner = new Author { GivenName = "Jerimy B.", Surname = "Essner" };
        var Author_JA_Kist = new Author { GivenName = "Jennifer A", Surname = "Kist" };
        var Author_L_Polo_Parada = new Author { GivenName = "Luis", Surname = "Polo-Parada" };
        var Paper_Artifacts_And_Errors = new Paper
        {
            Authors = new HashSet<Author>() { Author_JB_Essner, Author_JA_Kist, Author_L_Polo_Parada },
            Name = @"Artifacts and errors associated with the ubiquitous presence of fluorescent impurities in carbon nanodots",
            URL = @"https://www.academia.edu/download/55961585/2018_Artifact_and_Errors_associated_wit_Ubiquitous_presence_of_Fluorescent_impurities_in_Carbon_Nanodot.pdf",
            Abstract = @"Fluorescent carbon dots have attracted tremendous attention owing to their superlative optical properties which suggest opportunities for replacing conventional fluorescent materials in various application fields. Not surprisingly, the rapid pace of publication has …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Paper_Artifacts_And_Errors);

        var Author_Marija_Ranic = new Author { GivenName = "Marija", Surname = "Ranic" };
        var Author_Marina_Nikolic = new Author { GivenName = "Marina", Surname = "Nikolic" };
        var Author_Marija_Pavlovic = new Author { GivenName = "Marija", Surname = "Pavlovic" };
        var Author_Aneta_Buntic = new Author { GivenName = "Aneta", Surname = "Buntic" };
        var Author_Slavica_SilerMarinkovic = new Author { GivenName = "Slavica", Surname = "Siler-Marinkovic" };
        var Author_Suzana_DimitrijevicBrankovic = new Author { GivenName = "Suzana", Surname = "Dimitrijevic-Brankovic" };
        var Optimization_Of_Microwaveassisted_Extraction = new Paper
        {
            Authors = new HashSet<Author>() { Author_Marija_Ranic, Author_Marina_Nikolic, Author_Marija_Pavlovic, Author_Aneta_Buntic, Author_Slavica_SilerMarinkovic, Author_Suzana_DimitrijevicBrankovic },
            Name = @"Optimization of microwave-assisted extraction of natural antioxidants from spent espresso coffee grounds by response surface methodology",
            URL = @"https://www.sciencedirect.com/science/article/pii/S095965261400537X?casa_token=1lyRzLyglDoAAAAA:VuWYbjcyByJosGFptXcla5QmDSd9Tki-WBgfJb44AShJoIcf7HxBVlxvYImVgMR7Qg2EpUzZ",
            Abstract = @"Espresso spent coffee grounds (SCG) that is a waste material abundantly produced by restaurants, cafeterias and in domestic environment could be used as a low-cost and rich source of valuable polyphenol compounds. The benefit would be twofold: extraction of …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Optimization_Of_Microwaveassisted_Extraction);

        context.SaveChanges();
    }
}
