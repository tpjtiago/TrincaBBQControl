using AutoMapper;
using TrincaBBQControl.Domain.Entities;
using TrincaBBQControl.Domain.Models;

namespace TrincaBBQControl.Domain.AutoMapper
{
    public class BarbecueProfile : Profile
    {
        public BarbecueProfile()
        {
            CreateMap<BarbecueModel, Barbecue>().ReverseMap();
        }
    }
}
