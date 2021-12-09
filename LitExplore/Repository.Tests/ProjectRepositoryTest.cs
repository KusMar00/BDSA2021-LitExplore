namespace LitExplore.Repository.Tests;

public class ProjectRepositoryTest : RepositoryTests
{
    private IProjectRepository repo;

    public ProjectRepositoryTest() : base() => repo = new ProjectRepository(Context);

    private readonly Guid
            Id_1 = Guid.Parse("448a0dbf93344b5b95fa30cbb64f982c"),
            Id_2 = Guid.Parse("117e7b425c0d411ba3ebd08867757467"),
            Id_3 = Guid.Parse("7c567afb2109486184ab68412fed03b8"),
            Id_4 = Guid.Parse("2e30168ef092482abc0d6ff812482155"),
            Id_5 = Guid.Parse("eb94a87f96ce49bca84675f4f7b4e9f6");

    protected override void SeedDatabase()
    {
        #region Papers
        Author
            Author_1 = new Author { Id = 1, GivenName = "Author 1", Surname = "Surname 1" },
            Author_2 = new Author { Id = 2, GivenName = "Author 2", Surname = "Surname 2" },
            Author_3 = new Author { Id = 3, GivenName = "Author 3", Surname = "Surname 3" },
            Author_4 = new Author { Id = 4, GivenName = "Author 4", Surname = "Surname 4" },
            Author_5 = new Author { Id = 5, GivenName = "Author 5", Surname = "Surname 5" };

        Paper
            Paper_1 = new Paper
            {
                Id = 1,
                Authors = new HashSet<Author> { Author_1, Author_2 },
                Name = "Paper 1",
                URL = "https://paper-1.com",
                Abstract = "Abstract 1"
            },
            Paper_2 = new Paper
            {
                Id = 2,
                Authors = new HashSet<Author> { Author_3, Author_4 },
                Name = "Paper 2",
                URL = "https://paper-2.com",
                Abstract = "Abstract 2"
            },
            Paper_3 = new Paper
            {
                Id = 3,
                Authors = new HashSet<Author> { Author_5 },
                Name = "Paper 3",
                URL = "https://paper-3.com",
                Abstract = "Abstract 3",
                Citings = new[] { Paper_1 }
            };
        #endregion
        #region Users
        User
            User_1 = new User { Id = Id_1, Email = "user1@mail.com", DisplayName = "User 1" },
            User_2 = new User { Id = Id_2, Email = "user2@mail.com", DisplayName = "User 2" },
            User_3 = new User { Id = Id_3, Email = "user3@mail.com", DisplayName = "User 3" },
            User_4 = new User { Id = Id_4, Email = "user4@mail.com", DisplayName = "User 4" },
            User_5 = new User { Id = Id_5, Email = "user5@mail.com", DisplayName = "User 5" };
        #endregion
        #region Projects
        Project
            Project_1 = new Project
            {
                Id = 1,
                Name = "Project 1",
                Owner = User_1,
                Collaborators = new HashSet<User>() { User_2, User_3, User_4 },
                Papers = new HashSet<Paper>() { Paper_1, Paper_2 }
            },
            Project_2 = new Project
            {
                Id = 2,
                Name = "Project 2",
                Owner = User_2,
                Collaborators = new HashSet<User>() { User_4, User_5 },
                Papers = new HashSet<Paper>() { Paper_2, Paper_3 }
            },
            Project_3 = new Project
            {
                Id = 3,
                Name = "Project 3",
                Owner = User_2,
                Collaborators = new HashSet<User>() { },
                Papers = new HashSet<Paper>() { }
            },
            Project_4 = new Project
            {
                Id = 4,
                Name = "Project 4",
                Owner = null, // This should never be able to happen in the actual database,
                              // but we don't want the system to break if it does.
                Collaborators = new HashSet<User>() { },
                Papers = new HashSet<Paper>() { }
            };
        #endregion

        Context.Projects.AddRange(new[] { Project_1, Project_2, Project_3, Project_4 });

        Context.SaveChanges();
    }

    #region ReadProjectAsync
    [Fact]
    public async void ReadProjectAsync_Non_Existing_Returns_Null()
    {
        // Arrange
        ProjectDTO? expected = null;

        // Act
        var acutal = await repo.ReadProjectAsync(10);

        // Assert
        Assert.Equal(expected, acutal);
    }

    [Fact]
    public async void ReadProjectAsync_Project_1_Returns_Project_1()
    {
        // Arrange
        ProjectDTO expected = new(
            Id: 1,
            Name: "Project 1",
            Owner: new(Id_1, "user1@mail.com", "User 1"),
            Collaborators: new HashSet<UserDTO>() {
                new(Id_2, "user2@mail.com", "User 2"),
                new(Id_3, "user3@mail.com", "User 3"),
                new(Id_4, "user4@mail.com", "User 4"),
            }
        );

        // Act
        var actual = await repo.ReadProjectAsync(1);

        // Assert
        Assert.NotNull(actual);
#pragma warning disable CS8602 // Dereference of a possibly null reference. (We already asserted not null)
        Assert.Equal(expected.Id, actual.Id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        Assert.Equal(expected.Owner, actual.Owner);
        Assert.Equal(expected.Collaborators, actual.Collaborators);
    }

    [Fact]
    public async void ReadProjectAsync_No_Owner_Does_Not_Break()
    {
        // Arrange
        ProjectDTO expected = new(
            Id: 4,
            Name: "Project 4",
            Owner: new(Guid.Empty, "", ""),
            Collaborators: new HashSet<UserDTO>() { }
        );

        // Act
        var actual = await repo.ReadProjectAsync(4);

        // Assert
        Assert.NotNull(actual);
#pragma warning disable CS8602 // Dereference of a possibly null reference. (We already asserted not null)
        Assert.Equal(expected.Id, actual.Id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        Assert.Equal(expected.Owner, actual.Owner);
        Assert.Equal(expected.Collaborators, actual.Collaborators);
    }
    #endregion

    #region ReadProjectDetailsAsync
    [Fact]
    public async void ReadProjectDetailsAsync_Non_Existing_Returns_Null()
    {
        // Arrange
        ProjectDetailsDTO? expected = null;

        // Act
        var acutal = await repo.ReadProjectDetailsAsync(10);

        // Assert
        Assert.Equal(expected, acutal);
    }

    [Fact]
    public async void ReadProjectDetailsAsync_Project_1_Returns_Project_1()
    {
        // Arrange
        ProjectDetailsDTO expected = new(
            Id: 1,
            Name: "Project 1",
            Owner: new(Id_1, "user1@mail.com", "User 1"),
            Collaborators: new HashSet<UserDTO>() {
                new(Id_2, "user2@mail.com", "User 2"),
                new(Id_3, "user3@mail.com", "User 3"),
                new(Id_4, "user4@mail.com", "User 4"),
            },
            Papers: new HashSet<PaperDTO>() {
                new(1, "Paper 1"),
                new(2, "Paper 2"),
            }
        );

        // Act
        var actual = await repo.ReadProjectDetailsAsync(1);

        // Assert
        Assert.NotNull(actual);
#pragma warning disable CS8602 // Dereference of a possibly null reference. (We already asserted not null)
        Assert.Equal(expected.Id, actual.Id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        Assert.Equal(expected.Owner, actual.Owner);
        Assert.Equal(expected.Collaborators, actual.Collaborators);
        Assert.Equal(expected.Papers, actual.Papers);
    }

    [Fact]
    public async void ReadProjectDetailsAsync_No_Owner_Does_Not_Break()
    {
        // Arrange
        ProjectDetailsDTO expected = new(
            Id: 4,
            Name: "Project 4",
            Owner: new(Guid.Empty, "", ""),
            Collaborators: new HashSet<UserDTO>() { },
            Papers: new HashSet<PaperDTO>() { }
        );

        // Act
        var actual = await repo.ReadProjectDetailsAsync(4);

        // Assert
        Assert.NotNull(actual);
#pragma warning disable CS8602 // Dereference of a possibly null reference. (We already asserted not null)
        Assert.Equal(expected.Id, actual.Id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        Assert.Equal(expected.Owner, actual.Owner);
        Assert.Equal(expected.Collaborators, actual.Collaborators);
        Assert.Equal(expected.Papers, actual.Papers);
    }
    #endregion

    #region CreateProjectAsync
    [Fact]
    public async void CreateProjectAsync_Creates_Project_And_Returns_Created()
    {
        // Arrange
        var expectedStatus = Status.Created;
        var expectedProject = new ProjectDTO(
            Id: 5,
            Name: "Project 5",
            Owner: new(Id_3, "user3@mail.com", "User 3"),
            Collaborators: new HashSet<UserDTO>()
        );

        // Act
        var actual = await repo.CreateProjectAsync(new(Id_3, "Project 5"));

        // Assert
        Assert.Equal(expectedStatus, actual.status);
        AssertProjectDTOEquals(expectedProject, actual.project);
        // Was the project actually created?
        AssertProjectDTOEquals(expectedProject, await repo.ReadProjectAsync(5));
    }

    [Fact]
    public async void CreateProjectAsync_Non_Existing_User_Returns_NotFound()
    {
        // Arrange
        var expectedStatus = Status.NotFound;

        // Act
        var actual = await repo.CreateProjectAsync(new(Guid.Empty, "Project 5"));

        // Assert
        Assert.Equal(expectedStatus, actual.status);
        Assert.Null(actual.project);
        Assert.Null(await repo.ReadProjectAsync(5));
    }

    [Fact]
    public async void CreateProjectAsync_Name_Exists_For_Owner_Conflict()
    {
        // Arrange
        var expectedStatus = Status.Conflict;
        var expectedProject = new ProjectDTO(
            Id: 1,
            Name: "Project 1",
            Owner: new(Id_1, "user1@mail.com", "User 1"),
            Collaborators: new HashSet<UserDTO>()
            {
                new(Id_2, "user2@mail.com", "User 2"),
                new(Id_3, "user3@mail.com", "User 3"),
                new(Id_4, "user4@mail.com", "User 4"),
            }
        );

        // Act
        var actual = await repo.CreateProjectAsync(new(Id_1, "Project 1"));

        // Assert
        Assert.Equal(expectedStatus, actual.status);
        AssertProjectDTOEquals(expectedProject, actual.project);
    }
    #endregion

    #region DeleteProjectAsync
    [Fact]
    public async void DeleteProjectAsync_Non_Existing_Project_Returns_Not_Found()
    {
        // Assert
        var expected = Status.NotFound;

        // Act
        var actual = await repo.DeleteProjectAsync(10);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void DeleteProjectAsync_Delete_Project_1()
    {
        // Assert
        var expected = Status.Deleted;

        // Act
        var actual = await repo.DeleteProjectAsync(1);

        // Assert
        Assert.Equal(expected, actual);
        // Is it actually gone?
        Assert.Null(await repo.ReadProjectAsync(1));

    }
    #endregion

    #region AddPaperAsync
    [Fact]
    public async void AddPaperAsync_Add_Non_Existing_Paper_Returns_NotFound()
    {
        // Arrange
        var expected = Status.NotFound;

        // Act
        var actual = await repo.AddPaperAsync(new(1, 10));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void AddPaperAsync_Add_To_Non_Existing_Project_Returns_NotFound()
    {
        // Arrange
        var expected = Status.NotFound;

        // Act
        var actual = await repo.AddPaperAsync(new(10, 1));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void AddPaperAsync_Add_Paper_3_To_Project_1_Returns_Updated()
    {
        // Arrange
        var expected = Status.Updated;

        // Act
        var actual = await repo.AddPaperAsync(new(1, 3));
#pragma warning disable CS8602 // Dereference of a possibly null reference. (Tested elsewhere)
        var paperSet = (await repo.ReadProjectDetailsAsync(1)).Papers;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        // Assert
        Assert.Equal(expected, actual);
        Assert.Contains(paperSet, p => p.Id == 3);
    }
    
    [Fact]
    public async void AddPaperAsync_Already_In_Project_Returns_Conflict()
    {
        // Arrange
        var expected = Status.Conflict;

        // Act
        var actual = await repo.AddPaperAsync(new(1, 1));

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region RemovePaperAsync
    [Fact]
    public async void RemovePaperAsync_Remove_Paper_Not_In_Project_Returns_NotFound()
    {
        // Arrange
        var expected = Status.NotFound;

        // Act
        var actual = await repo.RemovePaperAsync(new(1, 10));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void RemovePaperAsync_Remove_From_Non_Existing_Project_Returns_NotFound()
    {
        // Arrange
        var expected = Status.NotFound;

        // Act
        var actual = await repo.RemovePaperAsync(new(10, 1));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void RemovePaperAsync_Remove_Paper_1_From_Project_1_Returns_Deleted()
    {
        // Arrange
        var expected = Status.Deleted;

        // Act
        var actual = await repo.RemovePaperAsync(new(1, 1));
#pragma warning disable CS8602 // Dereference of a possibly null reference. (Tested elsewhere)
        var paperSet = (await repo.ReadProjectDetailsAsync(1)).Papers;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        // Assert
        Assert.Equal(expected, actual);
        Assert.DoesNotContain(paperSet, p => p.Id == 1);
    }
    #endregion

    #region AddCollaboratorAsync
    [Fact]
    public async void AddCollaboratorAsync_Add_Non_Existing_Collaborator_Returns_NotFound()
    {
        // Arrange
        var expected = Status.NotFound;

        // Act
        var actual = await repo.AddCollaboratorAsync(new(1, Guid.Empty));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void AddCollaboratorAsync_Add_To_Non_Existing_Project_Returns_NotFound()
    {
        // Arrange
        var expected = Status.NotFound;

        // Act
        var actual = await repo.AddCollaboratorAsync(new(10, Id_1));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void AddCollaboratorAsync_Add_User_5_To_Project_1_Returns_Updated()
    {
        // Arrange
        var expected = Status.Updated;

        // Act
        var actual = await repo.AddCollaboratorAsync(new(1, Id_5));
#pragma warning disable CS8602 // Dereference of a possibly null reference. (Tested elsewhere)
        var collaboratorSet = (await repo.ReadProjectDetailsAsync(1)).Collaborators;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        // Assert
        Assert.Equal(expected, actual);
        Assert.Contains(collaboratorSet, u => u.Id == Id_5);
    }

    [Fact]
    public async void AddCollaboratorAsync_Already_In_Project_Returns_Conflict()
    {
        // Arrange
        var expected = Status.Conflict;

        // Act
        var actual = await repo.AddCollaboratorAsync(new(1, Id_2));

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region RemoveCollaboratorAsync
    [Fact]
    public async void RemoveCollaboratorAsync_Remove_Collaborator_Not_In_Project_Returns_NotFound()
    {
        // Arrange
        var expected = Status.NotFound;

        // Act
        var actual = await repo.RemoveCollaboratorAsync(new(1, Guid.Empty));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void RemoveCollaboratorAsync_Remove_From_Non_Existing_Project_Returns_NotFound()
    {
        // Arrange
        var expected = Status.NotFound;

        // Act
        var actual = await repo.RemoveCollaboratorAsync(new(10, Id_1));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void RemoveCollaboratorAsync_Remove_User_2_From_Project_1_Returns_Deleted()
    {
        // Arrange
        var expected = Status.Deleted;

        // Act
        var actual = await repo.RemoveCollaboratorAsync(new(1, Id_2));
#pragma warning disable CS8602 // Dereference of a possibly null reference. (Tested elsewhere)
        var collaboratorSet = (await repo.ReadProjectDetailsAsync(1)).Collaborators;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        // Assert
        Assert.Equal(expected, actual);
        Assert.DoesNotContain(collaboratorSet, u => u.Id == Id_2);
    }
    #endregion

    private void AssertProjectDTOEquals (ProjectDTO? expected, ProjectDTO? actual)
    {
        Assert.NotNull(actual);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Assert.Equal(expected.Id, actual.Id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Owner, actual.Owner);
        Assert.Equal(expected.Collaborators, actual.Collaborators);
    }
}
