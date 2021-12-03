namespace LitExplore.Repository.Tests;

public class PaperRepositoryTest : RepositoryTests
{
    private IPaperRepository repo;

    public PaperRepositoryTest() : base() => repo = database.PaperRepository;

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
                Id = 0,
                Authors = new HashSet<Author> { Author_1, Author_2 },
                Name = "Paper 1",
                Abstract = "Abstract 1"
            },
            Paper_2 = new Paper
            {
                Id = 1,
                Authors = new HashSet<Author> { Author_3, Author_4 },
                Name = "Paper 2",
                Abstract = "Abstract 2"
            },
            Paper_3 = new Paper
            {
                Id = 1,
                Authors = new HashSet<Author> { Author_5 },
                Name = "Paper 3",
                Abstract = "Abstract 3",
                Citings = new[] { Paper_1, Paper_2 }
            };

        Context.Papers.AddRange(new[] { Paper_1 });

        Context.SaveChanges();
    }

    [Fact]
    public async void Read_Non_Existing_Returns_Null()
    {
        // Arrange
        PaperDTO? expected = null;

        // Act
        var actual = await repo.ReadAsync(10);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void Read_Paper_1_Returns_Paper_1()
    {
        // Arrange
        PaperDTO expected = new(1, "Paper 1");

        // Act
        var actual = await repo.ReadAsync(1);

        // Assert
        Assert.Equal(expected, actual);
    }
}
