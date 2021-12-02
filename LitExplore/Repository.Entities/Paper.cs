namespace LitExplore.Repository.Entities;

public class Paper
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public ISet<Author> Authors { get; set; } = null!;

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(250)]
    [Url]
    public string? URL { get; set; }

    [StringLength(2200)]
    public string? Abstract { get; set; }
}

public record PaperDTO (int Id, string? Name);
public record PaperDetailsDTO (int Id, string? Name, ISet<Author> Authors, string? URL, string? Abstract) : PaperDTO (Id, Name);
