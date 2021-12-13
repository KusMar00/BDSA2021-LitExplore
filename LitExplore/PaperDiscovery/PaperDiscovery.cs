using LitExplore.Repository;
using LitExplore.Repository.Entities;
using System.Linq;



namespace LitExplore.PaperDiscovery;

    public static class PaperDiscovery
    {
        public static async Task<IReadOnlyCollection<PaperDTO>> GetPapersRelatedToProject(int projectId, IProjectRepository projectRepo, IPaperRepository paperRepo) {
            var projectPapers = (await projectRepo.ReadProjectDetailsAsync(projectId))?.Papers ?? new HashSet<PaperDTO>() { };
            var recommendedPapers = new HashSet<PaperDTO>() { };
            foreach (var paper in projectPapers)
            {
                var relatedPapers = (await paperRepo.ReadByRelationsAsync(paper.Id)).ToHashSet();
                recommendedPapers.UnionWith(relatedPapers);
            }
            var finalList = recommendedPapers.ToList().Except(projectPapers);
            return finalList.ToList().AsReadOnly();
        }
    }
