namespace LitExplore.Repository;

public class ProjectRepository : IProjectRepository
{
    protected LitExploreContext context;

    public ProjectRepository(LitExploreContext context) => this.context = context;

    public Task<Status> AddCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project)
    {
        throw new NotImplementedException();
    }

    public Task<Status> AddPaperAsync(ProjectAddRemovePaperDTO project)
    {
        throw new NotImplementedException();
    }

    public Task<(Status, ProjectDTO)> CreateProjectAsync(ProjectCreateDTO project)
    {
        throw new NotImplementedException();
    }

    public Task<Status> DeleteProjectAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectDTO> ReadProjectAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectDetailsDTO> ReadProjectDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Status> RemoveCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project)
    {
        throw new NotImplementedException();
    }

    public Task<Status> RemovePaperAsync(ProjectAddRemovePaperDTO project)
    {
        throw new NotImplementedException();
    }
}
