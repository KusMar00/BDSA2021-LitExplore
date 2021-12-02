namespace LitExplore.Repository;

public class UserRepository : IUserRepository
{
    protected LitExploreContext context;

    public UserRepository(LitExploreContext context) => this.context = context;

    public Task<(Status, UserDTO)> CreateAsync(UserDTO user)
    {
        throw new NotImplementedException();
    }

    public Task<Status> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> ReadAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
