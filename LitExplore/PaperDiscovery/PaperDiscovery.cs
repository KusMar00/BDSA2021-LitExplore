using LitExplore.Repository;
using LitExplore.Repository.Entities;
using LitExplore.UserManagement;


namespace LitExplore.PaperDiscovery;

    public class PaperDiscovery : IPaperDiscovery
    {

        protected Database database;
        protected IPaperRepository paperRepository { get => database.PaperRepository; }
        protected string userName;

        public PaperDiscovery(Database _database, string _userName){
            database = _database;
            userName = _userName;
        }

        public async Task<PaperDTO?> GetPaperAsync(int id){
            var authorization = new CustomAuthStateProvider(userName);
            if (await authorization.isUserValidAsync()){
                return await paperRepository.ReadAsync(id);
            }
            return null;
        }

        public async Task<IReadOnlyCollection<PaperDTO>?> GetRelatedPaperAsync(int id){
            var authorization = new CustomAuthStateProvider(userName);
            if (await authorization.isUserValidAsync()){
                return await paperRepository.ReadByRelationsAsync(id);      // Maybe use sorting
            }
            return null;
        }



    }
