namespace LitExplore.Server.Controllers;

using LitExplore.ProjectManagement;


[Authorize]
[ApiController]
[Route("api/[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class ProjectController
{
	private readonly ILogger<ProjectController> _logger;
    private readonly IProjectManagement _manager;

	public ProjectController(ILogger<ProjectController> logger, IProjectManagement manager)
    {
        _logger = logger;
        _manager = manager;
    }

	[HttpGet]
	public async Task<IEnumerable<ProjectDTO>> Get() 
	{
		throw new NotImplementedException();
	}

	[HttpGet]
	public async Task<ProjectDetailsDTO> Get(int Id) 
	{
		throw new NotImplementedException();
	}

	[HttpPost]
	public async Task<(Status, ProjectDTO)> Post(ProjectCreateDTO)
	{
		throw new NotImplementedException();
	}

	[HttpDelete]
	public async Task<Status?> Delete(int id)
	{
		throw new NotImplementedException();
	}

	[HttpPost]
	public async Task<Status?> Post(ProjectAddRemoveCollaboratorDTO)
	{
		throw new NotImplementedException();
	}

	[HttpDelete]
	public async Task<Status?> Delete(ProjectAddRemoveCollaboratorDTO)
	{
		throw new NotImplementedException
	}

	[HttpPost]
	public async Task<Status?> Post(ProjectAddRemovePaperDTO)
	{
		throw new NotImplementedException();
	}

	[HttpDelete]
	public async Task<Status?> Delete(ProjectAddRemovePaperDTO)
	{
		throw new NotImplementedException();
	}
}