namespace LitExplore.Repository;

internal interface IProjectRepository
{
    public Task<(Status, ProjectDTO)> CreateProjectAsync(ProjectCreateDTO project);
    public Task<ProjectDTO> ReadProjectAsync(string id);
    public Task<ProjectDetailsDTO> ReadProjectDetailsAsync(string id);
    public Task<Status> AddCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project);
    public Task<Status> RemoveCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project);
    public Task<Status> AddPaperAsync(ProjectAddRemovePaperDTO project);
    public Task<Status> RemovePaperAsync(ProjectAddRemovePaperDTO project);
    public Task<Status> DeleteProjectAsync(string id);
}
