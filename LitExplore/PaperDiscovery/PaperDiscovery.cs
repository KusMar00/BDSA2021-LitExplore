using LitExplore.Repository.Entities;

namespace LitExplore.PaperDiscovery
{
    public class PaperDiscovery
    {

        List<PaperDetailsDTO> papers;

        public PaperDiscovery(List<PaperDetailsDTO> _papers){
            papers = _papers;
        }

        public async Task<PaperDetailsDTO> getPaper(int id){

            // Check if user is authenticated

            // Find paper with id from repository
            
            // Return PaperDetailsDTO from repository

            return papers[id];
        }

    }
}