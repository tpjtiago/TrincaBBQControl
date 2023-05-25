using Microsoft.AspNetCore.Mvc;
using Moq;
using TrincaBBQControl.API.Controllers;
using TrincaBBQControl.Domain.Contracts.Services;
using TrincaBBQControl.Domain.Models;

namespace TrincaBBQControl.Tests.Controllers
{
    public class ParticipantControllerTest
    {
        [Fact]
        public async Task CreateParticipant_ReturnsOkResult()
        {
            // Arrange
            var participantServiceMock = new Mock<IParticipantService>();
            var controller = new ParticipantController(participantServiceMock.Object);
            var participantModel = new ParticipantModel();

            // Act
            var result = await controller.CreateParticipant(participantModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContentResult()
        {
            // Arrange
            var participantServiceMock = new Mock<IParticipantService>();
            var controller = new ParticipantController(participantServiceMock.Object);
            var id = 1;

            // Act
            var result = await controller.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
