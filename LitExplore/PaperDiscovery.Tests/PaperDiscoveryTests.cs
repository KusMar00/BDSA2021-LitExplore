using System.Collections.Generic;
using System.Collections.ObjectModel;
using LitExplore.Repository.Entities;
using LitExplore.PaperDiscovery;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using LitExplore.Repository;

namespace LitExplore.PaperDiscovery.Tests
{
    public class PaperDiscoveryTests
    {
        public PaperDiscovery _PaperDisovery;

        public PaperDiscoveryTests(){

            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<LitExploreContext>();
            builder.UseSqlite(connection);       // Correct: builder.UseSqlite(connection);
            var context = new LitExploreContext(builder.Options);
            context.Database.EnsureCreated();

            var authors = new List<Author>{
                new Author{Id = 0, GivenName = "James", Surname = "Wilson"},
                new Author{Id = 1, GivenName = "Mark", Surname = "Madsen"},
                new Author{Id = 2, GivenName = "Johnny", Surname = "Deluxe"}
            };

            var PapersToAdd = new List<Paper>{
                new Paper{Id = 0, Name = "Paper0", Authors = new HashSet<Author>{authors[0]}, URL = null, Abstract = null},
                new Paper{Id = 1, Name = "Paper1", Authors = new HashSet<Author>{authors[1]}, URL = null, Abstract = null},
                new Paper{Id = 2, Name = "Paper2", Authors = new HashSet<Author>{authors[2]}, URL = null, Abstract = null},
                new Paper{Id = 3, Name = "Paper3", Authors = new HashSet<Author>{authors[0], authors[1]}, URL = null, Abstract = null},
            };

            context.Papers.AddRange(PapersToAdd);
        }

        [Fact]
        public async Task UnitTest1()
        {
        }

    }

}