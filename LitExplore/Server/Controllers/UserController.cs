namespace LitExplore.Server.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
public class UserController : Controller
{
	private readonly ILogger<UserController> logger;
	protected IUserRepository repository;
	
	public UserController(ILogger<UserController> _logger, IUserRepository _repository)
    {
        logger = _logger;
		repository = _repository;
    }

	[HttpPost]
	public async Task<(Status, UserDTO)> Post(UserDTO user)
	{
		return await repository.CreateAsync(user);
	}

	[HttpGet("{userId}")]
	public async Task<UserDTO?> Get(Guid userId)
	{
		return await repository.ReadAsync(userId);
	}
    
    [HttpDelete]
    public async Task<Status?> delete(Guid id)
    {
        return await repository.DeleteAsync(id);
    }
}