using LitExplore.Repository.Entities;
using LitExplore.Repository;
using Microsoft.EntityFrameworkCore;

public interface ICustomAuthStateProvider
{
    Task<(Status?, UserDTO?)> PostUserAsync(UserDTO user);
    Task<UserDTO?> GetUserAsync(Guid id);

    Task<Boolean?> IsUserValidAsync(string userName);

    Task<Boolean?> IsUserOwnerAsync(string userName);
    
    Task<Boolean?> IsUserCollaboratorAsync(string userName);

}