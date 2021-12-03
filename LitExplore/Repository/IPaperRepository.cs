namespace LitExplore.Repository;


public interface IPaperRepository
{
    Task<PaperDTO?> ReadAsync(int id);
    Task<PaperDetailsDTO?> ReadDetailsAsync(int id);
    Task<IReadOnlyCollection<PaperDTO>> ReadByNameAsync(string name);
    Task<IReadOnlyCollection<PaperDTO>> ReadByRelationsAsync(int paperId);
}

