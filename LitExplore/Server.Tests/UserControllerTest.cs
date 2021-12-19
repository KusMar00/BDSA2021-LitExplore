using Xunit;
using System;
using System.Collections.Generic;
using LitExplore.Repository;
using LitExplore.Repository.Entities;
using LitExplore.Repository.Tests;
using LitExplore.Server.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace LitExplore.Server.Tests;

public class UserControllerTest : RepositoryTests
{
    private IUserRepository repo;
    private UserController userController;
    public UserControllerTest() {
        repo = new UserRepository(Context);
        var logger = new Mock<ILogger<UserController>>();
        userController = new UserController(logger.Object, repo);
    }
    
    private readonly Guid
        guid_1 = Guid.Parse("ebe36c43-60c7-4a36-81bc-0434c9c32721"),
        guid_2 = Guid.Parse("d12da757-4b34-4968-9a95-9dce8b15af3c"),
        guid_3 = Guid.Parse("3d36e17c-b0aa-434a-9f29-cd880d062ae9"),
        guid_4 = Guid.Parse("c769e61decf34661be80f421340f9a72");


    protected override void SeedDatabase() {
        User
            User_1 = new User {Id = guid_1, DisplayName = "User 1" },
            User_2 = new User {Id = guid_2, DisplayName = "User 2" },
            User_3 = new User {Id = guid_3, DisplayName = "User 3" };

            Context.Users.AddRange(new[]{User_1, User_2, User_3});
            Context.SaveChanges();
    }

    [Fact]
    public async void Get_User_By_Guid_1_Returns_User_1()
    {
        // Arrange
        UserDTO? expected = new(
            Id: guid_1,
            DisplayName: "User 1"
        );
    
        // Act
        var actual = await userController.Get(guid_1);
    
        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.DisplayName, actual.DisplayName);
    }

    [Fact]
    public async void Get_User_By_Guid_4_Returns_Null()
    {
        // Arrange
        UserDTO? expected = null;
    
        // Act
        var actual = await userController.Get(guid_4);
    
        // Assert
        Assert.Equal(expected, actual);
    }


    [Fact]
    public async void Post_User_With_Guid_4_Returns_Status_Created_And_User_4()
    {
        // Arrange
        Status? expected = Status.Created;
    
        // Act
        UserDTO testUser = new UserDTO(guid_4, "User 4");
        var actual = await userController.Post(testUser);
    
        // Assert
        Assert.Equal(expected, actual.Item1);
        Assert.Equal(testUser, actual.Item2);
    }


    [Fact]
    public async void Post_User_With_Guid_1_Returns_Status_Conflict()
    {
        // Arrange
        Status? expected = Status.Conflict;
    
        // Act
        var actual = await userController.Post(new UserDTO(guid_1, "User 1"));
    
        // Assert
        Assert.Equal(expected, actual.Item1);
    }


    [Fact]
    public async void Delete_User_With_Guid_1_Returns_Status_Deleted()
    {
        // Arrange
        Status? expected = Status.Deleted;
    
        // Act
        var actual = await userController.delete(guid_1);
    
        // Assert
        Assert.Equal(expected, actual);
    }


    [Fact]
    public async void Delete_User_With_Guid_4_Returns_Status_NotFound()
    {
        // Arrange
        Status? expected = Status.NotFound;
    
        // Act
        var actual = await userController.delete(guid_4);
    
        // Assert
        Assert.Equal(expected, actual);
    }

}