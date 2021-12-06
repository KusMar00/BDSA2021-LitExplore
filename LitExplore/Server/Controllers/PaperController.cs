namespace LitExplore.Server.Controllers;

using LitExplore.PaperDiscovery;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class PaperController
{
	private readonly ILogger<PaperController> _logger;
    private readonly IPaperDiscovery _manager;

	public PaperController(ILogger<PaperController> logger, IPaperDiscovery manager)
    {
        _logger = logger;
        _manager = manager;
    }

	[HttpGet]
	public async Task<PaperDetailsDTO> Get(int id) {
		throw new NotImplementedException();
	}

    [HttpGet]
	public async Task<PaperDetailsDTO> Get(string name) {
		throw new NotImplementedException();
	}

	[HttpGet]
	public async Task<IEnumerable<PaperDetailsDTO>> GetRelated(int id) {
		throw new NotImplementedException();
	}
}