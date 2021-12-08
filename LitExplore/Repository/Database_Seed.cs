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

        Author
            Author_GN_Surname = new() { GivenName = "", Surname = "" },
            Author_GN_Surname = new() { GivenName = "", Surname = "" };
        
        Paper PaperName = new()
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

        Author
            Author_P_Esquivel = new() { GivenName = "Patricia", Surname = "Esquivel" },
            Author_VM_Jimenez = new() { GivenName = "Victor M.", Surname = "Jimenez" };

        Paper Paper_Functional_Properties_Of_Coffee = new()
        {
            Authors = new HashSet<Author> { Author_P_Esquivel, Author_VM_Jimenez },
            Name = @"Functional properties of coffee and coffee by-products",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0963996911003449?casa_token=tdCQmafGfxcAAAAA:tKxOe9YNAwPLm6A_w-oKnGKZPLZu1Dug4RaZ68RKeDCfeEdjs_HFiJh0q5j-hwIEB6PBpXT0914",
            Abstract = @"Coffee, one of the most popular beverages, is consumed by millions of people every day. Traditionally, coffee beneficial effects have been attributed solely to its most intriguing and investigated ingredient, caffeine, but it is now known that other compounds also contribute to …",
        };
        context.Papers.Add(Paper_Functional_Properties_Of_Coffee);


        Author
            Author_A_Zuorro = new() { GivenName = "Antonio", Surname = "ZUORRO" },
            Author_R_Lavecchia = new() { GivenName = "Roberto", Surname = "Lavecchia" };

        Paper Paper_Spent_Coffee_Grounds = new()
        {
            Authors = new HashSet<Author>() { Author_A_Zuorro, Author_R_Lavecchia },
            Name = @"Spent coffee grounds as a valuable source of phenolic compounds and bioenergy",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0959652611005117?casa_token=N76EXWDZvMoAAAAA:9ryevfBm9sXLugCElAxj47CxgJS2XQ08c-LW04yZyYo2h9DRKtKSsH0xUhqL3APxHAD0Slz2taI",
            Abstract = @"Spent coffee grounds collected from coffee bars (SCG-1) or recovered from coffee capsules (SCG-2) were investigated as a potential source of phenolic compounds and energy. Preliminary characterization of these materials provided a total phenolic content of 17.75 mg …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Paper_Spent_Coffee_Grounds);


        Author
            Author_Y_Narita = new() { GivenName = "Y", Surname = "Narita" },
            Author_K_Inouye = new() { GivenName = "K", Surname = "Inouye" };

        Paper Review_On_Utilization_And_Composition_of_Coffee_Silverskin = new()
        {
            Authors = new HashSet<Author>() { Author_Y_Narita, Author_K_Inouye },
            Name = @"Review on utilization and composition of coffee silverskin",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0963996914000295?casa_token=2IWcGZxe2gQAAAAA:xZPHNHZgDB0snvQbAL1AlWQXTVXBjjG5R6Eh0SLgQz5ufhyVAQry_dOc9IpEMqMsXGkSEwx4",
            Abstract = @"Coffee is one of the most frequently consumed drinks in the world. Coffee silverskin (CS) is the only by-product produced during the coffee beans roasting process, and large amounts of CS are produced by roasters in coffee-consuming countries. However, methods for the …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Review_On_Utilization_And_Composition_of_Coffee_Silverskin);


        Author
            Author_JB_Essner = new() { GivenName = "Jerimy B.", Surname = "Essner" },
            Author_JA_Kist = new() { GivenName = "Jennifer A", Surname = "Kist" },
            Author_L_Polo_Parada = new() { GivenName = "Luis", Surname = "Polo-Parada" };

        Paper Paper_Artifacts_And_Errors = new()
        {
            Authors = new HashSet<Author>() { Author_JB_Essner, Author_JA_Kist, Author_L_Polo_Parada },
            Name = @"Artifacts and errors associated with the ubiquitous presence of fluorescent impurities in carbon nanodots",
            URL = @"https://www.academia.edu/download/55961585/2018_Artifact_and_Errors_associated_wit_Ubiquitous_presence_of_Fluorescent_impurities_in_Carbon_Nanodot.pdf",
            Abstract = @"Fluorescent carbon dots have attracted tremendous attention owing to their superlative optical properties which suggest opportunities for replacing conventional fluorescent materials in various application fields. Not surprisingly, the rapid pace of publication has …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Paper_Artifacts_And_Errors);


        Author
            Author_Marija_Ranic = new() { GivenName = "Marija", Surname = "Ranic" },
            Author_Marina_Nikolic = new() { GivenName = "Marina", Surname = "Nikolic" },
            Author_Marija_Pavlovic = new() { GivenName = "Marija", Surname = "Pavlovic" },
            Author_Aneta_Buntic = new() { GivenName = "Aneta", Surname = "Buntic" },
            Author_Slavica_SilerMarinkovic = new() { GivenName = "Slavica", Surname = "Siler-Marinkovic" },
            Author_Suzana_DimitrijevicBrankovic = new() { GivenName = "Suzana", Surname = "Dimitrijevic-Brankovic" };

        Paper Optimization_Of_Microwaveassisted_Extraction = new()
        {
            Authors = new HashSet<Author>() { Author_Marija_Ranic, Author_Marina_Nikolic, Author_Marija_Pavlovic, Author_Aneta_Buntic, Author_Slavica_SilerMarinkovic, Author_Suzana_DimitrijevicBrankovic },
            Name = @"Optimization of microwave-assisted extraction of natural antioxidants from spent espresso coffee grounds by response surface methodology",
            URL = @"https://www.sciencedirect.com/science/article/pii/S095965261400537X?casa_token=1lyRzLyglDoAAAAA:VuWYbjcyByJosGFptXcla5QmDSd9Tki-WBgfJb44AShJoIcf7HxBVlxvYImVgMR7Qg2EpUzZ",
            Abstract = @"Espresso spent coffee grounds (SCG) that is a waste material abundantly produced by restaurants, cafeterias and in domestic environment could be used as a low-cost and rich source of valuable polyphenol compounds. The benefit would be twofold: extraction of …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Optimization_Of_Microwaveassisted_Extraction);


        Author
            Author_R_Campos_Vega = new() { GivenName = "Rocio", Surname = "Campos-Vega" },
            Author_G_Loarca_Pina = new() { GivenName = "Guadalupe", Surname = "Loarca-Piña" };

        Paper Paper_Spent_Coffee_Grounds_Review = new()
        {
            Authors = new HashSet<Author>() { Author_R_Campos_Vega, Author_G_Loarca_Pina },
            Name = @"Spent coffee grounds: A review on current research and future prospects",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0924224415001193?casa_token=ej7n7x4S764AAAAA:uprQrezreHFr0IDoxZRUkR3ZTsn9jlsfTdUEfYX65tz1ynJz7ixm4_EiFXZhnhNBis9vEaDRHN8",
            Abstract = @"Spent coffee ground (SCG) contains large amounts of organic compounds (ie fatty acids, amino acids, polyphenols, minerals and polysaccharides) that justify its valorization. Earlier innovation explored the extraction of specific components such as oil, flavor, terpenes, and …",
            Citings = new List<Paper> { Paper_Spent_Coffee_Grounds }
        };
        context.Papers.Add(Paper_Spent_Coffee_Grounds_Review);


        Author
            Author_A_Panusa = new() { GivenName = "Alessia", Surname = "Panusa" },
            // A Zuorro already exists
            // R Lavecchia already exists
            Author_G_Marrosu = new() { GivenName = "Giancarlo", Surname = "Marrosu" },
            Author_R_Petrucci = new() { GivenName = "Rita", Surname = "Petrucci" };

        Paper Paper_Recovery_Of_Natural_Antioxidants = new()
        {
            Authors = new HashSet<Author>() { Author_A_Panusa, Author_A_Zuorro, Author_R_Lavecchia, Author_G_Marrosu, Author_R_Petrucci },
            Name = @"Recovery of natural antioxidants from spent coffee grounds",
            URL = @"https://pubs.acs.org/doi/abs/10.1021/jf4005719",
            Abstract = @"Spent coffee grounds (SCG) were extracted with an environmentally friendly procedure and analyzed to evaluate the recovery of relevant natural antioxidants for use as nutritional supplements, foods, or cosmetic additives. SCG were characterized in terms of their total …",
            Citings = new List<Paper>() { Paper_Spent_Coffee_Grounds }
        };
        context.Papers.Add(Paper_Recovery_Of_Natural_Antioxidants);

        context.SaveChanges();
    }
}
