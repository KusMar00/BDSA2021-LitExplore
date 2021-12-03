namespace LitExplore.Repository.Tests;

public class PaperRepositoryTest : RepositoryTests
{
    private IPaperRepository repo;

    public PaperRepositoryTest() : base() => repo = database.PaperRepository;

    protected override void SeedDatabase()
    {
        // Nothing for now
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
}
