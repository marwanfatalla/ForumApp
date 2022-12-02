using ForumAPI.Controllers;
using ForumAPI.Entities;
using ForumAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Thread = ForumAPI.Entities.Thread;
using CategoryEnum = ForumAPI.Enums.CategoryEnum;

namespace ForumTests.Controllers
{
    public class ThreadsControllerTests
    {
        private readonly Mock<IThreadServices> serviceStub = new();
        [Fact]
        public void GetAll_UnexistingThreads_ReturnsNotFound()
        {
            //Arrange
            serviceStub.Setup(service => service.GetAllThreads()).Returns(new List<ForumAPI.Entities.Thread>());
            var controller = new ThreadsController(serviceStub.Object);
            //Act
            var result = controller.GetAll();
            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetAll_ExistingThreads_ReturnsExpectedThreads()
        {
            //Arrange
            var expectedThreads = GenerateThreads();
            serviceStub.Setup(service => service.GetAllThreads()).Returns(expectedThreads);
            var controller = new ThreadsController(serviceStub.Object);
            //Act
            var result = controller.GetAll();
            //Assert
            Assert.IsType<List<Thread>>(result.Value);
            Assert.Equal(expectedThreads, result.Value);
        }

        public List<Thread> GenerateThreads()
        {
            var programmingPosts = new List<Post>
            {
                new Post(){Id = Guid.NewGuid(), Username="Diogo", Title="Here's how to create a forum using .Net and React", Body="Just try to do it and google search your way in, Just try to do it and google search your way in, Just try to do it and google search your way in.", Category = ForumAPI.Enums.CategoryEnum.Clarification, ImageURL="..."},
                new Post(){Id = Guid.NewGuid(), Username="Marwan", Title="For programmers who stress alot", Body="Calm down you should enjoy programming and building stuff don't stress it. Calm down you should enjoy programming and building stuff don't stress it. ", Category = CategoryEnum.Suggestion, ImageURL="..."},
                new Post(){Id = Guid.NewGuid(), Username="Marwan", Title="How to center a div", Body="You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.You can't.", Category = CategoryEnum.Question, ImageURL="..."},
            };

            var filmPosts = new List<Post>
            {
                new Post(){Id = Guid.NewGuid(), Username="Diogo", Title="For those who say Andrei Tarkovsky's films are boring, here's what you want to do", Body="Don't watch his movies. Don't watch his movies. Don't watch his movies", Category = CategoryEnum.Suggestion, ImageURL="..."},
                new Post(){Id = Guid.NewGuid(), Username="Marwan", Title="What are the best Christmas films ever", Body="Christmas is coming and I want to know. Christmas is coming and I want to know. Christmas is coming and I want to know. ", Category = CategoryEnum.Question, ImageURL="..."},

            };

            return new List<Thread>
            {
                new Thread(){Id = "0", Title="Programming", Posts = programmingPosts},
                new Thread(){Id = "1", Title="Films", Posts = filmPosts},
            };

        }
    }
}