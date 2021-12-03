using LitExplore.Repository.Entities;
using LitExplore.Repository;
using Microsoft.EntityFrameworkCore;
using LitExplore.UserManagement;


namespace LitExplore.ProjectManagement
{
    public class ProjectManagement : IProjectManagement
    {
        protected Database database;
        protected IProjectRepository projectRepository { get => database.ProjectRepository; }
        protected string userName;
        protected CustomAuthStateProvider authorization;

        public ProjectManagement(Database _database, string _userName){
            database = _database;
            userName = _userName;
            authorization = new CustomAuthStateProvider();
        }
    
        public async Task<Status?> PostProjectAsync(ProjectCreateDTO project){
            throw new NotImplementedException();
        }

        public async Task<ProjectDTO?> GetProjectAsync(int id){
            throw new NotImplementedException();
        }

        public async Task<Status?> DeleteProjectAsync(int id){
            throw new NotImplementedException();
        }

        public async Task<Status?> PostPaperToProjectAsync(ProjectAddRemovePaperDTO project){
            throw new NotImplementedException();
        }

        public async Task<Status?> DeletePaperFromProjectAsync(ProjectAddRemovePaperDTO project){
            throw new NotImplementedException();
        }

        public async Task<Status?> PostCollaboratorToProjectAsync(ProjectAddRemoveCollaboratorDTO project){
            throw new NotImplementedException();
        }

        public async Task<Status?> DeleteCollaboratorFromProjectAsync(ProjectAddRemoveCollaboratorDTO project){
            throw new NotImplementedException();
        }

    }
}