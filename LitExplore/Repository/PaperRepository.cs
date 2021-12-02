namespace LitExplore.Repository;

public class PaperRepository : IPaperRepository
{
    protected LitExploreContext context;

    public PaperRepository(LitExploreContext context) => this.context = context;

    public async Task<PaperDTO?> ReadAsync(int id)
    {
        return null;
    }

    public Task<IReadOnlyCollection<PaperDTO>> ReadByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<PaperDTO>> ReadByRelationsAsync(int paperId)
    {
        throw new NotImplementedException();
    }

    public Task<PaperDetailsDTO?> ReadDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }
}
