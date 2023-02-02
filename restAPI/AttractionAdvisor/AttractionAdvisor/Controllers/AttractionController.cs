using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttractionAdvisor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly IAttractionRepository _attractionRepository;

        public AttractionController(IAttractionRepository attractionRepository)
        {
        
            _attractionRepository = attractionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attraction>>> GetAttractions()
        {
            try
            {
                return Ok(await _attractionRepository.GetAttractions());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Attraction>> GetAttraction(int id)
        {
            if (id <= 0)
                return BadRequest();
            try
            {
                var result = await _attractionRepository.GetAttraction(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        ex.Message);
            }
        }

    

        [HttpPost]
        public async Task<ActionResult<Attraction>> AddAttraction(Attraction attraction)
        {
           
            try
            {
                var createdAttraction = await _attractionRepository.AddAttraction(attraction);
                
                return Ok(CreatedAtAction(nameof(GetAttraction),
                    new { id = createdAttraction.Id }, createdAttraction));
            }
            catch (Exception ex)
            {
                return StatusCode(
                        StatusCodes.Status500InternalServerError,
                       ex.Message);
            }
        }

        [HttpPut]

        public async Task<ActionResult<Attraction>> UpdateAttraction(Attraction attraction)
        {
           

            if (attraction.Id <= 0)
                return BadRequest();

            try
            {
                var attractionToUpdate = await _attractionRepository.GetAttraction(attraction.Id);
                if (attractionToUpdate == null)
                    return NotFound();



                var updatedAttraction = await _attractionRepository.UpdateAttraction(attraction);
                if (updatedAttraction == null)
                    return BadRequest();

                return Ok(updatedAttraction.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
       public async Task<ActionResult<bool>> DeleteAttraction(int id)
        {
            try
            {
                if (!await _attractionRepository.DeleteAttraction(id))
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   ex.Message);
            }
        }

    }
}
