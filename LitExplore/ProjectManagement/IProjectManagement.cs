using LitExplore.Repository.Entities;

namespace LitExplore.ProjectManagement;

public interface IProjectManagement{
    Task<(Status, ProjectDTO?)> PostProjectAsync(ProjectCreateDTO project);
    Task<ProjectDTO?> GetProjectAsync(int id);
    Task<Status?> DeleteProjectAsync(int id);
    Task<Status?> PostPaperToProjectAsync(ProjectAddRemovePaperDTO project);
    Task<Status?> DeletePaperFromProjectAsync(ProjectAddRemovePaperDTO project);
    Task<Status?> PostCollaboratorToProjectAsync(ProjectAddRemoveCollaboratorDTO project);
    Task<Status?> DeleteCollaboratorFromProjectAsync(ProjectAddRemoveCollaboratorDTO project);
}

