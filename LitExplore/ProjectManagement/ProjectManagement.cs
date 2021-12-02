using LitExplore.Repository.Entities;
using LitExplore.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

//todo: Skal user have et dbset? Færdiggør fra linje 79 og lav tilhørende tests

namespace LitExplore.ProjectManagement
{
    public class ProjectManagement : IProjectRepository
    {
        private readonly LitExploreContext context;
        public ProjectManagement(LitExploreContext _context)
        {
            context = _context;
        }

        public async Task<ProjectDTO> ReadProjectAsync(string id)
        {

            var project = from p in context.Projects
                          where p.Id.Equals(id)
                          select new ProjectDTO(p.Id, p.Owner, p.Collaborators);
            return await project.FirstOrDefaultAsync();

            // var project = (from p in context.Projects
            //                 where p.Id.Equals(id)
            //                 select new ProjectDTO(p.Id, p.Owner, p.Collaborators)).FirstOrDefaultAsync();
            // return await project;
        }


        public async Task<ProjectDetailsDTO> ReadProjectDetailsAsync(string id)
        {
            var project = from p in context.Projects
                          where p.Id.Equals(id)
                          select new ProjectDetailsDTO(p.Id, p.Owner, p.Collaborators, p.Papers);
            return await project.FirstOrDefaultAsync();
        }

        public async Task<Status> DeleteProjectAsync(string id)
        {
            var entity = await context.Projects.FindAsync(id);

            if (entity == null)
            {
                return Status.NotFound;
            }

            context.Projects.Remove(entity);
            await context.SaveChangesAsync();

            return Status.Deleted;
        }

        public async Task<(Status, ProjectDTO)> CreateProjectAsync(ProjectCreateDTO project)
        {
            if (project == null)
            {
                return (Status.BadRequest, null); //hvilken projectDTO her?
            }
            else
            {
                var entity = new Project
                {
                    Name = project.Name,
                    Owner = project.Owner,
                };

                context.Projects.Add(entity);
                await context.SaveChangesAsync();

                return (Status.Created, new ProjectDTO(entity.Id, entity.Owner, entity.Collaborators));

            }

        }

        public async Task<Status> AddCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project)
        {

            //Find projectet
            //Find user ud fra collaborator id
            //Tilføj den user til projectet

            var entity = await context.Projects.FirstOrDefaultAsync(p => p.Id == project.ProjectId);

            if (entity == null)
            {
                return Status.NotFound;
            }

            //collaborator er muligvis ikke en user her
            var collaborator = context.Users.Where(u => u.Id == project.CollaboratorId);
            context.Projects.Select(p => p.Collaborators.UnionWith(collaborator));
        }
        public async Task<Status> RemoveCollaboratorAsync(ProjectAddRemoveCollaboratorDTO project);
        public async Task<Status> AddPaperAsync(ProjectAddRemovePaperDTO project);
        public async Task<Status> RemovePaperAsync(ProjectAddRemovePaperDTO project);

    }

}