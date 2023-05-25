using Microsoft.AspNetCore.Mvc;
using TrincaBBQControl.Domain.Contracts.Services;
using TrincaBBQControl.Domain.Entities;

namespace TrincaBBQControl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarbecueController : ControllerBase
    {
        private readonly IBarbecueService _barbecueService;
        public BarbecueController(IBarbecueService barbecueService)
        {
            _barbecueService = barbecueService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBarbecue(Barbecue barbecue)
        {
            var model = await _barbecueService.Add(barbecue);

            return Ok(model);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _barbecueService.GetbyId(id);

            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _barbecueService.GetAll();

            return Ok(model);
        }
    }
}
