using AutoMapper;
using TrincaBBQControl.Domain.Contracts.Repositories;
using TrincaBBQControl.Domain.Contracts.Services;
using TrincaBBQControl.Domain.Entities;
using TrincaBBQControl.Domain.Models;

namespace TrincaBBQControl.Domain.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Participant> _repository;
        public ParticipantService(IMapper mapper, IRepository<Participant> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Participant> Add(ParticipantModel participantModel)
        {
            var result = await _repository.Add(_mapper.Map<Participant>(participantModel));

            return result;

        }

        public async Task<List<ParticipantModel>> GetAll()
        {
            var result = await _repository.GetAll();

            return _mapper.Map<List<ParticipantModel>>(result);
        }

        public async Task Remove(int id)
        {
            await _repository.Delete(id);
        }
    }
}
