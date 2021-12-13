namespace LitExplore.Repository.Entities;

public class User
{
    // This is here to make the guid easier to work with than if it were the primary key
    [Key]
    public int InternalId { get; set; }

    public Guid Id { get; set; }

    [StringLength(50)]
    public string DisplayName { get; set; } = null!;

    public ISet<Project> HasAccessTo { get; set; } = null!;

    public ISet<Project> IsOwnerOf { get; set; } = null!;

    public User(Guid id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }

    public User()
    {

    }
}

public record UserDTO (Guid Id, string DisplayName);

public record UserProjectDTO(Guid Id, IReadOnlyCollection<ProjectDTO> Owns, IReadOnlyCollection<ProjectDTO> HasAccesTo);