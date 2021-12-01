using System.Collections.Generic;
using System.Collections.ObjectModel;
using LitExplore.Repository.Entities;
using LitExplore.PaperDiscovery;
using Xunit;
using System.Threading.Tasks;

namespace LitExplore.PaperDiscovery.Tests
{
    public class PaperDiscoveryTests
    {
        public List<PaperDetailsDTO> papers = new List<PaperDetailsDTO>();
        public PaperDiscovery _PaperDisovery;

        public PaperDiscoveryTests(){

            var authors = new List<AuthorDTO>{
                new AuthorDTO(0, "James", "Wilson"),
                new AuthorDTO(1, "Mark", "Madsen"),
                new AuthorDTO(2, "Johnny", "Deluxe")
            };

            var papersToAdd = new List<PaperDetailsDTO>{
                new PaperDetailsDTO(0, "Paper0", new Collection<AuthorDTO>{authors[0]}, null, null),
                new PaperDetailsDTO(1, "Paper1", new Collection<AuthorDTO>{authors[1]}, null, null),
                new PaperDetailsDTO(2, "Paper2", new Collection<AuthorDTO>{authors[2]}, null, null),
                new PaperDetailsDTO(3, "Paper3", new Collection<AuthorDTO>{authors[0], authors[1]}, null, null)
            };

            papers.AddRange(papersToAdd);

            _PaperDisovery = new PaperDiscovery(papers);
        }


        [Fact]
        public async Task Given_ID_0_return_paper0_async()
        {
            PaperDetailsDTO paper = await _PaperDisovery.getPaper(0);

            Assert.Equal(papers[0], paper);
        }

        [Fact]
        public async Task Given_all_IDs_return_all_papers_in_database()
        {
            var returnedPapers = new List<PaperDetailsDTO>();

            for (int i = 0; i < papers.Count; i++)
            {
                 returnedPapers.Add(await _PaperDisovery.getPaper(i));
            }

            Assert.Equal(papers, returnedPapers);
        }
    }
}