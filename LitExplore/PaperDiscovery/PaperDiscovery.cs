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

            if(id < papers.Count){
                return papers[id];
            }
            else{
                return null;
            }
        }


        public async Task<List<RelationDTO>> getRelatedPaper(int id) {
            List<RelationDTO> _relations = new List<RelationDTO>();
            foreach (var relation in relations)
            {
                if(relation.from.Id == id || relation.to.Id == id){
                    _relations.Add(relation);
                }
            }
            return _relations;
        }

    }
}