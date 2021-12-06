using LitExplore.Repository.Entities;

public interface IPaperDiscovery
{
    Task<PaperDTO?> GetPaperAsync(int id);
    Task<IReadOnlyCollection<PaperDTO>?> GetRelatedPaperAsync(int id);

}