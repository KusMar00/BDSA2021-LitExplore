using LitExplore.Repository.Entities;
using LitExplore.Repository;
using Microsoft.EntityFrameworkCore;
using LitExplore.UserManagement;


namespace LitExplore.ProjectManagement
{
    public class ProjectManagement : IProjectManagement
    {
        protected IProjectRepository projectRepository;
        public string userName {get; set; }
        protected CustomAuthStateProvider authorization;

        public ProjectManagement(IProjectRepository _projectRepository, string _userName){
            projectRepository = _projectRepository;
            userName = _userName;
            authorization = new CustomAuthStateProvider();
        }
    
        public async Task<(Status, ProjectDTO?)> PostProjectAsync(ProjectCreateDTO project){
            if (await authorization.IsUserValidAsync(userName)){
                return await projectRepository.CreateProjectAsync(project);
            }
            return (Status.NotAuthorized, null);
        }

        public async Task<ProjectDTO?> GetProjectAsync(int id){
            if(await authorization.IsUserValidAsync(userName)) {
                return await projectRepository.ReadProjectAsync(id);
            }
            return null;
        }

        public async Task<Status?> DeleteProjectAsync(int id){
            if (await authorization.IsUserValidAsync(userName))
            {
                return await projectRepository.DeleteProjectAsync(id);
            }
            return Status.NotAuthorized;
        }

        public async Task<Status?> PostPaperToProjectAsync(ProjectAddRemovePaperDTO project){
            if (await authorization.IsUserValidAsync(userName))
            {
                return await projectRepository.AddPaperAsync(project);
            }
            return Status.NotAuthorized;
        }

        public async Task<Status?> DeletePaperFromProjectAsync(ProjectAddRemovePaperDTO project){
             if (await authorization.IsUserValidAsync(userName))
            {
                return await projectRepository.RemovePaperAsync(project);
            }
            return Status.NotAuthorized;
        }

        public async Task<Status?> PostCollaboratorToProjectAsync(ProjectAddRemoveCollaboratorDTO project){
            if (await authorization.IsUserValidAsync(userName))
            {
                return await projectRepository.AddCollaboratorAsync(project);
            }
            return Status.NotAuthorized;
        }

        public async Task<Status?> DeleteCollaboratorFromProjectAsync(ProjectAddRemoveCollaboratorDTO project){
            if (await authorization.IsUserValidAsync(userName))
            {
                return await projectRepository.RemoveCollaboratorAsync(project);
            }
            return Status.NotAuthorized;
        }

    }
}