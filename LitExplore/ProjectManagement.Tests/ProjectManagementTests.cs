using System.Collections.Generic;
using LitExplore.Repository.Entities;
using System;
using LitExplore.Repository.Tests;
using LitExplore.Repository;
using Xunit;

namespace LitExplore.ProjectManagement.Tests;

    public class ProjectManagementsTests : RepositoryTests
    {

        private IProjectRepository repo;
        private ProjectManagement projectManagement;
        public ProjectManagementsTests()
        {
            repo = database.ProjectRepository;
            projectManagement = new ProjectManagement(database, "AdminTestUser");
        }

        private readonly Guid
            guid_1 = Guid.Parse("ebe36c43-60c7-4a36-81bc-0434c9c32721"),
            guid_2 = Guid.Parse("d12da757-4b34-4968-9a95-9dce8b15af3c"),
            guid_3 = Guid.Parse("3d36e17c-b0aa-434a-9f29-cd880d062ae9");
        
        protected override void SeedDatabase()
        {
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

        [Fact]
        public async void GetProjectAsync_Project_1_Returns_Project_1(){
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
            var actual = await projectManagement.GetProjectAsync(1);

            // Assert
            #pragma warning disable CS8602
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Owner, actual.Owner);
            Assert.Equal(expected.Collaborators, actual.Collaborators);
        }

        [Fact]
        public async void DeleteProjectAsync_Project_2_Returns_Status_Deleted(){
            // Arrange
            Status? expected = Status.Deleted;

            // Act
            var actual = await projectManagement.DeleteProjectAsync(2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void DeleteProjectAsync_Project_10_Returns_Status_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectManagement.DeleteProjectAsync(10);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void DeleteProjectAsync_As_NonAuthorized_User_Returns_NotAuthorized()
        {
            // Arrange
            Status? expected = Status.NotAuthorized;
            projectManagement.userName = "hacker";

            // Act
            var actual = await projectManagement.DeleteProjectAsync(10);

            // Assert
            Assert.Equal(expected, actual);
        }



        [Fact]
        public async void PostPaperToProject_To_Existing_Project_Returns_Status_Updated()
        {
            // Arrange
            Status? expected = Status.Updated;

            // Act
            var actual = await projectManagement.PostPaperToProjectAsync(new(1, 3));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void PostPaperToProject_To_Non_Existing_Project_Returns_Status_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectManagement.PostPaperToProjectAsync(new(10, 2));

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public async void DeletePaperFromProjectAsync_Paper1_From_Project1_Returns_Status_Deleted()
        {
            // Arrange
            Status? expected = Status.Deleted;

            // Act
            var actual = await projectManagement.DeletePaperFromProjectAsync(new(1, 1));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void DeletePaperFromProjectAsync_Paper2_From_Project1_Returns_Status_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectManagement.DeletePaperFromProjectAsync(new(1, 2));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void PostCollaboratorToProjectAsync_User3_To_Project1_Returns_Status_Updated()
        {
            // Arrange
            Status? expected = Status.Updated;

            // Act
            var actual = await projectManagement.PostCollaboratorToProjectAsync(new(1, guid_3));

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public async void PostCollaboratorToProjectAsync_Non_Existing_User_To_Project1_Returns_Status_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectManagement.PostCollaboratorToProjectAsync(new(1, Guid.Empty));

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public async void PostCollaboratorToProjectAsync_User1_To_Non_Existing_Project_Returns_Status_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectManagement.PostCollaboratorToProjectAsync(new(4, guid_1));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void DeleteCollaboratorFromProjectAsync_User3_From_Project_2_Returns_Deleted()
        {
            // Arrange
            Status? expected = Status.Deleted;

            // Act
            var actual = await projectManagement.DeleteCollaboratorFromProjectAsync(new (2, guid_3));

            // Assert
            Assert.Equal(expected, actual);
        }

         [Fact]
        public async void DeleteCollaboratorFromProjectAsync_User3_From_Project_1_Returns_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectManagement.DeleteCollaboratorFromProjectAsync(new (1, guid_3));

            // Assert
            Assert.Equal(expected, actual);
        }

    }