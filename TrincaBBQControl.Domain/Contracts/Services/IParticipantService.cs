using TrincaBBQControl.Domain.Entities;
using TrincaBBQControl.Domain.Models;

namespace TrincaBBQControl.Domain.Contracts.Services
{
    public interface IParticipantService
    {
        Task<Participant> Add(ParticipantModel participantModel);
        Task<List<ParticipantModel>> GetAll();
        Task Remove(int id);
    }
}
