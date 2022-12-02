using ForumAPI.Controllers;
using ForumAPI.Dtos;
using ForumAPI.Entities;
using ForumAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumTests.Controllers
{
   
    public class PostsControllerTests
    {
        private readonly Mock<IPostService> serviceStub = new();
        [Fact]
        public void CreatePost_TitleOrBodyContainsBadWord_BadRequest()
        {
            //Arrange
            var dto = new CreatePostDto { Body = "Frick string jsnad", Category = 0, ImageURL = "string", Title = "string", Username = "string" };
            var post = new Post {Id=Guid.NewGuid(), Body = "Frick string jsnad", Category = 0, ImageURL = "string", Title = "string", Username = "string" };

            serviceStub.Setup(service => service.CreatePost(new CreatePostDto())).Returns(post);
            var controller = new PostsController(serviceStub.Object);
            //Act
            var result = controller.CreatePost(dto);
            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void CreatePost_ValidData_ExpectedResult()
        {
            //Arrange
            var dto = new CreatePostDto { Body = "Frick string jsnad", Category = 0, ImageURL = "string", Title = "string", Username = "string" };
            var post = new Post { Id = Guid.NewGuid(), Body = "string jsnad", Category = 0, ImageURL = "string", Title = "string", Username = "string" };

            serviceStub.Setup(service => service.CreatePost(dto)).Returns(post);

            var controller = new PostsController(serviceStub.Object);
            //Act
            var result = controller.CreatePost(dto);
            //Assert
            Assert.IsType<Post>(result.Value);
            Assert.Equal(post, result.Value);
        }


    }
}
