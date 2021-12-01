using Xunit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LitExplore.Repository.Entities;
using System;
using System.Threading.Tasks;

namespace LitExplore.ProjectManagement.Tests
{
    public class ProjectManagementsTests
    {

        public List<ProjectDetailsDTO> projects = new List<ProjectDetailsDTO>();
        public ProjectManagement _projectmanagement;

        public ProjectManagementsTests()
        {
            var Users = new List<UserDTO>(){
                new UserDTO(Guid.NewGuid(), "Peter"),
                new UserDTO(Guid.NewGuid(), "Albert"),
                new UserDTO(Guid.NewGuid(), "Frank")
            };

            var Papers = new List<PaperDTO>(){
                new PaperDTO(0, "Fancy paper"),
                new PaperDTO(1, "Boring paper"),
                new PaperDTO(2, "Cool paper"),
                new PaperDTO(3, "Awesome paper")
            };

            //Each project contains same collaborators for now
            var collaborators = new HashSet<UserDTO>();
            collaborators.Add(Users[1]);
            collaborators.Add(Users[2]);

            //Each project contains same papers for now
            var paperSet = new HashSet<PaperDTO>();
            paperSet.Add(Papers[0]);
            paperSet.Add(Papers[2]);

            var projectsToAdd = new List<ProjectDetailsDTO>() {
                new ProjectDetailsDTO(0, Users[0], collaborators, paperSet),
                new ProjectDetailsDTO(1, Users[1], collaborators, paperSet),
                new ProjectDetailsDTO(2, Users[2], collaborators, paperSet)
            };

            //Simulering af tilføjelse til context
            projects.AddRange(projectsToAdd);

            _projectmanagement = new ProjectManagement(projects);
            
        }

        [Fact]
        public async Task Given_ProjectID0_Returns_Project0_async()
        {
            var project = await _projectmanagement.getProject(0);

            Assert.Equal(projects[0], project);
        }

        [Fact]
        public async Task Given_ProjectID0_Deletes_Project0_async()
        {
            var status = await _projectmanagement.deleteProject(0);
            
            Assert.Equal(Status.Deleted, status);
            Assert.Equal(2, _projectmanagement.getProjects().Count);
        }

        [Fact]
        public async Task Given_Project_Adds_To_ProjectList()
        {
        
            var project = new ProjectDetailsDTO(5, new UserDTO(Guid.NewGuid(), "Lone"), new HashSet<UserDTO>(), new HashSet<PaperDTO>());

            var projectDTO = await _projectmanagement.postProject(project);

            var added = await _projectmanagement.getProject(3);

            Assert.Equal(projectDTO, project);
            Assert.Equal(added, projectDTO);
        }

        

    }
}