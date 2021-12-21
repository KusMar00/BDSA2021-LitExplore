using System.Collections.Generic;
using LitExplore.Repository.Entities;
using LitExplore.Repository;
using LitExplore.Repository.Tests;
using Xunit;
using System.Diagnostics.CodeAnalysis;

namespace LitExplore.PaperDiscovery.Tests;

/*
[ExcludeFromCodeCoverage]
public class PaperDiscoveryTests : RepositoryTests
{
    private IPaperRepository repo;
    private PaperDiscovery paperDiscovery;

    public PaperDiscoveryTests()
    {
        repo = new PaperRepository(Context);
        paperDiscovery = new PaperDiscovery(repo, "AdminTestUser");
    }

    protected override void SeedDatabase()
    {
        Author
            Author_1 = new Author { Id = 1, GivenName = "James", Surname = "Wilson" },
            Author_2 = new Author { Id = 2, GivenName = "Mark", Surname = "Madsen" },
            Author_3 = new Author { Id = 3, GivenName = "Johnny", Surname = "Deluxe" };

        Paper
            Paper_1 = new Paper { Id = 1, Name = "Paper1", Authors = new HashSet<Author> { Author_1 }, URL = null, Abstract = null },
            Paper_2 = new Paper { Id = 2, Name = "Paper2", Authors = new HashSet<Author> { Author_2 }, URL = null, Abstract = null, Citings = new[] { Paper_1 } },
            Paper_3 = new Paper { Id = 3, Name = "Paper3", Authors = new HashSet<Author> { Author_3 }, URL = null, Abstract = null, Citings = new[] { Paper_2 } },
            Paper_4 = new Paper { Id = 4, Name = "Paper4", Authors = new HashSet<Author> { Author_1, Author_2 }, URL = null, Abstract = null };

        Context.Papers.AddRange(new[] { Paper_1, Paper_2, Paper_3, Paper_4 });

        Context.SaveChanges();

    }

    [Fact]
    public async void GetPaperAsync_Paper_1_Returns_Paper_1()
    {
        // Arrange
        PaperDTO? expected = new(1, "Paper1");

        // Act
        var actual = await paperDiscovery.GetPaperAsync(1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void GetPaperAsync_Paper_5_Returns_Null()
    {
        // Arrange
        PaperDTO? expected = null;

        // Act
        var actual = await paperDiscovery.GetPaperAsync(5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void GetRelatedPaperAsync_Paper_1_Returns_Paper_2()
    {
        // Arrange
        IReadOnlyCollection<PaperDTO>? expected = new[] { new PaperDTO(2, "Paper2") };

        // Act
        var actual = await paperDiscovery.GetRelatedPaperAsync(1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void GetRelatedPaperAsync_Paper_2_Returns_Paper_1_And_Paper_3()
    {
        // Arrange
        IReadOnlyCollection<PaperDTO>? expected = new[] { new PaperDTO(1, "Paper1"), new PaperDTO(3, "Paper3") };

        // Act
        var actual = await paperDiscovery.GetRelatedPaperAsync(2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void GetRelatedPaperAsync_Paper_4_Returns_Empty()
    {
        // Arrange
        IReadOnlyCollection<PaperDTO>? expected = new List<PaperDTO>();

        // Act
        var actual = await paperDiscovery.GetRelatedPaperAsync(4);

        // Assert
        Assert.Equal(expected, actual);
    }
}
*/