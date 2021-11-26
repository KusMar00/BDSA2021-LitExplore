namespace LitExplore.Repository.Entities;

public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(50)]
    public string GivenName { get; set; } = null!;

    [StringLength(50)]
    public string Surname { get; set; } = null!;
}

public record AuthorDTO(int Id, string GivenName, string Surname);
