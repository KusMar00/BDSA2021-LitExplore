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

            var relationsToAdd = new List<Relation>{
                new Relation{From = PapersToAdd[0], To = PapersToAdd[3]},
                new Relation{From = PapersToAdd[1], To = PapersToAdd[3]}
            };

            context.Relations.AddRange(relationsToAdd);


            _PaperDisovery = new PaperDiscovery(context);
        }


        [Fact]
        public async Task Given_ID_0_return_paper_0()
        {
            var paper = await _PaperDisovery.ReadAsync(0);

            Assert.Equal(0, paper.Id);
            Assert.Equal("Paper0", paper.Name);
        }

/*
        [Fact]
        public async Task Given_all_IDs_return_all_context.Papers_in_database()
        {
            var returnedcontext.Papers = new List<PaperDetailsDTO>();

            for (int i = 0; i < context.Papers.Count; i++)
            {
                 returnedcontext.Papers.Add(await _PaperDisovery.getPaper(i));
            }

            Assert.Equal(context.Papers, returnedcontext.Papers);
        }

        [Fact]
        public async Task Can_not_find_paper_from_ID_4()
        {
            var paper = await _PaperDisovery.getPaper(4);

            Assert.Equal(null, paper);
        }




        [Fact]
        public async Task Given_ID_0_return_relation_between_paper_0_and_3()
        {
            var returnedRelations = await _PaperDisovery.getRelatedPaper(0);

            Assert.Equal(relations[0], returnedRelations[0]);
        }

        [Fact]
        public async Task Given_ID_3_return_2_relations()
        {
            var returnedRelations = await _PaperDisovery.getRelatedPaper(3);

            Assert.Equal(relations[0], returnedRelations[0]);
            Assert.Equal(relations[1], returnedRelations[1]);
        }

        public async Task Can_not_find_relations()
        {
            var returnedRelations = await _PaperDisovery.getRelatedPaper(4);

            Assert.Equal(returnedRelations.Count, 0);
        }
            */
    }

}