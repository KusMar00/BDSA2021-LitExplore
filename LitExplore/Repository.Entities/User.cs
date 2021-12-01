namespace LitExplore.Repository.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(50)]
    public string DisplayName { get; set; } = null!;

    public ISet<Project> HasAccessTo { get; set; } = null!;

    public ISet<Project> IsOwnerOf { get; set; } = null!;
}

public record UserDTO (Guid Id, string DisplayName);
