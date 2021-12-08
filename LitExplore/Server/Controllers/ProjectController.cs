namespace LitExplore.Server.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class ProjectController
{
	private readonly ILogger<ProjectController> logger;
	private IProjectRepository repository;

	public ProjectController(ILogger<ProjectController> _logger, IProjectRepository _repository)
    {
        logger = _logger;
		repository = _repository;
    }

	[HttpGet]
	public async Task<UserProjectDTO> Get(Guid id) {
		return await repository.ReadProjectsByUserAsync(id);
	}

	[HttpPost]
	public async Task<(Status, ProjectDTO?)> Post(ProjectCreateDTO project){
		return await repository.CreateProjectAsync(project);
	}

	[HttpGet]
	public async Task<ProjectDTO?> Get(int id){
		return await repository.ReadProjectAsync(id);
	}

	[HttpDelete]
	public async Task<Status?> Delete(int id){
		return await repository.DeleteProjectAsync(id);
	}

	[HttpPost]
	public async Task<Status?> Post(ProjectAddRemovePaperDTO paper){
		return await repository.AddPaperAsync(paper);
	}

	[HttpDelete]
	public async Task<Status?> Delete(ProjectAddRemovePaperDTO paper){
        return await repository.RemovePaperAsync(paper);
    }

	[HttpPost]
	public async Task<Status?> Post(ProjectAddRemoveCollaboratorDTO collaborator){
		return await repository.AddCollaboratorAsync(collaborator);
	}

	[HttpDelete]
	public async Task<Status?> Delete(ProjectAddRemoveCollaboratorDTO collaborator){
		return await repository.RemoveCollaboratorAsync(collaborator);
	}
}