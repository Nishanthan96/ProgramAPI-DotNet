using Microsoft.AspNetCore.Mvc;
using Moq;
using ProgramAPI.Controllers;
using ProgramDatabase.Models;
using ProgramService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramXUnitTest
{
    public class EmployerControllerTests
    {
        [Fact]
        public async Task GetQuestionTypes_ReturnsOk()
        {
            var mockService = new Mock<IEmployerService>();
            var controller = new EmployerController(mockService.Object);

            var result = controller.GetQuestionTypes();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateQuestion_ValidInput_ReturnsOk()
        {
            var mockService = new Mock<IEmployerService>();
            mockService.Setup(service => service.AddQuestion(It.IsAny<List<CustomQuestionTemplate>>()))
                       .ReturnsAsync(true);
            var controller = new EmployerController(mockService.Object);
            var questions = new List<CustomQuestionTemplate>(); 

            var result = await controller.CreateQuestion(questions);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetAllQuestions_ReturnsOk()
        {
            var mockService = new Mock<IEmployerService>();
            mockService.Setup(service => service.GetAllQuestions())
                       .ReturnsAsync(new List<CustomQuestionTemplate>());
            var controller = new EmployerController(mockService.Object);

            var result = await controller.GetAllQuestions();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetQuestionByTypeId_ReturnsOk()
        {
            var mockService = new Mock<IEmployerService>();
            mockService.Setup(service => service.GetQuestionById(It.IsAny<int>()))
                       .ReturnsAsync(new CustomQuestionTemplate());
            var controller = new EmployerController(mockService.Object);
            var id = 1;

            var result = await controller.GetQuestionByTypeId(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }
    }
}
