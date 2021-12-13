namespace LitExplore.Repository;

public interface IUserRepository
{
    Task<(Status, UserDTO)> CreateAsync(UserDTO user);
    Task<UserDTO?> ReadAsync(Guid id);
    Task<Status> DeleteAsync(Guid id);
    Task<IReadOnlyCollection<UserDTO>> ReadByNameAsync(string name);
}
