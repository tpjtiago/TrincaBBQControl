using AutoMapper;
using TrincaBBQControl.Domain.Entities;
using TrincaBBQControl.Domain.Models;

namespace TrincaBBQControl.Domain.AutoMapper
{
    public class ParticipantProfile : Profile
    {
        public ParticipantProfile()
        {
            CreateMap<ParticipantModel, Participant>().ReverseMap();
        }
    }
}
