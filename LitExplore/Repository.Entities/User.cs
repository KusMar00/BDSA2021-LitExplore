namespace LitExplore.Repository.Entities;

public class User
{
    [Key, Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Key, Column(Order = 1)]
    [EmailAddress]
    public string Email { get; set; }

    [StringLength(50)]
    public string DisplayName { get; set; } = null!;

    public ISet<Project> HasAccessTo { get; set; } = null!;

    public ISet<Project> IsOwnerOf { get; set; } = null!;

    public User(Guid id, string email, string displayName)
    {
        Id = id;
        Email = email;
        DisplayName = displayName;
    }

    public User()
    {

    }
}

public record UserDTO (Guid Id, string Email, string DisplayName);

public record UserProjectDTO(Guid Id, string Email, IReadOnlyCollection<ProjectDTO> Owns, IReadOnlyCollection<ProjectDTO> HasAccesTo);