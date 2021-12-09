namespace LitExplore.Server.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class PaperController : Controller
{
	private readonly ILogger<PaperController> logger;
	protected IPaperRepository repository;
	
	public PaperController(ILogger<PaperController> _logger, IPaperRepository _repository)
    {
        logger = _logger;
		repository = _repository;
    }

	[HttpGet]
	public async Task<PaperDTO?> Get(int id){
		return await repository.ReadAsync(id);
    }

	[HttpGet]
	public async Task<IReadOnlyCollection<PaperDTO?>?> Get(string name){
		return await repository.ReadByNameAsync(name);
	}

	//TODO: DETTE BURDE SKE I EN ANDEN KLASSE
	[HttpGet]
	public async Task<IReadOnlyCollection<PaperDTO>?> GetRelated(int id){
		return await repository.ReadByRelationsAsync(id);
	}
}