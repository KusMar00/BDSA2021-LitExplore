using LitExplore.Repository.Entities;

namespace LitExplore.ProjectManagement
{
    public class ProjectManagement
    {
        List<ProjectDetailsDTO> projects;

        public ProjectManagement(List<ProjectDetailsDTO> _projects)
        {
            projects = _projects;
        }

        public async Task<ProjectDetailsDTO> getProject(int id)
        {
            return projects[id];
        }

        public async Task<Status> deleteProject(int id)
        {
            for (int i = 0; i < projects.Count; i++)
            {
                if (projects[i].Id == id)
                {
                    projects.RemoveAt(i);
                    return Status.Deleted;
                }
            }
            return Status.NotFound;
        }

        //Skal nok tage en projectcreateDTO, men så kan den ikke komme ind i listen
        public async Task<ProjectDetailsDTO> postProject(ProjectDetailsDTO project) {
            projects.Add(project);

            return project;
        }

        

        //Ved ikke lige hvorfor getter ikke virker i field
        public List<ProjectDetailsDTO> getProjects() {
            return projects;
        }

    }

}