using Xunit;
using System;
using System.Collections.Generic;
using LitExplore.Repository;
using LitExplore.Repository.Entities;
using LitExplore.Repository.Tests;
using LitExplore.Server.Controllers;
using Microsoft.Extensions.Logging;

namespace LitExplore.Server.Tests
{
    public class ProjectControllerTest : RepositoryTests
    {
        private IProjectRepository repo;
        private ProjectController projectManagement;
        public ProjectControllerTest () {
            repo = database.ProjectRepository;
            var logger = new Logger<ProjectController>;
            projectManagement = new ProjectController(_logger, repo);
        }

        private readonly Guid
            guid_1 = Guid.Parse("ebe36c43-60c7-4a36-81bc-0434c9c32721"),
            guid_2 = Guid.Parse("d12da757-4b34-4968-9a95-9dce8b15af3c"),
            guid_3 = Guid.Parse("3d36e17c-b0aa-434a-9f29-cd880d062ae9");
        
        protected override void SeedDatabase() {
            Author
                Author_1 = new Author{Id = 1, GivenName = "James", Surname = "Wilson"},
                Author_2 = new Author{Id = 2, GivenName = "Mark", Surname = "Madsen"},
                Author_3 = new Author{Id = 3, GivenName = "Johnny", Surname = "Deluxe"};
            
            Paper
                Paper_1 = new Paper{Id = 1, Name = "Paper1", Authors = new HashSet<Author>{Author_1}, URL = null, Abstract = null},
                Paper_2 = new Paper{Id = 2, Name = "Paper2", Authors = new HashSet<Author>{Author_2}, URL = null, Abstract = null, Citings = new []{Paper_1}},
                Paper_3 = new Paper{Id = 3, Name = "Paper3", Authors = new HashSet<Author>{Author_3}, URL = null, Abstract = null, Citings = new []{Paper_2}},
                Paper_4 = new Paper{Id = 4, Name = "Paper4", Authors = new HashSet<Author>{Author_1, Author_2}, URL = null, Abstract = null};

            User
                User_1 = new User {Id = guid_1, DisplayName = "User 1" },
                User_2 = new User {Id = guid_2, DisplayName = "User 2" },
                User_3 = new User {Id = guid_3, DisplayName = "User 3" };

            Project 
                Project_1 = new Project 
                {
                    Id = 1,
                    Name = "Project 1",
                    Owner = User_1,
                    Collaborators = new HashSet<User>(){User_2},
                    Papers = new HashSet<Paper>(){Paper_1}
                },
                Project_2 = new Project
                {
                    Id = 2,
                    Name = "Project 2",
                    Owner = User_2,
                    Collaborators = new HashSet<User>(){User_3},
                    Papers = new HashSet<Paper>(){Paper_2, Paper_3}
                },
                Project_3 = new Project
                {
                    Id = 3,
                    Name = "Project 3",
                    Owner = User_3,
                    Collaborators = new HashSet<User>(){User_1, User_2},
                    Papers = new HashSet<Paper>(){Paper_1,Paper_2,Paper_3,Paper_4}
                };
                
                Context.Projects.AddRange(new[] {Project_1, Project_2, Project_3});
                Context.SaveChanges();
        }

        #region GetProject
        [Fact]
        public async void GetProjectAsync_Project_1_Returns_Project_1()
        {
             // Arrange
            ProjectDTO? expected = new(
                Id: 1, 
                Name: "Project 1", 
                Owner: new (guid_1, "User 1"), 
                Collaborators: new HashSet<UserDTO>(){
                    new (guid_2, "User 2"),
                }
            );

            // Act
            var actual = await repo.GetProjectAsync(1);

            // Assert
            #pragma warning disable CS8602
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Owner, actual.Owner);
            Assert.Equal(expected.Collaborators, actual.Collaborators);
        }
        #endregion
    }
}