using LitExplore.Repository;
using LitExplore.Repository.Entities;
using LitExplore.UserManagement;


namespace LitExplore.PaperDiscovery;

    public class PaperDiscovery : IPaperDiscovery
    {

        protected Database database;
        protected IPaperRepository paperRepository { get => database.PaperRepository; }
        protected string userName;
        protected CustomAuthStateProvider authorization;

        public PaperDiscovery(Database _database, string _userName){
            database = _database;
            userName = _userName;
            authorization = new CustomAuthStateProvider();
        }
        

        public async Task<PaperDTO?> GetPaperAsync(int id){
            if (await authorization.IsUserValidAsync(userName)){
                return await paperRepository.ReadAsync(id);
            }
            return null;
        }

        public async Task<IReadOnlyCollection<PaperDTO?>?> GetPaperAsync(string name){
            if (await authorization.IsUserValidAsync(userName)){
                return await paperRepository.ReadByNameAsync(name);
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
