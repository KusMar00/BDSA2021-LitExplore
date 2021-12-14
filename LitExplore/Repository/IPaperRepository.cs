namespace LitExplore.Repository;


public interface IPaperRepository
{
    Task<PaperDTO?> ReadAsync(int id);
    Task<PaperDetailsDTO?> ReadDetailsAsync(int id);
    /// <summary>
    /// Reads a list of papers with a name simmilar to <paramref name="name"/>.
    /// </summary>
    Task<IReadOnlyCollection<PaperDTO>> ReadByNameAsync(string name);
    /// <summary>
    /// Reads a list of papers which are related to a given paper.
    /// Currenty, related papers are papers which either cite the given paper
    /// or is cited by the given paper.
    /// </summary>
    Task<IReadOnlyCollection<PaperDTO>> ReadByRelationsAsync(int paperId);
}

