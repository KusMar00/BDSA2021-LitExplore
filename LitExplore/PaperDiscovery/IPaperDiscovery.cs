using LitExplore.Repository.Entities;

public interface IPaperDiscovery
{
    Task<PaperDTO?> GetPaperAsync(int id);
    public Task<IReadOnlyCollection<PaperDTO>?> GetRelatedPaperAsync(int projectId);

}