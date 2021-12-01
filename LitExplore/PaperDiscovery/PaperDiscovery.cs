using System.Runtime.CompilerServices;
using LitExplore.Repository.Entities;
using Microsoft.VisualBasic;

namespace LitExplore.PaperDiscovery
{
    public class PaperDiscovery
    {

        List<PaperDetailsDTO> papers;
        List<RelationDTO> relations;

        public PaperDiscovery(List<PaperDetailsDTO> _papers, List<RelationDTO> _relations){
            papers = _papers;
            relations = _relations;
        }

        public async Task<PaperDetailsDTO> getPaper(int id){

            // Check if user is authenticated

            // Find paper with id from repository
            
            // Return PaperDetailsDTO from repository

            return papers[id];
        }

        // public Task<IEnumerable<RelationDTO>> getRelatedPaper(int id){
        //     return Task.WhenAll(from relation in relations select relation where .from.id == id);
        // }


        public async Task<List<RelationDTO>> getRelatedPaper(int id) {
            List<RelationDTO> _relations = new List<RelationDTO>();
            foreach (var relation in relations)
            {
                if(relation.from.Id == id){
                    _relations.Add(relation);
                }
            }
            return _relations;
        }

    }
}