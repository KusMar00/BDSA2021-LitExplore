using LitExplore.Repository;
using LitExplore.Repository.Entities;
using LitExplore.UserManagement;
using System.Diagnostics.CodeAnalysis;



namespace LitExplore.PaperDiscovery;

    [ExcludeFromCodeCoverage]
    public class PaperDiscovery : IPaperDiscovery
    {

        protected IPaperRepository paperRepository;
        protected string userName;
        protected CustomAuthStateProvider authorization;

        public PaperDiscovery(IPaperRepository _paperRepository, string _userName){
            paperRepository = _paperRepository;
            userName = _userName;
            authorization = new CustomAuthStateProvider();
        }

        public async Task<PaperDTO?> GetPaperAsync(int id){
            if (await authorization.IsUserValidAsync(userName)){
                return await paperRepository.ReadAsync(id);
            }
            return null;
        }

        public async Task<IReadOnlyCollection<PaperDTO>?> GetRelatedPaperAsync(int id){
            if (await authorization.IsUserValidAsync(userName)){
                return await paperRepository.ReadByRelationsAsync(id);      // Maybe use sorting
            }
            return null;
        }
    }
