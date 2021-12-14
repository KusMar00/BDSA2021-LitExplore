namespace LitExplore.Repository;

public interface IUserRepository
{
    Task<(Status, UserDTO)> CreateAsync(UserDTO user);
    Task<UserDTO?> ReadAsync(Guid id);
    Task<Status> DeleteAsync(Guid id);
    /// <summary>
    /// Reads a list of users with a name simmilar to <paramref name="name"/>.
    /// </summary>
    Task<IReadOnlyCollection<UserDTO>> ReadByNameAsync(string name);
}
