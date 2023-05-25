using AutoMapper;
using Moq;
using TrincaBBQControl.Domain.Contracts.Repositories;
using TrincaBBQControl.Domain.Contracts.Services;
using TrincaBBQControl.Domain.Entities;
using TrincaBBQControl.Domain.Models;
using TrincaBBQControl.Domain.Services;

namespace TrincaBBQControl.Tests.Services
{
    public class ParticipantServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<Participant>> _repositoryMock;
        private readonly IParticipantService _participantService;

        public ParticipantServiceTest()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParticipantModel, Participant>();
                cfg.CreateMap<Participant, ParticipantModel>();
            });

            _mapper = mapperConfig.CreateMapper();
            _repositoryMock = new Mock<IRepository<Participant>>();
            _participantService = new ParticipantService(_mapper, _repositoryMock.Object);
        }

        [Fact]
        public async Task Add_ReturnsAddedParticipant()
        {
            // Arrange
            var participantModel = new ParticipantModel();
            var expectedParticipant = new Participant();
            _repositoryMock.Setup(mock => mock.Add(It.IsAny<Participant>())).ReturnsAsync(expectedParticipant);

            // Act
            var result = await _participantService.Add(participantModel);

            // Assert
            Assert.Equal(expectedParticipant, result);
        }

        [Fact]
        public async Task Remove_CallsRepositoryDelete_WithCorrectId()
        {
            // Arrange
            var id = 1;

            // Act
            await _participantService.Remove(id);

            // Assert
            _repositoryMock.Verify(mock => mock.Delete(id), Times.Once);
        }
    }
}
