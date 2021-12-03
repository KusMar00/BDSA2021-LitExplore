using LitExplore.Repository.Entities;
using LitExplore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq;

namespace LitExplore.PaperDiscovery
{
    public class PaperDiscovery : IPaperRepository
    {

        List<PaperDetailsDTO> papers;
        List<RelationDTO> relations;

        private readonly LitExploreContext context;

        public PaperDiscovery(LitExploreContext _context){
            context = _context;
        }

        public async Task<PaperDTO> ReadAsync(int id){
            // Check if user is authenticated

            // Find paper with id from repository
            
            // Return PaperDTO from repository

            var paper = (from p in context.Papers
                        where p.Id == id
                        select new PaperDTO(p.Id, p.Name)).FirstOrDefaultAsync();
            return await paper;
        }
        public async Task<PaperDetailsDTO> ReadDetailsAsync(int id){

            // Check if user is authenticated

            // Find paper with id from repository
            
            // Return PaperDetailsDTO from repository

            var paper = (from p in context.Papers
                        where p.Id == id
                        select new PaperDetailsDTO(p.Id, p.Name, p.Authors, p.URL, p.Abstract)).FirstOrDefaultAsync();
            return await paper;
        }

        public async Task<IReadOnlyCollection<PaperDTO>> ReadByNameAsync(string name){
            var papersOut = (from p in context.Papers
                        where p.Name == name
                        select new PaperDetailsDTO(p.Id, p.Name, p.Authors, p.URL, p.Abstract)).ToListAsync();
            return await papersOut;
        }

        public async Task<IReadOnlyCollection<PaperDTO>>  ReadByRelationsAsync(int paperId) {
            var result = new List<PaperDTO>();

            foreach (var relation in context.Relations)
            {
                if(relation.From.Id == paperId){
                    result.Add(new PaperDTO(relation.To.Id, relation.To.Name));
                }
                else if(relation.To.Id == paperId){
                    result.Add(new PaperDTO(relation.From.Id, relation.From.Name));
                }
            }
            return result;
        }

    }
}