namespace LitExplore.Repository;

internal interface IUserRepository
{
    Task<(Status, UserDTO)> CreateAsync(UserDTO user);
    Task<UserDTO> ReadAsync(Guid id);
    Task<Status> DeleteAsync(Guid id);
}
