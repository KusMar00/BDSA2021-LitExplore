﻿namespace LitExplore.Repository.Entities;

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

}

//Owner skal måske være UserDTO og Iset<User> skal måske være Iset<UserDTO>
public record ProjectDTO(int Id, User Owner, ISet<User> Collaborators)
{
    private User owner;
    private ISet<User> collaborators;
}

//skal måske være paperDTO i Iset papers
public record ProjectDetailsDTO(int Id, User Owner, ISet<User> Collaborators, ISet<Paper> Papers) : ProjectDTO(Id, Owner, Collaborators);

public record ProjectCreateDTO
{
    [Required]
    public User Owner { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
}

public record ProjectAddRemoveCollaboratorDTO
{
    [Required]
    public int ProjectId { get; set; }

    [Required]
    public Guid CollaboratorId { get; set; }
}

public record ProjectAddRemovePaperDTO
{
    [Required]
    public int ProjectId { get; set; }

    [Required]
    public int PaperId { get; set; }
}
