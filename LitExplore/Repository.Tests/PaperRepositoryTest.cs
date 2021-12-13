namespace LitExplore.Repository.Tests;

public class PaperRepositoryTest : RepositoryTests
{
    private IPaperRepository repo;

    public PaperRepositoryTest() : base() => repo = new PaperRepository(Context);

    protected override void SeedDatabase()
    {
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

        Context.Papers.AddRange(new[] { Paper_1, Paper_2, Paper_3 });

        Context.SaveChanges();
    }

    #region ReadAsync
    [Fact]
    public async void ReadAsync_Non_Existing_Returns_Null()
    {
        // Arrange
        PaperDTO? expected = null;

        // Act
        var actual = await repo.ReadAsync(10);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void ReadAsync_Paper_1_Returns_Paper_1()
    {
        // Arrange
        PaperDTO expected = new(1, "Paper 1");

        // Act
        var actual = await repo.ReadAsync(1);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region ReadDetailsAsync
    [Fact]
    public async void ReadDetailsAsync_Non_Existing_Returns_Null()
    {
        // Arrange
        PaperDetailsDTO? expected = null;

        // Act
        var actual = await repo.ReadDetailsAsync(10);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void ReadDetailsAsync_Paper_1_Returns_Paper_1()
    {
        // Arrange
        PaperDetailsDTO expected = new(
            1,
            "Paper 1",
            new HashSet<AuthorDTO> {
                new(1, "Author 1", "Surname 1"),
                new(2, "Author 2", "Surname 2")
            },
            "https://paper-1.com",
            "Abstract 1"
        );

        // Act
        var actual = await repo.ReadDetailsAsync(1);

        // Assert
        Assert.NotNull(actual);
#pragma warning disable CS8602 // Dereference of a possibly null reference. (We already asserted not null)
        Assert.Equal(expected.Id, actual.Id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Authors, actual.Authors);
        Assert.Equal(expected.URL, actual.URL);
        Assert.Equal(expected.Abstract, actual.Abstract);
    }
    #endregion

    #region ReadByNameAsync
    [Fact]
    public async void ReadByNameAsync_Non_Exsisting_Returns_Empty_List()
    {
        // Arrange
        var expected = new List<PaperDTO>() { };

        // Act
        var actual = await repo.ReadByNameAsync("Paper 10");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void ReadByNameAsync_Paper_1_Returns_List_With_Paper_1()
    {
        // Arrange
        var expected = new List<PaperDTO>() { new(1, "Paper 1") };

        // Act
        var actual = await repo.ReadByNameAsync("Paper 1");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void ReadByNameAsync_per_Returns_All()
    {
        // Arrange
        var expected = new List<PaperDTO>() { new(1, "Paper 1"), new(2, "Paper 2"), new(3, "Paper 3") };

        // Act
        var actual = await repo.ReadByNameAsync("per");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void ReadByNameAsync_Is_Case_Insensitive()
    {
        // Arrange
        var expected = new List<PaperDTO>() { new(1, "Paper 1"), new(2, "Paper 2"), new(3, "Paper 3") };

        // Act
        var actual = await repo.ReadByNameAsync("pAPeR");

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    
    #region ReadByRelationAsync
    [Fact]
    public async void ReadByRelationAsync_Paper_2_Has_No_Relations()
    {
        // Arrange
        var expected = new List<PaperDTO>() { };

        // Act
        var actual = await repo.ReadByRelationsAsync(2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void ReadByRelationAsync_Non_Exsisting_Returns_Empty_List()
    {
        // Arrange
        var expected = new List<PaperDTO>() { };

        // Act
        var actual = await repo.ReadByRelationsAsync(10);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void ReadByRelationAsync_Paper_1_Cited_By_3()
    {
        // Arrange
        var expected = new List<PaperDTO>() { new(3, "Paper 3") };

        // Act
        var actual = await repo.ReadByRelationsAsync(1);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public async void ReadByRelationAsync_Paper_3_Cited_By_1()
    {
        // Arrange
        var expected = new List<PaperDTO>() { new(1, "Paper 1") };

        // Act
        var actual = await repo.ReadByRelationsAsync(3);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
}
