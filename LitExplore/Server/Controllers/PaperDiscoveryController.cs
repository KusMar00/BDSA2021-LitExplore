using LitExplore.PaperDiscovery;

namespace LitExplore.Server.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
public class PaperDiscoveryController : Controller
{
	private readonly ILogger<PaperController> logger;
    protected IProjectRepository projectRepo;
    protected IPaperRepository paperRepo;
	
	
	public PaperDiscoveryController(ILogger<PaperController> _logger, IProjectRepository _projectRepo, IPaperRepository _paperRepo)
    {
        logger = _logger;
		projectRepo = _projectRepo;
        paperRepo = _paperRepo;
    }

    [HttpGet("{projectId}")]
    public async Task<IReadOnlyCollection<PaperDTO>> get(int projectId){
        return await PaperDiscovery.PaperDiscovery.GetPapersRelatedToProject(projectId, projectRepo, paperRepo);
    }
}