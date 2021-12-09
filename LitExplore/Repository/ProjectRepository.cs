namespace LitExplore.Repository;

public class ProjectRepository : IProjectRepository
{
    protected LitExploreContext context;

    public ProjectRepository(LitExploreContext context) => this.context = context;

    public async Task<Status> AddCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project)
    {
        var projectToModify = await (
           from p in context.Projects
           where p.Id == project.ProjectId
           select p
        ).FirstOrDefaultAsync();

        if (projectToModify == null)
        {
            return Status.NotFound;
        }

        var collaboratorToAdd = await (
            from u in context.Users
            where u.Id == project.CollaboratorId
            select u
        ).FirstOrDefaultAsync();

        if (collaboratorToAdd == null)
        {
            return Status.NotFound;
        }

        if (projectToModify.Collaborators.Contains(collaboratorToAdd))
        {
            return Status.Conflict;
        }

        projectToModify.Collaborators.Add(collaboratorToAdd);
        await context.SaveChangesAsync();
        return Status.Updated;
    }

    public async Task<Status> AddPaperAsync(ProjectAddRemovePaperDTO project)
    {
        var projectToModify = await (
            from p in context.Projects
            where p.Id == project.ProjectId
            select p
        ).FirstOrDefaultAsync();

        if (projectToModify == null)
        {
            return Status.NotFound;
        }

        var paperToAdd = await (
            from p in context.Papers
            where p.Id == project.PaperId
            select p
        ).FirstOrDefaultAsync();

        if (paperToAdd == null)
        {
            return Status.NotFound;
        }

        if (projectToModify.Papers.Contains(paperToAdd))
        {
            return Status.Conflict;
        }

        projectToModify.Papers.Add(paperToAdd);
        await context.SaveChangesAsync();
        return Status.Updated;
    }

    public async Task<(Status, ProjectDTO?)> CreateProjectAsync(ProjectCreateDTO project)
    {
        var conflict = await ( // Conflict if the owner already has a project with this name.
            from p in context.Projects
            where p.Owner != null && p.Owner.Id == project.OwnerId && p.Name == project.Name
            select p.ToDTO()
        ).FirstOrDefaultAsync();

        if (conflict != null)
        {
            return (Status.Conflict, conflict);
        }

        var owner = (
            from u in context.Users
            where u.Id == project.OwnerId
            select u
        ).FirstOrDefault();

        if (owner == null)
        { // No owner is not allowed.
            return (Status.NotFound, null);
        }

        var entity = new Project()
        {
            Name = project.Name,
            Owner = owner,
            Collaborators = new HashSet<User> { },
            Papers = new HashSet<Paper> { },
        };

        context.Projects.Add(entity);
        await context.SaveChangesAsync();
        return (Status.Created, entity.ToDTO());
    }

    public async Task<Status> DeleteProjectAsync(int id)
    {
        var entity = await (
            from p in context.Projects
            where p.Id == id
            select p
        ).FirstOrDefaultAsync();

        if (entity == null)
        {
            return Status.NotFound;
        }

        context.Projects.Remove(entity);
        await context.SaveChangesAsync();

        return Status.Deleted;
    }

    public async Task<ProjectDTO?> ReadProjectAsync(int id)
    {
        var projects = from p in context.Projects
                       where p.Id == id
                       select p.ToDTO();
        return await projects.FirstOrDefaultAsync();
    }

    public async Task<ProjectDetailsDTO?> ReadProjectDetailsAsync(int id)
    {
        var projects = from p in context.Projects
                       where p.Id == id
                       select p.ToDetailsDTO();
        return await projects.FirstOrDefaultAsync();
    }

    public async Task<Status> RemoveCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project)
    {
        var projectToModify = await (
            from p in context.Projects
            where p.Id == project.ProjectId
            select p
        ).FirstOrDefaultAsync();

        if (projectToModify == null)
        {
            return Status.NotFound;
        }

        var collaboratorToRemove = (
            from p in projectToModify.Collaborators
            where p.Id == project.CollaboratorId
            select p
        ).FirstOrDefault();

        if (collaboratorToRemove == null)
        {
            return Status.NotFound;
        }

        projectToModify.Collaborators.Remove(collaboratorToRemove);
        context.SaveChanges();
        return Status.Deleted;
    }

    public async Task<Status> RemovePaperAsync(ProjectAddRemovePaperDTO project)
    {
        var projectToModify = await (
            from p in context.Projects
            where p.Id == project.ProjectId
            select p
        ).FirstOrDefaultAsync();

        if (projectToModify == null)
        {
            return Status.NotFound;
        }

        var paperToRemove = (
            from p in projectToModify.Papers
            where p.Id == project.PaperId
            select p
        ).FirstOrDefault();

        if (paperToRemove == null)
        {
            return Status.NotFound;
        }

        projectToModify.Papers.Remove(paperToRemove);
        context.SaveChanges();
        return Status.Deleted;
    }

    public async Task<UserProjectDTO> ReadProjectsByUserAsync(Guid userId)
    {
        var user = await (
            from u in context.Users
            where u.Id == userId
            select u
        ).FirstOrDefaultAsync();

        if (user == null) {
            return new UserProjectDTO(Guid.Empty, new List<ProjectDTO>(){}.AsReadOnly(), new List<ProjectDTO>() { }.AsReadOnly());
        }

        var owns = await (
            from p in context.Projects
            where p.Owner == user
            select p.ToDTO()
        ).ToListAsync<ProjectDTO>();

        var hasAccessTo = await (
            from p in context.Projects
            where p.Collaborators.Contains(user)
            select p.ToDTO()
        ).ToListAsync<ProjectDTO>();

        return new(user.Id, owns.AsReadOnly(), hasAccessTo.AsReadOnly());
    }
}
