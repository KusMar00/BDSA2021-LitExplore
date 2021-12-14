namespace LitExplore.Repository;

public interface IProjectRepository
{
    public Task<(Status status, ProjectDTO? project)> CreateProjectAsync(ProjectCreateDTO project);
    public Task<ProjectDTO?> ReadProjectAsync(int id);
    /// <summary>
    /// Reads a list of all projects which a given user has access to.
    /// </summary>
    public Task<UserProjectDTO?> ReadProjectsByUserAsync(Guid userId);
    public Task<ProjectDetailsDTO?> ReadProjectDetailsAsync(int id);
    /// <summary>
	/// Adds a collaborator to a project.
	/// </summary>
    public Task<Status> AddCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project);
    /// <summary>
    /// Removes a collaborator from a project.
    /// </summary>
    public Task<Status> RemoveCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project);
	/// <summary>
	/// Adds a paper to a project.
	/// </summary>
	public Task<Status> AddPaperAsync(ProjectAddRemovePaperDTO project);
    /// <summary>
    /// Removes a paper from a project.
    /// </summary>
    public Task<Status> RemovePaperAsync(ProjectAddRemovePaperDTO project);
    public Task<Status> DeleteProjectAsync(int id);
}
