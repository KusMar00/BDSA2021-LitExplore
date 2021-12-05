using System.Collections.Generic;
using LitExplore.Repository.Entities;
using LitExplore.Repository;
using LitExplore.Repository.Tests;
using Xunit;
using System;

namespace LitExplore.PaperDiscovery.Tests;
    public class PaperDiscoveryTests : RepositoryTests
    {
        
        private IPaperRepository repo;
        private PaperDiscovery? paperDiscovery;

        public PaperDiscoveryTests() {
            repo = database.PaperRepository;
            paperDiscovery = new PaperDiscovery(database, "AdminTestUser");
        }
        
    protected override void SeedDatabase()
    {
        
        Author
            Author_1 = new Author{Id = 10, GivenName = "James", Surname = "Wilson"},
            Author_2 = new Author{Id = 11, GivenName = "Mark", Surname = "Madsen"},
            Author_3 = new Author{Id = 12, GivenName = "Johnny", Surname = "Deluxe"};
        
        Paper
            Paper_1 = new Paper{Id = 10, Name = "Paper0", Authors = new HashSet<Author>{Author_1}, URL = null, Abstract = null},
            Paper_2 = new Paper{Id = 11, Name = "Paper1", Authors = new HashSet<Author>{Author_2}, URL = null, Abstract = null},
            Paper_3 = new Paper{Id = 12, Name = "Paper2", Authors = new HashSet<Author>{Author_3}, URL = null, Abstract = null},
            Paper_4 = new Paper{Id = 13, Name = "Paper3", Authors = new HashSet<Author>{Author_1, Author_2}, URL = null, Abstract = null};

        Context.Papers.AddRange(new[] {Paper_1, Paper_2, Paper_3, Paper_4});

        Context.SaveChanges();
        
    }

    #region ReadAsync
    // [Fact]
    // public async void GetPaperAsync_paper1_from_Id_0(){
        
    //     // Arrange
    //     PaperDTO? expected = new PaperDTO(0, "Paper0");

    //     // Act
    //     var actual = await paperDiscovery.GetPaperAsync(0);

    //     // Assert
    //     Assert.Equal(expected, actual);
    // }

    [Fact]
    public async void ReadAsync_Paper_1_Returns_Paper_1()
    {
        // Arrange
        PaperDTO? expected = new(10, "Paper0");

        // Act
        var actual = await paperDiscovery.GetPaperAsync(10);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
}