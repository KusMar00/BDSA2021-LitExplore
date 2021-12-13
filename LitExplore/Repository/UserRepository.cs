namespace LitExplore.Repository;

public class UserRepository : IUserRepository
{
    protected LitExploreContext context;

    public UserRepository(LitExploreContext context) => this.context = context;

    public async Task<(Status, UserDTO)> CreateAsync(UserDTO user)
    {
        var conflict = await context.Users
                            .Where(u => u.Id == user.Id)
                            .Select(u => new UserDTO(u.Id, u.DisplayName))
                            .FirstOrDefaultAsync();

            if (conflict != null)
            {
                return (Status.Conflict, conflict);
            }

            var entity = new User(user.Id, user.DisplayName);

            context.Users.Add(entity);

            await context.SaveChangesAsync();

            return (Status.Created, new UserDTO(entity.Id, entity.DisplayName));
    }

    public async Task<Status> DeleteAsync(Guid id)
    {
        var entity = await context.Users
                            .Include(u => u.IsOwnerOf)
                            .FirstOrDefaultAsync(u => u.Id == id);

            if (entity == null)
            {
                return Status.NotFound;
            }

            if (entity.IsOwnerOf.Any())
            {
                return Status.Conflict;
            }

            context.Users.Remove(entity);
            await context.SaveChangesAsync();

            return Status.Deleted;
    }

    public async Task<UserDTO?> ReadAsync(Guid id)
    {
        var users = from u in context.Users
                    where u.Id == id
                    select new UserDTO(u.Id, u.DisplayName);
        return await users.FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<UserDTO>> ReadByNameAsync(string name)
    {
        var users = from u in context.Users
                     where u.DisplayName != null && u.DisplayName.ToLower().Contains(name.ToLower())
                     select new UserDTO(u.Id, u.DisplayName);
        return (await users.ToListAsync()).AsReadOnly();
    }
}
