using Microsoft.AspNetCore.Mvc;
using MyTriApp.Services.DTOs;
using MyTriApp.Services.Interfaces;

namespace MyTriApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteController : ControllerBase
    {
        private IAthleteService _athleteService;

        public AthleteController(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }


        [HttpGet]
        public async Task<ActionResult<List<AthleteDTO>>> GetAllAthletes()
        {
            return Ok(await _athleteService.GetAllAthletes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AthleteDTO>> GetAthleteById(int id)
        {
            var athlete = await _athleteService.GetAthleteById(id);

            if (athlete == null)
            {
                return NotFound();
            }

            return Ok(athlete);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAthlete(AthleteDTO athlete)
        {
            var createdAthlete = await _athleteService.CreateAthlete(athlete);

            if (createdAthlete == null)
            {
                return NotFound();
            }

            return Ok(createdAthlete);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAthlete(AthleteDTO athleteUpdate)
        {
            var updatedAthlete = await _athleteService.UpdateAthlete(athleteUpdate);

            if (updatedAthlete == null)
            {
                return NotFound();
            }

            return Ok(updatedAthlete);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAthleteById(int id)
        {
            var isDeleted = await _athleteService.DeleteAthleteById(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
