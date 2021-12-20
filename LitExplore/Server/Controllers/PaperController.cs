namespace LitExplore.Server.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
public class PaperController : Controller
{
	private readonly ILogger<PaperController> logger;
	protected IPaperRepository repository;
	
	
	public PaperController(ILogger<PaperController> _logger, IPaperRepository _repository)
    {
        logger = _logger;
		repository = _repository;
    }

	[HttpGet("{name}")]
	[ActionName("Name")]
	public async Task<IReadOnlyCollection<PaperDTO?>?> Get(string name){
		return await repository.ReadByNameAsync(name);
	}

	[HttpGet("{id}")]
	[ActionName("Details")]
	public async Task<PaperDetailsDTO?> Get(int id) {
		return await repository.ReadDetailsAsync(id);
	}
}