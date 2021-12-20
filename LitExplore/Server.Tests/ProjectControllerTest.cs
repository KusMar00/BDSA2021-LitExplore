using Xunit;
using System;
using System.Collections.Generic;
using LitExplore.Repository;
using LitExplore.Repository.Entities;
using LitExplore.Repository.Tests;
using LitExplore.Server.Controllers;
using Microsoft.Extensions.Logging;
using Moq;


namespace LitExplore.Server.Tests;

    public class ProjectControllerTest : RepositoryTests
    {
        private IProjectRepository repo;
        private ProjectController projectController;
        public ProjectControllerTest () {
            repo = new ProjectRepository(Context);
            var logger = new Mock<ILogger<ProjectController>>();
            projectController = new ProjectController(logger.Object, repo);
        }

        private readonly Guid
            guid_1 = Guid.Parse("ebe36c43-60c7-4a36-81bc-0434c9c32721"),
            guid_2 = Guid.Parse("d12da757-4b34-4968-9a95-9dce8b15af3c"),
            guid_3 = Guid.Parse("3d36e17c-b0aa-434a-9f29-cd880d062ae9"),
            guid_4 = Guid.Parse("c769e61decf34661be80f421340f9a72");
        
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
                User_3 = new User {Id = guid_3, DisplayName = "User 3" },
                User_4 = new User {Id = guid_4, DisplayName = "User 4" };

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
                Context.Users.Add(User_4);
                Context.SaveChanges();
        }

        #region GetProject
        [Fact]
        public async void Get_Project_By_Id_1_Returns_Project_1()
        {
             // Arrange
            ProjectDetailsDTO? expected = new(
                Id: 1, 
                Name: "Project 1", 
                Owner: new (guid_1, "User 1"), 
                Collaborators: new HashSet<UserDTO>(){
                    new (guid_2, "User 2"),
                },
                Papers: new HashSet<PaperDTO>(){
                    new (1, "Paper1"),
                }
            );

            // Act
            var actual = await projectController.Get(1);

            // Assert
            #pragma warning disable CS8602
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Owner, actual.Owner);
            Assert.Equal(expected.Collaborators, actual.Collaborators);
        }
        #endregion

        #region DeleteProject
        [Fact]
        public async void Delete_Project_By_Id_2_Returns_Status_Deleted(){
            // Arrange
            Status? expected = Status.Deleted;

            // Act
            var actual = await projectController.Delete(2);
            
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void Delete_Project_By_Id_10_Returns_Status_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectController.Delete(10);
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region PostPaper
        [Fact]
        public async void Post_Paper_3_To_Existing_Project_1_Returns_Status_Updated()
        {
            // Arrange
            Status? expected = Status.Updated;

            // Act
            var actual = await projectController.Post(new ProjectAddRemovePaperDTO(1, 3));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void Post_Paper_2_To_Non_Existing_Project_10_Returns_Status_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectController.Post(new ProjectAddRemovePaperDTO(10, 2));

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region DeletePaper
        [Fact]
        public async void Delete_Paper_1_From_Project_1_Returns_Status_Deleted()
        {
            // Arrange
            Status? expected = Status.Deleted;

            // Act
            var actual = await projectController.Delete(new ProjectAddRemovePaperDTO(1, 1));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void Delete_Paper_2_From_Project_1_Returns_Status_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectController.Delete(new ProjectAddRemovePaperDTO(1, 2));

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region PostCollaborator
        [Fact]
        public async void Post_Collaborator_3_To_Existing_Project_1_Returns_Status_Updated()
        {
            // Arrange
            Status? expected = Status.Updated;

            // Act
            var actual = await projectController.Post(new ProjectAddRemoveCollaboratorDTO(1, guid_3));

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public async void Post_Non_Existing_Collaborator_To_Existing_Project_1_Returns_Status_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectController.Post(new ProjectAddRemoveCollaboratorDTO(1, Guid.Empty));

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public async void Post_Collaborator_4_To_Non_Existing_Project_Returns_Status_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectController.Post(new ProjectAddRemoveCollaboratorDTO(4, guid_4));

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region DeleteCollaborator
        [Fact]
        public async void Delete_Collaborator_3_From_Project_2_Returns_Deleted()
        {
            // Arrange
            Status? expected = Status.Deleted;

            // Act
            var actual = await projectController.Delete(new ProjectAddRemoveCollaboratorDTO(2, guid_3));

            // Assert
            Assert.Equal(expected, actual);
        }

         [Fact]
        public async void Delete_Collaborator_3_From_Project_1_Returns_NotFound()
        {
            // Arrange
            Status? expected = Status.NotFound;

            // Act
            var actual = await projectController.Delete(new ProjectAddRemoveCollaboratorDTO(1, guid_3));

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        [Fact]
        public async void Get_UserProjectDTO_By_userId_4_Returns_Empty_UserProjectDTO()
        {
            // Arrange
            var expected = new UserProjectDTO(Id: guid_4, 
                                            Owns: new List<ProjectDTO>(){ }.AsReadOnly(), 
                                            HasAccesTo: new List<ProjectDTO>(){ }.AsReadOnly()
                                            );

            // Act
            var actual = await projectController.Get(guid_4);
        
            // Assert
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Owns, actual.Owns);
            Assert.Equal(expected.HasAccesTo, actual.HasAccesTo);
        }

        [Fact]
        public async void ReadProjectsByUserAsync_User_Null_Returns_Empty_UserProjectDTO()
        {
            // Arrange
            var expected = new UserProjectDTO(Id: Guid.Empty, 
                                            Owns: new List<ProjectDTO>(){ }.AsReadOnly(), 
                                            HasAccesTo: new List<ProjectDTO>(){ }.AsReadOnly()
                                            );

            // Act
            User? testUser = new User(Guid.Empty, "");
            var actual = await projectController.Get(testUser.Id);
        
            // Assert
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Owns, actual.Owns);
            Assert.Equal(expected.HasAccesTo, actual.HasAccesTo);
        }
        
    private void AssertProjectDTOEquals (ProjectDTO? expected, ProjectDTO? actual)
    {
        Assert.NotNull(actual);
        #pragma warning disable CS8602 // Dereference of a possibly null reference.
        Assert.Equal(expected.Id, actual.Id);
        #pragma warning restore CS8602 // Dereference of a possibly null reference.
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Owner, actual.Owner);
        Assert.Equal(expected.Collaborators, actual.Collaborators);
    }
    [Fact]
    public async void Post_Creates_Project_And_Returns_Created()
    {
        // Arrange
        var expectedStatus = Status.Created;
        var expectedProject = new ProjectDTO(
            Id: 4,
            Name: "Project 4",
            Owner: new(guid_3, "User 3"),
            Collaborators: new HashSet<UserDTO>()
        );

        // Act
         var actual = await projectController.Post(new ProjectCreateDTO(guid_3, "Project 4"));

        // Assert
        Assert.Equal(expectedStatus, actual.Item1);
        AssertProjectDTOEquals(expectedProject, actual.Item2);
        // Was the project actually created?
        AssertProjectDTOEquals(expectedProject, await projectController.Get(4));
    }

    [Fact]
    public async void Post_Non_Existing_User_Returns_NotFound()
    {
        // Arrange
        var expectedStatus = Status.NotFound;

        // Act
        var actual = await projectController.Post(new ProjectCreateDTO(Guid.Empty, "Project 5"));

        // Assert
        Assert.Equal(expectedStatus, actual.Item1);
        Assert.Null(actual.Item2);
        Assert.Null(await repo.ReadProjectAsync(5));
    }

    [Fact]
    public async void CreateProjectAsync_Name_Exists_For_Owner_Conflict()
    {
        // Arrange
        var expectedStatus = Status.Conflict;
        var expectedProject = new ProjectDTO(
            Id: 1,
            Name: "Project 1",
            Owner: new UserDTO(guid_1, "User 1"),
            Collaborators: new HashSet<UserDTO>()
            {
                new UserDTO(guid_2, "User 2"),
            }
        );

        // Act
        var actual = await projectController.Post(new ProjectCreateDTO(guid_1, "Project 1"));

        // Assert
        Assert.Equal(expectedStatus, actual.Item1);
        AssertProjectDTOEquals(expectedProject, actual.Item2);
    }   
}