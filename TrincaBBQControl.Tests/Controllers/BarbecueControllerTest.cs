using Microsoft.AspNetCore.Mvc;
using Moq;
using TrincaBBQControl.API.Controllers;
using TrincaBBQControl.Domain.Contracts.Services;
using TrincaBBQControl.Domain.Entities;

namespace TrincaBBQControl.Tests.Controllers
{
    public class BarbecueControllerTest
    {
        [Fact]
        public async Task CreateBarbecue_ReturnsOkResult()
        {
            // Arrange
            var barbecueServiceMock = new Mock<IBarbecueService>();
            var controller = new BarbecueController(barbecueServiceMock.Object);
            var barbecue = new Barbecue();

            // Act
            var result = await controller.CreateBarbecue(barbecue);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult()
        {
            // Arrange
            var barbecueServiceMock = new Mock<IBarbecueService>();
            var controller = new BarbecueController(barbecueServiceMock.Object);
            var id = 1;

            // Act
            var result = await controller.GetById(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            // Arrange
            var barbecueServiceMock = new Mock<IBarbecueService>();
            var controller = new BarbecueController(barbecueServiceMock.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
