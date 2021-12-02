using Microsoft.EntityFrameworkCore;

namespace LitExplore.Repository;

public interface ILitExploreContext : IDisposable
{
    DbSet<Paper> Papers { get; }
    DbSet<Author> Authors { get; }
    DbSet<Relation> Relations { get; }
}