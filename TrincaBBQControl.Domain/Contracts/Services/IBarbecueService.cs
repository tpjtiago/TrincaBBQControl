using TrincaBBQControl.Domain.Entities;
using TrincaBBQControl.Domain.Models;

namespace TrincaBBQControl.Domain.Contracts.Services
{
    public interface IBarbecueService
    {
        Task<Barbecue> Add(Barbecue barbecueModel);
        Task<BarbecueModel> GetbyId(int id);
        Task<List<Barbecue>> GetAll();

        //Task<List<BarbecueModel>> GetListEligibleFamilies();
    }
}
