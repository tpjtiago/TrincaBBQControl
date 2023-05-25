using AutoMapper;
using TrincaBBQControl.Domain.Contracts.Repositories;
using TrincaBBQControl.Domain.Contracts.Services;
using TrincaBBQControl.Domain.Entities;
using TrincaBBQControl.Domain.Models;

namespace TrincaBBQControl.Domain.Services
{
    public class BarbecueService : IBarbecueService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Barbecue> _repository;
        private readonly IRepository<Participant> _participantRepository;
        public BarbecueService(IMapper mapper, IRepository<Barbecue> repository, IRepository<Participant> participantRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _participantRepository = participantRepository;
        }

        public async Task<Barbecue> Add(Barbecue barbecue)
        {
            var result = await _repository.Add(_mapper.Map<Barbecue>(barbecue));

            return result;

        }

        public async Task<BarbecueModel> GetbyId(int id)
        {
            var result = await _repository.Get(id);

            if (result is null)
            {
                throw new Exception("Churrasco não encontrado");
            }
            var participants = await _participantRepository.GetAll();

            var model = _mapper.Map<BarbecueModel>(result);

            var participantsFilter = participants.Where(x => x.BarbecueId == id).ToList();

            model.Participants = participantsFilter;
            model.TotalParticipants = participantsFilter.Count();
            model.TotalContributionAmount = CalculateTotalContributionAmount(participantsFilter);

            return model;
        }

        public async Task<List<Barbecue>> GetAll()
        {
            var result = await _repository.GetAll();

            return _mapper.Map<List<Barbecue>>(result);
        }

        private decimal CalculateTotalContributionAmount(List<Participant> participants)
        {
            decimal totalContributionAmount = 0;

            foreach (var participant in participants)
            {
                participant.SuggestedContribution = participant.IncludesBeverage ? 10 : 0;
                totalContributionAmount += participant.ContributionAmount + participant.SuggestedContribution;
            }

            return totalContributionAmount;
        }
    }
}
