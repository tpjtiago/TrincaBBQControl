using Microsoft.AspNetCore.Mvc;
using TrincaBBQControl.Domain.Contracts.Services;
using TrincaBBQControl.Domain.Models;

namespace TrincaBBQControl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;
        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParticipant(ParticipantModel participantModel)
        {
            var model = await _participantService.Add(participantModel);

            return Ok(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<NoContentResult> Delete(int id)
        {
            await _participantService.Remove(id);

            return NoContent();
        }
    }
}
