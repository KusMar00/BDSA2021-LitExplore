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

    [Fact(Skip = "We don't want to modify the live database when testing.")]
    public static void Get_Options_Builder_NotNull(){
        // Arrange

        // Act
        DbContextOptionsBuilder actual = Database.GetOptionsBuilder();

        // Assert
        Assert.NotNull(actual);
    }

    [Fact(Skip = "We don't want to modify the live database when testing.")]
    public static void Get_Connection_String_NotNull(){
        // Arrange

        // Act
        var actual = Database.GetConnectionString();

        // Assert
        Assert.NotNull(actual);
    }

    [Fact(Skip = "We don't want to modify the live database when testing.")]
    public static void Load_Configuration_NotNull(){
        // Arrange

        // Act
        var actual = Database.LoadConfiguration();

        // Assert
        Assert.NotNull(actual);
    }


    [Fact(Skip = "We don't want to modify the live database when testing.")]
    public static void LitExploreContextFactory_Create_DB_Context_NotNull(){
        // Arrange
        var LitExploreContextFactory = new LitExploreContextFactory();

        // Act
        var actual = LitExploreContextFactory.CreateDbContext(new string[] { });

        // Assert
        Assert.NotNull(actual);
    }
}
