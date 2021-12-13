namespace LitExplore.Server.Controllers;

using Microsoft.AspNetCore.Identity;
using System.Web;

[Authorize]
[ApiController]
[Route("api/[controller]/[Action]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
public class ProjectController : Controller
{
	private readonly ILogger<ProjectController> logger;
	private IProjectRepository repository;
	public ProjectController(ILogger<ProjectController> _logger, IProjectRepository _repository)
    {
        logger = _logger;
		repository = _repository;
    }

	[HttpGet("{userId}")]
	[ActionName("userId")]
	public async Task<UserProjectDTO?> Get(Guid userId) {
		return await repository.ReadProjectsByUserAsync(userId);
	}

	[HttpGet("{ProjectId}")]
	[ActionName("ProjectId")]
	public async Task<ProjectDetailsDTO?> Get(int ProjectId)
	{
		return await repository.ReadProjectDetailsAsync(ProjectId);
	}

	[HttpPost]
	[ActionName("Create")]
	public async Task<(Status, ProjectDTO?)> Post(ProjectCreateDTO project){
		return await repository.CreateProjectAsync(project);
	}

	[HttpDelete("{id}")]
	[ActionName("Delete")]
	public async Task<Status?> Delete(int id){
		return await repository.DeleteProjectAsync(id);
	}

	[HttpPost]
	[ActionName("Paper")]
	public async Task<Status?> Post(ProjectAddRemovePaperDTO paper){
		return await repository.AddPaperAsync(paper);
	}

	[HttpPut]
	[ActionName("Paper")]
	public async Task<Status?> Delete(ProjectAddRemovePaperDTO paper){
        return await repository.RemovePaperAsync(paper);
    }

	[HttpPost]
	[ActionName("Collaborator")]
	public async Task<Status?> Post(ProjectAddRemoveCollaboratorDTO collaborator){
		return await repository.AddCollaboratorAsync(collaborator);
	}

	[HttpPut]
	[ActionName("Collaborator")]
	public async Task<Status?> Delete(ProjectAddRemoveCollaboratorDTO collaborator){
		return await repository.RemoveCollaboratorAsync(collaborator);
	}
}