using System.Diagnostics.CodeAnalysis;

namespace LitExplore.Repository.Entities;

public class Paper
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public ISet<Author> Authors { get; set; } = null!;

    [StringLength(150)]
    public string? Name { get; set; }

    [StringLength(250)]
    [Url]
    public string? URL { get; set; }

    [StringLength(2200)]
    public string? Abstract { get; set; }

    public ISet<Project> UsedIn { get; set; } = null!;

    // When creating the database, EF Core will generate a 'PaperPaper' entity for these two collections.
    // This entity is equivilent to the 'Relation' object in the Application model.
    public ICollection<Paper> Citings { get; set; } = null!;
    public ICollection<Paper> CitedBy { get; set; } = null!;
}

public record PaperDTO (int Id, string? Name);
public record PaperDetailsDTO (int Id, string? Name, ISet<AuthorDTO> Authors, string? URL, string? Abstract) : PaperDTO (Id, Name);
