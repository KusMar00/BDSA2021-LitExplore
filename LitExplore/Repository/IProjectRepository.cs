namespace LitExplore.Repository;

public interface IProjectRepository
{
    public Task<(Status status, ProjectDTO? project)> CreateProjectAsync(ProjectCreateDTO project);
    public Task<ProjectDTO?> ReadProjectAsync(int id);
    public Task<IReadOnlyCollection<UserProjectDTO>> ReadProjectsByUserAsync(Guid userID);
    public Task<ProjectDetailsDTO?> ReadProjectDetailsAsync(int id);
    public Task<Status> AddCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project);
    public Task<Status> RemoveCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project);
    public Task<Status> AddPaperAsync(ProjectAddRemovePaperDTO project);
    public Task<Status> RemovePaperAsync(ProjectAddRemovePaperDTO project);
    public Task<Status> DeleteProjectAsync(int id);
}
