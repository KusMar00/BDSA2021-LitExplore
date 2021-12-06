namespace LitExplore.Repository.Entities;

public class Project
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    // The user should never be null, but enforcing this with database constraints
    // causes issues with cycles and cascade paths, so we must handle this manually.
    public User? Owner { get; set; }

    public ISet<User> Collaborators { get; set; } = null!;

    public ISet<Paper> Papers { get; set; } = null!;


    public ProjectDTO ToDTO()
    {
        return new ProjectDTO(
            Id,
            Name,
            new( // The owner should never be null if everything works
                 // as intended, but we better make sure it works
                 // anyway.
                Owner != null ? Owner.Id : Guid.Empty,
                Owner != null ? Owner.DisplayName : ""
            ),
            ( // Convert to DTOs.
                from u in Collaborators
                select new UserDTO(u.Id, u.DisplayName)
            ).ToHashSet()
        );
    }

    public ProjectDetailsDTO ToDetailsDTO()
    {
        var basicDTO = ToDTO();
        return new ProjectDetailsDTO(
            basicDTO.Id,
            basicDTO.Name,
            basicDTO.Owner,
            basicDTO.Collaborators,
            ( // Convert to DTOs.
                from p in Papers
                select new PaperDTO(p.Id, p.Name)
            ).ToHashSet()
        );
    }
}

public record ProjectDTO(int Id, string Name, UserDTO Owner, ISet<UserDTO> Collaborators);

public record ProjectDetailsDTO(int Id, string Name, UserDTO Owner, ISet<UserDTO> Collaborators, ISet<PaperDTO> Papers) : ProjectDTO(Id, Name, Owner, Collaborators);

public record ProjectCreateDTO
{
    public ProjectCreateDTO(Guid ownerId, string name)
    {
        OwnerId = ownerId;
        Name = name;
    }

    [Required]
    public Guid OwnerId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
}

public record ProjectAddRemoveCollaboratorDTO
{
    public ProjectAddRemoveCollaboratorDTO(int projectId, Guid collaboratorId)
    {
        ProjectId = projectId;
        CollaboratorId = collaboratorId;
    }

    /// <summary>
    /// The Project to modify
    /// </summary>
    [Required]
    public int ProjectId { get; set; }

    /// <summary>
    ///  The Collaborator to add/remove
    /// </summary>
    [Required]
    public Guid CollaboratorId { get; set; }
}

public record ProjectAddRemovePaperDTO
{
    public ProjectAddRemovePaperDTO(int projectId, int paperId)
    {
        ProjectId = projectId;
        PaperId = paperId;
    }

    /// <summary>
    /// The Project to modify
    /// </summary>
    [Required]
    public int ProjectId { get; set; }

    /// <summary>
    /// The Paper to add/remove
    /// </summary>
    [Required]
    public int PaperId { get; set; }
}
