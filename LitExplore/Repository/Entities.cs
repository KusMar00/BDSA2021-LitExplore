namespace LitExplore.Repository
{
    public class Paper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ICollection<Author> Authors { get; set; } = null!;

        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(250)]
        [Url]
        public string? URL { get; set; }

        [StringLength(2200)]
        public string? Abstract { get; set; }

        public ICollection<Paper> Citings { get; set; } = null!;
    }

    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string? GivenName { get; set; }

        [StringLength(50)]
        public string? Surname { get; set; }
    }

    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public User Owner { get; set; } = null!;

        public IEnumerable<User> Collaborators { get; set; } = null!;

        public IEnumerable<Paper> Papers { get; set; } = null!;

    }

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string? DisplayName { get; set; }
    }
}
