using System.IO;

namespace LitExplore.Repository.Tests;

public class DatabaseTests
{
    // Enable this test and run it to seed the database without running the whole program. 
    [Fact(Skip = "We don't want to modify the live database when testing.")]
    public void SetupDatabaseTest()
    {
        File.WriteAllText("appsettings.json", "{}");
        var context = new LitExploreContext(Database.GetOptionsBuilder().Options);
        Database.SetupDatabase(context);
        // If the database already exists, this shouldn't do anything.
        // If it does not, it should create and seed it.
    }
}
