namespace LitExplore.Repository.Tests;

public class UserRepositoryTest : RepositoryTests
{
    private IUserRepository repo;
    public UserRepositoryTest() : base() => repo = new UserRepository(Context);
    
    private readonly Guid
            Id_1 = Guid.Parse("448a0dbf93344b5b95fa30cbb64f982c"),
            Id_2 = Guid.Parse("117e7b425c0d411ba3ebd08867757467"),
            Id_3 = Guid.Parse("7c567afb2109486184ab68412fed03b8"),
            Id_4 = Guid.Parse("2e30168ef092482abc0d6ff812482155"),
            Id_5 = Guid.Parse("eb94a87f96ce49bca84675f4f7b4e9f6");
        
    protected override void SeedDatabase()
    {
        Project
            Project_1 = new Project{Id = 1, Name = "Project 1"};

        User
            User_1 = new User {Id = Id_1, DisplayName = "User 1"},
            User_2 = new User {Id = Id_2, DisplayName = "User 2"},
            User_3 = new User {Id = Id_3, DisplayName = "User 3", IsOwnerOf = new HashSet<Project>(){Project_1}},
            User_4 = new User {Id = Id_4, DisplayName = "User 4"},
            User_5 = new User {Id = Id_5, DisplayName = "User 5"};

            Context.Users.AddRange(new[] { User_1, User_2, User_3, User_4, User_5});
            Context.SaveChanges();
    }
    
    #region ReadAsync
    [Fact]
    public async void ReadAsync_Non_Existing_Returns_Null()
    {
        // Arrange
        UserDTO? expected = null;

        // Act
        var actual = await repo.ReadAsync(Guid.Parse("381131f7794443849d83fed9296e3e4d"));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void ReadAsync_User_1_Returns_User_1()
    {
        // Arrange
        UserDTO expected = new(Id_1, "User 1");

        // Act
        var actual = await repo.ReadAsync(Id_1);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region CreateAsync
    [Fact]
    public async void CreateAsync_Given_User_Returns_Created()
    {
        // Arrange
        UserDTO user = new(Guid.Parse("540c877045f644c7860f275e1db7a497"), "User 6");

        // Act
        var actual = await repo.CreateAsync(user);

        // Assert
        Assert.Equal((Status.Created, user), actual);
    }

    [Fact]
    public async void CreateAsync_Given_Existing_User_Returns_Conflict()
    {
        // Arrange
        UserDTO user = new(Id_1, "User 1");

        // Act
        var actual = await repo.CreateAsync(user);

        // Assert
        Assert.Equal((Status.Conflict, user), actual);
    }
    #endregion

    #region DeleteAsync
    [Fact]
    public async void DeleteAsync_Non_Existing_Returns_Not_Found()
    {
        // Arrange
        Guid Id_7 = Guid.Parse("077a7f35dad84294a510a41da5c9a6e8");
    
        // Act
        var actual = await repo.DeleteAsync(Id_7);

        // Assert
        Assert.Equal(Status.NotFound, actual);
    }

    [Fact]
    public async void DeleteAsync_Delete_User_Returns_Deleted()
    {
        // Arrange
    
        // Act
        var actual = await repo.DeleteAsync(Id_2);
    
        // Assert
        Assert.Equal(Status.Deleted, actual);
    }

    [Fact]
    public async void DeleteAsync_Delete_User_With_Project_Returns_Conflict()
    {
        // Arrange
    
        // Act
        var actual = await repo.DeleteAsync(Id_3);
    
        // Assert
        Assert.Equal(Status.Conflict, actual);
    }
    #endregion
}
