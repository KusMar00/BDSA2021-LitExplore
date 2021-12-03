using LitExplore.Repository.Entities;
using LitExplore.Repository;
using Microsoft.EntityFrameworkCore;

public interface IPaperDiscovery
{
    Task<PaperDTO?> GetPaperAsync(int id);
    Task<IReadOnlyCollection<PaperDTO>?> GetRelatedPaperAsync(int id);

}