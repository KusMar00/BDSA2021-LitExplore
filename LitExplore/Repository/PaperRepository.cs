namespace LitExplore.Repository;

public class PaperRepository : IPaperRepository
{
    protected LitExploreContext context;

    public PaperRepository(LitExploreContext context) => this.context = context;

    public async Task<PaperDTO?> ReadAsync(int id)
    {
        var papers = from p in context.Papers
                     where p.Id == id
                     select new PaperDTO(p.Id, p.Name);
        return await papers.FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<PaperDTO>> ReadByNameAsync(string name)
    {
        var papers = from p in context.Papers
                     where p.Name != null && p.Name.ToLower().Contains(name.ToLower())
                     select new PaperDTO(p.Id, p.Name);
        return (await papers.ToListAsync()).AsReadOnly();
    }

    public async Task<IReadOnlyCollection<PaperDTO>> ReadByRelationsAsync(int paperId)
    {
        var papers = from p in context.Papers
                     // This checks the number of cited/citedby papers whose id matches paperId.
                     // using .First may be a little faster, but it is slightly less readable.
                     where p.Citings.Count(p => p.Id == paperId) > 0 || p.CitedBy.Count(p => p.Id == paperId) > 0
                     select new PaperDTO(p.Id, p.Name);

        return (await papers.ToListAsync()).AsReadOnly();
    }
    
    public async Task<PaperDetailsDTO?> ReadDetailsAsync(int id)
    {
        var papers = from p in context.Papers
                     where p.Id == id
                     select new PaperDetailsDTO(
                         p.Id,
                         p.Name,
                         ( // We need to convert Authors to AuthorDTOs.
                             from a in p.Authors
                             select new AuthorDTO(a.Id, a.GivenName, a.Surname)
                         ).ToHashSet(),
                         p.URL,
                         p.Abstract
                     );
        return await papers.FirstOrDefaultAsync();
    }
}
