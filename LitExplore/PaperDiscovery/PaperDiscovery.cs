﻿using LitExplore.Repository;
using LitExplore.Repository.Entities;
using System.Linq;
using System.Diagnostics.CodeAnalysis;


namespace LitExplore.PaperDiscovery;

    [ExcludeFromCodeCoverage]
    public static class PaperDiscovery

    {
        /// <summary>
        /// Returns a list of all papers which are related to any paper in a
        /// given project (excluding those which are already in the project).
        /// </summary>
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
