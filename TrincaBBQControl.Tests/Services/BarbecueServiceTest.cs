using AutoMapper;
using Moq;
using TrincaBBQControl.Domain.Contracts.Repositories;
using TrincaBBQControl.Domain.Contracts.Services;
using TrincaBBQControl.Domain.Entities;
using TrincaBBQControl.Domain.Models;
using TrincaBBQControl.Domain.Services;

namespace TrincaBBQControl.Tests.Services
{
    public class BarbecueServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<Barbecue>> _repositoryMock;
        private readonly Mock<IRepository<Participant>> _participantRepositoryMock;
        private readonly IBarbecueService _barbecueService;

        public BarbecueServiceTest()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Barbecue, BarbecueModel>();
                cfg.CreateMap<BarbecueModel, Barbecue>();
            });

            _mapper = mapperConfig.CreateMapper();
            _repositoryMock = new Mock<IRepository<Barbecue>>();
            _participantRepositoryMock = new Mock<IRepository<Participant>>();
            _barbecueService = new BarbecueService(_mapper, _repositoryMock.Object, _participantRepositoryMock.Object);
        }

        [Fact]
        public async Task Add_ReturnsAddedBarbecue()
        {
            // Arrange
            var barbecue = new Barbecue();
            var expectedBarbecue = new Barbecue();
            _repositoryMock.Setup(mock => mock.Add(It.IsAny<Barbecue>())).ReturnsAsync(expectedBarbecue);

            // Act
            var result = await _barbecueService.Add(barbecue);

            // Assert
            Assert.Equal(expectedBarbecue, result);
        }

        [Fact]
        public async Task GetbyId_ThrowsException_WhenBarbecueNotFound()
        {
            // Arrange
            var id = 1;
            _repositoryMock.Setup(mock => mock.Get(id)).ReturnsAsync((Barbecue)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _barbecueService.GetbyId(id));
        }

        [Fact]
        public async Task GetbyId_ReturnsBarbecueModel_WithParticipants()
        {
            // Arrange
            var id = 1;
            var participants = new List<Participant>
            {
                new Participant { BarbecueId = 1, ContributionAmount = 20, IncludesBeverage = true },
                new Participant { BarbecueId = 1, ContributionAmount = 15, IncludesBeverage = false }
            };
            var expectedModel = new BarbecueModel
            {
                Participants = participants,
                TotalParticipants = participants.Count,
                TotalContributionAmount = 45
            };
            _repositoryMock.Setup(mock => mock.Get(id)).ReturnsAsync(new Barbecue { Id = id });
            _participantRepositoryMock.Setup(mock => mock.GetAll()).ReturnsAsync(participants);

            // Act
            var result = await _barbecueService.GetbyId(id);

            // Assert
            Assert.Equal(expectedModel.Participants, result.Participants);
            Assert.Equal(expectedModel.TotalParticipants, result.TotalParticipants);
            Assert.Equal(expectedModel.TotalContributionAmount, result.TotalContributionAmount);
        }
    }
}
